using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    { 
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private EnemyScript enemy;
        private Rigidbody2D enemyRigidbody2D;
        private Rigidbody2D playerRigidbody2D;
        private Vector2 velocity = Vector2.zero;

        private void Start() => enemyRigidbody2D = enemy.GetRigidbody2D;

        protected internal void RotateEnemy()
        {
            var position = enemy.Target.PlayerRigidbody2D.position;
            var direction = (position - enemyRigidbody2D.position).normalized;
            var targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            enemyRigidbody2D.SetRotation(targetAngle);
        }

        protected internal void MoveEnemy()
        {
            var position = enemy.Target.PlayerRigidbody2D.position;
            var direction = (position - enemyRigidbody2D.position).normalized;
            velocity = direction * maxSpeed;
            enemyRigidbody2D.linearVelocity = velocity * acceleration;
        }
    }
}