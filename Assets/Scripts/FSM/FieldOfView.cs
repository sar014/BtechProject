using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public bool canSeePlayer;  // Public so it can be accessed by states
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public float radius;
    [Range(0, 360)]
    public float angle;

    void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            // Debug for direction and angle
            Debug.Log("Target found in range. Checking angle...");

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    Debug.Log("Can see the player!");
                    canSeePlayer = true;
                }
                else
                {
                    Debug.Log("Player blocked by an obstacle.");
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
                Debug.Log("Player out of view angle.");
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            Debug.Log("No player in range.");
        }
    }
}
