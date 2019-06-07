using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Multiboxer
{
    public partial class MainForm : Form
    {
        bool isListening = false; // is the program listening for input?

        private InputCallback input;
        private ConfigurationManager config;
        private ConfigurationManager.ConsoleWriter consoleWriterMain;

        /* TODO NEXT *
         * Find out a way to make DebugLog and UpdateStatus linked  (DONE)
         * Find out a way to make DebugLog instance accessible from all classes (SEMI-DONE) (P3)
         * Make Master Client selector show the character name (read memory) (DONE)
         * Create a hotkey for starting/stopping multiboxing that is customizable (P1)
         * Add more/better UI elements such as tab control for settings (P2)
         * Test out hotkey creator that can send commands to window such as: (P3)
         * <Press Enter><Type "/script AcceptGroup"> etc. and possibly look at creating an addon for simpler macros, such as "/mb p a" for accepting group
         * Figure out how to send complex keystrokes to windows, such as shift-4 (DONE)
         * Re-make blacklist with better options and pressing keys to add instead of manually typing out names (P2)
         * Blacklist options: (P1)
         * Blacklist profiles, ability to enable/disable profiles, ability to create whitelist instead of blacklist
         * Mouse broadcasting? (P4) */

        #region Initialization
        public MainForm()
        {
            InitializeComponent();
        }

        // Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Init input callbacks and config manager
            InitializeClasses();

            if (!config.IsFirstRun())
            {
                config.LoadFromConfig(richTextBox_IgnoreList); // load into ignore list from cfg
                input.ProcManager.SetIgnoredKeys(richTextBox_IgnoreList); // save ignore list
            }

            Console.SetOut(consoleWriterMain); // route console output to debug window

            // Check for running wow procs and populate the GUI list

            input.ProcManager.RefreshClientProcList();

            PopulateClientList();

            config.UpdateStatus($"Found {input.ProcManager.GameProcList.Length} process(es).", ConfigurationManager.LogType.MESSAGE);
        }

        private void InitializeClasses()
        {
            // Init input callbacks and config manager
            input = new InputCallback();
            config = new ConfigurationManager("config.cfg", toolStripStatusLabel_Status);
            consoleWriterMain = new ConfigurationManager.ConsoleWriter(richTextBox_MainDebugConsole, checkBox_LogMessages.Checked, checkBox_LogDebugs.Checked, checkBox_LogErrors.Checked);

            input.ProcManager.SetConsoleWriter(consoleWriterMain); // allow procManager to write to console
            config.SetConsoleWriter(consoleWriterMain);
            WindowUtil.SetConsoleWriter(consoleWriterMain);
        }
        #endregion Initialization

        #region Multiboxing Status (start/stop) Event Handlers
        private void button_StartMultiboxing_Click(object sender, EventArgs e)
        {
            bool errorOccurred = false;

            if (!isListening)
            {
                if (input.ProcManager.MasterClient == null) // error checking
                {
                    errorOccurred = true;
                    MessageBox.Show(GUIContent.ErrorText.MasterClient, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    input.Subscribe();

                    button_StartMultiboxing.Text = "Stop Multiboxing";

                    config.UpdateStatus($"Multiboxing started.", ConfigurationManager.LogType.MESSAGE);
                }
            }
            else if (isListening)
            {
                input.Unsubscribe();

                button_StartMultiboxing.Text = "Start Multiboxing";

                config.UpdateStatus($"Multiboxing stopped.", ConfigurationManager.LogType.MESSAGE);
            }

            if (!errorOccurred)
            {
                isListening = !isListening;
            }
        }
        #endregion Multiboxing Status (start/stop) Event Handlers

        #region Master Client Event Handlers
        private void listBox_SelectMasterClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string procDataUnformatted = listBox_SelectMasterClient.SelectedItem.ToString();

                string procDataFormatted = procDataUnformatted.Replace(" ", "");

                string[] procData = procDataFormatted.Split('-');

                input.ProcManager.SetMasterClient(Convert.ToInt32(procData[1]));

                config.UpdateStatus($"Set master client to {procData[0]} - {procData[1]}", ConfigurationManager.LogType.MESSAGE);
            }
            catch (Exception b)
            {
                consoleWriterMain.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        private void button_MasterClientListHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GUIContent.HelpText.MasterClient, "Master Client Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button_RefreshClients_Click(object sender, EventArgs e)
        {
            input.ProcManager.RefreshClientProcList();

            PopulateClientList();

            config.UpdateStatus($"Found {input.ProcManager.GameProcList.Length} process(es).", ConfigurationManager.LogType.MESSAGE);
        }
        #endregion Master Client Event Handlers

        #region Ignore List Event Handlers
        private void button_SaveIgnoreList_Click(object sender, EventArgs e)
        {
            input.ProcManager.SetIgnoredKeys(richTextBox_IgnoreList);

            config.SaveToConfig(richTextBox_IgnoreList.Lines);

            config.UpdateStatus($"Saved IgnoreList to config file successfully.", ConfigurationManager.LogType.MESSAGE);
        }

        private void button_IgnoreListHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GUIContent.HelpText.IgnoreList, "Ignore List Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void checkBox_EnableIgnoreList_CheckedChanged(object sender, EventArgs e)
        {
            input.ProcManager.SetIgnoreListEnabled(checkBox_EnableIgnoreList.Checked);

            switch(checkBox_EnableIgnoreList.Checked)
            {
                case true:
                    config.UpdateStatus("IgnoreList enabled.", ConfigurationManager.LogType.MESSAGE);
                    break;

                case false:
                    config.UpdateStatus("IgnoreList disabled.", ConfigurationManager.LogType.MESSAGE);
                    break;
            }
        }

        private void checkBox_Blacklist_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Blacklist.Checked)
            {
                if (checkBox_Whitelist.Checked)
                {
                    checkBox_Whitelist.CheckState = CheckState.Unchecked;
                    config.UpdateStatus("IgnoreList setting changed to blacklist.", ConfigurationManager.LogType.MESSAGE); // needs to be put here to avoid being sent every time it is clicked, even if setting is not actually changing
                }

                input.ProcManager.SetIgnoreListType(ProcessManager.IgnoreType.BLACKLIST);
            }

            if (!checkBox_Blacklist.Checked && !checkBox_Whitelist.Checked)
            {
                checkBox_Blacklist.CheckState = CheckState.Checked;
            }
        }

        private void checkBox_Whitelist_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Whitelist.Checked)
            {
                if (checkBox_Blacklist.Checked)
                {
                    checkBox_Blacklist.CheckState = CheckState.Unchecked;
                    config.UpdateStatus("IgnoreList setting changed to whitelist.", ConfigurationManager.LogType.MESSAGE); // needs to be put here to avoid being sent every time it is clicked, even if setting is not actually changing
                }

                input.ProcManager.SetIgnoreListType(ProcessManager.IgnoreType.WHITELIST);
            }

            if (!checkBox_Blacklist.Checked && !checkBox_Whitelist.Checked)
            {
                checkBox_Whitelist.CheckState = CheckState.Checked;
            }
        }
        #endregion Ignore List Event Handlers

        #region Main Console Event Handlers
        private void checkBox_LogMessages_CheckedChanged(object sender, EventArgs e) => consoleWriterMain.LogMessages = checkBox_LogMessages.Checked;

        private void checkBox_LogDebug_CheckedChanged(object sender, EventArgs e) => consoleWriterMain.LogDebugs = checkBox_LogDebugs.Checked;

        private void checkBox_LogError_CheckedChanged(object sender, EventArgs e) => consoleWriterMain.LogErrors = checkBox_LogErrors.Checked;

        private void button_ClearConsole_Click(object sender, EventArgs e) => richTextBox_MainDebugConsole.Clear();
        #endregion Main Console Event Handlers

        // Private methods

        private void PopulateClientList()
        {
            listBox_SelectMasterClient.Items.Clear();

            foreach (WoWClient c in input.ProcManager.GameClientList)
            {
                listBox_SelectMasterClient.Items.Add($"{c.Player.Name} - {c.GameProcess.Id}");
            }
        }
    }
}
