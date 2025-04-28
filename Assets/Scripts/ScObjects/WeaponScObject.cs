using UnityEngine;

namespace ScObjects
{
    [CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 52)]
    public class WeaponScObject : ScriptableObject
    {
        [SerializeField] private string weaponName;
        [SerializeField] private Texture2D texture;
        [SerializeField] private float weaponScatter;
        [SerializeField] private float damage;
        [SerializeField] private float fireRate;
        [SerializeField] private int magSize;
        [SerializeField] private float reloadTime;
        [SerializeField] private ProjectileScObject projectile;
        [SerializeField] private float offset;

        public string WeaponName => weaponName;

        public Texture2D Texture => texture;

        public float Damage => damage;

        public int MagSize => magSize;

        public float ReloadTime => reloadTime;

        public float FireRate => fireRate;

        public ProjectileScObject Projectile => projectile;

        public float Offset => offset;

        public float WeaponScatter => weaponScatter;
    }
}