using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : State
{
    StateManager stateManager;

    void Start()
    {
        stateManager = GetComponentInParent<StateManager>();
    }
    
    public override State RunCurrentState(FieldOfView fov)
    {
        animator.SetTrigger("Attack");
        if(!fov.canSeePlayer || (Vector3.Distance(this.transform.position,stateManager.playerf.transform.position)>=3f))
        {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Run");
            stateManager.RevertToPreviousState();
            return null;
        }
        else
        {
            return this;
        }
        
    }
}
