using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody2D rigidbod;
    BoxCollider2D boxCollider;
    private void Start()
    {
        rigidbod = GetComponent<Rigidbody2D>();
        rigidbod.AddForce(transform.up * 1000);
    }

    private void Update()
    {
       
    }
}
