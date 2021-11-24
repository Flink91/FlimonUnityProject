using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentBrain : MonoBehaviour
{

    public bool ShouldIMove;
    public GameObject GoalPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldIMove){
            GetComponent<NavMeshAgent>().SetDestination(GoalPoint.transform.position);
        }
    }
}
