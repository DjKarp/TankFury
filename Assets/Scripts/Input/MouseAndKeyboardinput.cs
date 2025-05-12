using UnityEngine;

namespace TankFury
{
    public class MouseAndKeyboardinput : Input
    {
        private float _vetricalValue;
        private float _horizontalValue;

        private void Update()
        {
            SetCursorPosition();
            SetMoveDirection();
        }

        public override void SetCursorPosition()
        {
            CursorPosition = UnityEngine.Input.mousePosition;
        }

        public override void SetMoveDirection()
        {
            _vetricalValue = UnityEngine.Input.GetAxis("Vertical");
            _horizontalValue = UnityEngine.Input.GetAxis("Horizontal");

            MoveDirection = new Vector2(_horizontalValue, _vetricalValue);
        }
    }
}
