using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        private GameObject player;
        private Rigidbody2D rb;

        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update() =>
            rb.MovePosition((transform.position + 
                             new Vector3(player.transform.position.x, player.transform.position.y, -10)) / 2);
    }
}