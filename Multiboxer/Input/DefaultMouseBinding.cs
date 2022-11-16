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
