using UnityEngine;

namespace Core.Entity
{
    public class Grounded : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _groundLayers;

        public bool Check()
        {
            return Physics.CheckSphere(_groundCheck.position, _radius, _groundLayers);
        }
    }
}