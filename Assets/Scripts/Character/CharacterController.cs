using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool jump = false;
    private bool doubleJump = false;
    public LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling, doubleJump };

    public AudioSource jumpSoundEffect;

    private float horizontal = 0f;
    public float jumpForce = 8f;
    public float doubleJumpForce = 6f;
    public float moveSpeed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            if (!jump && !doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jump = true;
                jumpSoundEffect.Play();

            }
            else if (jump && !doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                doubleJump = true;
                jump = false;
                jumpSoundEffect.Play();
            }
        }
        if (rb.velocity.y > -.1f && rb.velocity.y < .1f && IsGrounded())
        {
            jump = false;
            doubleJump = false;
        }
        UpdateAnimationState();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           
        }
        
        if (context.canceled)
        {
          
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           
        }
    }
    void UpdateAnimationState()
    {
        MovementState state;
        if (horizontal > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f && jump && !doubleJump)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y > .1f && doubleJump && !jump)
        {
            state = MovementState.doubleJump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
