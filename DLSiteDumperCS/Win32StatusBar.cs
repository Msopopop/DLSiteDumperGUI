using static User32;
using static Kernel32;
using System;

public class Win32StatusBar
{
    private IntPtr m_Hwnd;
    private IntPtr m_ParentProcess;

    public Win32StatusBar( IntPtr hProcess, IntPtr hWnd )
    {
        this.m_Hwnd = hWnd;
        this.m_ParentProcess = hProcess;
    }

    public int GetPanelCount( )
    {
        if( this.m_Hwnd != IntPtr.Zero )
            return (int)SendMessage( m_Hwnd, SB_GETPARTS );

        return 0;
    }

    public string GetCaption( int index )
    {
        int length = (int)SendMessage( m_Hwnd, SB_GETTEXTLENGTH, index, IntPtr.Zero );

        // Low part is the count. High part is the window type. Mask out the high bits.
        // The returned text will also be unicode so double the length to accomodate our buffer
        length = (length & 0x0000ffff) * 2;

        IntPtr hProcess = IntPtr.Zero;
        IntPtr allocated = IntPtr.Zero;

        try
        {
            // Allocate memory in the remote process
            allocated = VirtualAllocEx( m_ParentProcess, IntPtr.Zero, (uint)length, (VirtualAllocExTypes.MEM_COMMIT_OR_RESERVE), AccessProtectionFlags.PAGE_READWRITE );

            if( allocated != IntPtr.Zero )
            {
                IntPtr bytesRead = default;
                byte[] buffer = new byte[length];

                // SB_GETTEXT tells the remote process to write out text to the remote memory we allocated.
                SendMessage( this.m_Hwnd, SB_GETTEXT, (IntPtr)index, allocated );

                // Now we need to read that memory from the remote process into a local buffer.
                bool success = ReadProcessMemory( hProcess, allocated, buffer, length, out bytesRead );

                if( success )
                {
                    // Each char takes 2 bytes.
                    char[] characters = new char[length / 2];

                    for( int i = 0; i < buffer.Length; i = i + 2 )
                    {
                        // Even though the second byte will probably always be 0 for en-us let's so a bit shift
                        // then "or" the first and second bytes together before casting to char.
                        uint a = (uint)buffer[i];
                        uint b = (uint)buffer[i + 1] << 8;

                        characters[i / 2] = (char)(a | b);
                    }

                    return new string( characters );
                }
            }
        }
        finally
        {
            if( hProcess != IntPtr.Zero )
            {
                if( allocated != IntPtr.Zero )
                {
                    // Free the memory in the remote process
                    VirtualFreeEx( hProcess, allocated, 0, VirtualAllocExTypes.MEM_RELEASE );
                }
            }
        }

        return string.Empty;
    }
}