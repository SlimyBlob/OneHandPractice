using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace OneHandPractice.Settings
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual bool Enabled { get; set; } = false;
        public virtual bool LeftHand { get; set; } = false;

        // public virtual void Changed()
        // {
        //     if (Enabled)
        //     {
        //         Plugin.Logger.Info("Score Submission disabled pog");
        //         BS_Utils.Gameplay.ScoreSubmission.ProlongedDisableSubmission(nameof(OneHandPractice));
        //     }
        //     else
        //     {
        //         Plugin.Logger.Info("Score Submission enabled pog");
        //         BS_Utils.Gameplay.ScoreSubmission.RemoveProlongedDisable(nameof(OneHandPractice));
        //     }
        // }
    }
}