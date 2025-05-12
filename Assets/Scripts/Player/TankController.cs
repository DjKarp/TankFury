using UnityEngine;

namespace TankFury
{
    public class TankController : MonoBehaviour
    {
        private TankController _tankController;
        private TankFury.Input _Input;

        public void Init(Vector2 startPosition)
        {
            transform.position = startPosition;
        }
    }
}
