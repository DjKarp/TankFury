using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using R3;

public class GameEntryPoint
{
    public static GameEntryPoint Instance;

    private CorutinesInScene _corutinesInScene;

    private SceneEnterParams _SceneEnterParams;

    private Subject<float> _loadSceneSubject = new Subject<float>();

    //private UIMainView _UIMainView;

    //private AudioManager _AudioManager;
    //private SaveLoadData _SaveLoadData;
    //private LocalizeManager _LocalizeManager;

    private GameEntryPoint()
    {
        _corutinesInScene = new GameObject("[Coroutines]").AddComponent<CorutinesInScene>();
        Object.DontDestroyOnLoad(_corutinesInScene.gameObject);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutoStartGame()
    {
        Application.targetFrameRate = 60;

        Instance = new GameEntryPoint();
        Instance.StartGame();
    }

    private void StartGame()
    {
        //string sceneName = SceneManager.GetActiveScene().name;
        _corutinesInScene.StartCoroutine(LoadAndStartGame());
    }

    private IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync(sceneName);

        while (!LoadAsync.isDone)
        {
            _loadSceneSubject?.OnNext(LoadAsync.progress);

            yield return new WaitForEndOfFrame();
        }

        yield return LoadAsync;
    }

    private IEnumerator LoadAndStartGame(SceneEnterParams sceneEnterParams = null)
    {
        _SceneEnterParams = sceneEnterParams == null ? _SceneEnterParams : sceneEnterParams;

        yield return LoadScene(Scenes.Scene_Bootstrap);

        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1.0f);

        yield return LoadScene(Scenes.Scene_Game);


    }
}
