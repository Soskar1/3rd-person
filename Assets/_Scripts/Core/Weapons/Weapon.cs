using UnityEngine;

namespace Core.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform _shotPosition;
        [SerializeField] protected Transform _parent;
        [SerializeField] protected Bullet _bullet;

        public abstract void Fire(Vector3 target);
    }
}