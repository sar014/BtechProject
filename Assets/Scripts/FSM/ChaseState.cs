using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : State
{
    public StateManager stateManager; 
    public AttackState attackState;
    public bool isInAttackRange;

    void Start() {
        animator = GetComponentInParent<Animator>();
        stateManager = GetComponentInParent<StateManager>();
    }
    public override State RunCurrentState(FieldOfView fov)
    {
        if(animator!=null)
        {
            animator.SetTrigger("Run");
        }
        else{
            Debug.Log("Animator not found");
        }

        if(Vector3.Distance(this.transform.position,stateManager.playerf.transform.position)<=3f)
        {
            animator.ResetTrigger("Run");
            return attackState;
        }
        else if (fov.canSeePlayer)
        {
            fov.agent.SetDestination(stateManager.playerf.transform.position);
            return this;
        }
        else if(!fov.canSeePlayer)
        {
            animator.ResetTrigger("Run");
            animator.SetTrigger("Walk");
            stateManager.RevertToPreviousState();
            return null;
        }
        else{
            return this;
        }
    }
}
