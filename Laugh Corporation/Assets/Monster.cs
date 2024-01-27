using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject targetObject;
    public Transform spawnPoint;
    public float triggerDistance = 5.0f;

    private GameObject clonedObject;
    private Vector3 initialPosition;
    private bool isNear = false;
    private bool isDragging = false;

    void Start()
    {
        initialPosition = transform.parent.position;
    }

    void Update()
    {
        if (targetObject != null)
        {
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            isNear = distance <= triggerDistance;

            if (isNear)
            {
                OnNearTarget();
            }
            else
            {
                OnFarFromTarget();
            }

            // Check if the mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
            }

            // Check if the mouse button is released
            if (isDragging && Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                if (isNear)
                {
                    SnapToObject();
                }
                else
                {
                    SnapToInitialPosition();
                }
            }
        }
    }

    private void OnNearTarget()
    {
        if (clonedObject == null)
        {
            clonedObject = Instantiate(transform.parent.gameObject,
                new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1f, spawnPoint.position.z),
                Quaternion.identity);

            clonedObject.transform.localScale = Vector3.one;
            Debug.Log("Object is near the target.");
        }
    }

    private void OnFarFromTarget()
    {
        if (clonedObject != null)
        {
            Destroy(clonedObject);
            clonedObject = null;
            Debug.Log("Object is far from the target.");
        }
    }

    private void SnapToObject()
    {
        transform.parent.position = targetObject.transform.position;
        Debug.Log("Snapped to target object.");
    }

    private void SnapToInitialPosition()
    {
        transform.parent.position = initialPosition;
        Debug.Log("Snapped back to initial position.");
    }
}
