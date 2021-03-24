
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

// https://github.com/SonyWWS/ATF/blob/master/Framework/Atf.Gui/User32.cs
//Copyright © 2014 Sony Computer Entertainment America LLC. See License.txt.

/// <summary>
/// Interop for structures and functions in user32.dll</summary>
public static class User32
{
    // Windows Message Constants  WM_XXXX, etc., from winuser.h
    public const int WM_NULL = 0x0000;
    public const int WM_CREATE = 0x0001;
    public const int WM_DESTROY = 0x0002;
    public const int WM_MOVE = 0x0003;
    public const int WM_SIZE = 0x0005;

    public const int WM_ACTIVATE = 0x0006;

    //WM_ACTIVATE state values
    public const int WA_INACTIVE = 0;
    public const int WA_ACTIVE = 1;
    public const int WA_CLICKACTIVE = 2;

    public const int WM_SETFOCUS = 0x0007;
    public const int WM_KILLFOCUS = 0x0008;
    public const int WM_ENABLE = 0x000A;
    public const int WM_SETREDRAW = 0x000B;
    public const int WM_SETTEXT = 0x000C;
    public const int WM_GETTEXT = 0x000D;
    public const int WM_GETTEXTLENGTH = 0x000E;
    public const int WM_PAINT = 0x000F;
    public const int WM_CLOSE = 0x0010;
    public const int WM_ERASEBKGND = 0x0014;
    public const int WM_SETCURSOR = 32;

    public const int WM_GETMINMAXINFO = 0x0024;
    public const int WM_HELP = 0x0053;
    public const int WM_NCHITTEST = 0x0084;
    public const int WM_NCPAINT = 0x0085;
    public const int WM_NCLBUTTONDOWN = 0x00A1;
    public const int WM_NCLBUTTONUP = 0x00A2;
    public const int WM_KEYDOWN = 0x0100;
    public const int WM_SYSKEYDOWN = 0x0104;
    public const int WM_INITDIALOG = 0x110;
    public const int WM_COMMAND = 0x0111;
    public const int WM_SYSCOMMAND = 0x0112;
    public const int WM_HSCROLL = 0x114;
    public const int WM_VSCROLL = 0x115;
    public const int WM_UPDATEUISTATE = 0x0128;
    public const int WM_SIZING = 0x0214;
    public const int WM_LBUTTONDOWN = 0x0201;
    public const int WM_LBUTTONUP = 0x0202;
    public const int WM_LBUTTONDBLCLK = 0x0203;
    public const int WM_MOUSEMOVE = 0x0200;
    public const int WM_MOUSEWHEEL = 0x020A;
    public const int WM_CUT = 0x0300;
    public const int WM_COPY = 0x0301;
    public const int WM_PASTE = 0x0302;
    public const int WM_CLEAR = 0x0303;
    public const int WM_UNDO = 0x0304;
    public const int WM_USER = 0x0400;
    public const int WM_REFLECT = WM_USER + 0x1C00;
    public const int WM_NOTIFY = 0x004E;

    // Combo Box return Values
    public const int CB_OKAY = 0;
    public const int CB_ERR = -1;
    public const int CB_ERRSPACE = -2;

    // Combo Box Notification Codes
    public const int CBN_ERRSPACE = -1;
    public const int CBN_SELCHANGE = 1;
    public const int CBN_DBLCLK = 2;
    public const int CBN_SETFOCUS = 3;
    public const int CBN_KILLFOCUS = 4;
    public const int CBN_EDITCHANGE = 5;
    public const int CBN_EDITUPDATE = 6;
    public const int CBN_DROPDOWN = 7;
    public const int CBN_CLOSEUP = 8;
    public const int CBN_SELENDOK = 9;
    public const int CBN_SELENDCANCEL = 10;

    // Combo Box styles
    public const int CBS_SIMPLE = 0x0001;
    public const int CBS_DROPDOWN = 0x0002;
    public const int CBS_DROPDOWNLIST = 0x0003;
    public const int CBS_OWNERDRAWFIXED = 0x0010;
    public const int CBS_OWNERDRAWVARIABLE = 0x0020;
    public const int CBS_AUTOHSCROLL = 0x0040;
    public const int CBS_OEMCONVERT = 0x0080;
    public const int CBS_SORT = 0x0100;
    public const int CBS_HASSTRINGS = 0x0200;
    public const int CBS_NOINTEGRALHEIGHT = 0x0400;
    public const int CBS_DISABLENOSCROLL = 0x0800;
    public const int CBS_UPPERCASE = 0x2000;
    public const int CBS_LOWERCASE = 0x4000;

    // Combo Box messages
    public const int CB_GETEDITSEL = 0x0140;
    public const int CB_LIMITTEXT = 0x0141;
    public const int CB_SETEDITSEL = 0x0142;
    public const int CB_ADDSTRING = 0x0143;
    public const int CB_DELETESTRING = 0x0144;
    public const int CB_DIR = 0x0145;
    public const int CB_GETCOUNT = 0x0146;
    public const int CB_GETCURSEL = 0x0147;
    public const int CB_GETLBTEXT = 0x0148;
    public const int CB_GETLBTEXTLEN = 0x0149;
    public const int CB_INSERTSTRING = 0x014A;
    public const int CB_RESETCONTENT = 0x014B;
    public const int CB_FINDSTRING = 0x014C;
    public const int CB_SELECTSTRING = 0x014D;
    public const int CB_SETCURSEL = 0x014E;
    public const int CB_SHOWDROPDOWN = 0x014F;
    public const int CB_GETITEMDATA = 0x0150;
    public const int CB_SETITEMDATA = 0x0151;
    public const int CB_GETDROPPEDCONTROLRECT = 0x0152;
    public const int CB_SETITEMHEIGHT = 0x0153;
    public const int CB_GETITEMHEIGHT = 0x0154;
    public const int CB_SETEXTENDEDUI = 0x0155;
    public const int CB_GETEXTENDEDUI = 0x0156;
    public const int CB_GETDROPPEDSTATE = 0x0157;
    public const int CB_FINDSTRINGEXACT = 0x0158;
    public const int CB_SETLOCALE = 0x0159;
    public const int CB_GETLOCALE = 0x015A;
    public const int CB_GETTOPINDEX = 0x015b;
    public const int CB_SETTOPINDEX = 0x015c;
    public const int CB_GETHORIZONTALEXTENT = 0x015d;
    public const int CB_SETHORIZONTALEXTENT = 0x015e;
    public const int CB_GETDROPPEDWIDTH = 0x015f;
    public const int CB_SETDROPPEDWIDTH = 0x0160;
    public const int CB_INITSTORAGE = 0x0161;
    public const int CB_MULTIPLEADDSTRING = 0x0163;
    public const int CB_GETCOMBOBOXINFO = 0x0164;
    public const int CB_MSGMAX = 0x0165;

    // ListView messages 
    public const int LVM_FIRST = 0x1000;
    public const int HDM_FIRST = 0x1200;
    public const int HDM_SETFOCUSEDITEM = HDM_FIRST + 28;

    //parameters for ListView headers
    public const int HDI_FORMAT = 0x0004;
    public const int HDF_LEFT = 0x0000;
    public const int HDF_STRING = 0x4000;
    public const int HDF_SORTUP = 0x0400;
    public const int HDF_SORTDOWN = 0x0200;
    public const int LVM_GETHEADER = 0x1000 + 31;  // LVM_FIRST + 31
    public const int HDM_GETITEM = 0x1200 + 11;  // HDM_FIRST + 11
    public const int HDM_SETITEM = 0x1200 + 12;

    /// <summary>
    /// Contains information about an item in a header control</summary>
    /// <remarks>https://msdn.microsoft.com/en-us/library/windows/desktop/bb775247(v=vs.85).aspx</remarks>
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
    public struct HDITEM
    {
        public uint mask;
        public int cxy;
        public String pszText; //works for sending strings, but not for receiving. todo: use StringBuilder?
        public IntPtr hbm;
        public int cchTextMax;
        public int fmt;
        public IntPtr lParam;
        public int iImage;
        public int iOrder;
        public uint type;
        public IntPtr pvFilter; // this is void*
        public uint state;
    }


    // Button control styles, messages and notifications
    public const int BS_PUSHBUTTON = 0x00000000;
    public const int BS_DEFPUSHBUTTON = 0x00000001;
    public const int BS_CHECKBOX = 0x00000002;
    public const int BS_AUTOCHECKBOX = 0x00000003;
    public const int BS_RADIOBUTTON = 0x00000004;
    public const int BS_3STATE = 0x00000005;
    public const int BS_AUTO3STATE = 0x00000006;
    public const int BS_GROUPBOX = 0x00000007;
    public const int BS_AUTORADIOBUTTON = 0x00000009;
    public const int BS_OWNERDRAW = 0x0000000B;
    public const int BS_LEFTTEXT = 0x00000020;
    public const int BS_TEXT = 0x00000000;
    public const int BS_LEFT = 0x00000100;
    public const int BS_RIGHT = 0x00000200;
    public const int BS_CENTER = 0x00000300;
    public const int BS_TOP = 0x00000400;
    public const int BS_BOTTOM = 0x00000800;
    public const int BS_VCENTER = 0x00000C00;
    public const int BS_PUSHLIKE = 0x00001000;
    public const int BS_MULTILINE = 0x00002000;
    public const int BS_NOTIFY = 0x00004000;
    public const int BS_RIGHTBUTTON = BS_LEFTTEXT;

    public const int BN_CLICKED = 0;
    public const int BN_PAINT = 1;
    public const int BN_DBLCLK = 5;
    public const int BN_SETFOCUS = 6;
    public const int BN_KILLFOCUS = 7;

    public const int QS_MOUSEMOVE = 0x0002;
    public const int QS_MOUSEBUTTON = 0x0004;
    public const int QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON;
    public const int QS_KEY = 0x0001;
    public const int QS_RAWINPUT = 0x0400;

    public const int PM_QS_INPUT = (QS_MOUSE | QS_KEY | QS_RAWINPUT) << 16;
    public const int PM_NOREMOVE = 0x0000;
    public const int PM_REMOVE = 0x0001;
    public const int PM_NOYIELD = 0x0002;

    public const int TME_HOVER = 0x1;
    public const int HOVER_DEFAULT = -1; //0xFFFFFFFF;

    // WM_NCHITTEST and MOUSEHOOKSTRUCT  Mouse Position Codes

    public const int HTCAPTION = 0x2;

    // Class Styles Constants

    public const int CS_NOCLOSE = 0x0200;

    public const int EM_GETEVENTMASK = (WM_USER + 59);
    public const int EM_SETEVENTMASK = (WM_USER + 69);

    public const int NM_FIRST = 0x0000;

    public const int HDN_FIRST = (NM_FIRST - 300);
    public const int HDN_ITEMCHANGINGA = (HDN_FIRST - 0);
    public const int HDN_ITEMCHANGINGW = (HDN_FIRST - 20);
    public const int HDN_ITEMCHANGEDA = (HDN_FIRST - 1);
    public const int HDN_ITEMCHANGEDW = (HDN_FIRST - 21);
    public const int HDN_ITEMCLICKA = (HDN_FIRST - 2);
    public const int HDN_ITEMCLICKW = (HDN_FIRST - 22);
    public const int HDN_ITEMDBLCLICKA = (HDN_FIRST - 3);
    public const int HDN_ITEMDBLCLICKW = (HDN_FIRST - 23);
    public const int HDN_DIVIDERDBLCLICKA = (HDN_FIRST - 5);
    public const int HDN_DIVIDERDBLCLICKW = (HDN_FIRST - 25);
    public const int HDN_BEGINTRACKA = (HDN_FIRST - 6);
    public const int HDN_BEGINTRACKW = (HDN_FIRST - 26);
    public const int HDN_ENDTRACKA = (HDN_FIRST - 7);
    public const int HDN_ENDTRACKW = (HDN_FIRST - 27);
    public const int HDN_TRACKA = (HDN_FIRST - 8);
    public const int HDN_TRACKW = (HDN_FIRST - 28);
    public const int HDN_GETDISPINFOA = (HDN_FIRST - 9);
    public const int HDN_GETDISPINFOW = (HDN_FIRST - 29);
    public const int HDN_BEGINDRAG = (HDN_FIRST - 10);
    public const int HDN_ENDDRAG = (HDN_FIRST - 11);
    public const int HDN_FILTERCHANGE = (HDN_FIRST - 12);
    public const int HDN_FILTERBTNCLICK = (HDN_FIRST - 13);

    // structs

    /// <summary>
    /// POINT structure to interoperate with user32.dll</summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT( int x, int y )
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator System.Drawing.Point( POINT p )
        {
            return new System.Drawing.Point( p.X, p.Y );
        }

        public static implicit operator POINT( System.Drawing.Point p )
        {
            return new POINT( p.X, p.Y );
        }
    }

    /// <summary>
    /// RECT structure to interoperate with user32.dll</summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct RECT
    {
        public int Left, Top, Right, Bottom;

        public RECT( int left, int top, int right, int bottom )
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public RECT( System.Drawing.Rectangle r ) : this( r.Left, r.Top, r.Right, r.Bottom ) { }

        public int X
        {
            get { return Left; }
            set { Right -= (Left - value); Left = value; }
        }

        public int Y
        {
            get { return Top; }
            set { Bottom -= (Top - value); Top = value; }
        }

        public int Height
        {
            get { return Bottom - Top; }
            set { Bottom = value + Top; }
        }

        public int Width
        {
            get { return Right - Left; }
            set { Right = value + Left; }
        }

        public System.Drawing.Point Location
        {
            get { return new System.Drawing.Point( Left, Top ); }
            set { X = value.X; Y = value.Y; }
        }

        public System.Drawing.Size Size
        {
            get { return new System.Drawing.Size( Width, Height ); }
            set { Width = value.Width; Height = value.Height; }
        }

        public static implicit operator System.Drawing.Rectangle( RECT r )
        {
            return new System.Drawing.Rectangle( r.Left, r.Top, r.Width, r.Height );
        }

        public static implicit operator RECT( System.Drawing.Rectangle r )
        {
            return new RECT( r );
        }

        public static bool operator ==( RECT r1, RECT r2 )
        {
            return r1.Equals( r2 );
        }

        public static bool operator !=( RECT r1, RECT r2 )
        {
            return !r1.Equals( r2 );
        }

        public bool Equals( RECT r )
        {
            return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
        }

        public override bool Equals( object obj )
        {
            if( obj is RECT )
                return Equals( (RECT)obj );
            else if( obj is System.Drawing.Rectangle )
                return Equals( new RECT( (System.Drawing.Rectangle)obj ) );
            return false;
        }

        public override int GetHashCode( )
        {
            return ((System.Drawing.Rectangle)this).GetHashCode( );
        }

        public override string ToString( )
        {
            return string.Format( System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom );
        }
    }

    /// <summary>
    /// Information about a window's maximized size and position and its minimum and maximum
    /// tracking size.</summary>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms632605%28v=vs.85%29.aspx. </remarks>
    [StructLayout( LayoutKind.Sequential )]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }

    /// <summary>
    /// Structure with information about the size and position of a window</summary>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms632612%28v=vs.85%29.aspx. </remarks>
    [StructLayout( LayoutKind.Sequential )]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public uint flags;
    }

    /// <summary>
    /// Message structure for Windows messages to controls and applications. Defined in winuser.h.</summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct MSG

    {
        public IntPtr hWnd;
        public Int32 msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public POINT p;
    }

    /// <summary>
    /// TRACKMOUSEEVENT structure to interoperate with user32.dll</summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct TRACKMOUSEEVENT
    {
        public int cbSize;
        public int dwFlags;
        public IntPtr hwndTrack;
        public int dwHoverTime;
        public TRACKMOUSEEVENT( IntPtr hWnd )
        {
            cbSize = Marshal.SizeOf( typeof( TRACKMOUSEEVENT ) );
            hwndTrack = hWnd;
            dwHoverTime = HOVER_DEFAULT;
            dwFlags = TME_HOVER;
        }
    }

    /// <summary>
    /// NMHDR structure to interoperate with user32.dll</summary>
    [StructLayout( LayoutKind.Sequential )]
    public struct NMHDR
    {
        public IntPtr hwndFrom;
        public IntPtr idFrom;
        public int code;
    }

    /// <summary>
    /// Sends specified message to a window or windows</summary>
    /// <param name="hWnd">Handle to the window</param>
    /// <param name="msg">Message to be sent</param>
    /// <param name="wParam">Additional message-specific information</param>
    /// <param name="lParam">Additional message-specific information</param>
    /// <returns>Specifies result of message processing, depending on message sent</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms644950%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName, CharSet = CharSet.Unicode )]
    public static extern IntPtr SendMessage( IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam );

    /// <summary>
    /// Sends specified message to a header control. A header control is a window that is usually positioned
    /// above columns of text or numbers. It contains a title for each column, and it can be divided into parts.</summary>
    /// <param name="handle">Handle to the header control</param>
    /// <param name="msg">User32.HDM_GETITEM or User32.HDM_SETITEM</param>
    /// <param name="wParam">Additional message-specific information</param>
    /// <param name="lParam">HDITEM object</param>
    /// <returns>Specifies result of message processing, depending on message sent</returns>
    /// <remarks>For details on the Win32 SendMessage:
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms644950%28v=vs.85%29.aspx
    /// For HDM_GETITEM: https://msdn.microsoft.com/en-us/library/windows/desktop/bb775335(v=vs.85).aspx
    /// For HDM_SETITEM: https://msdn.microsoft.com/en-us/library/windows/desktop/bb775367(v=vs.85).aspx </remarks>
    [DllImport( DllName, EntryPoint = "SendMessage" )]
    public static extern IntPtr SendMessageITEM( IntPtr handle, Int32 msg, IntPtr wParam, ref HDITEM lParam );

    [DllImport( "user32.dll" )]
    public static extern bool PostMessage( IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam );

    /// <summary>
    /// Retrieves handle to window that has the keyboard focus</summary>
    /// <returns>Handle to window</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms646294%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi )]
    public static extern IntPtr GetFocus( );

    /// <summary>
    /// Retrieves handle to the given window's parent</summary>
    /// <returns>Handle to the parent window</returns>
    /// <remarks>For details, see https://msdn.microsoft.com/en-us/library/windows/desktop/ms633510(v=vs.85).aspx </remarks>
    [DllImport( DllName, CharSet = CharSet.Unicode )]
    public static extern IntPtr GetParent( IntPtr hWnd );

    /// <summary>
    /// Provides access to function required to delete handle. This method is used internally
    /// and is not required to be called separately.</summary>
    /// <param name="hIcon">Pointer to icon handle</param>
    /// <returns>Zero iff error occurred</returns>
    [DllImport( DllName )]
    public static extern int DestroyIcon( IntPtr hIcon );

    /// <summary>
    /// Loads the icon with the given name</summary>
    /// <param name="hInstance">Current instance</param>
    /// <param name="iconName">Icon name</param>
    /// <returns>Handle to icon with the given name</returns>
    [DllImport( DllName )]
    public static extern IntPtr LoadIcon( IntPtr hInstance, IntPtr iconName );

    /// <summary>
    /// Gets the scroll bar position for a given control</summary>
    /// <param name="hWnd">Control's handle</param>
    /// <param name="nBar">Orientation</param>
    /// <returns>Scroll bar position</returns>
    [DllImport( DllName, CharSet = CharSet.Unicode )]
    public static extern int GetScrollPos( IntPtr hWnd, int nBar );

    // ShowWindow Constants

    public const int SW_HIDE = 0;
    public const int SW_SHOWNORMAL = 1;
    public const int SW_NORMAL = 1;
    public const int SW_SHOWMINIMIZED = 2;
    public const int SW_SHOWMAXIMIZED = 3;
    public const int SW_MAXIMIZE = 3;
    public const int SW_SHOWNOACTIVATE = 4;
    public const int SW_SHOW = 5;
    public const int SW_MINIMIZE = 6;
    public const int SW_SHOWMINNOACTIVE = 7;
    public const int SW_SHOWNA = 8;
    public const int SW_RESTORE = 9;
    public const int SW_SHOWDEFAULT = 10;
    public const int SW_FORCEMINIMIZE = 11;
    public const int SW_MAX = 11;

    /// <summary>
    /// Returns the high-order word (highest 16 bits) of int</summary>
    /// <param name="n">Word whose highest 16 bits are obtained</param>
    /// <returns>Highest 16 bits of word</returns>
    public static int HIWORD( int n )
    {
        return (n >> 16) & 0xffff;
    }

    /// <summary>
    /// Returns the high-order word (highest 16 bits) of int</summary>
    /// <param name="n">Pointer to word whose highest 16 bits are obtained</param>
    /// <returns>Highest 16 bits of word</returns>
    public static int HIWORD( IntPtr n )
    {
        return HIWORD( unchecked((int)(long)n) );
    }

    /// <summary>
    /// Returns the low-order word (lowest 16 bits) of int</summary>
    /// <param name="n">Word whose lowest 16 bits are obtained</param>
    /// <returns>Lowest 16 bits of word</returns>
    public static int LOWORD( int n )
    {
        return n & 0xffff;
    }

    /// <summary>
    /// Returns the low-order word (lowest 16 bits) of int</summary>
    /// <param name="n">Pointer to word whose lowest 16 bits are obtained</param>
    /// <returns>Lowest 16 bits of word</returns>
    public static int LOWORD( IntPtr n )
    {
        return LOWORD( unchecked((int)(long)n) );
    }

    /// <summary>
    /// Sets window's show state</summary>
    /// <param name="hWnd">Window HWND</param>
    /// <param name="nCmdShow">Constant indicating how window is to be shown</param>
    /// <returns>Zero iff window was previously hidden; non-zero otherwise</returns>
    [DllImport( DllName )]
    public static extern bool ShowWindow( IntPtr hWnd, int nCmdShow );

    /// <summary>
    /// Brings window to foreground</summary>
    /// <param name="hWnd">Handle to window</param>
    /// <returns>Zero iff window was not brought to foreground</returns>
    [DllImport( DllName )]
    public static extern bool SetForegroundWindow( IntPtr hWnd );

    /// <summary>
    /// Tests if a window is minimized (iconic)</summary>
    /// <param name="hWnd">Handle to window</param>
    /// <returns>Zero iff window not iconic</returns>
    [DllImport( DllName )]
    public static extern bool IsIconic( IntPtr hWnd );

    /// <summary>
    /// Gets handle to window representing desktop</summary>
    /// <returns>Handle to window representing desktop</returns>
    [DllImport( DllName )]
    public static extern IntPtr GetDesktopWindow( );

    /// <summary>
    /// Gets device context for client area of specified window</summary>
    /// <param name="hwnd">Window handle</param>
    /// <returns>Window's device context</returns>
    [DllImport( DllName, EntryPoint = "GetDC" )]
    public static extern IntPtr GetDC( IntPtr hwnd );

    /// <summary>
    /// Gets window's device context</summary>
    /// <param name="hWnd">Window handle</param>
    /// <returns>Window's device context</returns>
    [DllImport( DllName )]
    public static extern IntPtr GetWindowDC( IntPtr hWnd );

    /// <summary>
    /// Releases window's device context</summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="hDC">Device context to release</param>
    /// <returns>Zero if device context not released; 1 if device context released</returns>
    [DllImport( DllName )]
    public static extern IntPtr ReleaseDC( IntPtr hWnd, IntPtr hDC );

    /// <summary>
    /// Gets window's rectangle</summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="rect">Rectangle obtained by function</param>
    /// <returns>Zero iff failed to get rectangle</returns>
    [DllImport( DllName )]
    public static extern IntPtr GetWindowRect( IntPtr hWnd, ref RECT rect );

    /// <summary>
    /// Gets window's client area rectangle</summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="r">Rectangle obtained by function</param>
    /// <returns>Zero iff failed to get rectangle</returns>
    [DllImport( DllName, CharSet = CharSet.Unicode, ExactSpelling = true )]
    public static extern bool GetClientRect( IntPtr hWnd, ref Rectangle r );

    /// <summary>
    /// Copies a visual window into the specified device context</summary>
    /// <param name="hWnd">A handle to the window that will be copied</param>
    /// <param name="hdcBlt">A handle to the device context</param>
    /// <param name="nFlags">The drawing options. PW_CLIENTONLY to copy client area only; otherwise copy entire window.</param>
    /// <returns>Zero iff not successful</returns>
    [DllImport( DllName )]
    public static extern bool PrintWindow( IntPtr hWnd, IntPtr hdcBlt, int nFlags );

    /// <summary>
    /// Copies the text of the specified window's title bar
    /// (if it has one) into a buffer. If the specified window is a control, the text of
    /// the control is copied. However, GetWindowText cannot retrieve the text of a
    /// control in another application.</summary>
    /// <param name="hWnd">Handle to window</param>
    /// <param name="lpString">Pointer to area that receives text</param>
    /// <param name="nMaxCount">Maximum number of characters to copy, including terminating NULL character</param>
    /// <returns>If the function succeeds, the return value is the length, in characters,
    /// of the copied string, not including the terminating NULL character. If the window
    /// has no title bar or text, if the title bar is empty, or if the window or control
    /// handle is invalid, the return value is zero. To get extended error information,
    /// call GetLastError.</returns>
    [DllImport( DllName, CharSet = CharSet.Unicode, SetLastError = true )]
    public static extern int GetWindowText( IntPtr hWnd, [Out, MarshalAs( UnmanagedType.LPTStr )] StringBuilder lpString, int nMaxCount );

    /// <summary>
    /// Retrieves a handle to the window that contains the specified point.</summary>
    /// <param name="point">The point to be checked</param>
    /// <returns>The return value is a handle to the window that contains the point.
    /// If no window exists at the given point, the return value is IntPtr.Zero.
    /// If the point is over a static text control, the return value is a handle to
    /// the window under the static text control.</returns>
    [DllImport( DllName )]
    public static extern IntPtr WindowFromPoint( Point point );

    /// <summary>
    /// Examines messages that are in the Windows message queue for this thread</summary>
    /// <param name="msg">Pointer to area that receives message</param>
    /// <param name="hWnd">Handle to window</param>
    /// <param name="messageFilterMin">Value to indicate first message to receive. 
    /// Set to WM_KEYFIRST (0x0100) for the first keyboard message or 
    /// WM_MOUSEFIRST (0x0200) for the first mouse message.</param>
    /// <param name="messageFilterMax">Value to indicate last message to receive.
    /// Set to WM_KEYLAST for the last keyboard message or WM_MOUSELAST for the last mouse message.</param>
    /// <param name="flags">Flags indicating how messages are handled. </param>
    /// <returns>Zero iff no messages are available</returns>
    [DllImport( DllName, CharSet = CharSet.Unicode )]
    public static extern bool PeekMessage( out MSG msg, Int32 hWnd,
            uint messageFilterMin, uint messageFilterMax, uint flags );

    /// <summary>
    /// Posts messages when mouse leaves or hovers over a window</summary>
    /// <param name="lpEventTrack">Pointer to TRACKMOUSEEVENT structure</param>
    /// <returns>Zero iff function fails</returns>
    [DllImport( DllName, CharSet = CharSet.Unicode )]
    public static extern bool TrackMouseEvent( ref TRACKMOUSEEVENT lpEventTrack );

    /// <summary>
    /// Waits until one or more objects are in the signaled state or timeout occurs</summary>
    /// <param name="nCount">Number of object handles in pHandles</param>
    /// <param name="pHandles">Array of handles for objects being monitored</param>
    /// <param name="bWaitAll">True to wait for all objects to get signaled. False if only wait until one object is signaled; 
    /// in this case, the return value indicated which object was signaled</param>
    /// <param name="dwMilliseconds">Time out period in milliseconds</param>
    /// <param name="dwWakeMask">Mask values that indicate what signals the function waits for</param>
    /// <returns>WAIT_FAILED iff function timed out. Otherwise, returns a value indicating what event caused the function to return, 
    /// such as an object being signaled.</returns>
    [DllImport( DllName )]
    public static extern int MsgWaitForMultipleObjects(
        int nCount,            // number of handles in array
        int pHandles,          // object-handle array
        bool bWaitAll,         // wait option
        int dwMilliseconds,    // time-out interval
        int dwWakeMask         // input-event type
        );

    /// <summary>
    /// Retrieves the clipboard sequence number, which is incremented each time the system
    /// clipboard changes. For details, see http://msdn.microsoft.com/en-us/library/ms649042(v=vs.85).aspx. </summary>
    /// <returns>Clipboard sequence number</returns>
    [DllImport( DllName )]
    public static extern uint GetClipboardSequenceNumber( );

    /// <summary>
    /// Resumes drawing to the specified window handle</summary>
    /// <param name="hwnd">Handle to window</param>
    public static void StartDrawing( IntPtr hwnd )
    {
        SendMessage( hwnd, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero );
    }

    /// <summary>
    /// Stops drawing of the specified window handle</summary>
    /// <param name="hwnd">Handle to window</param>
    public static void StopDrawing( IntPtr hwnd )
    {
        SendMessage( hwnd, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero );
    }

    /// <summary>
    /// Helper class to do the StopDrawing/StartDrawing function pair</summary>
    public class StopDrawingHelper : IDisposable
    {
        /// <summary>
        /// Constructor</summary>
        /// <param name="hwnd">Handle to window</param>
        public StopDrawingHelper( IntPtr hwnd )
        {
            m_hwnd = hwnd;
            StopDrawing( m_hwnd );
        }

        /// <summary>
        /// Dispose</summary>
        void IDisposable.Dispose( )
        {
            StartDrawing( m_hwnd );
        }

        private readonly IntPtr m_hwnd;
    }


    /// <summary>
    /// This delegate is used with SetWindowsHookEx(). For more details, see 
    /// http://msdn.microsoft.com/en-us/library/ms644990. </summary>
    /// <param name="code">The message ID depends on the HookType that was used. It will be ShellEvents
    /// for WH_SHELL or it will be CbtEvents for WH_CBT, for example. If it's less than zero, then that
    /// typically means that no processing should be done and the results of calling CallNextHookEx should
    /// be returned.</param>
    /// <param name="wParam">Additional message-specific information</param>
    /// <param name="lParam">Additional message-specific information</param>
    /// <returns>The result of calling CallNextHookEx() is typically returned.</returns>
    public delegate IntPtr WindowsHookCallback( int code, IntPtr wParam, IntPtr lParam );

    /// <summary>
    /// These are the different hook types when registering a callback with SetWindowsHookEx().
    /// For more details, see http://msdn.microsoft.com/en-us/library/ms644990. </summary>
    public enum HookType
    {
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14
    }

    /// <summary>
    /// These are the message IDs that can be passed in as the code parameter
    /// of the WindowsHookCallback that was registered with HookType.WH_SHELL.</summary>
    public enum ShellEvents
    {
        //This even only gets raised for the top-level unowned Forms, like the main form,
        //  not for various other floating windows Forms like open-file dialog boxes or user
        //  preferences.
        HSHELL_WINDOWCREATED = 1,

        HSHELL_WINDOWDESTROYED = 2,
        HSHELL_ACTIVATESHELLWINDOW = 3,
        HSHELL_WINDOWACTIVATED = 4,
        HSHELL_GETMINRECT = 5,
        HSHELL_REDRAW = 6,
        HSHELL_TASKMAN = 7,
        HSHELL_LANGUAGE = 8,
        HSHELL_ACCESSIBILITYSTATE = 11
    }

    /// <summary>
    /// These are the message IDs that can be passed in as the code parameter
    /// of the WindowsHookCallback that was registered with HookType.WH_CBT.
    /// For details, see http://msdn.microsoft.com/en-us/library/ms644977. </summary>
    public enum CbtEvents
    {
        HCBT_MOVESIZE = 0,
        HCBT_MINMAX = 1,
        HCBT_QS = 2,
        HCBT_CREATEWND = 3,
        HCBT_DESTROYWND = 4,
        HCBT_ACTIVATE = 5,
        HCBT_CLICKSKIPPED = 6,
        HCBT_KEYSKIPPED = 7,
        HCBT_SYSCOMMAND = 8,
        HCBT_SETFOCUS = 9
    }

    /// <summary>
    /// Sets a callback function to receive certain kinds of Windows events.
    /// For details, see http://msdn.microsoft.com/en-us/library/ms644990. </summary>
    /// <param name="code">The type of hook</param>
    /// <param name="func">The callback method delegate. Be sure to create this delegate explicitly and to
    /// hold on to it explicitly because otherwise the implicit delegate can get garbage collected. For example:
    /// private static readonly User32.WindowsHookCallback s_callbackDelegate = ShellHookCallback;</param>
    /// <param name="hInstance">Should be IntPtr.Zero unless the hook type is WH_KEYBOARD_LL or
    /// WH_MOUSE_LL. For details, see http://pinvoke.net/default.aspx/user32/SetWindowsHookEx.html. </param>
    /// <param name="threadID">The thread ID from calling AppDomain.GetCurrentThreadId().
    /// Use the pragma "warning disable 612,618" and "warning restore 612,618" to get rid
    /// of the compiler warning.</param>
    /// <returns>If successful, handle to the hook procedure. If fails, NULL. 
    /// To get extended error information, call GetLastError().</returns>
    [DllImport( DllName, CharSet = CharSet.Unicode )]
    public static extern IntPtr SetWindowsHookEx( HookType code, WindowsHookCallback func, IntPtr hInstance, int threadID );

    /// <summary>
    /// Passes hook information to next hook procedure in current hook chain</summary>
    /// <param name="hhk">Ignored</param>
    /// <param name="nCode">Hook code passed to current hook procedure</param>
    /// <param name="wParam">wParam value passed to the current hook procedure</param>
    /// <param name="lParam">lParam value passed to the current hook procedure</param>
    /// <returns>Value returned by the next hook procedure in the chain</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms644974%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName, CharSet = CharSet.Unicode )]
    public static extern IntPtr CallNextHookEx( IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam );

    /// <summary>
    /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx()</summary>
    /// <param name="hhk">Handle to the hook to be removed</param>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms644993%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName, CharSet = CharSet.Unicode, SetLastError = true )]
    [return: MarshalAs( UnmanagedType.Bool )]
    public static extern bool UnhookWindowsHookEx( IntPtr hhk );

    /// <summary>
    /// Adds rectangle to specified window's update region</summary>
    /// <param name="hWnd">Handle to window</param>
    /// <param name="lpRect">Pointer to a RECT structure for rectangle added to the update region</param>
    /// <param name="bErase">Specifies whether background within update region is erased</param>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/dd145002%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName )]
    public static extern bool InvalidateRect( IntPtr hWnd, IntPtr lpRect, bool bErase );

    /// <summary>
    /// Creates new shape for system caret and assigns ownership of caret to specified window</summary>
    /// <param name="hWnd">Handle to window that owns caret</param>
    /// <param name="hBitmap">Handle to bitmap that defines caret shape</param>
    /// <param name="nWidth">Width of caret</param>
    /// <param name="nHeight">Height of caret</param>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms648399%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName )]
    public static extern bool CreateCaret( IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight );
    /// <summary>
    /// Makes caret visible on screen at caret's current position</summary>
    /// <param name="hWnd">Handle to window that owns caret</param>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms648406%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName )]
    public static extern bool ShowCaret( IntPtr hWnd );
    /// <summary>
    /// Copies caret's position to specified POINT structure</summary>
    /// <param name="lpPoint">Pointer to POINT structure to receive client coordinates of caret</param>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms648402%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName )]
    public static extern bool GetCaretPos( out Point lpPoint );
    /// <summary>
    /// Removes caret from screen</summary>
    /// <param name="hWnd">Handle to window that owns caret</param>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms648403%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName )]
    public static extern bool HideCaret( IntPtr hWnd );
    /// <summary>
    /// Moves caret to specified coordinates</summary>
    /// <param name="x">New x-coordinate of the caret</param>
    /// <param name="y">New y-coordinate of the caret</param>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms648405%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName )]
    public static extern bool SetCaretPos( int x, int y );
    /// <summary>
    /// caret's current shape, frees caret from window, and caret from screen</summary>
    /// <returns>Nonzero iff function succeeds</returns>
    /// <remarks>For details, see http://msdn.microsoft.com/en-us/library/windows/desktop/ms648400%28v=vs.85%29.aspx </remarks>
    [DllImport( DllName )]
    public static extern bool DestroyCaret( );

    /// <summary>
    /// ToolTip related constant, found in CommCtrl.h.</summary>
    const int TTN_FIRST = -520;

    /// <summary>
    /// ToolTip related constant, found in CommCtrl.h.</summary>
    public const int TTN_SHOW = (TTN_FIRST - 1);

    /// <summary>
    /// ToolTip related constant, found in CommCtrl.h.</summary>
    public const int TTN_POP = (TTN_FIRST - 2);

    /// <summary>
    /// ToolTip related constant, found in CommCtrl.h.</summary>
    public const int TTN_LINKCLICK = (TTN_FIRST - 3);

    /// <summary>
    /// ToolTip related constant, found in CommCtrl.h.</summary>
    public const int TTN_GETDISPINFO = (TTN_FIRST - 10);

    /// <summary>
    /// ToolTip related constant.</summary>
    public const int TTM_SETMAXTIPWIDTH = 0x400 + 24;

    /// <summary>
    /// ToolTip related structure. Hard to find documentation on this. I took this from ObjectListView.</summary>
    /// <remarks>For ObjectListView, see http://objectlistview.sourceforge.net/cs/index.html </remarks>
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Auto )]
    public struct NMTTDISPINFO
    {
        public NMHDR hdr;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpszText;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szText;
        public IntPtr hinst;
        public int uFlags;
        public IntPtr lParam;
        //public int hbmp; This is documented but doesn't work. Also, it's not in the native version in CommCtrl.h.
    }

    private const string DllName = "user32.dll";

    /* Wappen added //////////////////////////////////////////*/

    // http://pinvoke.net/default.aspx/user32.GetWindowThreadProcessId
    [DllImport( "user32.dll", SetLastError = true )]
    public static extern uint GetWindowThreadProcessId( IntPtr hWnd, out int lpdwProcessId );

    [DllImport( "user32.dll" )]
    [return: MarshalAs( UnmanagedType.Bool )]
    public static extern bool IsWindowVisible( IntPtr hWnd );

    [DllImport( "user32.dll" )]
    public static extern IntPtr GetDlgItem( IntPtr hDlg, int nIDDlgItem );

    [DllImport( "user32.dll", SetLastError = true )]
    [return: MarshalAs( UnmanagedType.Bool )]
    public static extern bool GetWindowPlacement( IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl );

    /// <summary>
    /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
    /// </summary>
    /// <param name="hWnd">
    /// A handle to the window.
    /// </param>
    /// <param name="lpwndpl">
    /// A pointer to a WINDOWPLACEMENT structure that specifies the new show state and window positions.
    /// <para>
    /// Before calling SetWindowPlacement, set the length member of the WINDOWPLACEMENT structure to sizeof(WINDOWPLACEMENT). SetWindowPlacement fails if the length member is not set correctly.
    /// </para>
    /// </param>
    /// <returns>
    /// If the function succeeds, the return value is nonzero.
    /// <para>
    /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
    /// </para>
    /// </returns>
    [DllImport( "user32.dll", SetLastError = true )]
    [return: MarshalAs( UnmanagedType.Bool )]
    public static extern bool SetWindowPlacement( IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl );

    /// <summary>
    /// Contains information about the placement of a window on the screen.
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Sequential )]
    public struct WINDOWPLACEMENT
    {
        /// <summary>
        /// The length of the structure, in bytes. Before calling the GetWindowPlacement or SetWindowPlacement functions, set this member to sizeof(WINDOWPLACEMENT).
        /// <para>
        /// GetWindowPlacement and SetWindowPlacement fail if this member is not set correctly.
        /// </para>
        /// </summary>
        public int Length;

        /// <summary>
        /// Specifies flags that control the position of the minimized window and the method by which the window is restored.
        /// </summary>
        public int Flags;

        /// <summary>
        /// The current show state of the window.
        /// </summary>
        public ShowWindowCommands ShowCmd;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
        public POINT MinPosition;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
        public POINT MaxPosition;

        /// <summary>
        /// The window's coordinates when the window is in the restored position.
        /// </summary>
        public RECT NormalPosition;

        /// <summary>
        /// Gets the default (empty) value.
        /// </summary>
        public static WINDOWPLACEMENT Default
        {
            get
            {
                WINDOWPLACEMENT result = new WINDOWPLACEMENT();
                result.Length = Marshal.SizeOf( result );
                return result;
            }
        }
    }

    public enum ShowWindowCommands
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        Hide = 0,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or
        /// maximized, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window
        /// for the first time.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        ShowMinimized = 2,
        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        Maximize = 3, // is this the right value?
        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>      
        ShowMaximized = 3,
        /// <summary>
        /// Displays a window in its most recent size and position. This value
        /// is similar to <see cref="Kernel32.ShowWindowCommand.Normal"/>, except
        /// the window is not activated.
        /// </summary>
        ShowNoActivate = 4,
        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        Show = 5,
        /// <summary>
        /// Minimizes the specified window and activates the next top-level
        /// window in the Z order.
        /// </summary>
        Minimize = 6,
        /// <summary>
        /// Displays the window as a minimized window. This value is similar to
        /// <see cref="Kernel32.ShowWindowCommand.ShowMinimized"/>, except the
        /// window is not activated.
        /// </summary>
        ShowMinNoActive = 7,
        /// <summary>
        /// Displays the window in its current size and position. This value is
        /// similar to <see cref="Kernel32.ShowWindowCommand.Show"/>, except the
        /// window is not activated.
        /// </summary>
        ShowNA = 8,
        /// <summary>
        /// Activates and displays the window. If the window is minimized or
        /// maximized, the system restores it to its original size and position.
        /// An application should specify this flag when restoring a minimized window.
        /// </summary>
        Restore = 9,
        /// <summary>
        /// Sets the show state based on the SW_* value specified in the
        /// STARTUPINFO structure passed to the CreateProcess function by the
        /// program that started the application.
        /// </summary>
        ShowDefault = 10,
        /// <summary>
        ///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
        /// that owns the window is not responding. This flag should only be
        /// used when minimizing windows from a different thread.
        /// </summary>
        ForceMinimize = 11
    }

    // Additional from http://pinvoke.net/default.aspx/user32/SendMessage.html
    [DllImport( "user32.dll", CharSet = CharSet.Auto )]
    public static extern IntPtr SendMessage( IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam );

    [DllImport( "user32.dll", CharSet = CharSet.Auto )]
    public static extern IntPtr SendMessage( IntPtr hWnd, int Msg, IntPtr wParam, [MarshalAs( UnmanagedType.LPWStr )] string lParam );

    [DllImport( "user32.dll", CharSet = CharSet.Auto )]
    public static extern IntPtr SendMessage( IntPtr hWnd, int Msg, int wParam, [MarshalAs( UnmanagedType.LPWStr )] string lParam );

    [DllImport( "user32.dll", CharSet = CharSet.Auto )]
    public static extern IntPtr SendMessage( IntPtr hWnd, int Msg, int wParam, ref IntPtr lParam );

    [DllImport( "user32.dll", CharSet = CharSet.Auto )]
    public static extern IntPtr SendMessage( IntPtr hWnd, int Msg, int wParam, IntPtr lParam );

    /// <summary>
    /// Simple version with no arg.
    /// </summary>
    public static IntPtr SendMessage( IntPtr hWnd, int Msg )
    {
        return SendMessage( hWnd, Msg, IntPtr.Zero, IntPtr.Zero );
    }

    public static int MAKEWPARAM( int l, int h )
    {
        return (l & 0xFFFF) | (h << 16);
    }

    public static IntPtr MAKELPARAM( int l, int h )
    {
        return new IntPtr( (h << 16) | (l & 0xFFFF) );
    }


    [DllImport( "user32.dll", SetLastError = true )]
    public static extern bool SetWindowPos( IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags );

    [Flags]
    public enum SetWindowPosFlags : uint
    {
        /// <summary>If the calling thread and the thread that owns the window are attached to different input queues,
        /// the system posts the request to the thread that owns the window. This prevents the calling thread from
        /// blocking its execution while other threads process the request.</summary>
        /// <remarks>SWP_ASYNCWINDOWPOS</remarks>
        AsynchronousWindowPosition = 0x4000,
        /// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
        /// <remarks>SWP_DEFERERASE</remarks>
        DeferErase = 0x2000,
        /// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
        /// <remarks>SWP_DRAWFRAME</remarks>
        DrawFrame = 0x0020,
        /// <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to
        /// the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE
        /// is sent only when the window's size is being changed.</summary>
        /// <remarks>SWP_FRAMECHANGED</remarks>
        FrameChanged = 0x0020,
        /// <summary>Hides the window.</summary>
        /// <remarks>SWP_HIDEWINDOW</remarks>
        HideWindow = 0x0080,
        /// <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the
        /// top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter
        /// parameter).</summary>
        /// <remarks>SWP_NOACTIVATE</remarks>
        DoNotActivate = 0x0010,
        /// <summary>Discards the entire contents of the client area. If this flag is not specified, the valid
        /// contents of the client area are saved and copied back into the client area after the window is sized or
        /// repositioned.</summary>
        /// <remarks>SWP_NOCOPYBITS</remarks>
        DoNotCopyBits = 0x0100,
        /// <summary>Retains the current position (ignores X and Y parameters).</summary>
        /// <remarks>SWP_NOMOVE</remarks>
        IgnoreMove = 0x0002,
        /// <summary>Does not change the owner window's position in the Z order.</summary>
        /// <remarks>SWP_NOOWNERZORDER</remarks>
        DoNotChangeOwnerZOrder = 0x0200,
        /// <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to
        /// the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
        /// window uncovered as a result of the window being moved. When this flag is set, the application must
        /// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
        /// <remarks>SWP_NOREDRAW</remarks>
        DoNotRedraw = 0x0008,
        /// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
        /// <remarks>SWP_NOREPOSITION</remarks>
        DoNotReposition = 0x0200,
        /// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
        /// <remarks>SWP_NOSENDCHANGING</remarks>
        DoNotSendChangingEvent = 0x0400,
        /// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
        /// <remarks>SWP_NOSIZE</remarks>
        IgnoreResize = 0x0001,
        /// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
        /// <remarks>SWP_NOZORDER</remarks>
        IgnoreZOrder = 0x0004,
        /// <summary>Displays the window.</summary>
        /// <remarks>SWP_SHOWWINDOW</remarks>
        ShowWindow = 0x0040,
    }

    public enum GWL
    {
        GWL_WNDPROC =    (-4),
        GWL_HINSTANCE =  (-6),
        GWL_HWNDPARENT = (-8),
        GWL_STYLE =      (-16),
        GWL_EXSTYLE =    (-20),
        GWL_USERDATA =   (-21),
        GWL_ID =     (-12)
    }

    [DllImport( "user32.dll", EntryPoint = "GetWindowLong" )]
    public static extern IntPtr GetWindowLongPtr( IntPtr hWnd, int nIndex );

    [DllImport( "user32.dll", EntryPoint = "GetWindowLong" )]
    public static extern IntPtr GetWindowLong( IntPtr hWnd, int nIndex );

    public static bool GetWindowLongHasFlag( IntPtr hWnd, GWL nIndex, WindowStyles checkingStyle )
    {
        IntPtr v = GetWindowLong( hWnd, (int)nIndex );
        return (v.ToInt32( ) & (int)checkingStyle) != 0;
    }

    /// <summary>
    /// Window Styles.
    /// The following styles can be specified wherever a window style is required. After the control has been created, these styles cannot be modified, except as noted.
    /// </summary>
    [Flags]
    public enum WindowStyles : uint
    {
        /// <summary>The window has a thin-line border.</summary>
        WS_BORDER = 0x800000,

        /// <summary>The window has a title bar (includes the WS_BORDER style).</summary>
        WS_CAPTION = 0xc00000,

        /// <summary>The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.</summary>
        WS_CHILD = 0x40000000,

        /// <summary>Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.</summary>
        WS_CLIPCHILDREN = 0x2000000,

        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated.
        /// If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
        /// </summary>
        WS_CLIPSIBLINGS = 0x4000000,

        /// <summary>The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.</summary>
        WS_DISABLED = 0x8000000,

        /// <summary>The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.</summary>
        WS_DLGFRAME = 0x400000,

        /// <summary>
        /// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style.
        /// The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
        /// </summary>
        WS_GROUP = 0x20000,

        /// <summary>The window has a horizontal scroll bar.</summary>
        WS_HSCROLL = 0x100000,

        /// <summary>The window is initially maximized.</summary>
        WS_MAXIMIZE = 0x1000000,

        /// <summary>The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.</summary>
        WS_MAXIMIZEBOX = 0x10000,

        /// <summary>The window is initially minimized.</summary>
        WS_MINIMIZE = 0x20000000,

        /// <summary>The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.</summary>
        WS_MINIMIZEBOX = 0x20000,

        /// <summary>The window is an overlapped window. An overlapped window has a title bar and a border.</summary>
        WS_OVERLAPPED = 0x0,

        /// <summary>The window is an overlapped window.</summary>
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

        /// <summary>The window is a pop-up window. This style cannot be used with the WS_CHILD style.</summary>
        WS_POPUP = 0x80000000u,

        /// <summary>The window is a pop-up window. The WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.</summary>
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,

        /// <summary>The window has a sizing border.</summary>
        WS_SIZEFRAME = 0x40000,

        /// <summary>The window has a window menu on its title bar. The WS_CAPTION style must also be specified.</summary>
        WS_SYSMENU = 0x80000,

        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key.
        /// Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.  
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
        /// For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
        /// </summary>
        WS_TABSTOP = 0x10000,

        /// <summary>The window is initially visible. This style can be turned on and off by using the ShowWindow or SetWindowPos function.</summary>
        WS_VISIBLE = 0x10000000,

        /// <summary>The window has a vertical scroll bar.</summary>
        WS_VSCROLL = 0x200000
    }

    [DllImport( "user32.dll" )]
    [return: MarshalAs( UnmanagedType.Bool )]
    public static extern bool GetScrollInfo( IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi );

    public enum ScrollInfoMask : uint
    {
        SIF_RANGE = 0x1,
        SIF_PAGE = 0x2,
        SIF_POS = 0x4,
        SIF_DISABLENOSCROLL = 0x8,
        SIF_TRACKPOS = 0x10,
        SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
    }

    public enum SBOrientation : int
    {
        SB_HORZ = 0x0,
        SB_VERT = 0x1,
        SB_CTL = 0x2,
        SB_BOTH = 0x3
    }

    [Serializable, StructLayout( LayoutKind.Sequential )]
    public struct SCROLLINFO
    {
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }

    public const int MK_LBUTTON = 0x0001;

    public const int SB_SETPARTS      = WM_USER + 4;
    public const int SB_GETPARTS      = WM_USER + 6;
    public const int SB_GETTEXTLENGTH = WM_USER + 12;
    public const int SB_GETTEXT       = WM_USER + 13;
}
