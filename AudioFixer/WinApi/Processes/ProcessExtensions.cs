using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioFixer.WinApi.Processes
{
    static class ProcessExtensions
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetCurrentProcess();

        [DllImport("ntdll.dll", SetLastError = false)]
        private static extern IntPtr NtSuspendProcess(IntPtr ProcessHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hHandle);

        public static void Suspend(this Process process)
        {
            var processHandle = GetCurrentProcess();

            if (processHandle == IntPtr.Zero)
            {
                return;
            }

            try
            {
                NtSuspendProcess(processHandle);
            }
            catch (Exception)
            {
                CloseHandle(processHandle);
            }         
        }
    }
}
