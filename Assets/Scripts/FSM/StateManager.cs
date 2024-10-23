using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Base State class
public abstract class State : MonoBehaviour
{
    //Using Abstract class as Base Class.Methods can only be declared not defined
    protected Animator animator; 
    public void SetAnimator(Animator anim)
    {
        animator = anim;
    }
    public abstract State RunCurrentState(FieldOfView fieldOfView);
}

public class StateManager : MonoBehaviour
{

    private FieldOfView fieldOfView;
    private Animator animator;
    private State previousState;
    private State currentState;
    public State initialState; 
    public GameObject playerf;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        fieldOfView = GetComponent<FieldOfView>();
        currentState = initialState;  
        currentState.SetAnimator(animator); //Making sure the current state gets the animator
    }

    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {   
        //State is a datatype. If currentState is not null call RunCurrentState
        State nextState = currentState?.RunCurrentState(fieldOfView);

        if(nextState != null && nextState != currentState)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        previousState = currentState;
        currentState = nextState;
        currentState.SetAnimator(animator); //Making sure the next state gets the animator
    }
    
    public void RevertToPreviousState()
    {
        if (previousState != null)
        {
            Debug.Log("Reverting to previous state: " + previousState);
            currentState = previousState;
            currentState.SetAnimator(animator); //Making sure the previous state gets the animator
        }
    }
}
