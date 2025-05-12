using UnityEngine;

namespace TankFury
{
    [CreateAssetMenu(menuName = "Create Tank Config", fileName = "TankConfig", order = 0)]
    public class TankConfig : ScriptableObject
    {
        public float MoveMaxSpeed = 10.0f;

        // The time it needs for the tank to move in a straight line to accelerate to maximum speed.
        public float Acceleration = 2.0f;

        public float RotateSpeed = 2.0f;
    }
}
