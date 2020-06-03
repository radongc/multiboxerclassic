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
        /* InputCallback
         * Handles subscribe/unsubscribe from global keyboard/mouse hooks and callback methods.
         * Also holds the main ProcessManager instance, which is accessible only through InputCallback */

        public static ProcessManager ProcManager;

        private bool comboKeyPressed = false;

        private bool _subscribed = false;

        private IKeyboardMouseEvents m_GlobalHook;

        public InputCallback()
        {
            ProcManager = new ProcessManager();

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += InputCallback_OnKeyDown;
            m_GlobalHook.KeyUp += InputCallback_OnKeyUp;
            //m_GlobalHook.MouseDown += Hook_OnMouseDown;
            //m_GlobalHook.MouseUp += Hook_OnMouseUp;
        }

        public void Subscribe()
        {
            _subscribed = true;
        }

        private void InputCallback_OnKeyDown(object sender, KeyEventArgs e) // TODO there are some bugs here. 1) when executing combo sequences (ex SHIFT+E) there is sometimes a delay and the combo must be pressed multiple times. 2) if one combo is executed and then another one is tried to be executed before SHIFT (or other combo key) is released, it won't register.
        {
            if (_subscribed || e.KeyCode == Keys.NumPad8)
            {
                if (e.KeyCode == Keys.NumPad8)
                {
                    MainForm.instance.StartStopMultiboxing();
                }

                if (ProcManager.IgnoreListEnabled)
                {
                    if (ProcManager.IgnoreListType == ProcessManager.IgnoreType.BLACKLIST) // BLACKLIST
                    {
                        bool keyIsBlacklisted = ProcManager.IgnoredKeys.Contains(e.KeyCode);

                        if (keyIsBlacklisted && !comboKeyPressed)
                        {
                            return;
                        }
                        else if (!keyIsBlacklisted || keyIsBlacklisted && comboKeyPressed)
                        {
                            foreach (Process p in ProcManager.GameProcList)
                            {
                                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                                {
                                    if (e.Control) // Press control
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        comboKeyPressed = true;
                                    }

                                    // Replace bad values
                                    if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                                        comboKeyPressed = true;
                                    }
                                    else if (e.KeyValue == (int)Keys.LControlKey)
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        comboKeyPressed = true;
                                    }
                                    else
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, (Keys)e.KeyValue);
                                    }
                                }
                            }
                        }
                    }
                    else if (ProcManager.IgnoreListType == ProcessManager.IgnoreType.WHITELIST)
                    {
                        bool keyIsWhitelisted = ProcManager.IgnoredKeys.Contains(e.KeyCode);

                        if (keyIsWhitelisted || !keyIsWhitelisted && comboKeyPressed) // essentially just do the opposite of what is done in the blacklist
                        {
                            foreach (Process p in ProcManager.GameProcList)
                            {
                                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                                {
                                    if (e.Control) // Press control
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        comboKeyPressed = true;
                                    }

                                    // Replace bad values
                                    if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                                        comboKeyPressed = true;
                                    }
                                    else if (e.KeyValue == (int)Keys.LControlKey)
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        comboKeyPressed = true;
                                    }
                                    else
                                    {
                                        WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, (Keys)e.KeyValue);
                                    }
                                }
                            }
                        }
                        else if (!keyIsWhitelisted && !comboKeyPressed)
                        {
                            return;
                        }
                    }
                }
                else // Ignore list disabled
                {
                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {
                            if (e.Control) // Press control
                            {
                                WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                            }

                            // Replace bad values
                            if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                            {
                                WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                            }
                            else if (e.KeyValue == (int)Keys.LControlKey)
                            {
                                WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                            }
                            else
                            {
                                WindowUtil.PostKeyDown(p.MainWindowHandle, p.MainWindowTitle, (Keys)e.KeyValue);
                            }
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void InputCallback_OnKeyUp(object sender, KeyEventArgs e) // TODO find a solution to the inefficiency of this method. it sends a WM_KEYUP msg to child clients for ALL keys, regardless of whether they are blacklisted/whitelisted or not.
        {
            if (_subscribed)
            {
                if ((ProcManager.IgnoreListEnabled && ProcManager.IgnoredKeys.Contains(e.KeyCode) && comboKeyPressed) || (ProcManager.IgnoreListEnabled && !ProcManager.IgnoredKeys.Contains(e.KeyCode)) || !ProcManager.IgnoreListEnabled)
                {
                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {

                            if (e.Control) // Press control
                            {
                                WindowUtil.PostKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                comboKeyPressed = false;
                            }

                            // Replace bad values
                            if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                            {
                                WindowUtil.PostKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                                comboKeyPressed = false;
                            }
                            else if (e.KeyValue == (int)Keys.LControlKey)
                            {
                                WindowUtil.PostKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                comboKeyPressed = false;
                            }
                            else
                            {
                                WindowUtil.PostKeyUp(p.MainWindowHandle, p.MainWindowTitle, (Keys)e.KeyValue); // Converting the KeyValue from int to Keys enum (the int in KeyValue is the identifier for the Key in the Keys enum..)
                            }
                        }
                    }
                }
            }
        }

        private void InputCallback_OnMouseDown(object sender, MouseEventArgs e)
        {
            ProcManager.RefreshClientProcList();

            foreach (Process p in ProcManager.GameProcList)
            {
                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        WindowUtil.PostMouseLeftDown(p.MainWindowHandle, p.MainWindowTitle);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        WindowUtil.PostMouseRightDown(p.MainWindowHandle, p.MainWindowTitle);
                    }
                }
            }
        }

        private void InputCallback_OnMouseUp(object sender, MouseEventArgs e)
        {
            ProcManager.RefreshClientProcList();

            foreach (Process p in ProcManager.GameProcList)
            {
                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id)) // .Equals() compares the contents, == compares the reference
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        WindowUtil.PostMouseLeftUp(p.MainWindowHandle, p.MainWindowTitle);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        WindowUtil.PostMouseRightUp(p.MainWindowHandle, p.MainWindowTitle);
                    }
                }
            }
        }

        public void Unsubscribe()
        {
            _subscribed = false;
        }

        public void Terminate()
        {
            m_GlobalHook.KeyDown -= InputCallback_OnKeyDown;
            m_GlobalHook.KeyUp -= InputCallback_OnKeyUp;
            //m_GlobalHook.MouseDown -= Hook_OnMouseDown;
            //m_GlobalHook.MouseUp -= Hook_OnMouseUp;

            m_GlobalHook.Dispose();
        }
    }
}
