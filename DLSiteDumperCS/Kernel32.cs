
using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

public static class Kernel32
{
    // https://www.pinvoke.net/default.aspx/kernel32.openprocess
    [DllImport( "kernel32.dll", SetLastError = true )]
    public static extern IntPtr OpenProcess(
         uint processAccess,
         bool bInheritHandle,
         int processId
    );

    [Flags]
    public enum ProcessAccessTypes
    {
        PROCESS_TERMINATE         = 0x00000001,
        PROCESS_CREATE_THREAD     = 0x00000002,
        PROCESS_SET_SESSIONID     = 0x00000004,
        PROCESS_VM_OPERATION      = 0x00000008,
        PROCESS_VM_READ           = 0x00000010,
        PROCESS_VM_WRITE          = 0x00000020,
        PROCESS_DUP_HANDLE        = 0x00000040,
        PROCESS_CREATE_PROCESS    = 0x00000080,
        PROCESS_SET_QUOTA         = 0x00000100,
        PROCESS_SET_INFORMATION   = 0x00000200,
        PROCESS_QUERY_INFORMATION = 0x00000400,
        STANDARD_RIGHTS_REQUIRED  = 0x000F0000,
        SYNCHRONIZE               = 0x00100000,
        PROCESS_ALL_ACCESS        = PROCESS_TERMINATE | PROCESS_CREATE_THREAD | PROCESS_SET_SESSIONID | PROCESS_VM_OPERATION |
          PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_DUP_HANDLE | PROCESS_CREATE_PROCESS | PROCESS_SET_QUOTA |
          PROCESS_SET_INFORMATION | PROCESS_QUERY_INFORMATION | STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE
    }

    public static IntPtr OpenProcess( Process proc, ProcessAccessTypes flags )
    {
        return OpenProcess( (uint)flags, false, proc.Id );
    }

    // https://www.pinvoke.net/default.aspx/kernel32.CloseHandle
    [DllImport( "kernel32.dll", SetLastError = true )]
    [ReliabilityContract( Consistency.WillNotCorruptState, Cer.Success )]
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs( UnmanagedType.Bool )]
    public static extern bool CloseHandle( IntPtr hObject );

    [DllImport( "kernel32.dll" )]
    public static extern int VirtualQueryEx( IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength );

    [StructLayout( LayoutKind.Sequential )]
    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public IntPtr RegionSize;
        public uint State;
        public uint Protect;
        public uint Type;
    }

    public enum PageAllocationProtect : uint
    {
        PAGE_EXECUTE           = 0x00000010,
        PAGE_EXECUTE_READ      = 0x00000020,
        PAGE_EXECUTE_READWRITE = 0x00000040,
        PAGE_EXECUTE_WRITECOPY = 0x00000080,
        PAGE_NOACCESS          = 0x00000001,
        PAGE_READONLY          = 0x00000002,
        PAGE_READWRITE         = 0x00000004,
        PAGE_WRITECOPY         = 0x00000008,
        PAGE_GUARD             = 0x00000100,
        PAGE_NOCACHE           = 0x00000200,
        PAGE_WRITECOMBINE      = 0x00000400
    }

    public enum MemState : uint
    {
        MEM_COMMIT  = 0x1000,
        MEM_FREE    = 0x10000,
        MEM_RESERVE = 0x2000
    }

    public enum MemType : uint
    {
        MEM_IMAGE   = 0x1000000,
        MEM_MAPPED  = 0x40000,
        MEM_PRIVATE = 0x20000
    }

    [DllImport( "kernel32.dll", SetLastError = true )]
    public static extern bool ReadProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesRead );

    public static byte[] StructToBytes<T>( T str ) where T : struct
    {
        int size = Marshal.SizeOf(str);
        byte[] arr = new byte[size];

        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr( str, ptr, true );
        Marshal.Copy( ptr, arr, 0, size );
        Marshal.FreeHGlobal( ptr );
        return arr;
    }

    [Flags]
    public enum VirtualAllocExTypes
    {
        WRITE_WATCH_FLAG_RESET = 0x00000001, // Win98 only
        MEM_COMMIT             = 0x00001000,
        MEM_RESERVE            = 0x00002000,
        MEM_COMMIT_OR_RESERVE  = 0x00003000,
        MEM_DECOMMIT           = 0x00004000,
        MEM_RELEASE            = 0x00008000,
        MEM_FREE               = 0x00010000,
        MEM_PUBLIC             = 0x00020000,
        MEM_MAPPED             = 0x00040000,
        MEM_RESET              = 0x00080000, // Win2K only
        MEM_TOP_DOWN           = 0x00100000,
        MEM_WRITE_WATCH        = 0x00200000, // Win98 only
        MEM_PHYSICAL           = 0x00400000, // Win2K only
        //MEM_4MB_PAGES        = 0x80000000, // ??
        SEC_IMAGE              = 0x01000000,
        MEM_IMAGE              = SEC_IMAGE
    }

    [Flags]
    public enum AccessProtectionFlags
    {
        PAGE_NOACCESS          = 0x001,
        PAGE_READONLY          = 0x002,
        PAGE_READWRITE         = 0x004,
        PAGE_WRITECOPY         = 0x008,
        PAGE_EXECUTE           = 0x010,
        PAGE_EXECUTE_READ      = 0x020,
        PAGE_EXECUTE_READWRITE = 0x040,
        PAGE_EXECUTE_WRITECOPY = 0x080,
        PAGE_GUARD             = 0x100,
        PAGE_NOCACHE           = 0x200,
        PAGE_WRITECOMBINE      = 0x400
    }

    [DllImport( "kernel32.dll" )]
    public static extern IntPtr VirtualAllocEx(
        IntPtr hProcess,
        IntPtr address,
        UInt32 size,
        VirtualAllocExTypes allocationType,
        AccessProtectionFlags flags
        );

    [DllImport( "kernel32.dll" )]
    public static extern bool VirtualFreeEx(
        IntPtr hProcess,
        IntPtr address,
        UInt32 size,
        VirtualAllocExTypes dwFreeType
        );
}