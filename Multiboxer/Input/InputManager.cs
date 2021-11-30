/*
 * InputManager.cs
 * The core of the multiboxing functionality. This class handles all key hooking and broadcasting. Needs to be rewritten as soon as possible as it is messy.
 */

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
    class InputManager
    {
        /* InputCallback
         * Handles subscribe/unsubscribe from global keyboard/mouse hooks and callback methods.
         * Also holds the main ProcessManager instance, which is accessible only through InputCallback */
        /*
         * FUTURE APPROACH:
         * Have a dictionary that translates key pressed to key sent, and check those first. If no key is in that dictionary, then just unpress the key physically pressed.
         * Currently, it does this in a hardcoded, non-variable way. This whole class should be analyzed and rewritten.
         */

        public static ProcessManager ProcManager;

        private bool _comboKeyPressed = false;

        private bool _subscribed = false;

        private Keys _lastKeyPressed;
        private List<Keys> _multiBroadcastMouseTranslationQueue;  // when multiple keys are sent on a single click (key translation), they are stored here to be unpressed
        private MouseButtons _lastMouseButtonPressed;
        private int _lastMousePressTimestamp;

        private IKeyboardMouseEvents m_GlobalHook;

        public Dictionary<string, bool> DefaultBindingMap { get; private set; }

        public InputManager()
        {
            ProcManager = new ProcessManager();

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += InputCallback_OnKeyDown;
            m_GlobalHook.KeyUp += InputCallback_OnKeyUp;

            _multiBroadcastMouseTranslationQueue = new List<Keys>();

            DefaultBindingMap = new Dictionary<string, bool>();
            DefaultBindingMap.Add("F12Key", false);
            DefaultBindingMap.Add("F12OrAltKey", false);
            DefaultBindingMap.Add("F11Key", false);
            DefaultBindingMap.Add("F10Key", false);
            DefaultBindingMap.Add("UPKey", false);
            DefaultBindingMap.Add("SingleClickMouse", false);
            DefaultBindingMap.Add("F9Key", false);
            DefaultBindingMap.Add("F8Key", false);
        }

        public void ToggleDefaultBinding(string bindingKey, bool value)
        {
            DefaultBindingMap[bindingKey] = value;
        }

        public void Subscribe()
        {
            _subscribed = true;
            m_GlobalHook.MouseDownExt += InputCallback_OnMouseDown;
            m_GlobalHook.MouseUp += InputCallback_OnMouseUp;
        }

        private void InputCallback_OnKeyDown(object sender, KeyEventArgs e) // TODO there are some bugs here. 1) when executing combo sequences (ex SHIFT+E) there is sometimes a delay and the combo must be pressed multiple times. 2) if one combo is executed and then another one is tried to be executed before SHIFT (or other combo key) is released, it won't register.
        {
            if (_subscribed || e.KeyCode == Keys.Oem5)
            {
                if (e.KeyCode == Keys.Oem5)
                {
                    MainForm.instance.StartStopMultiboxing();
                }


                // HARDCODED DEFAULT BINDING; NEEDS TO BE REWRITTEN
                if (e.KeyCode == Keys.W)
                {
                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {
                            SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.F8);
                        }
                    }
                }
                //

                if (ProcManager.IgnoreListEnabled)
                {
                    if (ProcManager.IgnoreListType == ProcessManager.IgnoreType.BLACKLIST) // BLACKLIST
                    {
                        bool keyIsBlacklisted = ProcManager.IgnoredKeys.Contains(e.KeyCode);

                        if (keyIsBlacklisted && !_comboKeyPressed)
                        {
                            return;
                        }
                        else if (!keyIsBlacklisted || keyIsBlacklisted && _comboKeyPressed)
                        {
                            foreach (Process p in ProcManager.GameProcList)
                            {
                                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                                {
                                    if (e.Control) // Press control
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        _comboKeyPressed = true;
                                    }

                                    // Replace bad values
                                    if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                                        _comboKeyPressed = true;
                                    }
                                    else if (e.KeyValue == (int)Keys.LControlKey)
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        _comboKeyPressed = true;
                                    }
                                    else
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, e.KeyCode);
                                    }
                                }
                            }
                        }
                    }
                    else if (ProcManager.IgnoreListType == ProcessManager.IgnoreType.WHITELIST)
                    {
                        bool keyIsWhitelisted = ProcManager.IgnoredKeys.Contains(e.KeyCode);

                        if (keyIsWhitelisted || !keyIsWhitelisted && _comboKeyPressed) // essentially just do the opposite of what is done in the blacklist
                        {
                            foreach (Process p in ProcManager.GameProcList)
                            {
                                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                                {
                                    if (e.Control) // Press control
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        _comboKeyPressed = true;
                                    }

                                    // Replace bad values
                                    if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                                        _comboKeyPressed = true;
                                    }
                                    else if (e.KeyValue == (int)Keys.LControlKey)
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                        _comboKeyPressed = true;
                                    }
                                    else
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, (Keys)e.KeyValue);
                                    }
                                }
                            }
                        }
                        else if (!keyIsWhitelisted && !_comboKeyPressed)
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
                                SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                            }

                            // Replace bad values
                            if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                            {
                                SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                            }
                            else if (e.KeyValue == (int)Keys.LControlKey)
                            {
                                SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                            }
                            else
                            {
                                SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, (Keys)e.KeyValue);
                            }
                        }
                    }
                }

                _lastKeyPressed = e.KeyCode;
            }
            else
            {
                return;
            }
        }

        private void InputCallback_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (_subscribed)
            {
                foreach (Process p in ProcManager.GameProcList)
                {
                    if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                    {
/*                        if (_multiBroadcastQueue.Count > 0)
                        {
                            foreach (Keys key in _multiBroadcastQueue)
                            {
                                WindowUtil.PostKeyUp(p.MainWindowHandle, p.MainWindowTitle, key);
                            }

                            _multiBroadcastQueue.Clear();
                        }
                        else
                        {*/
                        if (e.KeyCode == Keys.W)
                        {
                            SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.F8);
                        }
                        else
                        {
                            SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, e.KeyCode);
                        }
                        /*}*/

                        if (_comboKeyPressed)
                        {
                            _comboKeyPressed = false;
                        }
                    }
                }
            }
        }

        /*private void InputCallback_OnKeyUp(object sender, KeyEventArgs e) // TODO find a solution to the inefficiency of this method. it sends a WM_KEYUP msg to child clients for ALL keys, regardless of whether they are blacklisted/whitelisted or not.
        {
            if (_subscribed)
            {
                // DEFAULT BINDINGS
                foreach (Process p in ProcManager.GameProcList)
                {
                    if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                    {
                        if (e.KeyCode == Keys.W)
                        {
                            SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.F8);
                        }
                    }
                }

                if ((ProcManager.IgnoreListEnabled && ProcManager.IgnoredKeys.Contains(e.KeyCode) && comboKeyPressed) || (ProcManager.IgnoreListEnabled && !ProcManager.IgnoredKeys.Contains(e.KeyCode)) || !ProcManager.IgnoreListEnabled)
                {
                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {

                            if (e.Control) // Press control
                            {
                                SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                comboKeyPressed = false;
                            }

                            // Replace bad values
                            if (e.KeyValue == (int)Keys.LShiftKey) // Replace LShiftKey with ShiftKey
                            {
                                SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.ShiftKey);
                                comboKeyPressed = false;
                            }
                            else if (e.KeyValue == (int)Keys.LControlKey)
                            {
                                SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, Keys.ControlKey);
                                comboKeyPressed = false;
                            }
                            else
                            {
                                SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, (Keys)e.KeyValue); // Converting the KeyValue from int to Keys enum (the int in KeyValue is the identifier for the Key in the Keys enum..)
                            }
                        }
                    }
                }
            }
        }*/

        private void InputCallback_OnMouseDown(object sender, MouseEventExtArgs e)
        {
            ProcManager.RefreshClientProcList();

            // ALL HARDCODED DEFAULT VALS
            foreach (Process p in ProcManager.GameProcList)
            {
                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (_lastMouseButtonPressed == MouseButtons.Left && e.Timestamp - _lastMousePressTimestamp <= 300)
                        {
                            SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.F9);
                        }
                        else
                        {
                            SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.F12);
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.F12);
                        SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.F11);
                        SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.F10);
                    }
                    else if (e.Button == MouseButtons.XButton2)
                    {
                        SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, Keys.Up);
                    }
                }
            }

            _lastMouseButtonPressed = e.Button;
            _lastMousePressTimestamp = e.Timestamp;
        }

        private void InputCallback_OnMouseUp(object sender, MouseEventArgs e)
        {
            ProcManager.RefreshClientProcList();

            // ALL HARDCODED DEFAULT VALS
            foreach (Process p in ProcManager.GameProcList)
            {
                if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                {
                    if (_multiBroadcastMouseTranslationQueue.Count > 0)
                    {
                        foreach(Keys key in _multiBroadcastMouseTranslationQueue)
                        {
                            WindowUtil.PostKeyUp(p.MainWindowHandle, p.MainWindowTitle, key);
                        }

                        _multiBroadcastMouseTranslationQueue.Clear();
                    }

                    if (_comboKeyPressed)
                    {
                        _comboKeyPressed = false;
                    }
                }
            }
        }

        public void SendKeyDown(IntPtr hWnd, string windowTitle, Keys key)
        {
            WindowUtil.PostKeyDown(hWnd, windowTitle, key);
        }

        public void SendMouseTranslationKeyDown(IntPtr hWnd, string windowTitle, Keys key)
        {
            WindowUtil.PostKeyDown(hWnd, windowTitle, key);
            _multiBroadcastMouseTranslationQueue.Add(key);
        }

        public void SendKeyUp(IntPtr hWnd, string windowTitle, Keys key)
        {
            WindowUtil.PostKeyUp(hWnd, windowTitle, key);
        }

        public void Unsubscribe()
        {
            _subscribed = false;
            m_GlobalHook.MouseDownExt -= InputCallback_OnMouseDown;
            m_GlobalHook.MouseUp -= InputCallback_OnMouseUp;
        }

        public void Terminate()
        {
            m_GlobalHook.KeyDown -= InputCallback_OnKeyDown;
            m_GlobalHook.KeyUp -= InputCallback_OnKeyUp;
            m_GlobalHook.MouseDownExt -= InputCallback_OnMouseDown;
            m_GlobalHook.MouseUp -= InputCallback_OnMouseUp;

            m_GlobalHook.Dispose();
        }
    }
}
