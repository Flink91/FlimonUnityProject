using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBrain : MonoBehaviour
{

    private Transform target = null;

    [Header("General")]

	public float range = 15f;


	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start () {
        //update target straight away and then every second look if another enemy is closer
		InvokeRepeating("UpdateTarget", 0f, 1f);
	}


    void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		} else
		{
			target = null;
		}

	}

    // Update is called once per frame
	void Update () {
		if (target == null)
			return;

		//Target lock on
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);

        //smoothly rotate to the next target with lerp
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

	}

    //an easy way to show the range in editor
    void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
