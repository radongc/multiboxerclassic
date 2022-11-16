/*
    Multiboxer Classic (c) by Radon (https://github.com/radongc)

    Multiboxer Classic is licensed under a
    Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

    You should have received a copy of the license along with this
    work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Multiboxer
{
    class ProcessManager
    {
        /* ProcessManager
         * Handles most all functions having to do with process manipulation. 
         * Keeps track of master client, client list, key ignores etc.*/

        // Fields

        private readonly string _gameProcessNamePartial = "WowClassic";
        private readonly string _gameProcessNameLegacyPartial = "WoW";

        private ConfigurationManager.ConsoleWriter consoleWriter;

        // Properties

        public WoWClient MasterClient { get; private set; }
        public WoWClient[] GameClientList { get; private set; }
        public Process[] GameProcList { get; private set; }
        public Keys[] IgnoredKeys { get; private set; }
        public IgnoreType IgnoreListType { get; private set; }
        public bool IgnoreListEnabled { get; private set; }

        public enum IgnoreType
        {
            BLACKLIST,
            WHITELIST
        }

        // Constructor
        public ProcessManager()
        {
            RefreshClientProcList();

            // default settings
            IgnoreListEnabled = true;
            IgnoreListType = IgnoreType.BLACKLIST;
        }

        // Mutators (not simple mutators, more of methods that select the value)

        public void SetConsoleWriter(ConfigurationManager.ConsoleWriter writer)
        {
            consoleWriter = writer;
        }

        public void SetMasterClient(int procId) // using this to test what memory i'm reading, ie. how to read memory
        {
            Process master = Process.GetProcessById(procId);

            MasterClient = new WoWClient(master.Id);

            consoleWriter.Clear();

            consoleWriter.DebugLog($"Set master client to {MasterClient.GameProcess.ProcessName} - {procId}", ConfigurationManager.LogType.MESSAGE);
        }

        public void SetIgnoredKeys(RichTextBox rtb)
        {
            try
            {
                if (rtb.Lines.Length > 0) // avoiding exceptions
                {
                    if (!rtb.Lines[rtb.Lines.Length - 1].ToString().Equals("")) // avoiding exceptions
                    {
                        IgnoredKeys = new Keys[rtb.Lines.Length];

                        int j = 0;

                        foreach (string line in rtb.Lines)
                        {
                            try
                            {
                                string formatLine = line.Replace("\n", "");

                                IgnoredKeys[j] = (Keys)Enum.Parse(typeof(Keys), formatLine, false);
                                j++;
                            }
                            catch (Exception b) // TODO add error handling/logging
                            {
                                consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
                                break;
                            }
                        }

                        consoleWriter.DebugLog("Saved IgnoreList:", ConfigurationManager.LogType.CONFIG);

                        for (int i = 0; i < IgnoredKeys.Length; i++)
                        {
                            consoleWriter.DebugLog(IgnoredKeys[i].ToString(), ConfigurationManager.LogType.CONFIG);
                        }
                    }
                }
                else
                {
                    IgnoredKeys = new Keys[0];
                }
            }
            catch (Exception b)
            {
                consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }

        public void SetIgnoreListType(IgnoreType type) => IgnoreListType = type;

        public void SetIgnoreListEnabled(bool value) => IgnoreListEnabled = value;

        // Public methods

        public void RefreshClientProcList()
        {
            try
            {
                WoWClient.CurrentGameNum = 1; // make sure it doesnt keep renaming windows higher and higher

                Process[] procs = Process.GetProcesses();

                int i = 0;

                foreach (Process p in procs)
                {
                    if (p.ProcessName.Contains(_gameProcessNamePartial) || p.ProcessName.Contains(_gameProcessNameLegacyPartial))
                    {
                        i++;
                    }
                }

                WoWClient[] tempClientList = new WoWClient[i];

                int j = 0;

                foreach (Process p in procs)
                {
                    if (j >= i)
                    {
                        break;
                    }

                    if (p.ProcessName.Contains(_gameProcessNamePartial) || p.ProcessName.Contains(_gameProcessNameLegacyPartial))
                    {
                        tempClientList[j] = new WoWClient(p.Id);
                        j++;
                    }
                }

                Process[] tempProcList = new Process[tempClientList.Length];

                int y = 0;

                foreach (WoWClient c in tempClientList)
                {
                    if (y >= j)
                    {
                        break;
                    }

                    tempProcList[y] = tempClientList[y].GameProcess;
                    y++;
                }

                GameProcList = tempProcList;
                GameClientList = tempClientList;
            }
            catch (Exception b)
            {
                consoleWriter.DebugLog(b.ToString(), ConfigurationManager.LogType.ERROR);
            }
        }
    }
}
