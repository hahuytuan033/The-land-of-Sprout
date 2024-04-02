using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private float moveSpeed = 2f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;

    private Vector2 lastMove;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();

        float inputX = movement.x;
        float inputY = movement.y;

        myAnimator.SetFloat("x", inputX);
        myAnimator.SetFloat("y", inputY);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));

        if (movement != Vector2.zero)
        {
            myAnimator.SetBool("IsMoving", true);
            lastMove = movement;
        }
        else
        {
            myAnimator.SetBool("IsMoving", false);
            myAnimator.SetFloat("lastMoveX", lastMove.x);
            myAnimator.SetFloat("lastMoveY", lastMove.y);
        }
    }
}
