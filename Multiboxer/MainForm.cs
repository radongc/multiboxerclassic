using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            input = new InputCallback();
        }

        private void button_StartMultiboxing_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                input.Subscribe();

                button_StartMultiboxing.Text = "Stop Multiboxing";
            }
            else if (isListening)
            {
                input.Unsubscribe();

                button_StartMultiboxing.Text = "Start Multiboxing";
            }

            isListening = !isListening;
        }

        private void listBox_SelectMasterClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            string procDataUnformatted = listBox_SelectMasterClient.SelectedItem.ToString();

            string procDataFormatted = procDataUnformatted.Replace(" ", "");

            string[] procData = procDataFormatted.Split('-');

            input.ProcManager.SetMasterClient(procData[0], Convert.ToInt32(procData[1]));
        }

        private void button_RefreshClients_Click(object sender, EventArgs e)
        {
            input.ProcManager.RefreshGameProcessList();

            PopulateClientList();
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
            MessageBox.Show(GUIStringLibrary.IgnoreListHelpText, "Ignore List Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button_SaveIgnoreList_Click(object sender, EventArgs e)
        {
            input.ProcManager.SetIgnoredKeys(richTextBox_IgnoreList);
        }
    }
}
