using UnityEngine;

namespace TankFury
{
    public class MachineGunController : GunPlayer
    {
        protected override void Shoot()
        {
            Debug.LogError("Shoot machine gun!");
        }
    }
}
