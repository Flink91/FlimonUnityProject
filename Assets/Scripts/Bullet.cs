using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 50f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;

    private float missileStartTime = 1f;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        missileStartTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            // if missile loses target, explode
            if(explosionRadius > 0)
            {
                HitTarget();
            }
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * speed;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }


        if (explosionRadius > 0)
        {
            // dir.Normalize();
            if (missileStartTime >= 0)
            {
                Debug.Log("up up");
                missileStartTime -= Time.deltaTime;
                // float rotateAmount = Vector3.Cross(dir, transform.up).z;
                transform.Translate(Vector3.up * Time.deltaTime * (speed/2), Space.World);
            }
            else
            {
                transform.Translate(dir.normalized * distanceThisFrame, Space.World);
                transform.LookAt(target);
            }
        }
        else
        {
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);
        }
    }

    void HitTarget()
    {

        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        PlayerStats.Money++;
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        EnemyAgent e = enemy.GetComponent<EnemyAgent>();

        if (e != null)
        {
            e.TakeDamage();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
