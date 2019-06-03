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

        // Properties

        private readonly string _gameProcessNamePartial = "WoW";

        // Constructor
        public ProcessManager()
        {
            RefreshGameProcessList();
        }

        // Accessors

        public Process MasterClient { get; private set; }

        public Process[] GameProcessList { get; private set; }

        public Keys[] IgnoredKeys { get; private set; }

        // Mutators (not simple mutators, more of methods that select the value)

        public void SetMasterClient(string procName, int procId)
        {
            Process[] clients = Process.GetProcessesByName(procName);

            Console.WriteLine(clients.Length);

            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i].Id == procId)
                {
                    MasterClient = clients[i];

                    Console.WriteLine($"Set Master Client to ProcID {clients[i].Id}");
                }
            }
        }

        public void SetIgnoredKeys(RichTextBox rtb)
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
                            MessageBox.Show(b.ToString());
                            break;
                        }
                    }

                    for (int i = 0; i < IgnoredKeys.Length; i++)
                    {
                        Console.WriteLine(IgnoredKeys[i]);
                    }
                }
            }
            else
            {
                IgnoredKeys = new Keys[0];
            }
        }

        // Public methods

        public void RefreshGameProcessList()
        {
            Process[] procs = Process.GetProcesses();

            int i = 0;

            foreach (Process p in procs)
            {
                if (p.ProcessName.Contains(_gameProcessNamePartial))
                {
                    i++;
                }
            }

            Process[] tempProcList = new Process[i];

            int j = 0;

            foreach (Process p in procs)
            {
                if (j >= i)
                {
                    break;
                }

                if (p.ProcessName.Contains(_gameProcessNamePartial))
                {
                    tempProcList[j] = p;
                    j++;
                }
            }

            GameProcessList = tempProcList;
        }
    }
}
