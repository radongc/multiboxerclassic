using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiboxer
{
    class WindowUtil
    {
        // Windows messages

        const uint WM_KEYDOWN = 0x100;
        const uint WM_KEYUP = 0x101;

        // Native method imports
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);

        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        // Native method wrappers

        public static IntPtr GetWindow(string windowName)
        {
            IntPtr hWnd = FindWindow(windowName, windowName);
            return hWnd;
        }

        //public static IntPtr GetProcessWindow(int processID) // For windows 10 version
        //{
        //    // Now need to run a loop to get the correct window for process.
        //    bool bFound = false;
        //    IntPtr prevWindow = IntPtr.Zero;

        //    while (!bFound)
        //    {
        //        IntPtr desktopWindow = GetDesktopWindow();
        //        if (desktopWindow == IntPtr.Zero)
        //            break;


        //        IntPtr nextWindow = FindWindowEx(desktopWindow, prevWindow, null, null);
        //        if (nextWindow == IntPtr.Zero)
        //            break;

        //        // Check whether window belongs to the correct process.
        //        int procId = -1;
        //        GetWindowThreadProcessId(nextWindow, out procId);

        //        if (procId == processID)
        //        {

        //            return nextWindow;
        //        }

        //        prevWindow = nextWindow;
        //    }

        //    return IntPtr.Zero;
        //}

        private static void PostMessageSafe(IntPtr hWnd, uint msg, int wParam, int lParam)
        {
            bool returnValue = PostMessage(hWnd, msg, wParam, lParam);

            if (!returnValue)
            {
                // error
                MessageBox.Show("Error");
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        // Helpful methods

        public static async void PostKey(IntPtr hWnd, Keys key)
        {
            PostMessageSafe(hWnd, WM_KEYDOWN, (int)key, 0);
            await Task.Delay(100);
            PostMessageSafe(hWnd, WM_KEYUP, (int)key, 0);
        }

        public static void PostKeyDown(IntPtr hWnd, Keys key)
        {
            PostMessageSafe(hWnd, WM_KEYDOWN, (int)key, 0);
        }

        public static void PostKeyUp(IntPtr hWnd, Keys key)
        {
            PostMessageSafe(hWnd, WM_KEYUP, (int)key, 0);
        }
    }
}
