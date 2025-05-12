using UnityEngine;
using Zenject;

namespace TankFury
{
    public class TankController : MonoBehaviour
    {
        private TankViewController _tankViewController;
        private InputHandler _input;
        private TankMove _tankMove;

        [Inject]
        private void Construct(TankMove tankMove, InputHandler input, TankViewController tankViewController)
        {
            _tankMove = tankMove;
            _input = input;
            _tankViewController = tankViewController;
        }

        private void Update()
        {

        }

        public void Init(Vector2 startPosition)
        {
            transform.position = startPosition;
        }
    }
}
