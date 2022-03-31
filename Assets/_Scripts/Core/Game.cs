using Core.Entity;
using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _player.gameObject.SetActive(true);
        }
    }
}