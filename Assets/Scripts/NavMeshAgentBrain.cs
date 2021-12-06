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
        Invoke("SpawnNavMeshAgent", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // if(ShouldIMove && myNavMeshAgent.enabled){   
        // }
          if( myNavMeshAgent && myNavMeshAgent.remainingDistance <= 0.67f ) {
            DestroyImmediate(myNavMeshAgent.gameObject);
        }
    }

    private void SpawnNavMeshAgent ()
        {
            myNavMeshAgent = GetComponent<NavMeshAgent> ();
            myNavMeshAgent.SetDestination(GoalPoint.transform.position);

        }
}
