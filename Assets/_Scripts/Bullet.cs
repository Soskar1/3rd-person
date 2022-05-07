using UnityEngine;

namespace Core
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        public Vector3 target { get; set; }

        private void OnEnable() => Destroy(gameObject, _lifeTime);

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<IHittable>() != null)
                Destroy(gameObject);
        }
    }
}