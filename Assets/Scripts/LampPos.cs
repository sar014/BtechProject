using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPos : MonoBehaviour
{


    public int numberOfRays = 8;        // Number of raycasts to shoot
    public float rayDistance = 5.0f;    // Max distance for each raycast
    public LayerMask wallLayerMask;     // Layer for walls
    public Vector3 offset;     

    private void Start() 
    {

        StartCoroutine(AttachToNearestWall());
    }

    IEnumerator AttachToNearestWall()
    {
        yield return new WaitForSeconds(10f);
        float smallestDistance = Mathf.Infinity;
        RaycastHit nearestHit = new RaycastHit();

        // Shoot rays in a circular pattern
        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = i * (360f / numberOfRays);
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;



            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, rayDistance, wallLayerMask))
            {
                // Debug.DrawRay(transform.position, direction * rayDistance, Color.red);
                // Debug.Log("ON HIT INFO"+hit);
                if (hit.distance < smallestDistance)
                {
                    smallestDistance = hit.distance;
                    nearestHit = hit;
                }
            }


        }

        // If we found a nearest wall, attach the lamp to it
        if (smallestDistance < Mathf.Infinity)
        {
            transform.position = nearestHit.point + offset;
            transform.rotation = Quaternion.LookRotation(nearestHit.normal, Vector3.up);
        }
        else
        {
            Debug.LogWarning("No wall found within raycasting distance.");
        }
    }

    // void OnDrawGizmos()
    // {
    //     // Visualize the raycasts in the editor
    //     Gizmos.color = Color.red;
    //     for (int i = 0; i < numberOfRays; i++)
    //     {
    //         float angle = i * (360f / numberOfRays);
    //         Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
    //         Gizmos.DrawRay(transform.position, direction * rayDistance);
    //     }
    // }
}
