using UnityEngine;

namespace Enemy
{
    public abstract class EnemyAbstract : MonoBehaviour, ICanTakeDamage
    {
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private WeaponScript weapon;
        [SerializeField] private EnemyScObject enemySc;
        private float currentHp;
        public Rigidbody2D GetRigidbody2D { get; private set; }

        protected void Start()
        {
            GetRigidbody2D = GetComponent<Rigidbody2D>();
            currentHp = enemySc.Machine.HitPoints;
        }

        protected internal void Update()
        {
            movement.RotateEnemy(); 
            movement.MoveEnemy();   
        }

        public bool TakeDamage(float value)
        {
            currentHp -= value;
            if (currentHp <= 0)
            {
                Death();
            }
            print(currentHp);
            return true;
        }
        private bool Death()
        {
            print("enemy dead");
            return true;
        }
        protected abstract void PerformAction();
    }
}   