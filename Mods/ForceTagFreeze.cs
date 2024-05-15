using System;
using System.Collections.Generic;
using System.Text;

namespace Shade_Pad.Mods
{
    internal class ForceTagFreeze
    {
        public static void FTagFreezeMod()
        {
            GorillaLocomotion.Player.Instance.disableMovement = true;
        }

    }
}
