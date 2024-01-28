using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI startLevelButtonText;
        
        [SerializeField] private Button startLevelButton;
        [SerializeField] private Button creditsButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartProgress;


        private void Start()
        {
            if (PlayerPrefs.GetInt("Level", 0) >= 3)
            {
                startLevelButtonText.text = "Coming Soon";
                restartProgress.gameObject.SetActive(true);
                restartProgress.onClick.AddListener(RestartProgress);
            }
            else
                startLevelButton.onClick.AddListener(StartLevel);
            
            creditsButton.onClick.AddListener(Credits);
            exitButton.onClick.AddListener(Exit);
        }

        private void StartLevel()
        {
            SceneManager.LoadScene("MapScene");
        }

        private void Credits()
        {
            //Show Credits
        }
        private void Exit()
        {
            Application.Quit();
        }

        private void RestartProgress()
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
