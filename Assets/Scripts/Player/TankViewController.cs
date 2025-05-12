using UnityEngine;
using Zenject;

namespace TankFury
{
    public class TankViewController : MonoBehaviour
    {
        [SerializeField] private Animator _trackLeftAnimator;
        [SerializeField] private Animator _trackRightAnimator;
        private string _trackMoveParameter = "isMoveTrack";
        private string _trackSpeedAnimationsParameter = "SpeedTrack";

        private InputHandler _input;
        private Vector2 _moveDirection;

        [Inject]
        private void Construct(InputHandler input)
        {
            _input = input;
        }

        private void Update()
        {
            _moveDirection = _input.GetMoveDirection();
            if (_moveDirection != Vector2.zero)
                StartMoveTank();
            else
                StopMoveTank();
        }

        public void StartMoveTank()
        {
            _trackLeftAnimator.SetBool(_trackMoveParameter, true);
            _trackRightAnimator.SetBool(_trackMoveParameter, true);
        }

        public void StopMoveTank()
        {
            _trackLeftAnimator.SetBool(_trackMoveParameter, false);
            _trackRightAnimator.SetBool(_trackMoveParameter, false);
        }
    }
}
