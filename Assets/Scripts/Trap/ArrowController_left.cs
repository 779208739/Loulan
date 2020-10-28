using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowController_left : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;
    public float speed;
    private float initx,inity;
    public float distance;
    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        rb = GetComponent<Rigidbody2D>();
        initx = transform.position.x;
        inity = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((initx - Player.transform.position.x)>=0&&(initx - Player.transform.position.x) < distance && System.Math.Abs(inity-Player.transform.position.y)<1)
            on = true;
        if (on == true)
        {
            Invoke("Movement", 0.2f);
        }
        //Movement();
    }

    void Movement()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        transform.gameObject.SetActive(false);
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        //Invoke("Restart", 0);
    //    }

    //}
    /*void Restart()
    {
        Debug.Log("gogogo");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
