using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Entity
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Input _input;
        [SerializeField] private ThirdPerson _thirdPerson;
        [SerializeField] private Jump _jump;
        [SerializeField] private Shooting _shooting;
        [SerializeField] private Aim _aim;

        [Header("Animation")]
        [SerializeField] private Animator _animator;
        private bool _isShooting = false;

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

        private void Update()
        {
            _thirdPerson.SetMovementInput(_input.MovementInput);
            _animator.SetFloat("Speed", Mathf.Abs(_input.MovementInput.magnitude));

            if (_isShooting)
                _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10));
            else
                _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 0f, Time.deltaTime * 10));
        }

        private void StartAim(InputAction.CallbackContext ctx)
        {
            _aim.StartAim();
            _thirdPerson.SetIsAiming(false);
            _input.Controls.Player.Shoot.performed += Shoot;
            _isShooting = true;
        }

        private void CancelAim(InputAction.CallbackContext ctx)
        {
            _aim.CancelAim();
            _thirdPerson.SetIsAiming(true);
            _input.Controls.Player.Shoot.performed -= Shoot;
            _isShooting = false;
        }

        private void Shoot(InputAction.CallbackContext ctx) => _shooting.Shoot();
    }
}