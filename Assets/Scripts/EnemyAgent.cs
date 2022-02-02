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
        this.transform.rotation = Quaternion.LookRotation(myNavMeshAgent.velocity, Vector3.up) * Quaternion.Euler(0,180f,0);
        //Vector3 dir = GoalPoint.transform.position - transform.position;
        //dir.y = 0;//This allows the object to only rotate on its y axis

        //Quaternion rot = Quaternion.LookRotation(-dir);

        //transform.rotation = Quaternion.Lerp(transform.rotation, rot, 5f * Time.deltaTime);

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
