using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject player;
    //public NavMeshAgent enemy;


    //public float speed = 5.0f;
    public float shootingRange = 15.0f; // Distance at which the enemy starts shooting
    public GameObject bulletPrefab; // Prefab of the bullet to shoot
    public Transform firePoint; // Point where the bullet is spawned
    public float shootInterval = 1.0f; // Interval between shots
    public float bulletSpeed = 10.0f;

    private bool isShooting = false;
    private float lastShootTime;

    public float verticalMovementAmount = 0.5f; // Amount of vertical movement
    public float verticalMovementSpeed = 1.0f;


    float time_interval = 0;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Make sure to tag your player GameObject with 'Player'.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
            return;
        //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //enemy.SetDestination(player.position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Check if the enemy is within shooting range
        if (distanceToPlayer <= shootingRange)
        {
            // Start shooting
            if (Time.deltaTime > time_interval)
            {
                StartCoroutine(Shoot());
                time_interval = shootInterval;
            }
            
            
        }
        else
        {
            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            targetPosition = player.transform.position + playerDirection * Random.Range(2.0f, 5.0f);
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1.0f);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject != gameObject) // Avoid self
                {
                    Vector3 avoidanceDirection = (transform.position - collider.transform.position).normalized;
                    targetPosition += avoidanceDirection * 1.0f;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            // Stop shooting
            if (isShooting)
            {
                StopCoroutine(Shoot());
                isShooting = false;
            }
        }

        float verticalMovement = Mathf.Sin(Time.time * verticalMovementSpeed) * verticalMovementAmount;
        //transform.position += new Vector3(0, 0.5f, 0);

        time_interval -= Time.deltaTime;
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        
            // Spawn bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Calculate direction towards the player
        Vector3 direction = (player.transform.position - firePoint.position).normalized;
            // Set bullet velocity
        bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
            // Destroy bullet after some time
        Destroy(bullet, 2.0f);

            // Wait for the next shot
        yield return new WaitForSeconds(shootInterval);


        isShooting=false;
        //Debug.Log("cook");
        
    }
}
