using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiboxer
{
    internal static class Offsets
    {
        internal static class Player
        {
            internal static IntPtr Name = (IntPtr) 0x827D88;
            internal static IntPtr Class = (IntPtr) 0xC27E81;

            internal static IntPtr IsLooting = (IntPtr) 0xB71B48;

            internal static int RealZoneText = 0xB4B404;
            internal static IntPtr ContinentText = (IntPtr) 0x00C961A0;
            internal static IntPtr MinimapZoneText = (IntPtr) 0xB4DA28;
        }

        internal static class Misc
        {
            internal static IntPtr GameVersion = (IntPtr) 0x00837C04;
            internal static IntPtr RealmName = (IntPtr) 0x00C27FC1;
        }
    }
}
