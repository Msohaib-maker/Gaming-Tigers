using System.Collections;
using static UnityEngine.Rendering.SplashScreen;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;

    RaycastHit hit;
    float range = 1000.0f;


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("click");

            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootRay()
    {
        //Debug.Log("shoot ray");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("shoot");
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.collider);
            GameObject.Destroy(laser, 2f);


        }
        else
        {
            GameObject laser1 = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            //laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser1, 5f);
        }

        

    }



}