using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerScript player;
        [SerializeField] private ParticleSystem particles;

        private Rigidbody2D playerRigidbody2D;

        private float maxSpeed;
        private float acceleration;

        private void Start()
        {
            playerRigidbody2D = player.PlayerRigidbody2D;
            maxSpeed = player.MachineScObject.MaxSpeed;
            acceleration = player.MachineScObject.Acceleration;
        }

        public void MovePlayer(Vector2 input)
        {
            var velocity = playerRigidbody2D.linearVelocity + input.normalized * acceleration * Time.deltaTime * 100;
            if (velocity.magnitude < maxSpeed)
                playerRigidbody2D.linearVelocity = velocity;
        }

        public void RotatePlayer(Vector3 input)
        {
            var rotation = input - player.transform.position;
            var rotationZAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
            playerRigidbody2D.SetRotation(rotationZAngle);
        }

        public void Dash()
        {
            player.AddStamina(-player.MachineScObject.DashStaminaNeed);
            maxSpeed = player.MachineScObject.MaxDashSpeed;
            acceleration = player.MachineScObject.DashAccel;
            var emission = particles.emission;
            emission.rateOverTime = 800;
        }

        public void FinishDash()
        {
            maxSpeed = player.MachineScObject.MaxSpeed;
            acceleration = player.MachineScObject.Acceleration;
            var emission = particles.emission;
            emission.rateOverTime = 300;
        }
    }
}