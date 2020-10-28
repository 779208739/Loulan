using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlat : MonoBehaviour
{
    public GameObject brop;
    private bool cd,isbreaking;
    private float timer1,timer2;
    private Animator myanim;

    // Start is called before the first frame update
    void Start()
    {
        cd = false;
        timer1 = 1;
        timer2 = 5;
        myanim=brop.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isbreaking)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
            {
                this.transform.GetComponent<BoxCollider2D>().enabled = false;
                brop.SetActive(false);
                myanim.SetBool("isbreaking", false);
                cd = true;
                timer1 = 1;
                isbreaking = false;
            }

        }
        if(cd)
        {
            timer2 -= Time.deltaTime;
            if (timer2 <= 0)
            {
                brop.SetActive(true);
                cd = false;
                timer2 = 5;
                this.transform.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"&&other.transform.position.y>(this.transform.position.y-1.85))
        {
            myanim.SetBool("isbreaking", true);
            isbreaking = true;
        }
    }

}
