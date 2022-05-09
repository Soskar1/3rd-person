using UnityEngine;

namespace Core.Entity
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Aim _aim;
        [SerializeField] private Bullet _bullet;

        [SerializeField] private Transform _shotPos;

        [SerializeField] private Transform _parent;

        public void Shoot()
        {
            Vector3 aimDirection = (_aim.MouseWorldPosition - _shotPos.position).normalized;
            Instantiate(_bullet, _shotPos.position, Quaternion.LookRotation(aimDirection, Vector3.up), _parent);
        }
    }
}