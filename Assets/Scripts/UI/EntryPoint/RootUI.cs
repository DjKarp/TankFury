using UnityEngine;
using System.Collections;
using R3;
using Zenject;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System.Collections.Generic;

namespace TankFury
{
    public class RootUI : MonoBehaviour
    {
        [SerializeField] private Transform _sceneConteinerUI;
        public Transform SceneConteinerUI { get => _sceneConteinerUI; }

        [SerializeField] private Image _backgroundImage;
        private Tween _tween;

        private Stack<UIwindow> _currentWindowUIList = new Stack<UIwindow>();
        private UIwindow _currentWindowUI;
        private UIwindow[] _uIwindows = new UIwindow[5];

        public MainMenuUIwindow MainMenuUIwindow { get => (MainMenuUIwindow)_uIwindows[0]; }
        public SettingsUIwindow SettingsUIwindow { get => (SettingsUIwindow)_uIwindows[1]; }
        public GameplayUIwindow GameplayUIwindow { get => (GameplayUIwindow)_uIwindows[2]; }
        public PauseUIwindow PauseUIwindow { get => (PauseUIwindow)_uIwindows[3]; }
        public DialogUIwindow DialogUIwindow { get => (DialogUIwindow)_uIwindows[4]; }

        private CollectionPrefabUI _collectionPrefabUI;
        private DialogSystem _dialogSystem;

        private SignalBus _signalBus;
        private bool _startStopGame;


        public void Init(CollectionPrefabUI collectionPrefabUI, DialogSystem dialogSystem, SignalBus signalBus)
        {
            _collectionPrefabUI = collectionPrefabUI;
            _dialogSystem = dialogSystem;
            _signalBus = signalBus;

            for (int i = 0; i < _collectionPrefabUI.UiwindowList.Count; i++)
            {
                _uIwindows[i] = Instantiate(_collectionPrefabUI.UiwindowList[i], SceneConteinerUI);
                _uIwindows[i].Init(this);
                if (_uIwindows[i].GetType().ToString() == "GameplayUIwindow")
                {
                    GameplayUIwindow gameUI = (GameplayUIwindow)_uIwindows[i];
                    gameUI.Construct(_dialogSystem);
                }
                else if (_uIwindows[i].GetType().ToString() == "DialogUIwindow")
                {
                    _dialogSystem.Init((DialogUIwindow)_uIwindows[i]);
                }
            }

            _currentWindowUI = MainMenuUIwindow;
            _backgroundImage.enabled = false;
            AttachUI(_currentWindowUI.gameObject);
        }

        public void ChangeWindowUIonPrevious()
        {
            ChangeWindowUI(_currentWindowUIList.Pop(), true);
        }

        public void ChangeWindowUI(UIwindow uIwindow, bool isPrevious = false)
        {
            if (!isPrevious)
                _currentWindowUIList.Push(_currentWindowUI);

            _currentWindowUI = uIwindow;
            _currentWindowUI?.Hide();

            bool startStopGame = uIwindow != GameplayUIwindow;
            if (!startStopGame)
                _signalBus.Fire(new PlayPauseGameSignal(!startStopGame));

            _backgroundImage.enabled = startStopGame;

            StartCoroutine(AddedNewWindowUI(uIwindow));
        }

        private IEnumerator AddedNewWindowUI(UIwindow uIwindow)
        {
            yield return new WaitForSeconds(uIwindow.DurationHideShow);
            AttachUI(uIwindow.gameObject);
        }

        private void ClearAttachUI()
        {
            int childCount = _sceneConteinerUI.childCount;
            for (int i = 0; i < childCount; i++)
                _sceneConteinerUI.GetChild(i).gameObject.SetActive(false);
        }

        private void AttachUI(GameObject sceneUI_GO)
        {
            ClearAttachUI();

            sceneUI_GO.transform.SetParent(_sceneConteinerUI, false);
            sceneUI_GO.gameObject.SetActive(true);
            _currentWindowUI?.Show();
        }

        private void OnDisable()
        {
            _tween.Kill(true);
        }
    }
}