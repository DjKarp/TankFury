using System.Collections.Generic;
using UnityEngine;

namespace TankFury
{
    public class CollectionPrefabUI
    {
        public MainMenuUIwindow MainMenuUIwindow { get; private set; }
        public SettingsUIwindow SettingsUIwindow { get; private set; }
        public GameplayUIwindow GameplayUIwindow { get; private set; }
        public PauseUIwindow PauseUIwindow { get; private set; }
        public DialogUIwindow DialogUIwindow { get; private set; }

        public GameObject LoadingUI { get; private set; }

        public List<UIwindow> UiwindowList = new List<UIwindow>();


        public void Init()
        {
            MainMenuUIwindow = Resources.Load<MainMenuUIwindow>("MainMenuUI");
            SettingsUIwindow = Resources.Load<SettingsUIwindow>("SettingsUI");
            GameplayUIwindow = Resources.Load<GameplayUIwindow>("GameplayUI");
            PauseUIwindow = Resources.Load<PauseUIwindow>("PauseUI");
            DialogUIwindow = Resources.Load<DialogUIwindow>("DialogUI");

            UiwindowList = new List<UIwindow> { MainMenuUIwindow, SettingsUIwindow, GameplayUIwindow, PauseUIwindow, DialogUIwindow };

            LoadingUI = Resources.Load<GameObject>("LoadingUI");            
        }
    }
}
