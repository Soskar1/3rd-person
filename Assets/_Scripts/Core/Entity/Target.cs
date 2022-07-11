using Core.HUD;
using UnityEngine;

namespace Core.Entity
{
    public class Target : Entity
    {
        private Vector3 _direction = Vector3.zero;
        private Score _score;

        public Vector3 Direction { set => _direction = value; }

        private void Start() => _score = FindObjectOfType<Score>();

        private void Update()
        {
            if (_direction == Vector3.zero)
                return;

            Move();
        }

        public override void Move() => _movement.Move(_direction);

        private void OnDestroy() => _score.AddPoint();
    }
}