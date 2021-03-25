using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using static Gdi32;
using static Kernel32;
using static User32;
using HWND = System.IntPtr;

class ViewerDumper : IDisposable
{
    readonly DLSiteDumperCS.MainForm parentDialog;
    
    public string BaseSavePath { get; set; }
    public int TargetPid { get; set; }
    public int BasePageOffset { get; set; } = 1;
    public string TargetImageExt { get; set; } = "png";
    public int BetweenPageDelayMs { get; set; } = 1000;

    public ViewerDumper( DLSiteDumperCS.MainForm parentDialog )
    {
        this.parentDialog = parentDialog;
    }

    /// <summary>
    /// Indicates that PID is valid and we can open process.
    /// </summary>
    public bool IsReady => viewer_process != HWND.Zero && viewer_area_main != HWND.Zero;

    Process viewerProcess;
    HWND viewer_process;
    HWND viewer_window_main;

    const int VIEWER_BUTTON_PARENT_CODE = 0xE805;
    const int VIEWER_BUTTON_FIRST_CODE = 0x8023;
    const int VIEWER_BUTTON_NEXT_CODE = 0x8020;
    const int VIEWER_BUTTON_ZOOM_CODE = 0x800A;
    const int VIEWER_AREA_PARENT_CODE = 0xE900;
    const int VIEWER_AREA_MAIN_CODE = 0xE900;
    const int STATUS_BAR = 59393;

    HWND viewer_button_parent;
    HWND viewer_button_first;
    HWND viewer_button_next;
    HWND viewer_button_zoom;
    HWND viewer_area_parent;
    HWND viewer_area_main;
    //Win32StatusBar m_ViewerStatusBar;

    public void Dispose( )
    {
        if( viewer_process != IntPtr.Zero )
            CloseHandle( viewer_process );
        if( m_BmpMemoryStream != null )
            m_BmpMemoryStream.Dispose( );
    }

    public void Setup( int processId )
    {
        TargetPid = processId;
        viewerProcess = Process.GetProcessById( processId );
        viewer_process = OpenProcess( viewerProcess, ProcessAccessTypes.PROCESS_VM_READ | ProcessAccessTypes.PROCESS_QUERY_INFORMATION );

        viewer_window_main = WndSearcher.SearchForWindowWithPid( viewerProcess.Id );

        // Find all the subwindow by control ID
        viewer_button_parent = GetDlgItem( viewer_window_main, VIEWER_BUTTON_PARENT_CODE );
        viewer_button_first  = GetDlgItem( viewer_button_parent, VIEWER_BUTTON_FIRST_CODE );
        viewer_button_next   = GetDlgItem( viewer_button_parent, VIEWER_BUTTON_NEXT_CODE );
        viewer_button_zoom   = GetDlgItem( viewer_button_parent, VIEWER_BUTTON_ZOOM_CODE );
        viewer_area_parent   = GetDlgItem( viewer_window_main, VIEWER_AREA_PARENT_CODE );
        viewer_area_main     = GetDlgItem( viewer_area_parent, VIEWER_AREA_MAIN_CODE );

        // Note: I tried to read status bar that displaying page number,
        // but looks like its text is hidden. So no auto page detection for now
#if false
        HWND statusBarHwnd = GetDlgItem( viewer_window_main, STATUS_BAR );
        m_ViewerStatusBar = new Win32StatusBar( viewer_process, statusBarHwnd );

        int panels = m_ViewerStatusBar.GetPanelCount( );
        for( int i=0 ; i<panels ; i++ )
        {
            string caption = m_ViewerStatusBar.GetCaption( i );
            Debug.Print( $"caption {i} = {caption}" );
        }
#endif
    }

    BackgroundWorker worker;
    DoWorkEventArgs workerArg;
    public void SetupBackgroundWorker( BackgroundWorker worker, DoWorkEventArgs e )
    {
        this.worker = worker;
        workerArg = e;
    }

    struct ViewerState
    {
        public bool hasData;
        public WINDOWPLACEMENT original_window_placement;
        public WINDOWPLACEMENT temp_window_placement;
        public RECT original_window_rect;
        public int original_zoom_selection;

        public void SaveSnapshot( HWND viewer_window_main, HWND viewer_button_zoom )
        {
            hasData = true;

            // Current placement
            original_window_placement = default;
            original_window_placement.Length = Marshal.SizeOf( original_window_placement );
            GetWindowPlacement( viewer_window_main, ref original_window_placement );

            // Current zoom state
            original_zoom_selection = (int)SendMessage( viewer_button_zoom, CB_GETCURSEL );

            GetWindowRect( viewer_window_main, ref original_window_rect );
        }

        public void Restore( HWND viewer_window_main, HWND viewer_button_zoom )
        {
            // Restore window size and state
            var targetWindowPosFlags = SetWindowPosFlags.IgnoreZOrder | SetWindowPosFlags.DoNotChangeOwnerZOrder | SetWindowPosFlags.IgnoreMove | SetWindowPosFlags.DoNotActivate;
            SetWindowPos( viewer_window_main, IntPtr.Zero, 0, 0, original_window_rect.Right - original_window_rect.Left, original_window_rect.Top - original_window_rect.Bottom, targetWindowPosFlags );
            SetWindowPlacement( viewer_window_main, ref original_window_placement );

            // Restore zoom level
            //ComboBox_SetCurSel( viewer_button_zoom, original_zoom_selection );
            //SendMessage( viewer_button_parent, WM_COMMAND, MAKEWPARAM( VIEWER_BUTTON_ZOOM_CODE, CBN_SELCHANGE ), (LPARAM)viewer_button_zoom );
        }
    }
    ViewerState m_ViewerState;

    void PrepareViewerForDump( )
    {
        // Store original window position and state
        // Window will be shrunken to ensure window size is smaller than the image
        // This is necessary so that the immage in memory will not be padded
        if( !m_ViewerState.hasData )
            m_ViewerState.SaveSnapshot( viewer_window_main, viewer_button_zoom );

        WINDOWPLACEMENT temp_window_placement = m_ViewerState.original_window_placement;
        temp_window_placement.ShowCmd = ShowWindowCommands.Show;
        SetWindowPlacement( viewer_window_main, ref temp_window_placement );

        // Set zoom level to 100%
        SendMessage( viewer_button_zoom, CB_SELECTSTRING, -1, "100%" );

        // Programatically selecting a ComboBox option will not send a selection change message to the parent, so do that manually
        SendMessage( viewer_button_parent, WM_COMMAND, MAKEWPARAM( VIEWER_BUTTON_ZOOM_CODE, CBN_SELCHANGE ), viewer_button_zoom );

        var targetWindowPosFlags = SetWindowPosFlags.IgnoreZOrder | SetWindowPosFlags.DoNotChangeOwnerZOrder | SetWindowPosFlags.IgnoreMove | SetWindowPosFlags.DoNotActivate;
        SetWindowPos( viewer_window_main, HWND.Zero, 0, 0, 256, 256, targetWindowPosFlags );

        // Send a virtual click to the first page button
        // Note: This was removed because original author lets user specify first page to capture in case of crash
        // SendMessage(viewer_button_first, WM_LBUTTONDOWN, MK_LBUTTON, MAKELPARAM(1, 1));
        // SendMessage(viewer_button_first, WM_LBUTTONUP, MK_LBUTTON, MAKELPARAM(1, 1));

        // It seems it takes some time for messages to propagate to other buttons, so wait until the next button is enabled
        // This will prevent the bug where if the Viewer was opened to the last page, it would only export the first image
        Thread.Sleep( 1000 );
    }

    

    void RestoreViewerState( )
    {
        if( m_ViewerState.hasData )
            m_ViewerState.Restore( viewer_window_main, viewer_button_zoom );
    }

    byte[] m_ImageDumpBuffer;

    public void DumpBatch( )
    {
        PrepareViewerForDump( );

        // Beginning RIP
        // Continue until the next button becomes disabled, indicating the last image
        bool ending = false;
        for( int pages = BasePageOffset; ; pages++ )
        {
            if( worker.CancellationPending )
            {
                workerArg.Cancel = true;
                break;
            }

            // If the next button is disabled, we reached the end; grab one last image and finish
            if( GetWindowLongHasFlag( viewer_button_next, GWL.GWL_STYLE, WindowStyles.WS_DISABLED ) )
            {
                ending = true;
                workerArg.Result = "Capture operation completed successfully.";
            }

            _DumpOneImpl( pages );
            if( ending )
                break;

            _NextPage( );
        }

    }

    public void DumpOne( )
    {
        PrepareViewerForDump( );

        _DumpOneImpl( BasePageOffset );
    }

    void _DumpOneImpl( int pageNumber )
    {
        // As a hack, the dimensions of the images are determined by
        // looking at the size of the scroll area
        // This requires that the image area be smaller than the image
        SCROLLINFO sih = default, siv = default;

        sih.cbSize = (uint)Marshal.SizeOf( sih );
        sih.fMask = (uint)ScrollInfoMask.SIF_ALL;
        siv.cbSize = (uint)Marshal.SizeOf( siv );
        siv.fMask = (uint)ScrollInfoMask.SIF_ALL;

        GetScrollInfo( viewer_area_main, (int)SBOrientation.SB_HORZ, ref sih );
        GetScrollInfo( viewer_area_main, (int)SBOrientation.SB_VERT, ref siv );

        int w = sih.nMax - sih.nMin + 1;
        int h = siv.nMax - siv.nMin + 1;

        int imageSize = (((w * 32 + 31) & ~31) >> 3) * h;
        if( m_ImageDumpBuffer == null || m_ImageDumpBuffer.Length < imageSize )
            m_ImageDumpBuffer = new byte[imageSize];

        // Prepare BMP header for hijacking
        BITMAPFILEHEADER bmf = default;
        BITMAPINFOHEADER bmi = default;

        bmf.bfType = 0x4d42;
        bmf.bfSize = (uint)(Marshal.SizeOf( bmf ) + Marshal.SizeOf( bmi ) + imageSize);
        bmf.bfOffBits = (uint)(Marshal.SizeOf( bmf ) + Marshal.SizeOf( bmi ));

        bmi.biSize        = 40; // Size of info header, must be 40
        bmi.biWidth       = w;
        bmi.biHeight      = -h;
        bmi.biPlanes      = 1;
        bmi.biBitCount    = 32; // Data dumped from mem is 32bpp
        bmi.biCompression = 0;
        //bmi.biSizeImage = (uint)imageSize; // biSizeImage is not required if there is no compression

        byte[] bmfHeaderBytes = StructToBytes( bmf );
        byte[] bmiHeaderBytes = StructToBytes( bmi );

        for( IntPtr address = default; ; )
        {
            MEMORY_BASIC_INFORMATION mbi = default;
            int actualByteRead = -1;
            while( VirtualQueryEx( viewer_process, address, out mbi, (uint)Marshal.SizeOf( mbi ) ) != 0 )
            {
                if( mbi.State == (uint)MemState.MEM_COMMIT && mbi.Type == (uint)MemType.MEM_PRIVATE && mbi.Protect == (uint)PageAllocationProtect.PAGE_READWRITE && mbi.RegionSize.ToInt32( ) >= imageSize )
                {
                    IntPtr byteRead;
                    if( !ReadProcessMemory( viewer_process, mbi.BaseAddress, m_ImageDumpBuffer, imageSize, out byteRead ) )
                    {
                        Debug.Print( $"ReadProcessMemory failed at PID {viewer_process} addess 0x{mbi.BaseAddress:X} size {imageSize}. But it will continue..." );
                        continue;
                    }

                    actualByteRead = byteRead.ToInt32( );
                    Debug.Print( "ReadProcessMemory success\n" );
                }

                // Iterate to see next memory page
                address = IntPtr.Add( mbi.BaseAddress, mbi.RegionSize.ToInt32( ) );
            }

            // Write to file
            // Three digit decimal with padding
            if( actualByteRead > 0 )
            {
                string filename = GetFileNameForPage( pageNumber, TargetImageExt );
                string outputPath = Path.Combine( BaseSavePath, filename );

                worker.ReportProgress( 0, $"Dumping page {pageNumber}\nto {outputPath}" );

#if false // This was saving plain BMP file
                try
                {
                    using( FileStream ls = new FileStream( outputPath, FileMode.Create ) )
                    {
                        ls.Write( bmfHeaderBytes, 0, bmfHeaderBytes.Length );
                        ls.Write( bmiHeaderBytes, 0, bmiHeaderBytes.Length );
                        ls.Write( m_ImageDumpBuffer, 0, actualByteRead );
                    }
                }
                catch( Exception e )
                {
                    Debug.Print( $"Failed to write to {outputPath}\n{e.Message}" );
                }
#endif
                // Transfer to in-memory BMP file and convert
                {
                    if( m_BmpMemoryStream == null )
                        m_BmpMemoryStream = new MemoryStream( );
                    m_BmpMemoryStream.SetLength( 0 ); // Reset and reuse it

                    m_BmpMemoryStream.Write( bmfHeaderBytes, 0, bmfHeaderBytes.Length );
                    m_BmpMemoryStream.Write( bmiHeaderBytes, 0, bmiHeaderBytes.Length );
                    m_BmpMemoryStream.Write( m_ImageDumpBuffer, 0, actualByteRead );

                    Image bmp = Image.FromStream( m_BmpMemoryStream );

                    if( TargetImageExt == "png" )
                        bmp.Save( outputPath, ImageFormat.Png );
                    else if( TargetImageExt == "jpg" )
                        bmp.Save( outputPath, ImageFormat.Jpeg );
                }
            }

            Debug.Print( "Image dump ok, switch page." );
            break;
        }
    }

    MemoryStream m_BmpMemoryStream;
    
    void _NextPage( )
    {
        // Once image memory is ours, 'click' to the next image
        SendMessage( viewer_button_next, WM_LBUTTONDOWN, MK_LBUTTON, MAKELPARAM( 1, 1 ) );
        SendMessage( viewer_button_next, WM_LBUTTONUP, MK_LBUTTON, MAKELPARAM( 1, 1 ) );

        // There is delay for DLS to decode-display an image
        // So wait a bit
        Thread.Sleep( BetweenPageDelayMs );
    }

    public static string GetFileNameForPage( int page, string ext )
    {
        return $"{page:D3}.{ext}";
    }
}