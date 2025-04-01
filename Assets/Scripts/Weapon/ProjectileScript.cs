using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody2D rigidbod;
    private BoxCollider2D boxCollider;

    private ProjectileScObject projectileSc;

    public void SetScObject(ProjectileScObject newProjectileSc)
    {
        projectileSc = newProjectileSc;
    }

    private void Start()
    {
        rigidbod = GetComponent<Rigidbody2D>();
        rigidbod.AddForce(transform.up * projectileSc.Velocity);
    }

    private void Update()
    {
        
    }
}
