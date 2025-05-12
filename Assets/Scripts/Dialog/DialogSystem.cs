using System.Collections.Generic;
using UnityEngine;

namespace TankFury
{
    public class DialogSystem
    {
        private Stack<string> _dialogList = new Stack<string>();
        private DialogUIwindow _dialogUIwindow;

        public void Init(DialogUIwindow dialogUIwindow)
        {
            _dialogUIwindow = dialogUIwindow;
        }

        public void AddedNewDialog(string text)
        {
            _dialogList.Push(text);
        }

        public void CheckShowDialogWindow()
        {
            if (_dialogList.Count > 0)
            {
                _dialogUIwindow.ShowDialog(_dialogList.Pop());
            }
        }
    }
}
