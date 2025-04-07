using UnityEngine;

namespace Enemy
{
    public abstract class EnemyAbstract : MonoBehaviour
    {
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private WeaponScript weapon;
        public Rigidbody2D GetRigidbody2D { get; private set; }

        protected void Start()
        {
            GetRigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected internal void Update()
        {
            movement.RotateEnemy(); 
            movement.MoveEnemy();   
        }

        protected abstract void PerformAction();
    }
}   