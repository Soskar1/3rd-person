using UnityEngine;

namespace Core.Weapons
{
    public class Gun : Weapon
    {
        public override void Fire(Vector3 target)
        {
            Vector3 aimDirection = (target - _shotPosition.position).normalized;

            Bullet bullet = _bulletPool.Pool.GetFreeElement();
            bullet.transform.position = _shotPosition.position;
            bullet.transform.rotation = Quaternion.LookRotation(aimDirection, Vector3.up);
        }
    }
}