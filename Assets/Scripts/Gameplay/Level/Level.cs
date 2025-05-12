using UnityEngine;

namespace TankFury
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        public Vector2 StartPointPosition { get => _startPoint.position; }
    }
}
