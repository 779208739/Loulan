using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(SceneManager.GetActiveScene().buildIndex==2)
        {
            if(DoorToNext.doorswitch1)
            {
                this.GetComponent<Transform>().position = new Vector3(9f, -2.3f, 0f);
            }
            if(DoorToNext.doorswitch2)
            {
                this.GetComponent<Transform>().position = new Vector3(48.3f, -0.8f, 0f);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (DoorToNext.doorswitch1)
            {
                this.GetComponent<Transform>().position = new Vector3(9.19f, -2f, 0f);
            }
            if (DoorToNext.doorswitch2)
            {
                this.GetComponent<Transform>().position = new Vector3(42.52f, -1f, 0f);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    public void FixedUpdate()
    {
        /*if (isDead)
        {
            rb.velocity = Vector2.zero;
        }*/
        Movement();
        PhysicsCheck();
        Jump();
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
            JumpFX.SetActive(true);
            JumpFX.transform.position = transform.position + new Vector3(0, -0.25f, 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            canJump = false;
        }
    }

    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            isJump = false;
            rb.gravityScale = 3;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    public void FallFX()
    {
        LandFX.SetActive(true);
        LandFX.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
}
