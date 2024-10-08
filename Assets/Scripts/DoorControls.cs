using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The open and closing of doors was not working
So i created another door opening animation. and also removed the transition from opening to closing
*/

public class DoorControls : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public AudioSource doorSound;

    public bool inReach;

   
    void Start()
    {
        inReach = false;
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }
        
        else{
            DoorCloses();
        }
        
    }

    void DoorOpens()
    {
        door.SetBool("Open",true);
        door.SetBool("Closed",false);
        doorSound.Play();
    }

    void DoorCloses()
    {
        door.SetBool("Open",false);
        door.SetBool("Closed",true);
    }
}
