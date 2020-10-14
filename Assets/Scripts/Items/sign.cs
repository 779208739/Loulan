using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour
{
    public GameObject dialogbox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        if (isPlayerInSign)
        {
            dialogbox.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.BoxCollider2D")
            {
            dialogBoxText.text = signText;
            isPlayerInSign = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            isPlayerInSign = false;
            dialogbox.SetActive(false);
        }
    }
    // Update is called once per frame
    
}
