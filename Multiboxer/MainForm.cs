/*
    Multiboxer Classic (c) by Radon (https://github.com/radongc)

    Multiboxer Classic is licensed under a
    Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

    You should have received a copy of the license along with this
    work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Multiboxer
{
    public partial class MainForm : Form
    {
        // fields
        bool _isListeningForInput = false; // is the program listening for input?

        private Dictionary<string, InGameMacro> _childMacroList;

        // class instances
        private InputManager _inputManager;
        private ConfigurationManager _configManager;
        private ConfigurationManager.ConsoleWriter _consoleWriterMain;

        #region Initialization

        public static MainForm instance;

        public MainForm()
        {
            InitializeComponent();

            if (instance != null)
            {
                // not good
            }

            instance = this;
        }
        // Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Init input callbacks and config manager
            InitializeClasses();

            if (!_configManager.IsFirstRun())
            {
                _configManager.LoadIgnoreListToRichTextBox(richTextBoxIgnoreList); // load into ignore list from cfg
                InputManager.ProcManager.SetIgnoredKeys(richTextBoxIgnoreList); // save ignore list
            }

            Console.SetOut(_consoleWriterMain); // route console output to debug window

            // Check for running wow procs and populate the GUI list

            InputManager.ProcManager.RefreshClientProcList();

            PopulateClientList();
            PopulateMacroList();

            _configManager.UpdateStatus($"Found {InputManager.ProcManager.GameProcList.Length} process(es).", ConfigurationManager.LogType.MESSAGE);
        }

        private void InitializeClasses()
        {
            _childMacroList = new Dictionary<string, InGameMacro>();

            // Init input callbacks and config manager
            _inputManager = new InputManager();
            _configManager = new ConfigurationManager("config.cfg", toolStripStatusLabelStatus);
            _consoleWriterMain = new ConfigurationManager.ConsoleWriter(richTextBoxMainDebugConsole, "logs", checkBoxLogMessages.Checked, checkBoxLogDebugs.Checked, checkBoxLogErrors.Checked);

            InputManager.ProcManager.SetConsoleWriter(_consoleWriterMain); // allow procManager to write to console
            _configManager.SetConsoleWriter(_consoleWriterMain);
            _inputManager.SetConsoleWriter(_consoleWriterMain);
            WindowUtil.SetConsoleWriter(_consoleWriterMain);

            labelMultiboxerVersion.Text = $"Multiboxer Classic v{_configManager.MultiboxerVersion}";
        }
        #endregion Initialization

        #region MULTIBOXING TAB

        #region Main Console Event Handlers
        private void checkBoxLogMessages_CheckedChanged(object sender, EventArgs e) => _consoleWriterMain.LogMessages = checkBoxLogMessages.Checked;

        private void checkBoxLogDebug_CheckedChanged(object sender, EventArgs e) => _consoleWriterMain.LogDebugs = checkBoxLogDebugs.Checked;

        private void checkBoxLogError_CheckedChanged(object sender, EventArgs e) => _consoleWriterMain.LogErrors = checkBoxLogErrors.Checked;

        private void buttonClearConsole_Click(object sender, EventArgs e) => richTextBoxMainDebugConsole.Clear();
        #endregion Main Console Event Handlers

        private void buttonStartMultiboxing_Click(object sender, EventArgs e)
        {
            StartStopMultiboxing();
        }

        private void listBoxSelectMasterClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxSelectMasterClient.SelectedItem != null) // avoid unecessary exceptions
                {
                    string procDataUnformatted = listBoxSelectMasterClient.SelectedItem.ToString();

                    string procDataFormatted = procDataUnformatted.Replace(" ", "");

                    string[] procData = procDataFormatted.Split('-');

                    InputManager.ProcManager.SetMasterClient(Convert.ToInt32(procData[1]));
                }
            }
            catch (Exception b)
            {
                _consoleWriterMain.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        private void buttonMasterClientListHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StaticTextLibrary.HelpText.MasterClient, "Master Client Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void buttonRefreshClients_Click(object sender, EventArgs e)
        {
            InputManager.ProcManager.RefreshClientProcList();

            PopulateClientList();

            _configManager.UpdateStatus($"Found {InputManager.ProcManager.GameProcList.Length} process(es).", ConfigurationManager.LogType.MESSAGE);
        }

        #region Private Methods - Multiboxing Tab

        private void PopulateClientList()
        {
            listBoxSelectMasterClient.Items.Clear();

            foreach (WoWClient c in InputManager.ProcManager.GameClientList)
            {
                listBoxSelectMasterClient.Items.Add($"{c.GameProcess.MainWindowTitle} - {c.GameProcess.Id}");
            }

            WindowTab_PopulateGameWindowVisualizers();
        }

        public void StartStopMultiboxing()
        {
            InputManager.ProcManager.RefreshClientProcList();

            bool errorOccurred = false;

            if (!_isListeningForInput)
            {
                if (InputManager.ProcManager.MasterClient == null) // error checking
                {
                    errorOccurred = true;
                    MessageBox.Show(StaticTextLibrary.ErrorText.MasterClientMain, "Multiboxer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _inputManager.Subscribe();

                    buttonStartMultiboxing.Text = "Stop Multiboxing";

                    _configManager.UpdateStatus($"Multiboxing started.", ConfigurationManager.LogType.MESSAGE);
                }
            }
            else if (_isListeningForInput)
            {
                _inputManager.Unsubscribe();

                buttonStartMultiboxing.Text = "Start Multiboxing";

                _configManager.UpdateStatus($"Multiboxing stopped.", ConfigurationManager.LogType.MESSAGE);
            }

            if (!errorOccurred)
            {
                _isListeningForInput = !_isListeningForInput;
            }
        }
        #endregion Private Methods - Multiboxing Tab

        #endregion MULTIBOXING TAB

        #region IGNORE LIST TAB
        private void buttonSaveIgnoreList_Click(object sender, EventArgs e)
        {
            InputManager.ProcManager.SetIgnoredKeys(richTextBoxIgnoreList);

            _configManager.SaveIgnoreList(richTextBoxIgnoreList.Lines.ToList());

            _configManager.UpdateStatus($"Saved IgnoreList to config file successfully.", ConfigurationManager.LogType.MESSAGE);
        }

        private void buttonIgnoreListHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StaticTextLibrary.HelpText.IgnoreList, "Ignore List Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void checkBoxEnableIgnoreList_CheckedChanged(object sender, EventArgs e)
        {
            InputManager.ProcManager.SetIgnoreListEnabled(checkBoxEnableIgnoreList.Checked);

            switch(checkBoxEnableIgnoreList.Checked)
            {
                case true:
                    _configManager.UpdateStatus("IgnoreList enabled.", ConfigurationManager.LogType.MESSAGE);
                    break;

                case false:
                    _configManager.UpdateStatus("IgnoreList disabled.", ConfigurationManager.LogType.MESSAGE);
                    break;
            }
        }

        private void checkBoxBlacklist_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBlacklist.Checked)
            {
                if (checkBoxWhitelist.Checked)
                {
                    checkBoxWhitelist.CheckState = CheckState.Unchecked;
                    _configManager.UpdateStatus("IgnoreList setting changed to blacklist.", ConfigurationManager.LogType.MESSAGE); // needs to be put here to avoid being sent every time it is clicked, even if setting is not actually changing
                }

                InputManager.ProcManager.SetIgnoreListType(ProcessManager.IgnoreType.BLACKLIST);
            }

            if (!checkBoxBlacklist.Checked && !checkBoxWhitelist.Checked)
            {
                checkBoxBlacklist.CheckState = CheckState.Checked;
            }
        }

        private void checkBoxWhitelist_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWhitelist.Checked)
            {
                if (checkBoxBlacklist.Checked)
                {
                    checkBoxBlacklist.CheckState = CheckState.Unchecked;
                    _configManager.UpdateStatus("IgnoreList setting changed to whitelist.", ConfigurationManager.LogType.MESSAGE); // needs to be put here to avoid being sent every time it is clicked, even if setting is not actually changing
                }

                InputManager.ProcManager.SetIgnoreListType(ProcessManager.IgnoreType.WHITELIST);
            }

            if (!checkBoxBlacklist.Checked && !checkBoxWhitelist.Checked)
            {
                checkBoxWhitelist.CheckState = CheckState.Checked;
            }
        }

        private void buttonDefaultBindingsHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StaticTextLibrary.HelpText.DefaultBindings, "Default Bindings Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void checkBoxF12_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("F12Key", checkBoxF12.Checked);
        }

        private void checkBoxF12OrAlt_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("F12OrAltKey", checkBoxF12OrAlt.Checked);
        }

        private void checkBoxF11_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("F11Key", checkBoxF11.Checked);
        }

        private void checkBoxF10_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("F10Key", checkBoxF10.Checked);
        }

        private void checkBoxUP_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("UPKey", checkBoxUP.Checked);
        }

        private void checkBoxSingleClick_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("ToggleMouseBroadcasting", checkBoxSingleClick.Checked);
        }

        private void checkBoxF9_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("F9Key", checkBoxF9.Checked);
        }

        private void checkBoxF8_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("F8Key", checkBoxF8.Checked);
        }

        private void checkBoxSpace_CheckedChanged(object sender, EventArgs e)
        {
            _inputManager.ToggleDefaultBinding("BroadcastJump", checkBoxSpace.Checked);
        }

        #endregion IGNORE LIST TAB

        #region MACRO GENERATOR TAB
        private void listBoxDefaultMacros_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxDefaultMacros.SelectedItem != null) // Avoid unecessary exceptions
                {
                    PopulateMacroData(_childMacroList[listBoxDefaultMacros.SelectedItem.ToString()], _inputManager.DefaultBindingList[listBoxDefaultMacros.SelectedItem.ToString()].BindingBroadcastKey); // new method; pop macro data by selected item (key) and content value of selected item (key)
                }
            }
            catch (Exception b)
            {
                _consoleWriterMain.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        private void buttonCopyMacroName_Click(object sender, EventArgs e)
        {
            if (textBoxMacroName.Text != string.Empty)
            {
                Clipboard.SetText(textBoxMacroName.Text);

                MessageBox.Show("Name copied to clipboard!", "Macro Generator", MessageBoxButtons.OK);
            }
        }

        private void buttonMacroGenHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StaticTextLibrary.HelpText.MacroList, "Macro Generator Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void buttonCopyMacroContent_Click(object sender, EventArgs e)
        {
            if (richTextBoxMacroContent.Text != string.Empty)
            {
                Clipboard.SetText(richTextBoxMacroContent.Text);

                MessageBox.Show("Content copied to clipboard!", "Macro Generator", MessageBoxButtons.OK);
            }
        }

        #region Private Methods - Macro Generator Tab

        private void PopulateMacroList()
        {
            listBoxDefaultMacros.Items.Clear();

            _childMacroList.Clear();

            foreach(KeyValuePair<string, DefaultBinding> binding in _inputManager.DefaultBindingList)
            {
                if (binding.Value.Macro != null)
                {
                    _childMacroList.Add(binding.Value.BindingName, binding.Value.Macro);
                }
            }

            foreach (string s in _childMacroList.Keys)
            {
                listBoxDefaultMacros.Items.Add(s);
            }
        }

        private void PopulateMacroData(InGameMacro macro, Keys bindingKey)
        {
            textBoxMacroName.Text = macro.Name;
            richTextBoxMacroContent.Text = macro.Content;
            labelShouldBeBoundToText.Text = "Should be bound to: ";
            labelShouldBeBoundToKey.Text = bindingKey.ToString();
        }

        #endregion Private Methods - Macro Generator Tab

        #endregion MACRO GENERATOR TAB

        #region GAME WINDOW TAB

        private Dictionary<WoWClient, Panel> gameWindowPanels = new Dictionary<WoWClient, Panel>();
        private bool isDragging = false;
        private Point dragStart;
        private Panel selectedPanel = null;
        private bool isResizing = false;

        private void WindowTab_PopulateGameWindowVisualizers()
        {
            gameWindowPanels.Clear();
            panelScreenVisualizer.Controls.Clear();

            foreach (WoWClient client in InputManager.ProcManager.GameClientList)
            {
                AddWindowBox(client, client.GameTitle);
            }
        }

        private void AddWindowBox(WoWClient gameClient, string title)
        {
            // Create the main panel representing the window
            Panel windowPanel = new Panel
            {
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(200, 100),
                Tag = title
            };

            // Add a title label
            Label titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Height = 20
            };

            // Add a bottom-right corner indicator for resizing
            Label resizeGrip = new Label
            {
                BackColor = Color.Gray,
                Size = new Size(10, 10),
                Location = new Point(windowPanel.Width - 10, windowPanel.Height - 10), // Position at bottom-right
                Cursor = Cursors.SizeNWSE
            };

            // Adjust position dynamically when panel resizes
            resizeGrip.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Add mouse event handlers for resizing
            resizeGrip.MouseDown += ResizeGrip_MouseDown;
            resizeGrip.MouseMove += ResizeGrip_MouseMove;
            resizeGrip.MouseUp += ResizeGrip_MouseUp;

            // Add controls to the main panel
            windowPanel.Controls.Add(titleLabel);
            windowPanel.Controls.Add(resizeGrip);

            // Add drag events for the main panel
            windowPanel.MouseDown += WindowPanel_MouseDown;
            windowPanel.MouseMove += WindowPanel_MouseMove;
            windowPanel.MouseUp += WindowPanel_MouseUp;

            // Add the window panel to the workspace
            panelScreenVisualizer.Controls.Add(windowPanel);
            gameWindowPanels.Add(gameClient, windowPanel);
        }

        private Point resizeStart; // Initial cursor position during resize

        private void ResizeGrip_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Label grip)
            {
                selectedPanel = grip.Parent as Panel;
                resizeStart = e.Location;
                isResizing = true;
            }
        }

        private void ResizeGrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing && selectedPanel != null)
            {
                // Calculate the new size based on cursor movement
                int newWidth = selectedPanel.Width + (e.X - resizeStart.X);
                int newHeight = selectedPanel.Height + (e.Y - resizeStart.Y);

                // Clamp size to stay within parent panel and maintain minimum size
                newWidth = Math.Max(50, Math.Min(newWidth, panelScreenVisualizer.Width - selectedPanel.Location.X));
                newHeight = Math.Max(50, Math.Min(newHeight, panelScreenVisualizer.Height - selectedPanel.Location.Y));

                selectedPanel.Size = new Size(newWidth, newHeight);
            }
        }

        private void ResizeGrip_MouseUp(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                isResizing = false;
                selectedPanel = null;
            }
        }

        private void WindowPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && !isResizing)
            {
                selectedPanel = panel;
                dragStart = e.Location;
                isDragging = true;
            }
        }

        private void WindowPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedPanel != null)
            {
                // Dragging logic
                Point newLocation = selectedPanel.Location;
                newLocation.Offset(e.X - dragStart.X, e.Y - dragStart.Y);

                // Restrict movement within parent panel bounds
                newLocation.X = Math.Max(0, Math.Min(newLocation.X, panelScreenVisualizer.Width - selectedPanel.Width));
                newLocation.Y = Math.Max(0, Math.Min(newLocation.Y, panelScreenVisualizer.Height - selectedPanel.Height));

                selectedPanel.Location = newLocation;
            }
        }

        private void WindowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                selectedPanel = null;
            }
        }

        private void buttonResizeWindows_Click(object sender, EventArgs e)
        {
            // Get the monitor's resolution (primary screen)
            int monitorWidth = Screen.PrimaryScreen.Bounds.Width;
            int monitorHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calculate scaling factors
            float scaleX = (float)monitorWidth / panelScreenVisualizer.Width;
            float scaleY = (float)monitorHeight / panelScreenVisualizer.Height;

            foreach (KeyValuePair<WoWClient, Panel> gWindow in gameWindowPanels)
            {
                // Get the panel's current position and size
                int panelX = gWindow.Value.Location.X;
                int panelY = gWindow.Value.Location.Y;
                int panelWidth = gWindow.Value.Size.Width;
                int panelHeight = gWindow.Value.Size.Height;

                // Scale position and size to match the monitor's resolution
                int scaledX = (int)(panelX * scaleX);
                int scaledY = (int)(panelY * scaleY);
                int scaledWidth = (int)(panelWidth * scaleX);
                int scaledHeight = (int)(panelHeight * scaleY);

                // Resize and reposition the game window
                WindowUtil.MoveAndResizeWindow(gWindow.Key.GameProcess, scaledX, scaledY, scaledWidth, scaledHeight);
            }


        }

        #endregion
        #region SETTINGS TAB

        private void buttonSelectGameLocation_Click(object sender, EventArgs e)
        {
            openFileDialogSelectWowInstallLocation.ShowDialog();
        }

        private void openFileDialogSelectWowInstallLocation_FileOk(object sender, CancelEventArgs e)
        {
            textBoxWowInstallLocation.Text = openFileDialogSelectWowInstallLocation.FileName;
            _configManager.SaveWowInstallPath(textBoxWowInstallLocation.Text);
        }

        #endregion
    }
}
