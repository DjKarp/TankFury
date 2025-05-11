using UnityEngine;
using R3;
using Zenject;

namespace TankFury
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private RootUI _rootUI;

        private CollectionPrefabUI _collectionPrefabUI;
        private DialogSystem _dialogSystem;

        [Inject]
        public void Construct(CollectionPrefabUI collectionPrefabUI)
        {
            _collectionPrefabUI = collectionPrefabUI;
        }

        public void Run(RootUI rootUI, SceneEnterParams sceneEnterParams = null)
        {
            _rootUI = rootUI;
            Initialize();
        }

        private void Initialize()
        {
            _collectionPrefabUI.Init();
            _dialogSystem = new DialogSystem();
            _rootUI.Init(_collectionPrefabUI, _dialogSystem);
        }
    }
}