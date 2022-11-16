/*
 * InputManager.cs
 * The core of the multiboxing functionality. This class handles all key hooking and broadcasting. Needs to be rewritten as soon as possible as it is messy.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private bool _mouseBroadcastingEnabled = false;

        private Keys _lastKeyPressed;
        private List<Keys> _multiBroadcastMouseTranslationQueue;  // when multiple keys are sent on a single click (key translation), they are stored here to be unpressed
        private MouseButtons _lastMouseButtonPressed;
        private int _lastMousePressTimestamp;

        private IKeyboardMouseEvents m_GlobalHook;

        public Dictionary<string, DefaultBinding> DefaultBindingList { get; private set; }

        private ConfigurationManager.ConsoleWriter _consoleWriter;

        public InputManager()
        {
            ProcManager = new ProcessManager();

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += InputCallback_OnKeyDown;
            m_GlobalHook.KeyUp += InputCallback_OnKeyUp;
            m_GlobalHook.MouseDownExt += InputCallback_OnMouseDown;
            m_GlobalHook.MouseUp += InputCallback_OnMouseUp;

            _multiBroadcastMouseTranslationQueue = new List<Keys>();

            DefaultBindingList = new Dictionary<string, DefaultBinding>();
            DefaultBindingList.Add("F12Key", new DefaultMouseBinding("F12Key", false, false, new InGameMacro("Assist", "/assist Party1"), MouseButtons.Left, Keys.F12));
            DefaultBindingList.Add("F12OrAltKey", new DefaultMouseBinding("F12OrAltKey", false, false, new InGameMacro("Assist", "/assist Party1"), MouseButtons.Right, Keys.F12));
            DefaultBindingList.Add("F11Key", new DefaultMouseBinding("F11Key", false, false, null, MouseButtons.Right, Keys.F11));
            DefaultBindingList.Add("F10Key", new DefaultMouseBinding("F10Key", false, false, new InGameMacro("ConfirmQuest", "/script SelectGossipAvailableQuest(1)\n/script AcceptQuest(1)\n/script CompleteQuest()\n/script GetQuestReward()"), MouseButtons.Right, Keys.F10));
            DefaultBindingList.Add("UPKey", new DefaultMouseBinding("UPKey", false, false, null, MouseButtons.XButton2, Keys.Up));
            DefaultBindingList.Add("ToggleMouseBroadcasting", new SpecialBinding("ToggleMouseBroadcasting", false, false, Keys.LControlKey, () => _mouseBroadcastingEnabled = !_mouseBroadcastingEnabled));
            DefaultBindingList.Add("F9Key", new DefaultMouseBinding("F9Key", false, true, new InGameMacro("SetView", "/script SetView(5);SetView(5);"), MouseButtons.Left, Keys.F9));
            DefaultBindingList.Add("F8Key", new DefaultKeyBinding("F8Key", false, false, new InGameMacro("Follow", "/follow Party1"), Keys.W, Keys.F8));
        }

        internal void SetConsoleWriter(ConfigurationManager.ConsoleWriter writer)
        {
            _consoleWriter = writer;
        }

        public void ToggleDefaultBinding(string bindingKey, bool value)
        {
            try
            {
                DefaultBindingList[bindingKey].SetEnabled(value);
            }
            catch (Exception b)
            {
                _consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        public void Subscribe()
        {
            _subscribed = true;
        }

        private void InputCallback_OnKeyDown(object sender, KeyEventArgs e) // TODO there are some bugs here. 1) when executing combo sequences (ex SHIFT+E) there is sometimes a delay and the combo must be pressed multiple times. 2) if one combo is executed and then another one is tried to be executed before SHIFT (or other combo key) is released, it won't register.
        {
            try
            {
                if (_subscribed || e.KeyCode == Keys.Oem5)
                {
                    if (e.KeyCode == Keys.Oem5)
                    {
                        MainForm.instance.StartStopMultiboxing();
                    }

                    foreach (KeyValuePair<string, DefaultBinding> binding in DefaultBindingList)
                    {
                        if (!(binding.Value is SpecialBinding))
                            continue;

                        if (binding.Value.BindingEnabled)
                        {
                            if (e.KeyCode == ((SpecialBinding)binding.Value).BindingPressKey)
                            {
                                ((SpecialBinding)binding.Value).SpecialAction();
                            }
                        }
                    }

                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {
                            foreach (KeyValuePair<string, DefaultBinding> binding in DefaultBindingList)
                            {
                                if (!(binding.Value is DefaultKeyBinding))
                                    continue;

                                if (binding.Value.BindingEnabled)
                                {
                                    if (e.KeyCode == ((DefaultKeyBinding)binding.Value).BindingPressKey)
                                    {
                                        SendKeyDown(p.MainWindowHandle, p.MainWindowTitle, ((DefaultKeyBinding)binding.Value).BindingBroadcastKey);
                                    }
                                }
                            }
                        }
                    }

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
            catch (Exception b)
            {
                _consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        private void InputCallback_OnKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (_subscribed)
                {
                    bool keyIsBinding = false;

                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {
                            foreach (KeyValuePair<string, DefaultBinding> binding in DefaultBindingList)
                            {
                                if (!(binding.Value is DefaultKeyBinding))
                                    continue;

                                if (e.KeyCode == ((DefaultKeyBinding)binding.Value).BindingPressKey)
                                {
                                    keyIsBinding = true;
                                    SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, ((DefaultKeyBinding)binding.Value).BindingBroadcastKey);
                                }
                            }

                            if (!keyIsBinding)
                            {
                                SendKeyUp(p.MainWindowHandle, p.MainWindowTitle, e.KeyCode);
                            }

                            if (_comboKeyPressed)
                            {
                                _comboKeyPressed = false;
                            }
                        }
                    }
                }
            }
            catch (Exception b)
            {
                _consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        private void InputCallback_OnMouseDown(object sender, MouseEventExtArgs e)
        {
            try
            {
                if (_subscribed)
                {
                    ProcManager.RefreshClientProcList();

                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {
                            foreach (KeyValuePair<string, DefaultBinding> binding in DefaultBindingList)
                            {
                                if (!(binding.Value is DefaultMouseBinding))
                                    continue;

                                if (binding.Value.BindingEnabled)
                                {
                                    if (e.Button == ((DefaultMouseBinding)binding.Value).BindingPressButton)
                                    {
                                        if (!binding.Value.IsDoublePress)
                                        {
                                            SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, ((DefaultMouseBinding)binding.Value).BindingBroadcastKey);
                                        }
                                        else
                                        {
                                            if (_lastMouseButtonPressed == ((DefaultMouseBinding)binding.Value).BindingPressButton && e.Timestamp - _lastMousePressTimestamp <= 300)
                                            {
                                                SendMouseTranslationKeyDown(p.MainWindowHandle, p.MainWindowTitle, ((DefaultMouseBinding)binding.Value).BindingBroadcastKey);
                                            }
                                        }
                                    }
                                }
                            }

                            if (_mouseBroadcastingEnabled)
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    SendMouseDown(p.MainWindowHandle, p.MainWindowTitle, MouseButtons.Left, e.Location);
                                }
                                else if (e.Button == MouseButtons.Right)
                                {
                                    SendMouseDown(p.MainWindowHandle, p.MainWindowTitle, MouseButtons.Right, e.Location);
                                }
                            }
                        }
                    }

                    _lastMouseButtonPressed = e.Button;
                    _lastMousePressTimestamp = e.Timestamp;
                }
            }
            catch (Exception b)
            {
                _consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        private void InputCallback_OnMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_subscribed)
                {
                    ProcManager.RefreshClientProcList();

                    foreach (Process p in ProcManager.GameProcList)
                    {
                        if (!p.Id.Equals(ProcManager.MasterClient.GameProcess.Id))
                        {
                            if (_multiBroadcastMouseTranslationQueue.Count > 0)
                            {
                                foreach (Keys key in _multiBroadcastMouseTranslationQueue)
                                {
                                    WindowUtil.PostKeyUp(p.MainWindowHandle, p.MainWindowTitle, key);
                                }

                                _multiBroadcastMouseTranslationQueue.Clear();
                            }

                            if (_comboKeyPressed)
                            {
                                _comboKeyPressed = false;
                            }

/*                            if (_mouseBroadcastingEnabled)
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    SendMouseUp(p.MainWindowHandle, p.MainWindowTitle, MouseButtons.Left, e.Location);
                                }
                                else if (e.Button == MouseButtons.Right)
                                {
                                    SendMouseUp(p.MainWindowHandle, p.MainWindowTitle, MouseButtons.Right, e.Location);
                                }
                            }*/
                        }
                    }
                }
            }
            catch (Exception b)
            {
                _consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
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

        public void SendMouseDown(IntPtr hWnd, string windowTitle, MouseButtons button, Point location)
        {
            if (button == MouseButtons.Left)
            {
                WindowUtil.PostMouseLeft(hWnd, windowTitle, location.X, location.Y);
            }
            else if (button == MouseButtons.Right)
            {
                WindowUtil.PostMouseRight(hWnd, windowTitle, location.X, location.Y);
            }
        }

        public void SendMouseUp(IntPtr hWnd, string windowTitle, MouseButtons button, Point location)
        {
            if (button == MouseButtons.Left)
            {
                WindowUtil.PostMouseLeftUp(hWnd, windowTitle, location.X, location.Y);
            }
            else if (button == MouseButtons.Right)
            {
                WindowUtil.PostMouseRightUp(hWnd, windowTitle, location.X, location.Y);
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
            m_GlobalHook.MouseDownExt -= InputCallback_OnMouseDown;
            m_GlobalHook.MouseUp -= InputCallback_OnMouseUp;

            m_GlobalHook.Dispose();
        }
    }
}
