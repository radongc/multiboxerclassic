using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiboxer
{
    public class DefaultBinding
    {
        public string BindingName { get; private set; }
        public bool BindingEnabled { get; private set; }
        public bool IsDoublePress { get; private set; }

        public InGameMacro Macro { get; private set; }

        /// <summary>
        /// The key that gets broadcasted to other clients for this binding.
        /// </summary>
        public Keys BindingBroadcastKey { get; private set; }

        public DefaultBinding(string bindingName, bool bindingEnabled, bool isDoublePress, InGameMacro macro, Keys bindingBroadcastKey)
        {
            BindingName = bindingName;
            BindingEnabled = bindingEnabled;
            IsDoublePress = isDoublePress;
            Macro = macro;
            BindingBroadcastKey = bindingBroadcastKey;
        }

        public void SetEnabled(bool value)
        {
            BindingEnabled = value;
        }
    }
}