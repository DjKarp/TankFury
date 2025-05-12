using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace TankFury
{
    public class DialogUIwindow : UIwindow
    {
        private Button _nextButton;
        private TextMeshPro _dialogText;

        public override void Init()
        {
            base.Init();

            _nextButton = gameObject.GetComponentInChildren<Button>();
            _nextButton.onClick.AddListener(() => NextButtonClick());

            _dialogText = gameObject.GetComponentInChildren<TextMeshPro>();
        }
        public void ShowDialog(string text, Action newButtonAction = null)
        {
            _dialogText.text = text;

            _nextButton.onClick.RemoveAllListeners();
            if (newButtonAction != null)
                _nextButton.onClick.AddListener(() => newButtonAction());
            else
                _nextButton.onClick.AddListener(() => NextButtonClick());

            RootUI.ChangeWindowUI(RootUI.DialogUIwindow);
        }

        private void NextButtonClick()
        {
            RootUI.ChangeWindowUIonPrevious();
        }

        private void OnDestroy()
        {
            _nextButton.onClick.RemoveAllListeners();
        }
    }
}
