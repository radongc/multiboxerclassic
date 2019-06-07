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
        public PlayerInfo Player { get; private set; }
        public Process GameProcess { get; private set; }
        public IntPtr BaseAddress { get; private set; }

        // Private methods

        private void InitializePlayer()
        {
            if (GameProcess != null && BaseAddress != null)
            {
                Player = new PlayerInfo(this);
            }
        }

        // Constructors

        public WoWClient()
        {
            GameProcess = null;
            BaseAddress = IntPtr.Zero;
        }

        public WoWClient(int procId)
        {
            SetClient(procId);
        }

        // Mutators

        public void SetClient(int procId)
        {
            Process client = Process.GetProcessById(procId);

            GameProcess = client;
            BaseAddress = client.MainModule.BaseAddress;

            InitializePlayer();
        }

        /// <summary>
        /// Reads a string from the process memory
        /// </summary>
        /// <param name="address">The address of the string to read</param>
        /// <param name="size">The size of the string</param>
        /// <returns></returns>
        public string ReadString(IntPtr address, int size)
        {
            MemoryModule mem = new MemoryModule();

            var memoryStringBytes = mem.ReadMemory(GameProcess.Id, address, size);

            var memoryString = Encoding.Default.GetString(memoryStringBytes);

            return memoryString;
        }

        /// <summary>
        /// Reads a string from the base address of the process memory (some values, such as player name, require this)
        /// </summary>
        /// <param name="address">The address of the string to read</param>
        /// <param name="size">The size of the string</param>
        /// <returns></returns>
        public string ReadStringBase(IntPtr address, int size)
        {
            MemoryModule mem = new MemoryModule();

            var memoryStringBytes = mem.ReadMemory(GameProcess.Id, BaseAddress + (int)address, size); // This differs from the above here, in that you must add the offset to the base address in order to read it.

            var memoryString = Encoding.Default.GetString(memoryStringBytes);

            return memoryString;
        }

        /// <summary>
        /// Contains information about the Player for a WoWClient
        /// </summary>
        public class PlayerInfo
        {
            // fields
            private WoWClient _parentClient;

            // Properties
            public string Name { get; private set; }
            public string Class { get; private set; }

            // Constructor
            public PlayerInfo(WoWClient client)
            {
                _parentClient = client;

                InitProperties();
            }

            private void InitProperties()
            {
                string nameUnformatted = _parentClient.ReadStringBase(Offsets.Player.Name, 12);

                string nameFormatted = nameUnformatted.Replace("\0", "");

                Name = nameFormatted;
                Class = string.Empty; // for now
            }
        }
    }
}
