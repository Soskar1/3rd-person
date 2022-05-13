using System.Collections;
using UnityEngine;

namespace Core.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private Rigidbody _rb;
        private Transform _transform;
        
        private void OnEnable() => StartCoroutine(LifeRoutine());
        private void OnDisable() => StopCoroutine(LifeRoutine());

        private void Awake() => _transform = transform;

        private void FixedUpdate() => _rb.velocity = _transform.forward * _speed * Time.fixedDeltaTime;

        private void OnTriggerEnter(Collider collision)
        {
            gameObject.SetActive(false);
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(_lifeTime);

            Deactivate();
        }

        private void Deactivate() => gameObject.SetActive(false);
    }
}