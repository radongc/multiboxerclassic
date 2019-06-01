using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiboxer
{
    class WindowUtil
    {
        /* Windows messages */

        // keyboard
        const uint WM_KEYDOWN = 0x100;
        const uint WM_KEYUP = 0x101;

        // mouse
        const uint WM_LBUTTONDOWN = 0x201; // Left button
        const uint WM_LBUTTONUP = 0x202;

        const uint WM_RBUTTONDOWN = 0x204; // Right button
        const uint WM_RBUTTONUP = 0x205;

        const uint WM_MBUTTONDOWN = 0x207; // Middle button
        const uint WM_MBUTTONUP = 0x208;

        /* Native method imports */

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /* Native method wrappers */

        private static void PostMessageSafe(IntPtr hWnd, uint msg, int wParam, int lParam)
        {
            bool returnValue = PostMessage(hWnd, msg, wParam, lParam);

            if (!returnValue)
            {
                // error
                MessageBox.Show("Error");
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            else
            {
                Console.WriteLine($"Send msg {msg} to client {hWnd}");
            }
        }

        // Helpful methods


        // Keyboard

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


        // Mouse

        public static void PostMouseLeftDown(IntPtr hWnd)
        {
            PostMessageSafe(hWnd, WM_LBUTTONDOWN, 0, 0);
        }

        public static void PostMouseLeftUp(IntPtr hWnd)
        {
            PostMessageSafe(hWnd, WM_LBUTTONUP, 0, 0);
        }

        public static void PostMouseRightDown(IntPtr hWnd)
        {
            PostMessageSafe(hWnd, WM_RBUTTONDOWN, 0, 0);
        }

        public static void PostMouseRightUp(IntPtr hWnd)
        {
            PostMessageSafe(hWnd, WM_RBUTTONUP, 0, 0);
        }
    }
}
