using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public abstract class EnemyAbstract : MonoBehaviour, ICanTakeDamage
    {
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private WeaponScript weapon;
        [SerializeField] private WeaponScObject weaponScObject;
        [SerializeField] private EnemyScObject enemySc;
        [SerializeField] private Rigidbody2D enemyRigidbody2D;
        [SerializeField] private NavMeshAgent agent;
        
        private float currentHp;
        
        public Rigidbody2D EnemyRigidbody2D => enemyRigidbody2D;
        
        public NavMeshAgent Agent => agent;
        [SerializeField] private PlayerScript target;
        private float currentHp;
        public Rigidbody2D GetRigidbody2D { get { return enemyRigidbody2D; } }
        public PlayerScript Target { get { return target; } set { target = value; } }
        public void SetScObject(EnemyScObject newEnemySc)
        {
            enemySc = newEnemySc;
        }

        protected void Start()
        {
            currentHp = enemySc.Machine.HitPoints;
            weapon.SetScObject(enemySc.Weapon);
        }

        protected internal void Update()
        {
            movement.MoveUpdate();
            if (movement.IsOnFire())
                weapon.Fire();
        }

        public bool TakeDamage(float value)
        {
            currentHp -= value;
            if (currentHp <= 0) {
                Death();
            }
            return true;
        }
        
        private bool Death()
        {
            Destroy(gameObject);
            return true;
        }
    }
}   