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

namespace Multiboxer
{
    public class InGameMacro
    {
        public string Name { get; private set; }

        public string Content { get; private set; }

        public InGameMacro(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
