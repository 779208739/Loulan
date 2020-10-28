using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchcontrol : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;
    public GameObject locked_door;
    public GameObject unlocked_door;
    private bool playerin;
    // Start is called before the first frame update
    void Start()
    {
        switch1.SetActive(true);
        switch2.SetActive(false);
        locked_door.SetActive(true);
        unlocked_door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerin&& Input.GetKeyDown(KeyCode.E))
        {
            switch1.SetActive(false);
            switch2.SetActive(true);
            locked_door.SetActive(false);
            unlocked_door.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            playerin = true;
        }
    }

    private void OnTriggerErxit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            playerin = false;
        }
    }
}

