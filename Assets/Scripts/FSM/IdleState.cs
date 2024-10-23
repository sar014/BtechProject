using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;

    public override State RunCurrentState(FieldOfView fov)
    {
        if(fov.canSeePlayer){
            return chaseState;
        }
        else{
            animator.ResetTrigger("Run");
            animator.SetTrigger("Walk");
            return this;
        }
    }

}
