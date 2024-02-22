using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float sensitivity = 2.0f; // Mouse sensitivity
    //public Transform playerBody; // Player body to rotate along with the camera (optional)

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // Lock cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Calculate rotation for the camera vertically
        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, -45.0f, 45.0f); // Clamp rotation to prevent flipping
        //rotationY = Mathf.Clamp(rotationX, -45.0f, 45.0f);

        // Apply rotation to the camera vertically
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);

        //Rotate the camera horizontally
        //transform.parent.Rotate(Vector3.up * mouseX);
    }
}
