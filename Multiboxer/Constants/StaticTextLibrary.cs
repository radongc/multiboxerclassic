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
    internal static class StaticTextLibrary
    {
        /* GUIStringLibrary:
         * This class simply contains (generally long) strings that are used in the GUI. 
         * They are stored in a separate class for code readability. */

        internal static class HelpText
        {
            internal static string IgnoreList = "The Ignore List can be useful in specifying which keystrokes you do not want the Multiboxer to send to other clients. For example, if you chose to ignore the key 'D', whenever the key D is pressed, it will not be sent to the child clients." +
            "\n\nSyntax: To specify a key to ignore, you must enter the name that corresponds with the .NET Keys enum identifier for that key. For a full list of Keys, please visit https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=netframework-4.8." +
            "\n\nExample: If you wanted to ignore the key '7' on the keyboard, you would enter 'D7' (the Keys enum identifer for that key). Each key that you would like to ignore should be placed on a new line with ABSOLUTELY NO whitespace! Good luck!";

            internal static string DefaultBindings = "These options allow you to translate one action into another for a smoother multiboxing experience. Mouse clicks can be translated into keystrokes, sometimes a single click to multiple keys, to eliminate the need to be constantly pressing buttons to make your child characters assist, attack, accept quests, and so on." +
            "\n\nTo set up these bindings, create a macro for each of the different bindings (you can find some basic macros for each one in the Macro tab), and add them to your action bar bound to the key that will be broadcasted. For non-macro bindings such as Interact with Target, bind the desired action to the key that will be broadcasted on your child characters." +
            "\n\nFor others, no set up is needed (such as the 'UP' key binding).";

            internal static string MasterClient = "The Master Client is the client in which you are actively using (ie. playing on). The master client must be specified before starting the Multiboxer in order to prevent Keystrokes from being sent to it.";

            internal static string MacroList = "These are some example macros required for the default bindings (in the Key Configuration tab). Copy the names/content of each macro into WoW for each child character, and bind them to the corresponding key that will be broadcasted.";
        }

        internal static class ErrorText
        {
            internal static string MasterClientMain = "Please select the Master Client (the client in which you are going to be playing on) before starting the Multiboxer.";

            internal static string MasterClientMacro = "Please select the Master Client (the client in which you are going to be playing on) in the main Multiboxing tab before trying to generate macros.";

            internal static string MasterClientConfig = "Please select the Master Client (the client in which you are going to be playing on) in the main Multiboxing tab before entering character information.";
        }
    }
}
