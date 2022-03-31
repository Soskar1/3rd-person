using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Entity
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Grounded))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Grounded _grounded;
        [SerializeField] private float _jumpForce;

        public void TryJump(InputAction.CallbackContext ctx)
        {
            if (!_grounded.Check()) return;

            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }
    }
}