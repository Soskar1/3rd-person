using UnityEngine;

namespace Core.Entity
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;

        public void Move(Vector3 direction) => _rigidbody.velocity = new Vector3(_speed * direction.x, _rigidbody.velocity.y, _speed * direction.z);
    }
}