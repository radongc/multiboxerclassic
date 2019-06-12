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
                inviteMacroContent += $"// Bind this and AcceptGroupMacro to same key\n" +
                                      $"/invite {childNames[i]}\n";
                i++;
            }

            masterClientMacros.Add("InviteMacro", inviteMacroContent);

            // LEAVE MACRO

            string leaveMacroContent = "/script LeaveParty()";

            masterClientMacros.Add("LeavePartyMacro", leaveMacroContent);

            return masterClientMacros;
        }

        public static Dictionary<string, string> GenerateChildMacros(string masterName, Enums.Game.PlayerClass playerClass)
        {
            Dictionary<string, string> childClientMacros = new Dictionary<string, string>();

            // ACCEPTGROUP MACRO

            string acceptGroupMacroContent = "// Bind this and InviteMacro to same key\n" +
                                             "/script AcceptGroup()";

            childClientMacros.Add("AcceptGroupMacro", acceptGroupMacroContent);

            // ASSIST MACRO

            string assistMacroContent = $"/assist {masterName}\n" +
                                        $"/run AttackTarget()\n" +
                                        $"/follow {masterName}";

            childClientMacros.Add("AssistMacro", assistMacroContent);

            // FOLLOW MACRO

            string followMacroContent = $"/follow {masterName}";

            childClientMacros.Add("FollowMacro", followMacroContent);

            // Generate class macros
            ClassMacros(childClientMacros, masterName, playerClass);

            return childClientMacros;
        }

        public static void ClassMacros(Dictionary<string, string> macros, string masterName, Enums.Game.PlayerClass playerClass)
        {
            switch (playerClass) /* TODO: FINISH CLASS MACROS */
            {
                case Enums.Game.PlayerClass.Warrior: /* WARRIOR MACROS */

                    // HEROIC STRIKE MACRO

                    string warriorHeroicStrikeContent = $"/assist {masterName}\n" +
                                                        $"/cast Heroic Strike";

                    macros.Add("[WARRIOR]HeroicStrike", warriorHeroicStrikeContent);

                    // CHARGE MACRO

                    string warriorChargeContent = $"/assist {masterName}\n" +
                                                  $"/cast Charge";

                    macros.Add("[WARRIOR]Charge", warriorChargeContent);

                    break;

                case Enums.Game.PlayerClass.Paladin: /* PALADIN MACROS */

                    // HOLY LIGHT MACRO

                    string paladinHolyLightContent = $"/target {masterName}\n" +
                                                     $"/cast Holy Light\n";

                    macros.Add("[PALADIN]HolyLightMaster", paladinHolyLightContent);

                    break;

                case Enums.Game.PlayerClass.Hunter: /* HUNTER MACROS */

                    // ARCANE SHOT MACRO

                    string hunterArcaneShotContent = $"/assist {masterName}\n" +
                                                     $"/cast Arcane Shot";

                    macros.Add("[HUNTER]ArcaneShot", hunterArcaneShotContent);

                    // CONCUSSIVE SHOT MACRO

                    string hunterConcussiveShotContent = $"/assist {masterName}\n" +
                                                         $"/cast Concussive Shot";

                    macros.Add("[HUNTER]ConcShot", hunterConcussiveShotContent);

                    break;

                case Enums.Game.PlayerClass.Rogue: /* ROGUE MACROS */
                    break;

                case Enums.Game.PlayerClass.Priest: /* PRIEST MACROS */

                    // LESSER HEAL MACRO

                    string priestLesserHealContent = $"/target {masterName}\n" +
                                                     $"/cast Lesser Heal";

                    macros.Add("[PRIEST]LesserHeal", priestLesserHealContent);

                    // SMITE MACRO

                    string priestSmiteContent = $"/assist {masterName}\n" +
                                                $"/cast Smite";

                    macros.Add("[PRIEST]Smite", priestSmiteContent);

                    break;
            }
        }
    }
}
