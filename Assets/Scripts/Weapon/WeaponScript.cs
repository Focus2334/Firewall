using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject weaponSprite;

    private double feedbackTimer = 0;
    private double fireRateTimer = 0;

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
        if (feedbackTimer > 0)
        {
            feedbackTimer -= Time.deltaTime;
            if (feedbackTimer <= 0)
                weaponSprite.transform.localPosition = new Vector2(0, 0);
        }

        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
    }

    public bool Fire()
    {
        if (fireRateTimer > 0) {
            return false;
        }
        feedbackTimer = 0.05;
        weaponSprite.transform.localPosition = new Vector2(0, -0.02f);
        var createdProjectile = Instantiate(projectile, transform);
        var createdProjectileScript = createdProjectile.GetComponent<ProjectileScript>();
        createdProjectileScript.SetScObject(weaponSc.Projectile);
        createdProjectileScript.SetDamage(weaponSc.Damage);
        fireRateTimer = weaponSc.FireRate;
        return true;
    }
}
