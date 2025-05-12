using UnityEngine;

namespace TankFury
{
    public class TurretController : GunPlayer
    {
        private float _reloarTime = 2.0f;

        protected override void Shoot()
        {
            Debug.LogError("Shoot Turret!");
        }

        protected void Reload()
        {

        }
    }
}
