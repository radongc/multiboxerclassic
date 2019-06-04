using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiboxer
{
    class GUIStringLibrary
    {
        /* GUIStringLibrary:
         * This class simply contains (generally long) strings that are used in the GUI. 
         * They are stored in a separate class for code readability. */

        public static class HelpText
        {
            public static string IgnoreList = "The Ignore List can be useful in specifying which keystrokes you do not want the Multiboxer to send to other clients. For example, if you chose to ignore the key 'D', whenever the key D is pressed, it will not be sent to the child clients." +
            "\n\nSyntax: To specify a key to ignore, you must enter the name that corresponds with the .NET Keys enum identifier for that key. For a full list of Keys, please visit https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=netframework-4.8." +
            "\n\nExample: If you wanted to ignore the key '7' on the keyboard, you would enter 'D7' (the Keys enum identifer for that key). Each key that you would like to ignore should be placed on a new line with ABSOLUTELY NO whitespace! Good luck!";

            public static string MasterClient = "The Master Client is the client in which you are actively using (ie. playing on). The master client must be specified before starting the Multiboxer in order to prevent Keystrokes from being sent to it.";
        }

        public static class ErrorText
        {
            public static string MasterClient = "Please select the Master Client (the client in which you are going to be playing on) before starting the Multiboxer.";
        }
    }
}
