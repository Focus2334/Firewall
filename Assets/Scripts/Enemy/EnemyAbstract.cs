using Player;
using UnityEngine;
using UnityEngine.AI;
using Weapon;
using ScObjects;

namespace Enemy
{
    public abstract class EnemyAbstract : MonoBehaviour, ICanTakeDamage
    {
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private WeaponScript weapon;
        [SerializeField] private WeaponScObject weaponScObject;
        [SerializeField] protected internal EnemyScObject enemySc;
        [SerializeField] private Rigidbody2D enemyRigidbody2D;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private PlayerScript target;
        [SerializeField] private GameObject points;
        
        private float currentHp;
        
        public Rigidbody2D EnemyRigidbody2D => enemyRigidbody2D;
        
        public NavMeshAgent Agent => agent;
        
        public PlayerScript Target { get => target; set => target = value; }
        
        public void SetScObject(EnemyScObject newEnemySc) => enemySc = newEnemySc;

        public EnemyScObject EnemySc => enemySc;

        protected void Start()
        {
            currentHp = enemySc.Machine.HitPoints;
            weapon.SetScObject(enemySc.Weapon);
            gameObject.GetComponent<SpriteRenderer>().sprite = enemySc.Machine.Sprite;
        }

        protected internal void Update()
        {
            movement.CheckIsOnFire();
            movement.MoveUpdate();
            if (movement.IsOnFire)
                weapon.Fire();
        }

        public bool TakeDamage(float value)
        {
            currentHp -= value;
            if (currentHp <= 0) 
                Death();
            return true;
        }
        
        private bool Death()
        {
            Instantiate(points, transform.position, transform.rotation);
            Destroy(gameObject);
            return true;
        }
    }
}   