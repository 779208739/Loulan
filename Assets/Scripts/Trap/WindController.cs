using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private Rigidbody2D rb;
    public float windForce;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.velocity = new Vector2(rb.velocity.x, windForce);
            rb.gravityScale = 4;
        }

    }
}
