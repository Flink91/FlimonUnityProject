using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentBrain : MonoBehaviour
{

    public bool ShouldIMove;
    public GameObject GoalPoint;
    NavMeshAgent myNavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldIMove){
            Debug.Log("go");
            GetComponent<NavMeshAgent>().SetDestination(GoalPoint.transform.position);
        }
         // Check if we've reached the destination
         
        if (Vector3.Distance (GoalPoint.transform.position, target.position) > 1.0f) {
			GoalPoint.transform.position = target.position;
			print("da");
		}
    }
}
