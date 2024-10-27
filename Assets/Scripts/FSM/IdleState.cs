using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    FasterFind fasterFind;
    private float timeBetweenChecks = 30f;  // Time in seconds between checks
    private float nextCheckTime = 0f;
    public ChaseState chaseState;

    void Start()
    {
        fasterFind = GetComponentInParent<FasterFind>();
    }

    public override State RunCurrentState(FieldOfView fov)
    {
        if(fov.canSeePlayer){
            return chaseState;
        }
        else{
            animator.ResetTrigger("Run");
            animator.SetTrigger("Walk");

            // Only perform random check if enough time has passed
            if (Time.time > nextCheckTime)
            {
                nextCheckTime = Time.time + timeBetweenChecks;  // Set next check time

                // 15% chance of using faster find to find the player
                if (Random.Range(0, 100) < 15)
                {
                    fasterFind.CalculatePathToPlayer();
                }
            }
            return this;
        }
    }

}
