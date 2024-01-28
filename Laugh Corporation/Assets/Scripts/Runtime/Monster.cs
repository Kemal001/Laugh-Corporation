using System;
using UI;
using UnityEngine;

namespace Runtime
{
    public class Monster : MonoBehaviour
    {
        public GameObject targetObject;
        public Transform spawnPoint;
        public float triggerDistance = 5.0f;
        public MonsterName monsterName;

        private GameObject clonedObject;
        private Vector3 initialPosition;
        private bool isNear = false;
        private bool isDragging = false;
        

        void Start()
        {
            initialPosition = transform.parent.position;

            StateMachine.Instance.onMonsterChanged += CheckPosition;
        }

        void Update()
        {
            if(!StateMachine.Instance.isRunnig)
                return;
            
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

                if (Input.GetMouseButtonDown(0))
                {
                    isDragging = true;
                }

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
                if(!isDragging)
                    CheckPosition();
            }
            
        }

        private void OnNearTarget()
        {
            if (clonedObject == null)
            {
                clonedObject = Instantiate(transform.parent.gameObject,
                    new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1.5f, spawnPoint.position.z),
                    Quaternion.identity);

                clonedObject.transform.localScale = Vector3.one;
                clonedObject.GetComponentInChildren<BoxCollider>().enabled = false;
                StateMachine.Instance.currentMonsterName = monsterName;

                Debug.Log("Object is near the target.");
            }
        }

        private void OnFarFromTarget()
        {
            if (clonedObject != null)
            {
                Destroy(clonedObject);
                clonedObject = null;
                StateMachine.Instance.currentMonsterName = MonsterName.Empty;
                MonsterUI.Instance.UpdateUI();
                
                Debug.Log("Object is far from the target.");
            }
        }

        private void SnapToObject()
        {
            transform.parent.position = targetObject.transform.position;
            MonsterUI.Instance.UpdateUI();
            Debug.Log("Snapped to target object.");
        }

        private void SnapToInitialPosition()
        {
            transform.parent.position = initialPosition;
            if(clonedObject != null)
                Destroy(clonedObject);
            Debug.Log("Snapped back to initial position.");
        }

        private void CheckPosition()
        {
            if (StateMachine.Instance.currentMonsterName != monsterName)
                SnapToInitialPosition();
        }
    }

    public enum MonsterName
    {
        Empty,
        Zog,
        Lila,
        Rex,
        Mira,
        Bobo,
        Kiki,
        Nana
    }
}
