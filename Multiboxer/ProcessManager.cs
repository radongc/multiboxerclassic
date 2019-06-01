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

        public Keys[] IgnoredKeys { get; }

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
            int i = 0;

            foreach(string line in rtb.Lines)
            {
                try
                {
                    IgnoredKeys[i] = (Keys)Enum.Parse(typeof(Keys), line, true);
                    i++;
                }
                catch (Exception b) // TODO add error handling/logging
                {
                    MessageBox.Show(b.ToString());
                    break;
                }
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
