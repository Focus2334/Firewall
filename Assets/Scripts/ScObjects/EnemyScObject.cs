using UnityEngine;

namespace ScObjects
{
    [CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 53)]
    public class EnemyScObject : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private MachineScObject machine;
        [SerializeField] private WeaponScObject weapon;

        public string EnemyName => enemyName;
        public MachineScObject Machine => machine;
        public WeaponScObject Weapon => weapon;
    }
}