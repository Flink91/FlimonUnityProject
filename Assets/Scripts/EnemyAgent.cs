using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{

    public bool ShouldIMove;
    public GameObject GoalPoint;
    UnityEngine.AI.NavMeshAgent myNavMeshAgent;

    private bool isDead = false;

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

        //look in right direction
        if (myNavMeshAgent == null) return;
        this.transform.rotation = Quaternion.LookRotation(myNavMeshAgent.velocity, Vector3.up);

        //at goal point
        if ( myNavMeshAgent && myNavMeshAgent.remainingDistance <= 0.67f ) {
            PlayerStats.Lives--;
            Die();
        }
    }

    public void TakeDamage()
    {
        Die();
    }

    void Die()
    {
        isDead = true;
        Debug.Log("reached goal: " + myNavMeshAgent.remainingDistance + " :: " + GoalPoint.transform.position);
        //if the goal point is too close to 0,0,0, the enemy will be destroyed while instantiating, watch out!
        WaveSpawner.EnemiesAlive--;
        Debug.Log("enemies alive: " + WaveSpawner.EnemiesAlive);
        DestroyImmediate(myNavMeshAgent.gameObject);
    }

    private void SpawnNavMeshAgent ()
        {
        myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            myNavMeshAgent.SetDestination(GoalPoint.transform.position);

        }
}
