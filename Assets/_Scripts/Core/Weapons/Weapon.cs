using UnityEngine;
using Core.Pool;

namespace Core.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform _shotPosition;
        [SerializeField] protected BulletPool _bulletPool;

        public abstract void Fire(Vector3 target);
    }
}