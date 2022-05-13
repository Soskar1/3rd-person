using UnityEngine;

namespace Core.Entity
{
    public interface IMovement
    {
        void Move(Vector3 direction);
    }
}