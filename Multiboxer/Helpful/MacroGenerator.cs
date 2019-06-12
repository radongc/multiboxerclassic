using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiboxer
{
    class MacroGenerator
    {

        public static Dictionary<string, string> GenerateMasterMacros(string[] childNames)
        {
            // master dictionary
            Dictionary<string, string> masterClientMacros = new Dictionary<string, string>();

            // INVITE MACRO

            string inviteMacroContent = string.Empty;

            int i = 0;

            foreach (string s in childNames)
            {
                inviteMacroContent += $"/invite {childNames[i]}\n";
                i++;
            }

            masterClientMacros.Add("InviteMacro", inviteMacroContent);

            // LEAVE MACRO

            string leaveMacroContent = "/script LeaveParty()";

            masterClientMacros.Add("LeavePartyMacro", leaveMacroContent);

            return masterClientMacros;
        }

        public static Dictionary<string, string> GenerateChildMacros(string masterName)
        {
            Dictionary<string, string> childClientMacros = new Dictionary<string, string>();

            // ACCEPTGROUP MACRO

            string acceptGroupMacroContent = "/script AcceptGroup()";

            childClientMacros.Add("AcceptGroupMacro", acceptGroupMacroContent);

            // ASSIST MACRO

            string assistMacroContent = $"/assist {masterName}\n" +
                                        $"/run AttackTarget()\n" +
                                        $"/follow {masterName}";

            childClientMacros.Add("AssistMacro", assistMacroContent);

            // FOLLOW MACRO

            string followMacroContent = $"/follow {masterName}";

            childClientMacros.Add("FollowMacro", followMacroContent);

            return childClientMacros;
        }
    }
}
