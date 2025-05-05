using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TankFury
{
    public class SettingsUIwindow : UIwindow
    {
        [SerializeField] private Button _backButton;

        public override void Init()
        {
            base.Init();

            _backButton.onClick.AddListener(() => BackButtonClick());
        }

        private void BackButtonClick()
        {
            RootUI.ChangeWindowUIonPrevious();
        }
    }
}
