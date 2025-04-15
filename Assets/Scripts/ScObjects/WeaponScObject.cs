using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 52)]
public class WeaponScObject : ScriptableObject
{
    [SerializeField]
    private string weaponName;
    [SerializeField]
    private Texture2D texture;
    [SerializeField]
    private float weaponScatter;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float fire_rate;
    [SerializeField]
    private int magSize;
    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private ProjectileScObject projectile;
    [SerializeField]
    private float offset;

    public string WeaponName { get { return weaponName; } }
    public Texture2D Texture { get { return texture; } }
    public float Damage { get { return damage; } }
    public int MagSize { get { return magSize; } }
    public float ReloadTime { get { return reloadTime; } }
    public float FireRate { get { return fire_rate; } }
    public ProjectileScObject Projectile { get { return projectile; } }
    public float Offset { get { return offset; } }

    public float WeaponScatter { get { return weaponScatter; } }
}
