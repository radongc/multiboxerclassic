using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiboxer
{
    internal static class WindowUtil
    {
        /* WindowUtil (static)
         * Handles PostMessage functions and function wrappers. */

        /* ConsoleWriter */

        private static ConfigurationManager.ConsoleWriter consoleWriter;

        internal static void SetConsoleWriter(ConfigurationManager.ConsoleWriter writer)
        {
            consoleWriter = writer;
        }

        /* Windows messages */

        // keyboard
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x101;

        // mouse
        public const uint WM_LBUTTONDOWN = 0x201; // Left button
        public const uint WM_LBUTTONUP = 0x202;

        public const uint WM_RBUTTONDOWN = 0x204; // Right button
        public const uint WM_RBUTTONUP = 0x205;

        public const uint WM_MBUTTONDOWN = 0x207; // Middle button
        public const uint WM_MBUTTONUP = 0x208;

        /* Native method imports */

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        /* Native method wrappers */

        private static void PostMessageSafe(IntPtr hWnd, string windowTitle, uint msg, int wParam, int lParam)
        {
            bool returnValue = PostMessage(hWnd, msg, wParam, lParam);

            if (!returnValue)
            {
                // error
                consoleWriter.DebugLog(Marshal.GetLastWin32Error().ToString(), ConfigurationManager.LogType.ERROR);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            else
            {
                string msgName;

                switch(msg)
                {
                    case WM_KEYDOWN:
                        msgName = "WM_KEYDOWN";
                        break;

                    case WM_KEYUP:
                        msgName = "WM_KEYUP";
                        break;

                    default:
                        msgName = "";
                        break;
                }

                consoleWriter.DebugLog($"Send msg {msgName} {(Keys)wParam} to client {windowTitle}", ConfigurationManager.LogType.DEBUG);
            }
        }

        // Helpful methods

        // Window

        internal static void RenameWindow(Process p, string name)
        {
            SetWindowText(p.MainWindowHandle, name);
        }


        // Keyboard

        internal static async void PostKey(IntPtr hWnd, string windowTitle, Keys key)
        {
            PostMessageSafe(hWnd, windowTitle, WM_KEYDOWN, (int)key, 0);
            await Task.Delay(100);
            PostMessageSafe(hWnd, windowTitle, WM_KEYUP, (int)key, 0);
        }

        internal static void PostKeyDown(IntPtr hWnd, string windowTitle, Keys key)
        {
            PostMessageSafe(hWnd, windowTitle, WM_KEYDOWN, (int)key, 0);
        }

        internal static void PostKeyUp(IntPtr hWnd, string windowTitle, Keys key)
        {
            PostMessageSafe(hWnd, windowTitle, WM_KEYUP, (int)key, 0);
        }


        // Mouse (unused)


        internal static void PostMouseLeftDown(IntPtr hWnd, string windowTitle)
        {
            PostMessageSafe(hWnd, windowTitle, WM_LBUTTONDOWN, 0, 0);
        }

        internal static void PostMouseLeftUp(IntPtr hWnd, string windowTitle)
        {
            PostMessageSafe(hWnd, windowTitle, WM_LBUTTONUP, 0, 0);
        }

        internal static void PostMouseRightDown(IntPtr hWnd, string windowTitle)
        {
            PostMessageSafe(hWnd, windowTitle, WM_RBUTTONDOWN, 0, 0);
        }

        internal static void PostMouseRightUp(IntPtr hWnd, string windowTitle)
        {
            PostMessageSafe(hWnd, windowTitle, WM_RBUTTONUP, 0, 0);
        }
    }
}
