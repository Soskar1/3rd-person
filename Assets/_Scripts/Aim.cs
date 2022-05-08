using UnityEngine;

namespace Core.Entity
{
    public class Aim : MonoBehaviour
    {
        [SerializeField] private VirtualCameraSwitch _virtualCameras;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _aimLayerMask;

        private bool _isAiming;
        private Transform _transform;

        private void Awake() => _transform = transform;

        private void Update()
        {
            Vector3 mouseWorldPosition;

            Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = _camera.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimLayerMask))
                mouseWorldPosition = raycastHit.point;
            else
                mouseWorldPosition = ray.GetPoint(10);

            if (!_isAiming)
                return;

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = _transform.position.y;
            Vector3 aimDirection = (worldAimTarget - _transform.position).normalized;

            _transform.forward = Vector3.Lerp(_transform.forward, aimDirection, Time.deltaTime * 20f);
            //_transform.rotation = Quaternion.LookRotation(aimDirection);
        }

        public void StartAim()
        {
            _virtualCameras.SwitchToAimCamera();
            _isAiming = true;
        }

        public void CancelAim()
        {
            _virtualCameras.SwitchTo3rdPersonCamera();
            _isAiming = false;
        }
    }
}