using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed, jumpForce;

    private Rigidbody2D rb2d;
    private Animator animator;
    private float moveVelocity;

    private bool isGrounded = false;
    public LayerMask groundMask;
    private Collider2D playerCollider;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundMask);

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("Grounded", isGrounded); 
	}
}
