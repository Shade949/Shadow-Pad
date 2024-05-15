using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Shadow_Pad.Mods
{
    internal class No_Clip
    {
        public static void NoClipMod()
        {
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = ControllerInputPoller.instance.leftControllerIndexFloat < 0.1f;
                }
            }
        }

    }
}
