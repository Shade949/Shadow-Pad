using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Shadow_Pad.Mods
{
    internal class DeafAF
    {
        public static void BreakAudioAll()
        {
            if (ControllerInputPoller.instance.rightControllerIndexTouch > 0.5f)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.Others, new object[]{
                    111,
                    false,
                    999999f
                });
            }
        }
    }
}
