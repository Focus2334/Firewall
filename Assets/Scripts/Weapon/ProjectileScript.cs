using Enemy;
using Player;
using ScObjects;
using UnityEngine;

namespace Weapon
{
    public class ProjectileScript : MonoBehaviour, IProjectile
    {
        private Rigidbody2D projectileRigidbody;
        private BoxCollider2D boxCollider;

        [SerializeField] private ProjectileScObject projectileSc;

        private float damage = 10;
        private float currentLifetime = 1f;

        public void SetScObject(ProjectileScObject newProjectileSc) => projectileSc = newProjectileSc;

        public void SetDamage(float newDamage) => damage = newDamage;

        private void Start()
        {
            projectileRigidbody = GetComponent<Rigidbody2D>();
            projectileRigidbody.linearVelocity = transform.up * projectileSc.BulletSpeed;
            currentLifetime = projectileSc.Lifetime;
        }

        private void Update()
        {
            currentLifetime -= Time.deltaTime;
            if (currentLifetime < 0) 
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var collidedObject = collision.gameObject.GetComponent<ICanTakeDamage>();
            var anotherProjectileObject = collision.gameObject.GetComponent<IProjectile>();
            if (anotherProjectileObject is not null)
                return;

            // if (collidedObject is not null) 
            //     collidedObject.TakeDamage(damage);
            
            if ((collidedObject is PlayerScript && projectileSc.IsEnemiesProj) ||
                (collidedObject is EnemyScript && !projectileSc.IsEnemiesProj))
                collidedObject.TakeDamage(damage);

            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

        }
    }
}