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
         * Find out a way to make DebugLog and UpdateStatus linked 
         * Find out a way to make DebugLog instance accessible from all classes
         * Create a hotkey for starting/stopping multiboxing that is customizable
         * Add more/better UI elements such as tab control for settings
         * Test out hotkey creator that can send commands to window such as:
         * <Press Enter><Type "/script AcceptGroup"> etc. and possibly look at creating an addon for simpler macros, such as "/mb p a" for accepting group
         * Figure out how to send complex keystrokes to windows, such as shift-4 (DONE)
         * Re-make blacklist with better options and pressing keys to add instead of manually typing out names
         * Blacklist options: 
         * Blacklist profiles, ability to enable/disable profiles, ability to create whitelist instead of blacklist
         * Mouse broadcasting? */

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

            input.ProcManager.RefreshGameProcessList();

            PopulateClientList();

            config.UpdateStatus($"Found {input.ProcManager.GameProcessList.Length} process(es).", ConfigurationManager.LogType.MESSAGE);
        }

        private void InitializeClasses()
        {
            // Init input callbacks and config manager
            input = new InputCallback();
            config = new ConfigurationManager("config.cfg", toolStripStatusLabel_Status);
            consoleWriterMain = new ConfigurationManager.ConsoleWriter(richTextBox_MainDebugConsole);

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
                    MessageBox.Show(GUIStringLibrary.ErrorText.MasterClient, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                input.ProcManager.SetMasterClient(procData[0], Convert.ToInt32(procData[1]));

                config.UpdateStatus($"Set master client to {procData[0]} - {procData[1]}", ConfigurationManager.LogType.MESSAGE);
            }
            catch (Exception b)
            {
                consoleWriterMain.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        private void button_MasterClientListHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GUIStringLibrary.HelpText.MasterClient, "Master Client Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button_RefreshClients_Click(object sender, EventArgs e)
        {
            input.ProcManager.RefreshGameProcessList();

            PopulateClientList();

            config.UpdateStatus($"Found {input.ProcManager.GameProcessList.Length} process(es).", ConfigurationManager.LogType.MESSAGE);
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
            MessageBox.Show(GUIStringLibrary.HelpText.IgnoreList, "Ignore List Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void checkBox_EnableIgnoreList_CheckedChanged(object sender, EventArgs e)
        {
            input.ProcManager.SetIgnoreListEnabled(checkBox_EnableIgnoreList.Checked);
        }

        private void checkBox_Blacklist_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Blacklist.Checked)
            {
                if (checkBox_Whitelist.Checked)
                {
                    checkBox_Whitelist.CheckState = CheckState.Unchecked;
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
                }

                input.ProcManager.SetIgnoreListType(ProcessManager.IgnoreType.WHITELIST);
            }

            if (!checkBox_Blacklist.Checked && !checkBox_Whitelist.Checked)
            {
                checkBox_Whitelist.CheckState = CheckState.Checked;
            }
        }
        #endregion Ignore List Event Handlers

        #region Log Option Event Handlers
        private void checkBox_LogMessages_CheckedChanged(object sender, EventArgs e) => consoleWriterMain.LogMessages = checkBox_LogMessages.Checked;

        private void checkBox_LogDebug_CheckedChanged(object sender, EventArgs e) => consoleWriterMain.LogDebugs = checkBox_LogDebugs.Checked;

        private void checkBox_LogError_CheckedChanged(object sender, EventArgs e) => consoleWriterMain.LogErrors = checkBox_LogErrors.Checked;
        #endregion Log Option Event Handlers

        // Private methods

        private void PopulateClientList()
        {
            listBox_SelectMasterClient.Items.Clear();

            foreach (Process p in input.ProcManager.GameProcessList)
            {
                listBox_SelectMasterClient.Items.Add($"{p.ProcessName} - {p.Id}");
            }
        }
    }
}
