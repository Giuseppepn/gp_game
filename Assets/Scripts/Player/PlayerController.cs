using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private int coins = 0;
    private PlayerInputs playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private Sprite chestOpened;


    private void Awake()
    {
        playerControls = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        //patata
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
        checkDirection();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }


    private void checkDirection()
    {
        if (movement.x < 0)
        {
            
            mySpriteRender.flipX = true;
        }
        else if (movement.x > 0)
        {
            
            mySpriteRender.flipX = false;
        }
    }


    public void checkChestCollision()
    {

    }


}
