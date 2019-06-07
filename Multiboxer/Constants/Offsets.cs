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
        }

        internal static class Misc
        {
            internal static IntPtr RealmName = (IntPtr) 0x00C27FC1;
        }
    }
}
