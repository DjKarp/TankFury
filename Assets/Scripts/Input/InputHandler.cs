using UnityEngine;

namespace TankFury
{
    public abstract class InputHandler : MonoBehaviour
    {
        protected Vector2 MoveDirection;
        protected Vector2 CursorPosition;

        public Vector2 GetMoveDirection() => MoveDirection;
        public abstract void SetMoveDirection();

        public Vector2 GetCursorPosition() => CursorPosition;
        public abstract void SetCursorPosition();
    }
}
