using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireballController : MonoBehaviour
{
    public GameObject fireball;
    public float timer ;
    private float timer1;
    public float speed;
    private Rigidbody2D rb;
    private int cal = 0;
    private float initx;
    private float inity;

    // Start is called before the first frame update
    void Start()
    {
        fireball.SetActive(false);
        rb = fireball.GetComponent<Rigidbody2D>();
        initx = fireball.transform.position.x;
        inity = fireball.transform.position.y;
        timer1 = timer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0&&cal==0)
        {
            doSomething();
            timer = timer1;
            cal++;
        }
        if (timer <= 0 && cal == 1)
        {
            doSomething1();
            timer = timer1;
            cal--;
        }
    }
    void doSomething()
    {
        fireball.SetActive(true);
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }
    void doSomething1()
    {
        fireball.SetActive(false);
        fireball.transform.position = new Vector2(initx, inity);
    }
   

}
