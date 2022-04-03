using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float moveSpeed = 7f;
    private float jumpForce = 12f;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private enum MovementState { idle, running, jumping, falling } /* Behövs för att få variabler som kan enkelt användas inom animatorn i unity, gör det också enklare att byta mellan olika animationer */
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) // Ifall desa två conditions uppmöts så utförs funktionen //
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationUpdate();
    }
        private void UpdateAnimationUpdate()
        {  

        MovementState state;   
        
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
                state = MovementState.running;
                sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
         
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
             state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); // Skapar en "låda" runt spelaren som har samma form som boxcollidern, lådan kan checka om något overidar med lådan isåfall är den på marken //
    }
}
