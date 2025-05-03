using UnityEngine;
using R3;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private GameplayRootUI _gameplayRootUI_prefab;
    private GameplayRootUI _gameplayRootUI;

    public void Run(RootUI rootUI, SceneEnterParams sceneEnterParams)
    {
        _gameplayRootUI = Instantiate(_gameplayRootUI_prefab);
        rootUI.AttachUI(_gameplayRootUI.gameObject);

        Init();
    }

    private void Init()
    {

    }
}
