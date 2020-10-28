using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorToNext : MonoBehaviour
{


    public bool x;
    public static bool doorswitch1, doorswitch2;
    public bool bs1, bs2;
    public bool playerin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&playerin)
        {
           
            if (SceneManager.GetActiveScene().buildIndex == 3)
                SceneManager.LoadScene(2);
            else 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

   private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {

            playerin = true;
            if (gameObject.CompareTag("door1"))
            {
                doorswitch1 = true;
                doorswitch2 = false;
                bs1 = true;
                bs2 = false;
            }
            if (gameObject.CompareTag("door2"))
            {
                doorswitch1 = false;
                doorswitch2 = true;
                bs1 = true;
                bs2 = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D" )
        {
            playerin = false;

        }
    }
}
