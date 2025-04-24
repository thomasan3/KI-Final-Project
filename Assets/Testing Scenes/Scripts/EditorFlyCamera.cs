using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to EditorCamera so you can move around in game preview (use the same awsdqe keys)

public class EditorFlyCamera : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float lookSpeed = 2f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        // Look around with mouse
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);

        // Move with WASD + QE
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0;
        if (Input.GetKey(KeyCode.E)) moveY += 1;
        if (Input.GetKey(KeyCode.Q)) moveY -= 1;

        Vector3 move = transform.right * moveX + transform.forward * moveZ + transform.up * moveY;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
