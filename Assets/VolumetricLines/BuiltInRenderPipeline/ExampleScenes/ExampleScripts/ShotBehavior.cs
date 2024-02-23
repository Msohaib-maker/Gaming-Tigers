using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{

    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;
    private Collider targetCollider;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 30f;// The step size is equal to speed times frame time.
        //float step = speed * Time.deltaTime;

        /*if (m_target != null)
        {
            if (transform.position == m_target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }*/

    }

    public void setTarget(Collider target)
    {
        targetCollider = target;

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("defe");
        if (other == targetCollider)
        {
            //Debug.Log("defe");
            // Do something when the shot hits the target collider (e.g., trigger an explosion)
            EnemyCreate.instance.count_enemy -= 1;
            Destroy(other.gameObject);
            explode();
        }
    }

    void explode()
    {
        if (collisionExplosion != null)
        {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }

}