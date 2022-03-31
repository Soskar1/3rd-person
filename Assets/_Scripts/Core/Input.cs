using UnityEngine;

namespace Core
{
    public class Input : MonoBehaviour
    {
        private Controls _controls;
        private Vector2 _movementInput;

        public Controls Controls => _controls;
        public Vector2 MovementInput => _movementInput;

        private void Awake() => _controls = new Controls();
        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();

        private void Update() => _movementInput = _controls.Player.Move.ReadValue<Vector2>();
    }
}