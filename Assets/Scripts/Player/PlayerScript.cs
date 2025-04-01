using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInput playerInput;
    private Rigidbody2D playerRigidbody2D;

    public Rigidbody2D PlayerRigidbody2D { get { return playerRigidbody2D; } }

    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerMovement.MovePlayer(playerInput.GetMovementInput());
        playerMovement.RotatePlayer(playerInput.GetMousePosition());
    }
}
