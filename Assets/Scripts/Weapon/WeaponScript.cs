using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject weaponSprite;
    [SerializeField] private GameObject fireLight;
    [SerializeField] private ParticleSystem fireParticles;

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
            {
                fireParticles.Stop();
                weaponSprite.transform.localPosition = new Vector2(0, 0);
            }

                
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
        fireParticles.Play();
        feedbackTimer = 0.05;
        weaponSprite.transform.localPosition = new Vector2(0, -0.02f);
        var firePosition = transform.position + transform.up * weaponSc.Offset;
        var fireLightPosition = firePosition;
        fireLightPosition.z = -0.5f;
        var createdProjectile = Instantiate(projectile, firePosition, transform.rotation);
        var createdFireLight = Instantiate(fireLight, fireLightPosition, transform.rotation);
        var createdProjectileScript = createdProjectile.GetComponent<ProjectileScript>();
        createdProjectileScript.SetScObject(weaponSc.Projectile);
        createdProjectileScript.SetDamage(weaponSc.Damage);
        fireRateTimer = weaponSc.FireRate;
        return true;
    }
}
