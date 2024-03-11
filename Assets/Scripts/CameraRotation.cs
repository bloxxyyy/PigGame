using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 50.0f;

    void Update()
    {
        if (target != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
                transform.RotateAround(target.position, Vector3.down, rotationAmount);
            }
        }
    }
}
