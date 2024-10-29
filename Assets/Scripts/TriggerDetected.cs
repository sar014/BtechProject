using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetected : MonoBehaviour
{
    public bool hasEntered;
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            hasEntered = true;
        }
        
    }
}
