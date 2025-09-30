using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Helper.Memory
{
    public static class MemoryHelper
    {
        public static void FlushMem()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {

                SetProcessWorkingSetSize32Bit(System.Diagnostics
                   .Process.GetCurrentProcess().Handle, -1, -1);

            }

            // if (Environment.Is64BitProcess)//
            //    Console.WriteLine("64-bit process");//
            // else//
            //    Console.WriteLine("32-bit process");//
        }
        [DllImport("KERNEL32.DLL", EntryPoint =
         "SetProcessWorkingSetSize", SetLastError = true,
         CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize32Bit
         (IntPtr pProcess, int dwMinimumWorkingSetSize,
         int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint =
           "SetProcessWorkingSetSize", SetLastError = true,
           CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize64Bit
           (IntPtr pProcess, long dwMinimumWorkingSetSize,
           long dwMaximumWorkingSetSize);
    }
}
