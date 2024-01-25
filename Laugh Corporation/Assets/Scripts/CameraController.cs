using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 5.0f;
    public float maxYAngle = 30f;
    private Vector2 currentRotation;

    void Start()
    {
        currentRotation.y = 180f;
        transform.eulerAngles = new Vector3(0, currentRotation.y, 0);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            currentRotation.x += Input.GetAxis("Mouse Y") * sensitivity;
            currentRotation.y += Input.GetAxis("Mouse X") * sensitivity;

            currentRotation.x = Mathf.Clamp(currentRotation.x, -maxYAngle, maxYAngle);
            currentRotation.y = Mathf.Clamp(currentRotation.y, 180 - maxYAngle, 180 + maxYAngle);

            transform.rotation = Quaternion.Euler(-currentRotation.x, currentRotation.y, 0);
        }
    }
}
