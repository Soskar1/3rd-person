using Core.Weapons;
using UnityEngine;

namespace Core.Entity
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Aim _aim;
        [SerializeField] private Weapon _activeWeapon;

        public void Shoot() => _activeWeapon.Fire(_aim.MouseWorldPosition);
    }
}