using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public LayerMask layerMask;
    private GameObject selectedObject = null;
    private GameObject lastHoveredObject = null;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                selectedObject = hit.collider.gameObject;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }

        if (selectedObject != null)
        {
            MoveObject(selectedObject, ray);
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (lastHoveredObject != null && lastHoveredObject != hitObject)
            {
                ToggleComponent(lastHoveredObject, false);
            }

            ToggleComponent(hitObject, true);
            lastHoveredObject = hitObject;
        }
        else
        {
            if (lastHoveredObject != null)
            {
                ToggleComponent(lastHoveredObject, false);
                lastHoveredObject = null;
            }
        }
    }

    void ToggleComponent(GameObject obj, bool state)
    {
        Outline outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = state;
        }
    }

    void MoveObject(GameObject obj, Ray ray)
    {
        Plane plane = new Plane(Vector3.up, obj.transform.position);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            obj.transform.parent.position = ray.GetPoint(distance);
        }
    }
}
