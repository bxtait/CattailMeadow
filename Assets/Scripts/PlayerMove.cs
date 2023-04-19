using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
   /* public GameObject catcollect;
    public bool hasSprite = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == gameObject && !hasSprite)
        {
            hasSprite = true;
            catcollect.transform.SetParent(transform);
            catcollect.transform.localPosition = Vector3.zero; // or set to desired position
            catcollect.transform.localRotation = Quaternion.identity; // or set to desired rotation
            // catcollect.SetActive(false);
        }
    } */

    // creating private unachangeable variables to reuse
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    private enum Movement { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        // code for follow function
        
        /* hasSprite = false;
        catcollect.transform.parent = null;

        if (catcollect.transform.parent != transform && !hasSprite) // Check if catcollect should be set active
        {
            catcollect.SetActive(true);
        } */


    }

    // Update is called once per frame
    private void Update()
    {
        // Using Unity input manager names to gain player movement

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        /* if (hasSprite)
        {
            Vector3 targetPosition = transform.position;
             targetPosition.y = catcollect.transform.position.y;
            catcollect.transform.position = targetPosition;
        } */

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    // function to change between idle and running animations
    private void UpdateAnimation()
    {
        Movement state;

        if (dirX > 0f)
        {
            state = Movement.running;
            // to flip sprite on X axis when player moves another way
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = Movement.running;
            sprite.flipX = true;
        }
        else
        {
            state = Movement.idle;
        }
        // check for y velocity
        if (rb.velocity.y > .1f) // upwards force is applied
        {
            state = Movement.jumping;
        }
        else if (rb.velocity.y < -.1f) // downwards force applied
        {
            state = Movement.falling;
        }

        // turn enum into integer value
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}


