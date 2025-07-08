using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 100f;               // Movement speed of the player
    public float Sensibility = 20f;          // Mouse sensitivity for camera rotation
    public float limitX = 50;                // Vertical rotation limit for the camera
    public Transform cam;                    // Reference to the camera transform

    private float rotationX;                 // Stores vertical rotation value
    private bool cameraControlEnabled = true; // Toggles camera control with mouse

    void Update()
    {
        // Toggle camera control on/off when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraControlEnabled = !cameraControlEnabled;
        }

        // Get movement input from keyboard
        float x = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float y = Input.GetAxis("Vertical");   // W/S or Up/Down arrows
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Mouse scroll for forward/backward

        // Apply movement based on input
        Vector3 move = new Vector3(x, y, 0) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // Move forward/backward based on scroll input
        transform.position += cam.forward * scroll * speed * 10f * Time.deltaTime;

        // Rotate camera only if camera control is enabled
        if (cameraControlEnabled)
        {
            // Vertical rotation (pitch)
            rotationX += -Input.GetAxis("Mouse Y") * Sensibility;
            rotationX = Mathf.Clamp(rotationX, -limitX, limitX); // Clamp to avoid flipping
            cam.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // Horizontal rotation (yaw)
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * Sensibility, 0);
        }
    }
}





