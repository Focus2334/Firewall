using UnityEngine;

namespace Enemy
{
    public abstract class EnemyAbstract : MonoBehaviour, ICanTakeDamage
    {
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private WeaponScript weapon;
        [SerializeField] private EnemyScObject enemySc;
        [SerializeField] private PlayerScript target;
        private float currentHp;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        public Rigidbody2D GetRigidbody2D { get { return _rigidbody2D; } }
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
            
            movement.MoveEnemy();
            movement.RotateEnemy();
            weapon.Fire();
        }

        public bool TakeDamage(float value)
        {
            currentHp -= value;
            if (currentHp <= 0)
            {
                Death();
            }
            return true;
        }
        private bool Death()
        {
            Destroy(gameObject);
            return true;
        }
        protected abstract void PerformAction();
    }
}   