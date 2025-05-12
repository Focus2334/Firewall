using UnityEngine;

namespace ScObjects
{
    [CreateAssetMenu(fileName = "New ProjectileData", menuName = "Projectile Data", order = 54)]
    public class ProjectileScObject : ScriptableObject
    {
        [SerializeField] private string projectileName;
        [SerializeField] private float velocity;
        [SerializeField] private Texture2D texture;
        [SerializeField] private float lifetime;

        public string ProjectileName => projectileName;

        public float BulletSpeed => velocity;

        public Texture2D Texture => texture;

        public float Lifetime => lifetime;
    }
}