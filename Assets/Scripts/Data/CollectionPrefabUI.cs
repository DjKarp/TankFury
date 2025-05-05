using UnityEngine;

namespace TankFury
{
    public class CollectionPrefabUI
    {
        public MainMenuUIwindow MainMenuUIwindow { get; private set; }
        public SettingsUIwindow SettingsUIwindow { get; private set; }
        public GameplayUIwindow GameplayUIwindow { get; private set; }
        public PauseUIwindow PauseUIwindow { get; private set; }

        public GameObject LoadingUI { get; private set; }


        public void Init()
        {
            MainMenuUIwindow = Resources.Load<MainMenuUIwindow>("MainMenuUI");
            SettingsUIwindow = Resources.Load<SettingsUIwindow>("SettingsUI");
            GameplayUIwindow = Resources.Load<GameplayUIwindow>("GameplayUI");
            PauseUIwindow = Resources.Load<PauseUIwindow>("PauseUI");
            LoadingUI = Resources.Load<GameObject>("LoadingUI");
        }
    }
}
