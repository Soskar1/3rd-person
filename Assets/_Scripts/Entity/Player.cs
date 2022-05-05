using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Entity
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Input _input;

        private void OnEnable()
        {
            //_input.Controls.Player.Aim.performed += Aim;
            //_input.Controls.Player.Aim.canceled += NotAim;
        }

        private void OnDisable()
        {
            //_input.Controls.Player.Aim.performed -= Aim;
            //_input.Controls.Player.Aim.canceled -= NotAim;
        }
    }
}