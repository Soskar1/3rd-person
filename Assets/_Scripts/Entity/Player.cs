using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Entity
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Input _input;
        [SerializeField] private Jump _jump;
        [SerializeField] private Shooting _shooting;
        [SerializeField] private VirtualCameraSwitch _switch;

        private void OnEnable()
        {
            _input.Controls.Player.Aim.performed += StartAim;
            _input.Controls.Player.Aim.canceled += CancelAim;
            _input.Controls.Player.Jump.performed += _jump.TryJump;
        }

        private void OnDisable()
        {
            _input.Controls.Player.Aim.performed -= StartAim;
            _input.Controls.Player.Aim.canceled -= CancelAim;
            _input.Controls.Player.Jump.performed -= _jump.TryJump;
        }

        private void StartAim(InputAction.CallbackContext ctx)
        {
            _switch.StartAim();
            _input.Controls.Player.Shoot.performed += Shoot;
        }

        private void CancelAim(InputAction.CallbackContext ctx)
        {
            _switch.CancelAim();
            _input.Controls.Player.Shoot.performed -= Shoot;
        }

        private void Shoot(InputAction.CallbackContext ctx) => _shooting.Shoot();
    }
}