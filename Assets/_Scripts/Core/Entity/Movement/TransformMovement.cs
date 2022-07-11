using UnityEngine;

namespace Core.Entity
{
    public class TransformMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _speed;
        private Transform _transform;

        private void Awake() => _transform = transform;

        public void Move(Vector3 direction) => _transform.Translate(direction * _speed * Time.deltaTime);
    }
}