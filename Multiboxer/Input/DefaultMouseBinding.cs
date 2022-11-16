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
    class DefaultMouseBinding : DefaultBinding
    {
        /// <summary>
        /// The mouse button that is physically pressed for this binding.
        /// </summary>
        public MouseButtons BindingPressButton { get; private set; }

        public DefaultMouseBinding(string bindingName, bool bindingEnabled, bool isDoublePress, InGameMacro macro, MouseButtons bindingPressButton, Keys bindingBroadcastKey) : base(bindingName, bindingEnabled, isDoublePress, macro, bindingBroadcastKey)
        {
            BindingPressButton = bindingPressButton;
        }
    }
}
