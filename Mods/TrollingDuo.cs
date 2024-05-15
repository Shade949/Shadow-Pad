using System;
using System.Collections.Generic;
using System.Text;

namespace Shadow_Pad.Mods
{
        internal class GhostTrolling
        {
            public static void Ghostmonke()
            {
                bool rightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerSecondaryButtonTouch;
                if (rightControllerPrimaryButton)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }

            public static void InvisMonke()
            {
                var invistoggle = false;
                var invis = ControllerInputPoller.instance.rightControllerPrimaryButtonTouch;
                if (invis)
                {
                    if (invistoggle)
                    {
                        invistoggle = false;
                    }
                    else
                    {
                        if (!invistoggle)
                        {
                            invistoggle = true;
                        }
                    }



                }


                if (invistoggle)
                {
                    GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 180f;
                }
                else
                {
                    if (!invistoggle)
                    {
                        GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 0f;
                    }
                }
            }

            public static void DisableInvis()
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 0f;
            }
        }
}
