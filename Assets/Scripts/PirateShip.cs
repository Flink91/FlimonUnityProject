using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour
{

    public Transform target;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        // ship wobbles
        // transform.Rotate(new Vector3(0,0,1) * (3 * Time.deltaTime));
        // transform.position = Vector3.RotateTowards(transform.forward, Vector3.zero, 3, 0.0f);

    }
}
