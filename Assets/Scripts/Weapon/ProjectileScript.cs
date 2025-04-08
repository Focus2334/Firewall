using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody2D rigidbod;
    private BoxCollider2D boxCollider;

    [SerializeField]
    private ProjectileScObject projectileSc;

    private float damage = 10;
    private float currentLifetime = 1f;

    public void SetScObject(ProjectileScObject newProjectileSc)
    {
        projectileSc = newProjectileSc;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    private void Start()
    {
        rigidbod = GetComponent<Rigidbody2D>();
        rigidbod.AddForce(transform.up * projectileSc.Velocity);
        currentLifetime = projectileSc.Lifetime;
    }

    private void Update()
    {
        currentLifetime -= Time.deltaTime;
        if (currentLifetime < 0)
        {
            Destroy(rigidbod);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collidedObject = collision.gameObject.GetComponent<ICanTakeDamage>();
        if (!(collidedObject is null))
        {
            collidedObject.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
