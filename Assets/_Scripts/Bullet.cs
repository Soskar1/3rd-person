using UnityEngine;

namespace Core
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        public Vector3 target { get; set; }
        public bool hit { get; set; }

        private void OnEnable() => Destroy(gameObject, _lifeTime);

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
            if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}