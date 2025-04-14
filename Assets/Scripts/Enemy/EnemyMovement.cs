using UnityEngine;
using UnityEngine.AI;
using Player;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    { 
        [SerializeField] private PlayerScript player;
        [SerializeField] private EnemyScript enemy;

        private NavMeshAgent agent;
        private float acceleration;

        private void Start()
        {
            agent = enemy.Agent;
            agent.updateUpAxis = false;
            acceleration = agent.acceleration;
        }

        private void RotateEnemy()
        {
            var enemyPosition = enemy.EnemyRigidbody2D.position;
            var playerPosition = player.PlayerRigidbody2D.position;
            var direction = (playerPosition - enemyPosition).normalized;
            var targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            enemy.EnemyRigidbody2D.SetRotation(targetAngle);
        }

        private float DistanceToTarget()
        {
            var enemyPosition = enemy.EnemyRigidbody2D.position;
            var playerPosition = player.PlayerRigidbody2D.position;
            var distanceToPlayer = Vector2.Distance(playerPosition, enemyPosition);
            
            return distanceToPlayer;
        }

        private void Strafe()
        {
            var enemyPosition = enemy.EnemyRigidbody2D.position;
            var playerPosition = player.PlayerRigidbody2D.position;
            var directionToPlayer = (playerPosition - enemyPosition).normalized;
            var moveDirection = new Vector2(directionToPlayer.y, -directionToPlayer.x);
            var velocity = moveDirection * acceleration;
            
            enemy.EnemyRigidbody2D.linearVelocity = velocity;
        }

        public bool IsOnFire() => DistanceToTarget() <= 5;

        private void NavMeshMoveEnemy() => agent.SetDestination(player.transform.position);

        protected internal void MoveUpdate()
        {
            if (DistanceToTarget() > 5)
                NavMeshMoveEnemy();
            else
                Strafe();
            
            RotateEnemy();
        }
    }
}