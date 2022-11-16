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
using System.Windows.Forms;

namespace Multiboxer
{
    public class SpecialBinding : DefaultBinding
    {
        public Keys BindingPressKey { get; private set; }
        public Action SpecialAction { get; private set; }

        public SpecialBinding(string bindingName, bool bindingEnabled, bool isDoublePress, Keys bindingPressKey, Action specialAction) : base(bindingName, bindingEnabled, isDoublePress, null, Keys.None)
        {
            BindingPressKey = bindingPressKey;
            SpecialAction = specialAction;
        }
    }
}
