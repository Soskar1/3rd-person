using UnityEngine;

namespace Core.Entity
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;

        [SerializeField] private Transform _shotPos;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private Transform _parent;

        public void Shoot()
        {
            RaycastHit hit;
            Bullet bulletInstance = Instantiate(_bullet, _shotPos.position, Quaternion.identity, _parent);

            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, Mathf.Infinity, _layerMask))
            {
                bulletInstance.target = hit.point;
            }
            else
            {
                bulletInstance.target = _cameraTransform.position + _cameraTransform.forward * 25;
            }
        }
    }
}