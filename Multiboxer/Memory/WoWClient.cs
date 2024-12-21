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
using Jupiter;

namespace Multiboxer
{
    public class WoWClient
    {
        public static int CurrentGameNum; // set in ProcessManager.RefreshClientProcList()

        // Position settings
        public int WindowPosX { get; private set; }
        public int WindowPosY { get; private set; }

        // Size settings
        public int WindowHeight { get; private set; }
        public int WindowWidth { get; private set; }

        // Properties
        public Process GameProcess { get; private set; }
        public string GameTitle { get; private set; }

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

        public void SetSizeAndPosition(int width, int height, int posX, int posY)
        {
            WindowWidth = width;
            WindowHeight = height;
            WindowPosX = posX;
            WindowPosY = posY;
        }

        public void UpdatePosition()
        {
            WindowUtil.MoveAndResizeWindow(GameProcess, WindowPosX, WindowPosY, WindowWidth, WindowHeight);
        }

        private void WindowInit()
        {
            string gameTitle = "World of Warcraft";

            if (GameProcess.MainWindowTitle.Contains("World of Warcraft"))
            {
                gameTitle = "Game " + CurrentGameNum;
                WindowUtil.RenameWindow(GameProcess, gameTitle);
                CurrentGameNum++;
            }

            GameTitle = gameTitle;

            // TODO: Resize and position here?
        }
    }
}