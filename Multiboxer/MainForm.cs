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

        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

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
    }
}
