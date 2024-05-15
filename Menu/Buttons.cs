using Shade_Pad.Mods;
using Shadow_Pad.Mods;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods (page 1)
                new ButtonInfo { buttonText = "Page 2", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "More Mods."},
                new ButtonInfo { buttonText = "SpeedBoost", method =() => SpeedBoost.SpeedBoostMod(), toolTip = "Gives You a SpeedBoost.", isTogglable = true},
                new ButtonInfo { buttonText = "Force Tag Freeze", method =() => ForceTagFreeze.FTagFreezeMod(), toolTip = "Freezes all people in your server.", isTogglable = true},
                new ButtonInfo { buttonText = "Fly", method =() => Fly.FlyMod(), toolTip = "ITS A BIRD, ITS A PLANE, ITS A MODDER USING FLY MOD.", isTogglable = true},
                new ButtonInfo { buttonText = "NoClip", method =() => No_Clip.NoClipMod(), toolTip = "You Can Walk Through AnyThing!", isTogglable = true},
                new ButtonInfo { buttonText = "Platforms", method =() => PlatsMod.Platforms.PlatformMod(), toolTip = "Platforms!", isTogglable = true},
                new ButtonInfo { buttonText = "Ghost Monke", method =() => GhostTrolling.Ghostmonke(), toolTip = "Rig Stays Where You activated The Mod!", isTogglable = true},
                new ButtonInfo { buttonText = "Invis Monke", method =() => GhostTrolling.InvisMonke(), toolTip = "Play Peekaboo With Other Players!", isTogglable = true},
            },


            new ButtonInfo[] { // Page 2
                new ButtonInfo { buttonText = "Page 1", method =() => Global.ReturnHome(), isTogglable = true, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "page 3", method =() => SettingsMods.MenuSettings(), isTogglable = true, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => NoFingerMovement.NoMovement(), toolTip = "Your Fingers WONT Move!", isTogglable = true},
                new ButtonInfo { buttonText = "Audio Break All", method =() => DeafAF.BreakAudioAll(), toolTip = "Make Sure Your Friends have Earplugs In!", isTogglable = true},
                new ButtonInfo { buttonText = "Canyons Rope Control", method =() => Main.Canyons.CanyonsRopeControl(), toolTip = "Control Ropes Inside Canyons!", isTogglable = true},
            },

            new ButtonInfo[] { // Page 3
                new ButtonInfo { buttonText = "Page 2", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to Page 2."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },
        };
    }
}
