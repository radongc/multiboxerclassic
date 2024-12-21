/*
    Multiboxer Classic (c) by Radon (https://github.com/radongc)

    Multiboxer Classic is licensed under a
    Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

    You should have received a copy of the license along with this
    work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Multiboxer
{
    class ConfigurationManager
    {
        /* ConfigurationManager
         * Handles loading, saving, and config condition checking. */

        private ConsoleWriter consoleWriter;

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

        public class GameWindowConfig
        {
            public int PosX { get; set; }
            public int PosY { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
        }

        public class Configuration
        {
            public string WowInstallPath { get; set; }
            public List<string> IgnoreList { get; set; } = new List<string>();
            public List<GameWindowConfig> GameWindowConfigs { get; set; } = new List<GameWindowConfig>();
        }

        public Configuration CurrentConfig { get; private set; } = new Configuration();

        public ConfigurationManager(string cfgFilePath, ToolStripStatusLabel mainStatusLabel)
        {
            ConfigFilePath = cfgFilePath;
            MainStatusLabel = mainStatusLabel;

            if (File.Exists(ConfigFilePath))
            {
                LoadConfig();
            }
            else
            {
                SaveConfig();
            }
        }

        public void SetConsoleWriter(ConsoleWriter writer) => consoleWriter = writer;

        public void UpdateStatus(string text, LogType logType)
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

            consoleWriter?.DebugLog(text, logType);
        }

        public bool IsFirstRun() => !File.Exists(ConfigFilePath);

        public void SaveConfig()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(ConfigFilePath, JsonSerializer.Serialize(CurrentConfig, options));
            UpdateStatus("Configuration saved.", LogType.CONFIG);
        }

        public void LoadConfig()
        {
            try
            {
                string json = File.ReadAllText(ConfigFilePath);
                CurrentConfig = JsonSerializer.Deserialize<Configuration>(json) ?? new Configuration();
                UpdateStatus("Configuration loaded.", LogType.CONFIG);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Failed to load configuration: {ex.Message}", LogType.ERROR);
            }
        }

        public void SaveWowInstallPath(string path)
        {
            CurrentConfig.WowInstallPath = path;
            SaveConfig();
        }

        public void SaveIgnoreList(List<string> ignoreList)
        {
            CurrentConfig.IgnoreList = ignoreList;
            SaveConfig();
        }

        public void SaveWindowConfigs(Dictionary<WoWClient, Panel> windows)
        {
            CurrentConfig.GameWindowConfigs.Clear();

            foreach (KeyValuePair<WoWClient, Panel> gWindow in windows)
            {
                CurrentConfig.GameWindowConfigs.Add(new ConfigurationManager.GameWindowConfig() { PosX = gWindow.Value.Location.X, PosY = gWindow.Value.Location.Y, Width = gWindow.Value.Size.Width, Height = gWindow.Value.Size.Height });
            }
            
            SaveConfig();
        }

        public void LoadIgnoreListToRichTextBox(RichTextBox rtb)
        {
            rtb.Clear();
            foreach (string item in CurrentConfig.IgnoreList)
            {
                rtb.AppendText(item + "\n");
            }
        }

        public class ConsoleWriter : TextWriter
        {
            private readonly RichTextBox _myRtb;
            private readonly string _logFilePath;

            public string LogDirectoryPath { get; }
            public bool LogMessages { get; set; }
            public bool LogDebugs { get; set; }
            public bool LogErrors { get; set; }

            public ConsoleWriter(RichTextBox control, string logDirPath, bool logMessages, bool logDebugs, bool logErrors)
            {
                _myRtb = control;
                LogDirectoryPath = logDirPath;
                _logFilePath = Path.Combine(LogDirectoryPath, $"{DateTime.Now:MM-dd-yyyy}.log");

                LogMessages = logMessages;
                LogDebugs = logDebugs;
                LogErrors = logErrors;

                InitDirectories();
            }

            private void InitDirectories()
            {
                if (!Directory.Exists(LogDirectoryPath))
                {
                    Directory.CreateDirectory(LogDirectoryPath);
                }

                File.AppendAllText(_logFilePath, "----------START OF NEW SESSION----------\n");
            }

            public override void Write(char value)
            {
                _myRtb.AppendText(value.ToString());
            }

            public override void Write(string value)
            {
                string logText = $"[{DateTime.Now}] {value}\n";
                _myRtb.AppendText(logText);
                File.AppendAllText(_logFilePath, logText);
            }

            public override Encoding Encoding => Encoding.Unicode;

            public void DebugLog(string text, LogType logType)
            {
                Color newColor;
                string prefix;

                switch (logType)
                {
                    case LogType.MESSAGE:
                        if (!LogMessages) return;
                        newColor = Color.Blue;
                        prefix = "[MESSAGE]";
                        break;
                    case LogType.DEBUG:
                        if (!LogDebugs) return;
                        newColor = Color.YellowGreen;
                        prefix = "[DEBUG]";
                        break;
                    case LogType.CONFIG:
                        if (!LogDebugs) return;
                        newColor = Color.DarkGreen;
                        prefix = "[CONFIG]";
                        break;
                    case LogType.ERROR:
                        if (!LogErrors) return;
                        newColor = Color.Red;
                        prefix = "[ERROR]";
                        break;
                    default:
                        newColor = Color.Black;
                        prefix = "";
                        break;
                }

                _myRtb.SelectionColor = newColor;
                _myRtb.AppendText($"{prefix} {text}\n");
            }

            public void Clear()
            {
                _myRtb.Clear();
            }
        }
    }
}
