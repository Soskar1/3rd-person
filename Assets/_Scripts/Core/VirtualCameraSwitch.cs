using UnityEngine;
using Cinemachine;

namespace Core
{
    public class VirtualCameraSwitch : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _3rdPersonCamera;
        [SerializeField] private CinemachineVirtualCamera _aimCamera;

        [SerializeField] private Canvas _3rdPersonCanvas;
        [SerializeField] private Canvas _aimCanvas;

        public void SwitchToAimCamera()
        {
            _aimCamera.Priority = _3rdPersonCamera.Priority + 1;
            _aimCanvas.enabled = true;
            _3rdPersonCanvas.enabled = false;
        }

        public void SwitchTo3rdPersonCamera()
        {
            _aimCamera.Priority = _3rdPersonCamera.Priority - 1;
            _aimCanvas.enabled = false;
            _3rdPersonCanvas.enabled = true;
        }
    }
}