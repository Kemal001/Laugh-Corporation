using DG.Tweening;
using Runtime;
using UI;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public LayerMask layerMask;
    private GameObject selectedObject = null;
    private GameObject lastHoveredObject = null;
    private Camera mainCamera;

    [SerializeField] private Transform tabletTransform;
    [SerializeField] private Transform tabletStartPosition;
    [SerializeField] private Transform tabletEndPosition;
    [SerializeField] private float animTime;
    private bool tabletIsActive = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(!StateMachine.Instance.isRunnig)
            return;
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                selectedObject = hit.collider.gameObject;

                if (selectedObject.CompareTag("Tablet"))
                {
                    HandleTabletObject();
                    return;
                }
                if (selectedObject.CompareTag("Red Button"))
                {
                    HandleRedButtonObject();
                    return;
                }
                if (selectedObject.CompareTag("Pause Menu"))
                {
                    HandlePauseMenuObject();
                    return;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }

        if (selectedObject != null && !selectedObject.CompareTag("Tablet") && !selectedObject.CompareTag("Red Button") && !selectedObject.CompareTag("Pause Menu"))
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

    void HandleTabletObject()
    {
        AudioSystem.Instance.PlayTabletSound();
        
        if (!tabletIsActive)
        {
            tabletTransform.DOMove(tabletEndPosition.position, animTime);
            tabletTransform.DORotate(tabletEndPosition.eulerAngles, animTime);
        }
        else
        {
            tabletTransform.DOMove(tabletStartPosition.position, animTime);
            tabletTransform.DORotate(tabletStartPosition.eulerAngles, animTime);
        }

        tabletIsActive = !tabletIsActive;
    }
    private void HandleRedButtonObject()
    {
        AudioSystem.Instance.PlayClickSound();
        StateMachine.Instance.ChooseMonster();
    }
    private void HandlePauseMenuObject()
    {
        AudioSystem.Instance.PlayClickSound();
        StateMachine.Instance.isRunnig = false;
        PauseMenuUI.Instance.OpenWindow();
    }
}
