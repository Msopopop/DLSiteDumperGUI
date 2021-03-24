
using System;
using System.Runtime.InteropServices;
using System.Text;
// http://pinvoke.net/default.aspx/user32.EnumWindows
public class WndSearcher
{
    public static IntPtr SearchForWindowWithPid( int processId )
    {
        SearchData sd = new SearchData { pid=processId };
        EnumWindows( new EnumWindowsProc( EnumProc ), ref sd );
        return sd.hWnd;
    }

    public static IntPtr SearchForWindow( string wndclass, string title )
    {
        SearchData sd = new SearchData { Wndclass=wndclass, Title=title };
        EnumWindows( new EnumWindowsProc( EnumProc ), ref sd );
        return sd.hWnd;
    }

    public static bool EnumProc( IntPtr hWnd, ref SearchData data )
    {
        if( data.pid != 0 )
        {
            // Search using PID
            User32.GetWindowThreadProcessId( hWnd, out int processId );
            if( data.pid == processId )
            {
                // Any given process may have many invisible top level windows
                // DMMViewer has about 4, but should only have one visible (the main window)
                if( User32.IsWindowVisible( hWnd ) )
                {
                    data.hWnd = hWnd;
                    return false; // Finally found it
                }
            }
        }
        else
        {
            // Check classname and title
            // This is different from FindWindow() in that the code below allows partial matches
            StringBuilder sb = new StringBuilder(1024);
            GetClassName( hWnd, sb, sb.Capacity );
            if( sb.ToString( ).StartsWith( data.Wndclass ) )
            {
                sb = new StringBuilder( 1024 );
                GetWindowText( hWnd, sb, sb.Capacity );
                if( sb.ToString( ).StartsWith( data.Title ) )
                {
                    data.hWnd = hWnd;
                    return false;    // Found the wnd, halt enumeration
                }
            }
        }
        return true;
    }

    public class SearchData
    {
        public int pid;

        public string Wndclass;

        public string Title;
        public IntPtr hWnd;
    }

    private delegate bool EnumWindowsProc( IntPtr hWnd, ref SearchData data );

    [DllImport( "user32.dll" )]
    [return: MarshalAs( UnmanagedType.Bool )]
    private static extern bool EnumWindows( EnumWindowsProc lpEnumFunc, ref SearchData data );

    [DllImport( "user32.dll", SetLastError = true, CharSet = CharSet.Auto )]
    public static extern int GetClassName( IntPtr hWnd, StringBuilder lpClassName, int nMaxCount );

    [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
    public static extern int GetWindowText( IntPtr hWnd, StringBuilder lpString, int nMaxCount );
}