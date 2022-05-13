using Core.Entity;
using Core.Pool;
using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private BulletPool _bulletPool;

        private void Awake()
        {
            _bulletPool.InitializePool();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _player.gameObject.SetActive(true);
        }
    }
}