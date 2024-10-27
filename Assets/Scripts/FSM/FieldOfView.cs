using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    public List<Vector3> WayPointList;
    public NavMeshAgent agent;
    public bool canSeePlayer;  // Public so it can be accessed by states
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public float radius;
    [Range(0, 360)]
    public float angle;
    public SpawnManager spawnManager;

    void Start()
    {
        WayPointList = spawnManager.waypointsList;
        agent = GetComponentInParent<NavMeshAgent>();
        Patrol();
        StartCoroutine(FOVRoutine());

    }

    public void Patrol()
    {
        int WayPointIndex = UnityEngine.Random.Range(0, WayPointList.Count);
        agent.SetDestination(WayPointList[WayPointIndex]);

        StartCoroutine(RepeatPatrol(10f));
    }
    IEnumerator RepeatPatrol(float interval)
    {
        while (true)
        {
            int WayPointIndex = UnityEngine.Random.Range(0, WayPointList.Count);
            agent.SetDestination(WayPointList[WayPointIndex]);

            yield return new WaitForSeconds(interval);
        }
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
