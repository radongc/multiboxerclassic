using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiboxer
{
    class ConfigurationManager
    {
        /* ConfigurationManager
         * Handles loading, saving, and config condition checking. */

        private ConsoleWriter consoleWriter;
        
        public string ConfigFilePath { get; }
        public ToolStripStatusLabel MainStatusLabel { get; private set; }

        public enum LogType
        {
            MESSAGE,
            DEBUG,
            ERROR
        }

        public ConfigurationManager(string cfgFilePath, ToolStripStatusLabel mainStatusLabel)
        {
            MainStatusLabel = mainStatusLabel;
            ConfigFilePath = cfgFilePath;
        }

        public bool IsFirstRun()
        {
            if (File.Exists(ConfigFilePath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetConsoleWriter(ConsoleWriter writer) => consoleWriter = writer;

        public void UpdateStatus(string text, LogType logType) // Use UpdateStatus if you want the statusbar and the console to log. Use DebugLog if you only want the message to be logged to the console
        {
            Color newColor;

            switch (logType)
            {
                case LogType.DEBUG:
                    newColor = Color.YellowGreen;
                    break;

                case LogType.MESSAGE:
                    newColor = Color.Blue;
                    break;

                case LogType.ERROR:
                    newColor = Color.Red;
                    break;

                default:
                    newColor = Color.White;
                    break;
            }

            MainStatusLabel.ForeColor = newColor;
            MainStatusLabel.Text = text;

            if (consoleWriter != null)
            {
                consoleWriter.DebugLog(text, logType);
            }
        }

        // Save config file

        public void SaveToConfig(string[] contents)
        {
            string[] cfgContent = new string[contents.Length];

            int i = 0;

            foreach (string line in contents)
            {
                cfgContent[i] = line;
                i++;
            }

            WriteToConfig(cfgContent);
        }

        private void WriteToConfig(string[] contents)
        {
            string path = ConfigFilePath;

            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (string line in contents)
                {
                    sw.WriteLine(line);
                }
            }
        }

        // Read config file

        public void LoadFromConfig(RichTextBox rtb)
        {
            string path = ConfigFilePath;

            string[] cfgLines = File.ReadAllLines(path);

            int i = 0;

            foreach (string line in cfgLines)
            {
                if (i == (cfgLines.Length - 1))
                {
                    rtb.AppendText(cfgLines[i]);
                    i++;
                }
                else
                {
                    rtb.AppendText(cfgLines[i] + "\n");
                    i++;
                }
            }
        }

        public class ConsoleWriter : TextWriter
        {
            private RichTextBox _myControl;

            public bool LogMessages { get; set; }
            public bool LogDebugs { get; set; }
            public bool LogErrors { get; set; }

            public ConsoleWriter(RichTextBox control, bool logMessages, bool logDebugs, bool logErrors)
            {
                _myControl = control;

                LogMessages = logMessages;
                LogDebugs = logDebugs;
                LogErrors = logErrors;
            }

            public override void Write(char value)
            {
                _myControl.AppendText(value.ToString() + "\n");
            }

            public override void Write(string value)
            {
                _myControl.AppendText($"[{DateTime.Now.ToLocalTime()}] {value}\n");
            }

            public override Encoding Encoding
            {
                get => Encoding.Unicode;
            }

            public void DebugLog(string text, LogType logType)
            {
                Color newColor;
                string prefix;

                switch (logType)
                {
                    case LogType.DEBUG:
                        if (LogDebugs)
                        {
                            newColor = Color.YellowGreen;
                            prefix = "[DEBUG]";
                        }
                        else
                        {
                            return;
                        }
                        break;

                    case LogType.MESSAGE:
                        if (LogMessages)
                        {
                            newColor = Color.Blue;
                            prefix = "[MESSAGE]";
                        }
                        else
                        {
                            return;
                        }
                        break;

                    case LogType.ERROR:
                        if (LogErrors)
                        {
                            newColor = Color.Red;
                            prefix = "[ERROR]";
                        }
                        else
                        {
                            return;
                        }
                        break;

                    default:
                        newColor = Color.Black;
                        prefix = "";
                        break;
                }

                _myControl.SelectionColor = newColor;
                Console.Write($"{prefix} {text}");
            }
        }
    }
}
