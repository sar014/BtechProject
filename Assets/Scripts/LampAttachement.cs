using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampAttachement : MonoBehaviour
{
    public float detectionRadius = 5.0f;
    public LayerMask wallLayerMask;  // Assign the wall layer in the inspector
    public Vector3 offset;  // Offset to adjust the position if needed
    
    void Start()
    {
       StartCoroutine(AttachLampToWall());
    }

    IEnumerator AttachLampToWall()
    {
        yield return new WaitForSeconds(10f);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, wallLayerMask);

        if (hitColliders.Length > 0)
        {
            // Find the closest wall
            Collider closestWall = hitColliders[0];
            float closestDistance = Vector3.Distance(transform.position, closestWall.transform.position);

            foreach (var hitCollider in hitColliders)
            {
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                if (distance < closestDistance)
                {
                    closestWall = hitCollider;
                    closestDistance = distance;
                }
            }

            // Attach the lamp to the closest wall
            transform.position = closestWall.ClosestPoint(transform.position) + offset;
            transform.rotation = Quaternion.LookRotation(-closestWall.transform.forward, Vector3.up);
        }
        else
        {
            Debug.LogWarning("No wall found within detection radius.");
        }
    }
}
