using ScObjects;
using UnityEngine;
using Weapon;
using System.Collections.Generic;

public class RocketProjectileScript : MonoBehaviour, IProjectile
{
    [SerializeField] Collider2D projectileCollider;
    [SerializeField] private GameObject fireLight;
    [SerializeField] private GameObject fireParticles;
    [SerializeField] private GameObject fireSound;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private ProjectileScObject projectileSc;

    private float damage = 10;
    private float currentLifetime = 1f;

    private List<ICanTakeDamage> objectsInField = new List<ICanTakeDamage>();

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void SetScObject(ProjectileScObject newProjectileSc)
    {
        projectileSc = newProjectileSc;
        currentLifetime = projectileSc.Lifetime;
    }

    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.position = player.transform.position;
        var newpos = transform.position;
        newpos.z = -0.5f;
        transform.position = newpos;
    }

    void Update()
    {
        currentLifetime -= Time.deltaTime;
        var lifetimeCoefficient = currentLifetime / projectileSc.Lifetime;
        var newColor = spriteRenderer.color;
        newColor.r = 0.4f + (1 - lifetimeCoefficient) * 0.6f;
        spriteRenderer.color = newColor;
        if (currentLifetime < 0f)
        {
            for (int i = 0; i < objectsInField.Count; i++)
            {
                objectsInField[0].TakeDamage(damage);
            }
            var firePosition = transform.position;
            Instantiate(fireLight, firePosition, transform.rotation);
            Instantiate(fireSound, firePosition, transform.rotation);
            Instantiate(fireParticles, firePosition, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collidedObject = collision.gameObject.GetComponent<ICanTakeDamage>();
        var anotherProjectileObject = collision.gameObject.GetComponent<IProjectile>();
        if (!(anotherProjectileObject is null))
        {
            return;
        }
        if (!(collidedObject is null))
        {
            objectsInField.Add(collidedObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var collidedObject = collision.gameObject.GetComponent<ICanTakeDamage>();
        if (!(collidedObject is null))
        {
            objectsInField.Remove(collidedObject);
        }
    }
}
