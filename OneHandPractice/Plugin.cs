using System.Reflection;
using BeatSaberMarkupLanguage.GameplaySetup;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using OneHandPractice.Settings;
using OneHandPractice.UI;
using UnityEngine;
using Logger = IPA.Logging.Logger;

namespace OneHandPractice
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private const string _harmonyId = "be.slimyblob.onehandpractice";
        
        internal static Harmony HarmonyInstance;
        internal static Logger Logger;
        private SettingsModifier _settingsModifier;

        [Init]
        public void Init(Logger logger, Config config)
        {
            Logger = logger;

            PluginConfig.Instance = config.Generated<PluginConfig>();
            logger.Debug("Config loaded succesfully");
        }

        [OnEnable]
        public void OnEnable()
        {
            Logger.Log(Logger.Level.Info, $"{nameof(OneHandPractice)} enabled");
            
            GameplaySetup.instance.AddTab("OneHandPractice", "OneHandPractice.UI.SettingsModifier.bsml", _settingsModifier??=new SettingsModifier());
            
            HarmonyInstance = new Harmony(_harmonyId);
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            
            BS_Utils.Utilities.BSEvents.gameSceneLoaded+=BSEventsOngameSceneLoaded;
        }

        [OnDisable]
        public void OnDisable()
        {
            Logger.Log(Logger.Level.Info, $"{nameof(OneHandPractice)} disabled");

            BS_Utils.Utilities.BSEvents.gameSceneLoaded-=BSEventsOngameSceneLoaded;
            
            HarmonyInstance.UnpatchAll(_harmonyId);

            // BSMLSettings.instance.RemoveSettingsMenu(_settingsController);
            // _settingsController = null;
        }

        private void BSEventsOngameSceneLoaded()
        {
            if (PluginConfig.Instance.Enabled)
            {
                Logger.Info("hey, kzen uitgevoerd!");
                BS_Utils.Gameplay.ScoreSubmission.DisableSubmission(nameof(OneHandPractice));
            }
        }
    }
}