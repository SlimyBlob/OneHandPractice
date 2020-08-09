using System;
using HarmonyLib;
using OneHandPractice.Settings;
using TMPro;

namespace OneHandPractice.HarmonyPatches
{
    [HarmonyPatch(typeof(BeatmapObjectSpawnController))]
    [HarmonyPatch("SpawnNote", MethodType.Normal)]
    class BeatMapObjectSpawnControllerPatch
    {
        static bool Prefix(ref NoteData noteData)
        {
            if (PluginConfig.Instance.Enabled)
            {
                if (noteData.noteType == (PluginConfig.Instance.LeftHand ? NoteType.NoteB : NoteType.NoteA))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}