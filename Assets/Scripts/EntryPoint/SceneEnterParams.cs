namespace TankFury
{
    public class SceneEnterParams
    {
        public int _levelNumber { get; }
        public int _diffeculty { get; }

        public SceneExitParams _SceneExitParams;

        public SceneEnterParams(SceneExitParams sceneExitParams)
        {
            _SceneExitParams = sceneExitParams;
        }
    }
}