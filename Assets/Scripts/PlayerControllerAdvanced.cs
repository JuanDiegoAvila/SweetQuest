using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAdvanced : MonoBehaviour
{
    public float jumpForce = 5f;
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    public bool aturdido = false;
    private bool isGrounded;

    // New Jump variables
    public int maxJumps = 2; // How many jumps are allowed
    private int jumpsLeft;

    // New Attack variables
    public GameObject weaponPrefab; // Assign your weapon prefab in the editor
    public Transform attackSpawnPoint; // Where the weapon should spawn

    public float resetPositionZValue = -10f;
    private Vector3 initialPosition;


    private SoundBasics sounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sounds = GetComponent<SoundBasics>();
        jumpsLeft = maxJumps; // New
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!aturdido)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

            if (moveHorizontal != 0)
            {
                animator.SetBool("isMoving", true);
                FlipSprite(moveHorizontal);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    jumpsLeft = maxJumps;
                    isGrounded = false;
                }

                if (jumpsLeft > 0)
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    animator.SetBool("isJumping", true);
                    jumpsLeft--;
                }
            }

            if (transform.position.y < resetPositionZValue)
            {
                transform.position = initialPosition;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            jumpsLeft = maxJumps;
        }
    }
    void FlipSprite(float horizontalInput)
    {
        Vector3 scale = transform.localScale;
        scale.x = (horizontalInput > 0) ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
