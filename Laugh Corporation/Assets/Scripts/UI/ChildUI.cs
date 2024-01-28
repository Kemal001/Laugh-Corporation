using System;
using System.Collections.Generic;
using Data;
using Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChildUI : MonoBehaviour
    {
        public static ChildUI Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private List<Slider> skills;
        
        public void UpdateUI()
        {
            var currentKid = StateMachine.Instance.currentKid;

            icon.sprite = currentKid.Icon;
            name.text = currentKid.Name;
            for (int i = 0; i < skills.Count; i++)
            {
                skills[i].value = currentKid.StatsList[i].Amout;
            }
        }
    }
}
