using UnityEngine;

namespace TankFury
{
    public class TankMove : MonoBehaviour
    {
        private Transform _transform;

        [SerializeField] private TankConfig _tankConfig;
        private float _moveMaxSpeed;
        private float _currentMoveSpeed;
        private float _acceleration;

        private Input _input;
        private Vector2 _inputDirection;

        public void Init()
        {
            _moveMaxSpeed = _tankConfig.MaxSpeed;
            _acceleration = _tankConfig.TimeAcceleration;
            _currentMoveSpeed = 0.0f;

            _transform = gameObject.transform;
        }

        private void Update()
        {
            NewPosition();
        }

        public void NewPosition()
        {
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
    }
}
