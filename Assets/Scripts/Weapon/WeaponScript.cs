using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject weaponSprite;

    double feedbackTimer = 0;

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Fire();
        }
        if (feedbackTimer > 0)
        {
            feedbackTimer -= Time.deltaTime;
            if (feedbackTimer <= 0)
                weaponSprite.transform.localPosition = new Vector2(0, 0);
        }
    }

    private void Fire()
    {
        feedbackTimer = 0.1;
        weaponSprite.transform.localPosition = new Vector2(0, -0.02f);
        Instantiate(projectile, transform);
    }
}
