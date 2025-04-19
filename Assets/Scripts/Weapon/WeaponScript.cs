using UnityEngine;
using ScObjects;

namespace Weapon
{
    public class WeaponScript : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private GameObject weaponSprite;
        [SerializeField] private GameObject fireLight;
        [SerializeField] private ParticleSystem fireParticles;

        private System.Random random = new System.Random();
        private double feedbackTimer = 0;
        private double fireRateTimer = 0;
        private double reloadTimer = 0;

        private int currentProjectilesCount = 0;
        private WeaponScObject weaponSc;

        public bool Reloading { get; private set; }

        public double ReloadTimer
        {
            get { return reloadTimer; }
        }

        public void SetScObject(WeaponScObject newWeaponSc)
        {
            weaponSc = newWeaponSc;
            currentProjectilesCount = weaponSc.MagSize;
        }

        private void Start()
        {

        }

        private void Update()
        {
            if (feedbackTimer > 0)
            {
                feedbackTimer -= Time.deltaTime;
                if (feedbackTimer <= 0)
                {
                    fireParticles.Stop();
                    weaponSprite.transform.localPosition = new Vector2(0, 0);
                }
            }

            if (fireRateTimer > 0)
            {
                fireRateTimer -= Time.deltaTime;
            }

            if (reloadTimer > 0)
            {
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0)
                {
                    Reloading = false;
                    currentProjectilesCount = weaponSc.MagSize;
                }
            }
        }

        public void StartReloadWeapon()
        {
            if (!Reloading && currentProjectilesCount != weaponSc.MagSize)
            {
                Reloading = true;
                reloadTimer = weaponSc.ReloadTime;
            }
        }

        public int Fire()
        {
            if (fireRateTimer > 0 || currentProjectilesCount <= 0)
            {
                return currentProjectilesCount;
            }

            fireParticles.Play();
            feedbackTimer = 0.05;
            weaponSprite.transform.localPosition = new Vector2(0, -0.02f);
            var firePosition = transform.position + transform.up * weaponSc.Offset;
            var fireLightPosition = firePosition;
            fireLightPosition.z = -0.5f;
            var projectileRotation = transform.rotation;
            var projectileRotationEuler = transform.rotation.eulerAngles;
            var scatter = Random.Range(-weaponSc.WeaponScatter, weaponSc.WeaponScatter);
            projectileRotation.eulerAngles = new Vector3(0, 0, projectileRotationEuler.z + scatter);
            var createdProjectile = Instantiate(projectile, firePosition, projectileRotation);
            var createdFireLight = Instantiate(fireLight, fireLightPosition, transform.rotation);
            var createdProjectileScript = createdProjectile.GetComponent<ProjectileScript>();
            createdProjectileScript.SetScObject(weaponSc.Projectile);
            createdProjectileScript.SetDamage(weaponSc.Damage);
            fireRateTimer = weaponSc.FireRate;
            currentProjectilesCount--;
            if (currentProjectilesCount == 0)
            {
                StartReloadWeapon();
            }

            return currentProjectilesCount;
        }
    }
}