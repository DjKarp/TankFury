using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using R3;

namespace TankFury
{
    public class GameEntryPoint
    {
        public static GameEntryPoint Instance;

        private CorutinesInScene _corutinesInScene;
        private SceneEnterParams _SceneEnterParams;
        private Subject<float> _loadSceneSubject = new Subject<float>();
        private RootUI _rootUI;

        private GameEntryPoint()
        {
            _corutinesInScene = new GameObject("[Coroutines]").AddComponent<CorutinesInScene>();
            Object.DontDestroyOnLoad(_corutinesInScene.gameObject);

            var rootUIprefab = Resources.Load<RootUI>("RootUI");
            _rootUI = Object.Instantiate(rootUIprefab);
            Object.DontDestroyOnLoad(_rootUI);
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

            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            
            sceneEntryPoint?.Run(_rootUI, _SceneEnterParams);
        }
    }
}