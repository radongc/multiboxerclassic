﻿/*
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
using Jupiter;

namespace Multiboxer
{
    public class WoWClient
    {
        public static int CurrentGameNum; // set in ProcessManager.RefreshClientProcList()

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

                WindowInit();
            }
            catch (Exception b)
            {
                //
            }
        }

        private void WindowInit()
        {
/*            if (GameProcess.MainWindowTitle == "World of Warcraft")
            {
                WindowUtil.RenameWindow(GameProcess, "Game " + CurrentGameNum);
                CurrentGameNum++;
            }*/
        }
    }
}