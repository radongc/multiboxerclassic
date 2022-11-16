﻿using System;
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

        private string _ignoreListStartSequence = ":IGNORELIST:";
        private string _ignoreListEndSequence = ":ENDIGNORELIST:";

        private string _charInfoStartSequence = ":CHARINFO:";
        private string _charInfoEndSequence = ":ENDCHARINFO:";

        private int _currentConfigIndex = 0;

        public string MultiboxerVersion = "0.3.3";

        public string ConfigFilePath { get; }
        public ToolStripStatusLabel MainStatusLabel { get; private set; }

        public enum LogType
        {
            MESSAGE,
            DEBUG,
            CONFIG,
            ERROR
        }

        public ConfigurationManager(string cfgFilePath, ToolStripStatusLabel mainStatusLabel)
        {
            ConfigFilePath = cfgFilePath;
            MainStatusLabel = mainStatusLabel;
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
                case LogType.MESSAGE:
                    newColor = Color.Blue;
                    break;

                case LogType.DEBUG:
                    newColor = Color.YellowGreen;
                    break;

                case LogType.CONFIG:
                    newColor = Color.DarkGreen;
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

        public void SaveIgnoreListToConfig(string[] contents)
        {
            string[] cfgContent = new string[contents.Length + 2];

            cfgContent[0] = _ignoreListStartSequence;

            int i = 1;

            foreach (string line in contents)
            {
                cfgContent[i] = line;
                i++;
            }

            cfgContent[i] = _ignoreListEndSequence;

            _currentConfigIndex += i;

            WriteToConfig(cfgContent);
        }

        public void SaveCharInfoToConfig(string[] contents)
        {
            string[] cfgContent = new string[contents.Length + 2];

            cfgContent[0] = _charInfoStartSequence;

            int i = 1;

            foreach (string line in contents)
            {
                cfgContent[i] = line;
                i++;
            }

            cfgContent[i] = _charInfoEndSequence;

            _currentConfigIndex += i;

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

        public void LoadIgnoreListFromConfig(RichTextBox rtb)
        {
            string path = ConfigFilePath;

            string[] cfgLines = File.ReadAllLines(path);

            List<string> ignoreList = new List<string>();

            int ignoreListStartIndex = 0;
            int ignoreListEndIndex = 0;

            int i = 0;

            foreach (string line in cfgLines)
            {
                if (cfgLines[i] == _ignoreListStartSequence)
                {
                    ignoreListStartIndex = i;
                    break;
                }

                i++;
            }

            int j = 0;

            foreach (string line in cfgLines)
            {
                if (cfgLines[j] == _ignoreListEndSequence)
                {
                    ignoreListEndIndex = j;
                    break;
                }

                j++;
            }

            for (int y = ignoreListStartIndex + 1; y <= ignoreListEndIndex - 1; y++)
            {
                ignoreList.Add(cfgLines[y]);
            }

            int x = 0;

            foreach(string line in ignoreList)
            {
                if (x == (ignoreList.Count - 1))
                {
                    rtb.AppendText(ignoreList[x]);
                    x++;
                }
                else
                {
                    rtb.AppendText(ignoreList[x] + "\n");
                    x++;
                }
            }
        }

        public class ConsoleWriter : TextWriter
        {
            private RichTextBox _myRtb;
            private string _logFilePath;

            public string LogDirectoryPath { get; }

            public bool LogMessages { get; set; }
            public bool LogDebugs { get; set; }
            public bool LogErrors { get; set; }

            public ConsoleWriter(RichTextBox control, string logDirPath, bool logMessages, bool logDebugs, bool logErrors)
            {
                _myRtb = control;

                LogDirectoryPath = logDirPath;
                _logFilePath = $"{LogDirectoryPath}/{DateTime.Now.ToLocalTime().ToString("MM-dd-yyyy")}.log";

                LogMessages = logMessages;
                LogDebugs = logDebugs;
                LogErrors = logErrors;

                InitDirectories();
            }

            public void InitDirectories()
            {
                if (!Directory.Exists(LogDirectoryPath))
                {
                    Directory.CreateDirectory(LogDirectoryPath);
                }

                using (StreamWriter sw = File.AppendText(_logFilePath)) // create & open logfile
                {
                    sw.WriteLineAsync("----------START OF NEW SESSION----------");
                }
            }

            public override void Write(char value)
            {
                _myRtb.AppendText(value.ToString() + "\n");
            }

            public override void Write(string value)
            {
                string logText = $"[{DateTime.Now.ToLocalTime()}] {value}\n";

                _myRtb.AppendText(logText);

                using (StreamWriter sw = File.AppendText(_logFilePath)) // opens log file
                {
                    sw.WriteLineAsync(logText);
                }
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

                    case LogType.CONFIG:
                        if (LogDebugs)
                        {
                            newColor = Color.DarkGreen;
                            prefix = "[CONFIG]";
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

                _myRtb.SelectionColor = newColor;
                Console.Write($"{prefix} {text}");
            }

            public void Clear()
            {
                _myRtb.Clear();
            }
        }
    }
}
