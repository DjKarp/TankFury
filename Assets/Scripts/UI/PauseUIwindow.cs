using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TankFury
{
    public class PauseUIwindow : UIwindow
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _backButton;

        public override void Init()
        {
            base.Init();

            _menuButton.onClick.AddListener(() => MenuButtonClick());
            _settingsButton.onClick.AddListener(() => SettingsButtonClick());
            _backButton.onClick.AddListener(() => BackButtonClick());
        }

        private void MenuButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.MainMenuUIwindow);
        }

        private void SettingsButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.SettingsUIwindow);
        }

        private void BackButtonClick()
        {
            RootUI.ChangeWindowUIonPrevious();
        }
    }
}
