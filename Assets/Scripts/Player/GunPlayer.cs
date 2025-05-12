using UnityEngine;

namespace TankFury
{
    public abstract class GunPlayer : MonoBehaviour
    {
        [SerializeField] protected Transform ShootPoint;

        protected abstract void Shoot();        
    }
}
