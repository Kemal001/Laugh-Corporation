using System.Collections.Generic;
using Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MonsterUI : MonoBehaviour
    {
        public static MonsterUI Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }
        
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private List<Slider> skills;
        
        public void UpdateUI()
        {
            var currentMonster = StateMachine.Instance.GetCurrentMonsterData();

            if (currentMonster == null)
            {
                name.text = "";
                for (int i = 0; i < skills.Count; i++)
                {
                    skills[i].value = 0;
                }
                return;
            }
            
            name.text = currentMonster.Name.ToString();
            for (int i = 0; i < skills.Count; i++)
            {
                skills[i].value = currentMonster.StatsList[i].Amout;
            }
        }
        
    }
}
