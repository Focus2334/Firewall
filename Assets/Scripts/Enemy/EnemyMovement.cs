using UnityEngine;
using UnityEngine.AI;
using Player;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyScript enemy;
        [SerializeField] private float raycastDistance = 15;

        private NavMeshAgent agent;
        private PlayerScript player;
        private float acceleration;
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
            var moveDirection = strafeRightDirection ? 
                new Vector2(directionToPlayer.y, -directionToPlayer.x) :
                new Vector2(-directionToPlayer.y, directionToPlayer.x);
            var velocity = moveDirection * acceleration;
            
            UpdateStrafe();
            
            enemy.EnemyRigidbody2D.linearVelocity = velocity;
        }

        private void UpdateStrafe()
        {
            strafeTimer -= Time.deltaTime;
            if (strafeTimer <= 0)
            {
                strafeRightDirection = !strafeRightDirection;
                strafeTimer = 3;
            }
        }

        public bool IsOnFire()
        {
            var enemyPosition = enemy.EnemyRigidbody2D.position;
            var playerPosition = player.PlayerRigidbody2D.position;
            var direction = (playerPosition - enemyPosition).normalized;
            var raycast = Physics2D.Raycast(enemyPosition, direction, raycastDistance);
            
            return raycast.collider != null;
        }

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