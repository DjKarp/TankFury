using UnityEngine;

public class SceneExitParams
{
    public int _levelNumber { get; }
    public int _diffeculty { get; }

    public SceneEnterParams _SceneEnterParams;

    public SceneExitParams(SceneEnterParams sceneEnterParams)
    {
        _SceneEnterParams = sceneEnterParams;
    }
}
