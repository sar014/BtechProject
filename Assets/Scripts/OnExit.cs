using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExit : MonoBehaviour
{
    public GameObject winMessage;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You WIn");
            winMessage.SetActive(true);
        }
        
    }
}
