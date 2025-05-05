using UnityEngine;
using System.Collections;
using R3;
using Zenject;

namespace TankFury
{
    public class RootUI : MonoBehaviour
    {
        [SerializeField] private Transform _sceneConteinerUI;
        public Transform SceneConteinerUI { get => _sceneConteinerUI; }

        private UIwindow _currentWindowUI;
        private UIwindow _previousWindowUI;

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
            AttachUI(_currentWindowUI.gameObject);
        }

        public void ChangeWindowUIonPrevious()
        {
            ChangeWindowUI(_previousWindowUI);
        }

        public void ChangeWindowUI(UIwindow uIwindow)
        {
            _currentWindowUI?.Hide();
            StartCoroutine(AddedNewWindowUI(uIwindow));
        }

        private IEnumerator AddedNewWindowUI(UIwindow uIwindow)
        {
            yield return new WaitForSeconds(uIwindow.DurationHideShow);

            _previousWindowUI = _currentWindowUI;
            _currentWindowUI = uIwindow;
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
            _currentWindowUI.Show();
        }
    }
}