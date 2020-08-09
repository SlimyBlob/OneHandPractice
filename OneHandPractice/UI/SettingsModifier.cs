using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Notify;
using OneHandPractice.Settings;

namespace OneHandPractice.UI
{
    public class SettingsModifier : INotifiableHost
    {
        [UIValue("handToggle")]
        public bool HandToggle
        {
            get => PluginConfig.Instance.Enabled;
            set => PluginConfig.Instance.Enabled = value;
        }

        [UIValue("leftToggle")]
        public bool LeftToggle
        {
            get => PluginConfig.Instance.LeftHand;
            set => PluginConfig.Instance.LeftHand = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}