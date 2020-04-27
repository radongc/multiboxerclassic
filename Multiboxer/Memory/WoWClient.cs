using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Jupiter;

namespace Multiboxer
{
    public class WoWClient
    {
        // Properties
        public Process GameProcess { get; private set; }

        // Constructors

        public WoWClient()
        {
            GameProcess = null;
        }

        public WoWClient(int procId)
        {
            SetClient(procId);
        }

        // Mutators

        public void SetClient(int procId)
        {
            try
            {
                Process client = Process.GetProcessById(procId);

                GameProcess = client;
            }
            catch (Exception b)
            {
                //
            }
        }
    }
}