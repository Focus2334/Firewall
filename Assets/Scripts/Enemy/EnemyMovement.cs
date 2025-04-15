using UnityEngine;
using UnityEngine.AI;
using Player;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyScript enemy;

        private NavMeshAgent agent;
        private float acceleration;
        private PlayerScript player;

        private float strafeTimer = 3;
        private bool strafeRightDirection = true;

        private void Start()
        {
            agent = enemy.Agent;
            agent.updateUpAxis = false;
            acceleration = agent.acceleration;
            player = enemy.Target;
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
            var playerPosition = enemy.Target.PlayerRigidbody2D.position;
            var distanceToPlayer = Vector2.Distance(playerPosition, enemyPosition);
            
            return distanceToPlayer;
        }

        private void Strafe()
        {
            var enemyPosition = enemy.EnemyRigidbody2D.position;
            var playerPosition = player.PlayerRigidbody2D.position;
            var directionToPlayer = (playerPosition - enemyPosition).normalized;
            var moveDirection = new Vector2(-directionToPlayer.y, directionToPlayer.x);
            if (strafeRightDirection)
                moveDirection = new Vector2(directionToPlayer.y, -directionToPlayer.x);
            var velocity = moveDirection * acceleration;
            strafeTimer -= Time.deltaTime;
            if (strafeTimer <= 0)
            {
                strafeRightDirection = !strafeRightDirection;
                strafeTimer = 3;
            }

            enemy.EnemyRigidbody2D.linearVelocity = velocity;
        }

        public bool IsOnFire() => DistanceToTarget() <= 15;

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