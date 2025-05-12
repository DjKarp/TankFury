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
        private float _rotateSpeed;
        private bool _isReverse = false;

        private InputHandler _input;
        private Vector2 _inputDirection;
        private Vector3 _newPosition;

        private bool _isGamePlayOn = false;
        private SignalBus _signalBus;


        [Inject]
        private void Construct(InputHandler input, SignalBus signalBus)
        {
            _input = input;

            _signalBus = signalBus;
            _signalBus.Subscribe<PlayPauseGameSignal>(StartSropMove);
        }

        public void Start()
        {
            _moveMaxSpeed = _tankConfig.MoveMaxSpeed;
            _acceleration = _tankConfig.Acceleration;
            _rotateSpeed = _tankConfig.RotateSpeed;
            _currentMoveSpeed = 0.0f;

            _transform = gameObject.transform;
        }

        private void Update()
        {
            if (_isGamePlayOn)
            {
                _inputDirection = _input.GetMoveDirection();                
                NewRotation();
                NewPosition();
            }
        }
        public void NewRotation()
        {
            if (_inputDirection.x != 0.0f)
            {
                _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _transform.rotation * Quaternion.Euler(0, 0, (_inputDirection.x >= 0 ? -90.0f : 90.0f)), _rotateSpeed * Time.deltaTime);
            }
        }

        public void NewPosition()
        {
            if (_inputDirection.y != 0.0f)
                _isReverse = _inputDirection.y < 0.0f;

            if (_inputDirection.y == 0.0f && _currentMoveSpeed != 0)
            {
                _currentMoveSpeed = Mathf.Clamp(_currentMoveSpeed - (_acceleration * 2.0f * Time.deltaTime), 0.0f, _moveMaxSpeed);
            }
            else if (_inputDirection.y != 0.0f)
            {
                _currentMoveSpeed = Mathf.Clamp(_currentMoveSpeed + (_acceleration * Time.deltaTime), 0.0f, _moveMaxSpeed);                
            }

            _transform.position += _transform.up * (_isReverse ? -1.0f : 1.0f) * _currentMoveSpeed * Time.deltaTime;
        }        

        public float GetNormalizeSpeed()
        {
            return _currentMoveSpeed / _moveMaxSpeed;
        }

        private void StartSropMove(PlayPauseGameSignal gameSignal)
        {
            _isGamePlayOn = gameSignal.IsGamePlayOn;
        }

        private void OnDisable()
        {
            _signalBus.TryUnsubscribe<PlayPauseGameSignal>(() => _isGamePlayOn = !_isGamePlayOn);
        }
    }
}
