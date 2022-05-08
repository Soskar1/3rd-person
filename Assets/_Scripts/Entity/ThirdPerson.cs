using UnityEngine;

namespace Core.Entity
{
    public class ThirdPerson : MonoBehaviour
    {
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _walkSpeed;
        private float _targetSpeed;

        [Header("Rotation")]
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _turnSmoothTime;
        private float _targetRotation;
        private float _turnSmoothVelocity;

        private Transform _transform;
        private Vector3 _movementInput;
        private IMovement _movement;

        private bool _isAiming = true;

        private void Awake()
        {
            _movement = GetComponent<IMovement>();
            _transform = transform;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_movementInput.magnitude > 0.1f)
            {
                _targetSpeed = _isAiming ? _runSpeed : _walkSpeed;

                _targetRotation = Mathf.Atan2(_movementInput.x, _movementInput.y) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(_transform.eulerAngles.y, _targetRotation, ref _turnSmoothVelocity, _turnSmoothTime);

                if (_isAiming)
                    _transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }
            else
            {
                _targetSpeed = 0;
            }
            
            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

            _movement.Move(targetDirection.normalized * _targetSpeed * Time.fixedDeltaTime);
        }

        public void SetMovementInput(Vector3 newMovementInput) => _movementInput = newMovementInput;
        public void SetIsAiming(bool newIsAiming) => _isAiming = newIsAiming;
    }
}