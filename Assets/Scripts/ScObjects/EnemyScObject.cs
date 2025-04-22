using UnityEngine;

namespace ScObjects
{
    [CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 53)]
    public class EnemyScObject : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private MachineScObject machine;
        [SerializeField] private WeaponScObject weapon;
        [SerializeField] private float strafeSpeed;
        [SerializeField] private float strafeTime;
        [SerializeField] private float moveBackDistance;
        [SerializeField] private float moveForwardDistance;

        public string EnemyName => enemyName;
        public MachineScObject Machine => machine;
        public WeaponScObject Weapon => weapon;
        public float StrafeSpeed => strafeSpeed;
        public float StrafeTime => strafeTime;
        public float MoveBackDistance => moveBackDistance;
        public float MoveForwardDistance => moveForwardDistance;
    }
}