using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerScript player;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;

        private Rigidbody2D playerRigidbody2D;

        private void Start() => playerRigidbody2D = player.PlayerRigidbody2D;

        public void MovePlayer(Vector2 input)
        {
            var velocity = playerRigidbody2D.linearVelocity + input.normalized * acceleration;
            if (velocity.magnitude < maxSpeed)
                playerRigidbody2D.linearVelocity = velocity;
        }

        public void RotatePlayer(Vector3 input)
        {
            var rotation = input - player.transform.position;
            var rotationZAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
            playerRigidbody2D.SetRotation(rotationZAngle);
        }
    }
}