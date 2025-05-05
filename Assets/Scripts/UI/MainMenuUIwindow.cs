using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TankFury
{
    public class MainMenuUIwindow : UIwindow
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        public override void Init()
        {
            base.Init();

            _playButton.onClick.AddListener(() => PlayButtonClick());
            _settingsButton.onClick.AddListener(() => SettingsButtonClick());
        }

        private void PlayButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.GameplayUIwindow);
        }

        private void SettingsButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.SettingsUIwindow);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
        }
    }
}
