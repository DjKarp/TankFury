using UnityEngine;

namespace TankFury
{
    public class PlayPauseGameSignal
    {
        public bool PlayPauseGame = false;

        public PlayPauseGameSignal (bool playPauseGame)
        {
            PlayPauseGame = playPauseGame;
        }
    }
}
