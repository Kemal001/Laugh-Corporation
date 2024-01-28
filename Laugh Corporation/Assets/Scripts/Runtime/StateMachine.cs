using System;
using System.Collections.Generic;
using Data;
using UI;
using UnityEngine;

namespace Runtime
{
    public class StateMachine : MonoBehaviour
    {
        public static StateMachine Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }
        
        [HideInInspector]
        public MonsterName currentMonsterName;
        [HideInInspector]
        public ChildData currentKid;

        public Action onMonsterChanged;
        public bool isRunnig = true;
        
        [SerializeField] private LevelsDatabase levelsDatabase;
        [SerializeField] private List<MonsterDataDictionary> monsterDatas;

        private int levelNumber;
        private int levelKidNumber;
        private List<ChildData> currentLevelKids;

        private float LaughFuel;

        private void Start()
        {
            isRunnig = true;
            //PlayerPrefs.DeleteAll();
            levelNumber = PlayerPrefs.GetInt("Level", 0);
            Debug.Log(levelNumber);

            currentLevelKids = levelsDatabase.Levels[levelNumber].ChildDatas;
            levelKidNumber = 0;
            
            ChangeKid();
        }

        public void LoseGame()
        {
            LoseGameUI.Instance.OpenWindow();
        }
        
        public void WinGame()
        {
            var nextLevel = levelNumber + 1;
            PlayerPrefs.SetInt("Level",nextLevel);
            WinGameUI.Instance.OpenWindow(LaughFuel);
        }
        
        public void ChangeKid()
        {
            try
            {
                currentKid = currentLevelKids[levelKidNumber];
            }
            catch (Exception e)
            {
                WinOrLose();
                return;
            }
            
            levelKidNumber++;
            
            ChildUI.Instance.UpdateUI();
            currentMonsterName = MonsterName.Empty;
        }

        public void ChooseMonster()
        {
            if(currentMonsterName == MonsterName.Empty) return;

            if (currentKid.MonsterName == currentMonsterName)
            {
                LaughFuel += 0.17f;
                LaughFuelUI.Instance.UpdateUI();
            }
            else
            {
                //TODO Show Wrong Monster
                Debug.Log("Wrong");
            }

            ChangeKid();
        }

        private void WinOrLose()
        {
            isRunnig = false;
            if (LaughFuel >= 0.65)
            {
                WinGame();
                return;
            }
            LoseGame();
        }

        public MonsterData GetCurrentMonsterData()
        {
            for (int i = 0; i < monsterDatas.Count; i++)
            {
                if (currentMonsterName == monsterDatas[i].MonsterName)
                    return monsterDatas[i].MonsterData;
            }

            return null;
        }
        
    }

    [Serializable]
    public struct MonsterDataDictionary
    {
        public MonsterName MonsterName;
        public MonsterData MonsterData;
    }
}
