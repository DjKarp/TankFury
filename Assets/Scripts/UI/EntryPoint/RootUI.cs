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

        private GameplayUIwindow _gameplayUIwindow;        
        private SettingsUIwindow _settingsUIwindow;
        private MainMenuUIwindow _mainMenuUIwindow;
        private PauseUIwindow _pauseUIwindow;

        public GameplayUIwindow GameplayUIwindow { get => _gameplayUIwindow; }
        public SettingsUIwindow SettingsUIwindow { get => _settingsUIwindow; }
        public MainMenuUIwindow MainMenuUIwindow { get => _mainMenuUIwindow; }
        public PauseUIwindow PauseUIwindow { get => _pauseUIwindow; }

        private CollectionPrefabUI _collectionPrefabUI;

        public void Init(CollectionPrefabUI collectionPrefabUI)
        {
            _collectionPrefabUI = collectionPrefabUI;

            _mainMenuUIwindow = Instantiate(_collectionPrefabUI.MainMenuUIwindow, SceneConteinerUI);
            _mainMenuUIwindow.Init(this);

            _gameplayUIwindow = Instantiate(_collectionPrefabUI.GameplayUIwindow, SceneConteinerUI);
            _gameplayUIwindow.Init(this);

            _settingsUIwindow = Instantiate(_collectionPrefabUI.SettingsUIwindow, SceneConteinerUI);
            _settingsUIwindow.Init(this);

            _pauseUIwindow = Instantiate(_collectionPrefabUI.PauseUIwindow, SceneConteinerUI);
            _pauseUIwindow.Init(this);

            _currentWindowUI = _mainMenuUIwindow;
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
            _backgroundImage.enabled = uIwindow != _gameplayUIwindow;
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