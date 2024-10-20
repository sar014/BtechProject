using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBullets : MonoBehaviour
{
    public SimpleShoot simpleShoot;

    private void Start() 
    {
        simpleShoot = FindObjectOfType<SimpleShoot>();  // Dynamically find the SimpleShoot component in the scene
        if (simpleShoot == null)
        {
            Debug.LogError("SimpleShoot script not found!");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Reach"))
        {   
            Debug.Log("Reloading");
            simpleShoot.TobeReloaded = true;
        }
    }

}
