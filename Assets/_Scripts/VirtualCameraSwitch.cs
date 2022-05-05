using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;

namespace Core
{
    public class VirtualCameraSwitch : MonoBehaviour
    {
        [SerializeField] private Input _input;

        [SerializeField] private CinemachineVirtualCamera _3rdPersonCamera;
        [SerializeField] private CinemachineVirtualCamera _aimCamera;

        private void OnEnable()
        {
            _input.Controls.Player.Aim.performed += _ => StartAim();
            _input.Controls.Player.Aim.canceled += _ => CancelAim();
        }

        private void OnDisable()
        {
            _input.Controls.Player.Aim.performed -= _ => StartAim();
            _input.Controls.Player.Aim.canceled -= _ => CancelAim();
        }

        private void StartAim()
        {
            _aimCamera.Priority = _3rdPersonCamera.Priority + 1;
        }

        private void CancelAim()
        {
            _aimCamera.Priority = _3rdPersonCamera.Priority - 1;
        }
    }
}