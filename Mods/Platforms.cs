using BepInEx.Configuration;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Shadow_Pad.Mods
{
    internal class PlatsMod
    {
        internal class Platforms
        {
            public static Color PlatColorA = new Color32(0, 255, 0, 255);
            public static Color PlatColorB = new Color32(0, 255, 100, 255);

            public static GameObject platl;
            public static GameObject platr;

            public static void PlatformMod()
            {
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = 0
                };
                if (ControllerInputPoller.instance.rightGrab)
                {
                    if (Platforms.RightPlat == null)
                    {
                        RightPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (Platforms.currentPlatform != 2)
                        {
                            Platforms.RightPlat.transform.position = new Vector3(0f, -0.0175f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                        }
                        else
                        {
                            Platforms.RightPlat.transform.position = new Vector3(0f, 0.025f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                        }
                        Platforms.RightPlat.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                        Platforms.RightPlat.transform.localScale = Platforms.scale;
                        if (Platforms.currentPlatform == 1)
                        {
                            if (Platforms.RightPlat.GetComponent<MeshRenderer>() != null)
                            {
                                UnityEngine.Object.Destroy(Platforms.RightPlat.GetComponent<MeshRenderer>());
                            }
                        }
                        else
                        {
                            if (Platforms.RightPlat.GetComponent<MeshRenderer>() == null)
                            {
                                Platforms.RightPlat.AddComponent<MeshRenderer>();
                            }
                            Platforms.RightPlat.GetComponent<Renderer>().material.color = Color.black;
                            PhotonNetwork.RaiseEvent(110, new object[]
                            {
                            Platforms.RightPlat.transform.position,
                            Platforms.RightPlat.transform.rotation,
                            Platforms.scale,
                            Platforms.RightPlat.GetComponent<Renderer>().material.color
                            }, raiseEventOptions, SendOptions.SendReliable);
                        }
                    }
                }
                else if (Platforms.RightPlat != null)
                {
                    PhotonNetwork.RaiseEvent(111, null, raiseEventOptions, SendOptions.SendReliable);
                    UnityEngine.Object.Destroy(Platforms.RightPlat);
                    Platforms.RightPlat = null;
                }
                if (ControllerInputPoller.instance.leftGrab)
                {
                    if (Platforms.LeftPlat == null)
                    {
                        Platforms.LeftPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        Platforms.LeftPlat.transform.localScale = Platforms.scale;
                        if (Platforms.currentPlatform != 2)
                        {
                            Platforms.LeftPlat.transform.position = new Vector3(0f, -0.0175f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                        }
                        else
                        {
                            Platforms.LeftPlat.transform.position = new Vector3(0f, 0.025f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                        }
                        Platforms.LeftPlat.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                        if (Platforms.currentPlatform != 1)
                        {
                            if (Platforms.LeftPlat.GetComponent<MeshRenderer>() == null)
                            {
                                Platforms.LeftPlat.AddComponent<MeshRenderer>();
                            }
                            Platforms.LeftPlat.GetComponent<Renderer>().material.color = Color.black;
                            PhotonNetwork.RaiseEvent(110, new object[]
                            {
                            Platforms.LeftPlat.transform.position,
                            Platforms.LeftPlat.transform.rotation,
                            Platforms.scale,
                            Platforms.LeftPlat.GetComponent<Renderer>().material.color
                            }, raiseEventOptions, SendOptions.SendReliable);
                            return;
                        }
                        if (Platforms.LeftPlat.GetComponent<MeshRenderer>() != null)
                        {
                            UnityEngine.Object.Destroy(Platforms.LeftPlat.GetComponent<MeshRenderer>());
                            return;
                        }
                    }
                }
                else if (Platforms.LeftPlat != null)
                {
                    PhotonNetwork.RaiseEvent(121, null, raiseEventOptions, SendOptions.SendReliable);
                    UnityEngine.Object.Destroy(Platforms.LeftPlat);
                    Platforms.LeftPlat = null;
                }
            }



            private static GameObject LeftPlat;

            // Token: 0x040000C2 RID: 194
            private static GameObject RightPlat;

            // Token: 0x040000C3 RID: 195
            private static GameObject pointer;

            // Token: 0x040000C4 RID: 196
            private static GameObject[] LeftPlat_Networked = new GameObject[9999];

            // Token: 0x040000C5 RID: 197
            private static GameObject[] RightPlat_Networked = new GameObject[9999];

            // Token: 0x040000C6 RID: 198
            public static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

            // Token: 0x040000C7 RID: 199
            private static bool gravityToggled;

            // Token: 0x040000C8 RID: 200
            private static bool flying;

            // Token: 0x040000C9 RID: 201
            private static string oldRoom;

            // Token: 0x040000CA RID: 202
            private static bool canTP = false;

            // Token: 0x040000CB RID: 203
            private static float RG;

            // Token: 0x040000CC RID: 204
            private static float LG;

            // Token: 0x040000CD RID: 205
            private static bool RGrabbing;

            // Token: 0x040000CE RID: 206
            private static Vector3 CurHandPos;

            // Token: 0x040000CF RID: 207
            private static bool LGrabbing;

            // Token: 0x040000D0 RID: 208
            private static bool AirMode;

            // Token: 0x040000D1 RID: 209
            private static int layers = int.MaxValue;

            // Token: 0x040000D2 RID: 210
            public static float Spring;

            // Token: 0x040000D3 RID: 211
            public static float Damper;

            // Token: 0x040000D4 RID: 212
            public static float MassScale;

            // Token: 0x040000D5 RID: 213
            public static ConfigEntry<float> sp;

            // Token: 0x040000D6 RID: 214
            public static ConfigEntry<float> dp;

            // Token: 0x040000D7 RID: 215
            public static Color grapplecolor;

            // Token: 0x040000D8 RID: 216
            public static ConfigEntry<float> ms;

            // Token: 0x040000D9 RID: 217
            public static ConfigEntry<Color> rc;

            // Token: 0x040000DA RID: 218
            public static bool wackstart = false;

            // Token: 0x040000DB RID: 219
            public static bool canleftgrapple = true;

            // Token: 0x040000DC RID: 220
            private static bool canBHop = false;

            // Token: 0x040000DD RID: 221
            private static bool isBHop = false;

            // Token: 0x040000DE RID: 222
            private static bool isnoclipped = false;

            // Token: 0x040000DF RID: 223
            private static float LongArmsOffset = 0f;

            // Token: 0x040000E0 RID: 224
            private static LineRenderer lineRenderer;

            // Token: 0x040000E1 RID: 225
            private static bool disablegrapple = false;

            // Token: 0x040000E2 RID: 226
            private static RaycastHit hit;

            // Token: 0x040000E3 RID: 227
            public static float speedBoostMultiplier = 1.15f;

            // Token: 0x040000E4 RID: 228
            public static float flightMultiplier = 1.15f;

            // Token: 0x040000E5 RID: 229
            public static float WallWalkMultiplier = 1.15f;

            // Token: 0x040000E6 RID: 230
            private static bool clipped = false;

            // Token: 0x040000E7 RID: 231
            public static List<Vector3> Macro = new List<Vector3>();

            // Token: 0x040000E8 RID: 232
            public static float MacroHelp = 0f;

            // Token: 0x040000E9 RID: 233
            private static Vector3 head_direction;

            // Token: 0x040000EA RID: 234
            private static Vector3 roll_direction;

            // Token: 0x040000EB RID: 235
            private static Vector2 left_joystick;

            // Token: 0x040000EC RID: 236
            private static bool Start = false;

            // Token: 0x040000ED RID: 237
            private static float multiplier = 1f;

            // Token: 0x040000EE RID: 238
            private static float speed = 0f;

            // Token: 0x040000EF RID: 239
            private static float maxs = 10f;

            // Token: 0x040000F0 RID: 240
            private static float acceleration = 5f;

            // Token: 0x040000F1 RID: 241
            private static float distance = 0.35f;

            // Token: 0x040000F2 RID: 242
            public static List<Vector3> positions = new List<Vector3>();

            // Token: 0x040000F3 RID: 243
            public static float RewindHelp = 0f;

            // Token: 0x040000F4 RID: 244
            internal static Vector3 previousMousePosition;

            // Token: 0x040000F5 RID: 245
            public static float slideControlMultiplier = 1.15f;

            // Token: 0x040000F6 RID: 246
            public static string[] platformTypes = new string[] { "Normal", "Invisible", "Sticky" };

            // Token: 0x040000F7 RID: 247
            public static bool cangrapple = true;

            // Token: 0x040000F8 RID: 248
            public static float maxDistance = 100f;

            // Token: 0x040000F9 RID: 249
            private static float myVarY1;

            // Token: 0x040000FA RID: 250
            private static LineRenderer lr;

            // Token: 0x040000FB RID: 251
            public static Vector3 grapplePoint;

            // Token: 0x040000FC RID: 252
            public static Vector3 leftgrapplePoint;

            // Token: 0x040000FD RID: 253
            private static float myVarY2;

            // Token: 0x040000FE RID: 254
            private static float gainSpeed;

            // Token: 0x040000FF RID: 255
            public static SpringJoint joint;

            // Token: 0x04000100 RID: 256
            public static Vector3? leftHandOffsetInitial = null;

            // Token: 0x04000101 RID: 257
            public static Vector3? rightHandOffsetInitial = null;

            // Token: 0x04000102 RID: 258
            public static SpringJoint leftjoint;

            // Token: 0x04000103 RID: 259
            public static LineRenderer leftlr;

            // Token: 0x04000104 RID: 260
            public static float? maxArmLengthInitial = null;

            // Token: 0x04000105 RID: 261
            private static int currentPlatform;

            // Token: 0x04000106 RID: 262
            private static float ropetimeout;

            // Token: 0x04000107 RID: 263
            public static Vector3[] lastLeft = new Vector3[]
            {
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero
            };

            // Token: 0x04000108 RID: 264
            public static Vector3[] lastRight = new Vector3[]
            {
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero
            };


        }
    }
}
