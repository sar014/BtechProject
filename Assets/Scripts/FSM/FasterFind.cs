using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Use this script to find the player faster. To make the enemy look stronger. Attach only to Mutant
public class FasterFind : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    NavMeshPath path;
    NavMeshAgent navMeshAgent;

    void Start() {
        path = new NavMeshPath();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculatePathToPlayer()
    {
        if(navMeshAgent.CalculatePath(playerObj.transform.position,path))
        {
            navMeshAgent.SetDestination(playerObj.transform.position);
            Debug.Log("USING FASTER FIND");
        }
    }
}
