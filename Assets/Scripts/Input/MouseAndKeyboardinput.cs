using UnityEngine;

namespace TankFury
{
    public class MouseAndKeyboardInput : InputHandler
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
            CursorPosition = Input.mousePosition;
        }

        public override void SetMoveDirection()
        {
            _vetricalValue = Input.GetAxis("Vertical");
            _horizontalValue = Input.GetAxis("Horizontal");

            MoveDirection = new Vector2(_horizontalValue, _vetricalValue);
        }
    }
}
