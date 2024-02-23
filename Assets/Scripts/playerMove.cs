using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f).normalized;

        // Move the player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
