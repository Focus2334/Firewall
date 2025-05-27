using UnityEngine;
using UnityEngine.Audio;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        private GameObject player;
        private Rigidbody2D rb;
        [SerializeField] private AudioResource kaput;

        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody2D>();
            var audio = GetComponent<AudioSource>();
            if (CurrentValues.FunnySettings)
            {
                audio.resource = kaput;
                audio.Play();
            }
        }

        private void Update() =>
            rb.MovePosition((transform.position + 
                             new Vector3(player.transform.position.x, player.transform.position.y, -10)) / 2);
    }
}