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
        
        protected void Start()
        {
            currentHp = enemySc.Machine.HitPoints;
            weapon.SetScObject(weaponScObject);
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
            if (currentHp <= 0) 
                Death();
            print(currentHp);
            return true;
        }
        
        private bool Death()
        {
            print("enemy dead");
            Destroy(gameObject);
            return true;
        }
    }
}   