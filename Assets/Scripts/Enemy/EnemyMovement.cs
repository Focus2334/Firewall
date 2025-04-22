using System.Linq;
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
        private float strafeTimer;
        private float onFireTimer = 0.1f;
        private bool strafeRightDirection = true;
        private bool isOnfire = false;

        public bool IsOnfire { get { return isOnfire; } }

        private void Start()
        {
            agent = enemy.Agent;
            agent.updateUpAxis = false;
            
            player = enemy.Target;
            strafeTimer = enemy.EnemySc.StrafeTime;
            agent.speed = enemy.EnemySc.Machine.MaxSpeed;
            agent.acceleration = enemy.EnemySc.Machine.Acceleration * 100;
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
                transform.right :
                -transform.right;
            var velocity = moveDirection * enemy.EnemySc.StrafeSpeed;
            agent.isStopped = true;
            UpdateStrafe();
            
            enemy.EnemyRigidbody2D.linearVelocity = velocity;
        }

        private void UpdateStrafe()
        {
            strafeTimer -= Time.deltaTime;
            if (strafeTimer <= 0)
            {
                strafeRightDirection = !strafeRightDirection;
                strafeTimer = enemy.EnemySc.StrafeTime;
            }
        }

        public void CheckIsOnFire()
        {
            var enemyPosition = enemy.EnemyRigidbody2D.position;
            var playerPosition = player.PlayerRigidbody2D.position;
            var direction = (playerPosition - enemyPosition).normalized;
            var raycast = Physics2D.RaycastAll(enemyPosition, direction, raycastDistance);

            raycast = raycast.Where(ray => ray.collider.tag != "Enemy").ToArray();
            if (raycast.FirstOrDefault().collider.tag == "Player")
            {
                onFireTimer = 0.1f;
                isOnfire = true;
            }
            else
            {
                onFireTimer -= Time.deltaTime;
                if (onFireTimer <= 0)
                    isOnfire = false;
            }
        }

        public void MoveBack()
        {
            var enemyPosition = enemy.EnemyRigidbody2D.position;
            var playerPosition = player.PlayerRigidbody2D.position;
            var directionToPlayer = (playerPosition - enemyPosition).normalized;
            var velocity = -directionToPlayer * enemy.EnemySc.StrafeSpeed;
            agent.isStopped = true;
            enemy.EnemyRigidbody2D.linearVelocity = velocity;
        }

        private void NavMeshMoveEnemy() => agent.SetDestination(player.transform.position);

        protected internal void MoveUpdate()
        {
            RotateEnemy();
            if (!isOnfire || DistanceToTarget() > enemy.EnemySc.MoveForwardDistance)
            {
                agent.isStopped = false;
                NavMeshMoveEnemy();
            }
            else if (isOnfire && DistanceToTarget() < enemy.EnemySc.MoveBackDistance)
                MoveBack();
            else
                Strafe();
        }
    }
}