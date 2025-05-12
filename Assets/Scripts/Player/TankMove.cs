using UnityEngine;
using Zenject;

namespace TankFury
{
    public class TankMove : MonoBehaviour
    {
        private Transform _transform;

        [SerializeField] private TankConfig _tankConfig;
        private float _moveMaxSpeed;
        private float _currentMoveSpeed;
        private float _acceleration;

        private InputHandler _input;
        private Vector2 _inputDirection;

        private bool _startStopGame = false;
        private SignalBus _signalBus;


        [Inject]
        private void Construct(InputHandler input, SignalBus signalBus)
        {
            _input = input;

            _signalBus = signalBus;
            _signalBus.Subscribe<PlayPauseGameSignal>(() => _startStopGame = !_startStopGame);
        }

        public void Start()
        {
            _moveMaxSpeed = _tankConfig.MaxSpeed;
            _acceleration = _tankConfig.TimeAcceleration;
            _currentMoveSpeed = 0.0f;

            _transform = gameObject.transform;
        }

        private void Update()
        {
            if (_startStopGame)
                NewPosition();
        }


        public void NewPosition()
        {
            Debug.LogError("Move");

            _inputDirection = _input.GetMoveDirection();

            if (_inputDirection == Vector2.zero)
            {
                _currentMoveSpeed = 0;
                _transform.position = _transform.position;
            }
            else
            {
                _currentMoveSpeed = Mathf.Clamp(_currentMoveSpeed + (_acceleration * Time.deltaTime), 0.0f, _moveMaxSpeed);

                Vector2 position = _transform.position;
                _transform.position = position + (_inputDirection * _currentMoveSpeed * Time.deltaTime);
            }
        }

        public float GetNormalizeSpeed()
        {
            return _currentMoveSpeed / _moveMaxSpeed;
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayPauseGameSignal>(() => _startStopGame = !_startStopGame);
        }
    }
}
