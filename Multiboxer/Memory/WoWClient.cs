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
        /// Reads memory, returning a value of the specified type (cannot be used for strings)
        /// </summary>
        /// <typeparam name="T">The type to read as.</typeparam>
        /// <returns></returns>
        public T ReadAsType<T>(IntPtr address) where T : struct
        {
            MemoryModule mem = new MemoryModule();

            return mem.ReadMemory<T>(GameProcess.Id, address);
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

            var memoryString = Encoding.UTF8.GetString(memoryStringBytes);

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

            var memoryString = Encoding.UTF8.GetString(memoryStringBytes);

            return memoryString;
        }

        /// <summary>
        /// Contains information about the Player for a WoWClient
        /// </summary>
        public class PlayerInfo // rewrite this entire structure, the "Init" way only allows the values to be updated when a new PlayerInfo is instantiated, which is not useful. Possibly rewrite as a struct
        {
            // fields
            private WoWClient _parentClient;

            /* Properties */
            
            // World/Server/Misc
            public string GameVersion { get; private set; }
            public string RealmName { get; private set; }

            // In-game
            public string Name { get; private set; }
            public int Class { get; private set; } // Class ID, not name

            public string RealZoneText { get; private set; }
            public string ContinentText { get; private set; }
            public string MinimapZoneText { get; private set; }

            // Constructor
            public PlayerInfo(WoWClient client)
            {
                _parentClient = client;

                InitConstants();
            }

            private void InitConstants() // TODO : Reorganize and finish
            {
                string gameVersionUnformatted = _parentClient.ReadString(Offsets.Misc.GameVersion, 6);
                string realmNameUnformatted = _parentClient.ReadString(Offsets.Misc.RealmName, 10);
                string charNameUnformatted = _parentClient.ReadStringBase(Offsets.Player.Name, 12);

                string gameVersion = gameVersionUnformatted.Replace("\0", "");
                string realmName = realmNameUnformatted.Replace("\0", "");
                string charName = charNameUnformatted.Replace("\0", "");

                GameVersion = gameVersion;
                RealmName = realmName;
                Name = charName;
            }

            public bool IsLooting() => _parentClient.ReadAsType<bool>(Offsets.Player.IsLooting);
        }
    }
}
