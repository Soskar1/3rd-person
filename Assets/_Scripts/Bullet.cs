using UnityEngine;

namespace Core
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private Rigidbody _rb;
        private Transform _transform;

        public Vector3 target { get; set; }

        private void OnEnable() => Destroy(gameObject, _lifeTime);
        private void Awake() => _transform = transform;

        private void FixedUpdate() => _rb.velocity = _transform.forward * _speed * Time.fixedDeltaTime;

        private void OnTriggerEnter(Collider collision)
        {
            Destroy(gameObject);
        }
    }
}