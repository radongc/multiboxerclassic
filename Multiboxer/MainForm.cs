using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Multiboxer
{
    public partial class MainForm : Form
    {
        bool isListening = false; // is the program listening for input?

        private InputCallback input;
        private ConfigurationManager config;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Init input callbacks and config manager

            input = new InputCallback();
            config = new ConfigurationManager("config.cfg", toolStripStatusLabel_Status);

            if (!config.IsFirstRun())
            {
                config.LoadFromConfig(richTextBox_IgnoreList); // load into ignore list from cfg
                input.ProcManager.SetIgnoredKeys(richTextBox_IgnoreList); // save ignore list
            }

            // Check for running wow procs and populate the GUI list

            input.ProcManager.RefreshGameProcessList();

            PopulateClientList();

            config.UpdateStatus($"Found {input.ProcManager.GameProcessList.Length} process(es).", Color.ForestGreen);
        }

        private void button_StartMultiboxing_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                input.Subscribe();

                button_StartMultiboxing.Text = "Stop Multiboxing";

                config.UpdateStatus($"Multiboxing started.", Color.ForestGreen);
            }
            else if (isListening)
            {
                input.Unsubscribe();

                button_StartMultiboxing.Text = "Start Multiboxing";

                config.UpdateStatus($"Multiboxing stopped.", Color.ForestGreen);
            }

            isListening = !isListening;
        }

        private void listBox_SelectMasterClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            string procDataUnformatted = listBox_SelectMasterClient.SelectedItem.ToString();

            string procDataFormatted = procDataUnformatted.Replace(" ", "");

            string[] procData = procDataFormatted.Split('-');

            input.ProcManager.SetMasterClient(procData[0], Convert.ToInt32(procData[1]));

            config.UpdateStatus($"Set master client to {procData[0]} - {procData[1]}", Color.ForestGreen);
        }

        private void button_RefreshClients_Click(object sender, EventArgs e)
        {
            input.ProcManager.RefreshGameProcessList();

            PopulateClientList();

            config.UpdateStatus($"Found {input.ProcManager.GameProcessList.Length} process(es).", Color.ForestGreen);
        }

        private void PopulateClientList()
        {
            listBox_SelectMasterClient.Items.Clear();

            foreach (Process p in input.ProcManager.GameProcessList)
            {
                listBox_SelectMasterClient.Items.Add($"{p.ProcessName} - {p.Id}");
            }
        }

        private void button_IgnoreListHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GUIStringLibrary.HelpText.IgnoreList, "Ignore List Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button_SaveIgnoreList_Click(object sender, EventArgs e)
        {
            input.ProcManager.SetIgnoredKeys(richTextBox_IgnoreList);

            config.SaveToConfig(richTextBox_IgnoreList.Lines);

            config.UpdateStatus($"Saved IgnoreList to config file successfully.", Color.ForestGreen);
        }
    }
}
