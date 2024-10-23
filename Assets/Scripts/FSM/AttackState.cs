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
        if(fov.canSeePlayer)
        {
            animator.SetTrigger("Attack");
            return this;
        }
        else if(!fov.canSeePlayer)
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
