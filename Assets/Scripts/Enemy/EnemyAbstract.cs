using UnityEngine;

namespace Enemy
{
    public abstract class EnemyAbstract : MonoBehaviour, ICanTakeDamage
    {
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private WeaponScript weapon;
        [SerializeField] private EnemyScObject enemySc;
        private float currentHp;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        public Rigidbody2D GetRigidbody2D { get { return _rigidbody2D; } }

        protected void Start()
        {
            currentHp = enemySc.Machine.HitPoints;
        }

        protected internal void Update()
        {
            
            movement.MoveEnemy();
            movement.RotateEnemy();
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
            Destroy(gameObject);
            return true;
        }
        protected abstract void PerformAction();
    }
}   