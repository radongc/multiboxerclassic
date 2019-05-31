using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Multiboxer
{
    class InputCallback
    {
        private IKeyboardMouseEvents m_GlobalHook;

        public InputCallback()
        {

        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += InputCallback_OnKeyDown;
            m_GlobalHook.KeyUp += InputCallback_OnKeyUp;
            //m_GlobalHook.MouseDown += Hook_OnMouseDown;
            //m_GlobalHook.MouseUp += Hook_OnMouseUp;
        }

        private void InputCallback_OnKeyDown(object sender, KeyEventArgs e)
        {
            Process[] procs = Process.GetProcesses();

            foreach (Process p in procs)
            {
                if (p.ProcessName.Contains("WoW"))
                {
                    WindowUtil.PostKeyDown(p.MainWindowHandle, (Keys)e.KeyValue);
                }
            }
        }

        private void InputCallback_OnKeyUp(object sender, KeyEventArgs e)
        {
            Process[] procs = Process.GetProcesses();

            foreach (Process p in procs)
            {
                if (p.ProcessName.Contains("WoW"))
                {
                    WindowUtil.PostKeyUp(p.MainWindowHandle, (Keys)e.KeyValue);
                }
            }
        }

        private void InputCallback_OnMouseDown(object sender, MouseEventArgs e)
        {
            Process[] procs = Process.GetProcesses();

            foreach (Process p in procs)
            {
                if (p.ProcessName.Contains("WoW"))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        WindowUtil.PostMouseLeftDown(p.MainWindowHandle);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        WindowUtil.PostMouseRightDown(p.MainWindowHandle);
                    }
                }
            }
        }

        private void InputCallback_OnMouseUp(object sender, MouseEventArgs e)
        {
            Process[] procs = Process.GetProcesses();

            foreach (Process p in procs)
            {
                if (p.ProcessName.Contains("WoW"))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        WindowUtil.PostMouseLeftUp(p.MainWindowHandle);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        WindowUtil.PostMouseRightUp(p.MainWindowHandle);
                    }
                }
            }
        }

        public void Unsubscribe()
        {
            m_GlobalHook.KeyDown -= InputCallback_OnKeyDown;
            m_GlobalHook.KeyUp -= InputCallback_OnKeyUp;
            //m_GlobalHook.MouseDown -= Hook_OnMouseDown;
            //m_GlobalHook.MouseUp -= Hook_OnMouseUp;

            m_GlobalHook.Dispose();
        }

    }
}
