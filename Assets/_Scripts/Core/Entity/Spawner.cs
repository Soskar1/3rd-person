using System;
using UnityEngine;

namespace Core.Entity
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Target _target;
        [SerializeField] private Vector3 _direction;

        [SerializeField] private float _spawnTime;
        private bool _timerStarted = false;

        private void OnEnable() => _timerStarted = false;

        private void Update()
        {
            if (_timerStarted)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(_spawnTime, () => { Spawn(); _timerStarted = false; }));
        }

        private void Spawn()
        {
            Target targetInstance = Instantiate(_target, transform.position, Quaternion.identity);
            targetInstance.Direction = _direction;
        }
    }
}