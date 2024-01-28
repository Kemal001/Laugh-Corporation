using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject credits;
        [SerializeField] private GameObject tutorial;
        
        
        [SerializeField] private TextMeshProUGUI startLevelButtonText;
        
        [SerializeField] private Button startLevelButton;
        [SerializeField] private Button tutorialButton;
        [SerializeField] private Button creditsButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartProgress;
        [SerializeField] private Button closeCreditsButton;
        [SerializeField] private Button closeTutorialButton;

        [SerializeField] private AudioSource audioSource;


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
            creditsButton.onClick.AddListener(Credits);
            tutorialButton.onClick.AddListener(Tutorial);
            closeCreditsButton.onClick.AddListener(CloseCreditsButton);
            closeTutorialButton.onClick.AddListener(CloseTutorialButton);
        }

        private void StartLevel()
        {
            audioSource.Play();
            SceneManager.LoadScene("MapScene");
        }

        private void Credits()
        {
            audioSource.Play();
            
            mainMenu.SetActive(false);
            credits.SetActive(true);
            
            closeCreditsButton.gameObject.SetActive(true);
        }
        
        private void Tutorial()
        {
            audioSource.Play();
            
            mainMenu.SetActive(false);
            tutorial.SetActive(true);
            
            closeTutorialButton.gameObject.SetActive(true);
        }
        private void Exit()
        {
            audioSource.Play();
            Application.Quit();
        }

        private void RestartProgress()
        {
            audioSource.Play();
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("MainMenu");
        }

        private void CloseCreditsButton()
        {
            audioSource.Play();

            mainMenu.SetActive(true);
            credits.SetActive(false);
            
            closeCreditsButton.gameObject.SetActive(false);
        }
        
        private void CloseTutorialButton()
        {
            audioSource.Play();

            mainMenu.SetActive(true);
            tutorial.SetActive(false);
            
            closeTutorialButton.gameObject.SetActive(false);
        }
    }
}
