using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TankFury
{
    public class GameplayUIwindow : UIwindow
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _pauseButton;

        private DialogSystem _dialogSystem;

        [Inject]
        public void Construct(DialogSystem dialogSystem)
        {
            _dialogSystem = dialogSystem;
        }

        public override void Init()
        {
            base.Init();

            _menuButton.onClick.AddListener(() => MenuButtonClick());
            _pauseButton.onClick.AddListener(() => PauseButtonClick());

            _dialogSystem?.CheckShowDialogWindow();
        }

        private void MenuButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.MainMenuUIwindow);
        }

        private void PauseButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.PauseUIwindow);
        }

        private void OnDestroy()
        {
            _menuButton.onClick.RemoveAllListeners();
            _pauseButton.onClick.RemoveAllListeners();
        }
    }
}