using UnityEngine;

namespace Core.Weapons
{
    public class Gun : Weapon
    {
        public override void Fire(Vector3 target)
        {
            Vector3 aimDirection = (target - _shotPosition.position).normalized;
            Instantiate(_bullet, _shotPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up), _parent);
        }
    }
}