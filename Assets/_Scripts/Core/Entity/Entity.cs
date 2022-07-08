using UnityEngine;

namespace Core.Entity
{
    public abstract class Entity : MonoBehaviour
    {
        protected IMovement _movement;

        private void Awake() => _movement = GetComponent<IMovement>();

        public abstract void Move();
    }
}