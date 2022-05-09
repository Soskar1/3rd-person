using UnityEngine;

namespace Core.Entity
{
    public class Aim : MonoBehaviour
    {
        [SerializeField] private VirtualCameraSwitch _virtualCameras;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _aimLayerMask;

        private Vector3 _mouseWorldPosition;
        private bool _isAiming;
        
        private Transform _transform;

        public Vector3 MouseWorldPosition { get => _mouseWorldPosition; }

        private void Awake() => _transform = transform;

        private void Update()
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = _camera.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimLayerMask))
                _mouseWorldPosition = raycastHit.point;
            else
                _mouseWorldPosition = ray.GetPoint(10);

            if (!_isAiming)
                return;

            Vector3 worldAimTarget = _mouseWorldPosition;
            worldAimTarget.y = _transform.position.y;
            Vector3 aimDirection = (worldAimTarget - _transform.position).normalized;

            _transform.forward = Vector3.Lerp(_transform.forward, aimDirection, Time.deltaTime * 20f);
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