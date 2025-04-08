using UnityEngine;

[CreateAssetMenu(fileName = "New ProjectileData", menuName = "Projectile Data", order = 54)]
public class ProjectileScObject : ScriptableObject
{
    [SerializeField]
    private string projectileName;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Texture2D texture;
    [SerializeField]
    private float lifetime;

    public string ProjectileName { get { return projectileName; } }
    public float Velocity { get { return velocity; } }
    public Texture2D Texture { get { return texture; } }
    public float Lifetime { get { return lifetime; } }
}
