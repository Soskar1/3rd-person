using UnityEngine;

namespace Core.Entity
{
    public class ThirdPerson : MonoBehaviour
    {
        private Transform _transform;
        private IMovement _movement;

        [Header("Movement")]
        [SerializeField] private Input _input;
        [SerializeField] private Jump _jump;

        [Header("Rotation")]
        [SerializeField] private Transform _camera;
        [SerializeField] private float _turnSmoothTime;
        private float _turnSmoothVelocity;

        private void Awake()
        {
            _transform = transform;
            _movement = GetComponent<IMovement>();
        }

        private void OnEnable() => _input.Controls.Player.Jump.performed += _jump.TryJump;
        private void OnDisable() => _input.Controls.Player.Jump.performed -= _jump.TryJump;

        private void FixedUpdate()
        {
            if (_input.MovementInput.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(_input.MovementInput.x, _input.MovementInput.y) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                _transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 movementDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
                _movement.Move(movementDirection.normalized);
            }
            else
            {
                _movement.Move(Vector3.zero);
            }
        }
    }
}