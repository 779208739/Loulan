using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator anim;

    public float speed;
    public float jumpForce;


    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    [Header("Player State")]
    public float health;
    public bool isDead;

    [Header("States Check")]
    public bool isGround;
    public bool isJump;
    public bool canJump;

    [Header("Jump FX")]
    public GameObject JumpFX;
    public GameObject LandFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
    }

    public void FixedUpdate()
    {
        /*if (isDead)
        {
            rb.velocity = Vector2.zero;
        }*/
        Movement();
        //PhysicsCheck();
        //Jump();
    }

    void CheckInput()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            canJump = true;
        }

    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput, 1, 1);
        }
    }

    void Jump()
    {
        if (canJump)
        {
            isJump = true;
            //JumpFX.SetActive(true);
            //JumpFX.transform.position = transform.position + new Vector3(0, -0.45f, 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            canJump = false;
        }
    }

    void PhysicsCheck()
    {
        //isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            isJump = false;
            rb.gravityScale = 3;
        }
    }
}
