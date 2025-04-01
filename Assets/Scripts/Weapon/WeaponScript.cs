using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject weaponSprite;

    private double feedbackTimer = 0;

    private WeaponScObject weaponSc;

    public void SetScObject(WeaponScObject newWeaponSc)
    {
        weaponSc = newWeaponSc;
    }

    private void Start()
    {

    }

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
        var createdProjectile = Instantiate(projectile, transform);
        createdProjectile.GetComponent<ProjectileScript>().SetScObject(weaponSc.Projectile);
    }
}
