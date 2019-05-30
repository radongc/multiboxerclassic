using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.UserActivityMonitor;

namespace Multiboxer
{
    public partial class MainForm : Form
    {
        bool isListening = false; // is the program listening for input?

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button_StartMultiboxing_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                Process[] procs = Process.GetProcesses();

                foreach (Process p in procs)
                {
                    if (p.ProcessName.Contains("WoW"))
                    {
                        //WindowUtil.PostKeyDown(WindowUtil.GetWindow("WoW1"), Keys.W);
                        WindowUtil.PostKey(p.MainWindowHandle, Keys.Oemplus);
                    }
                }

                button_StartMultiboxing.Text = "Stop Multiboxing";
            }
            else if (isListening)
            {
                button_StartMultiboxing.Text = "Start Multiboxing";
            }

            isListening = !isListening;
        }
    }
}
