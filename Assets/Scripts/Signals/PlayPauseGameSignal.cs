using UnityEngine;

namespace TankFury
{
    public class PlayPauseGameSignal
    {
        public bool IsGamePlayOn = false;

        public PlayPauseGameSignal (bool isGamePlayOn)
        {
            IsGamePlayOn = isGamePlayOn;
        }
    }
}
