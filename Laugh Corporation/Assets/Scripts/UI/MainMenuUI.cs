using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button startLevelButton;
        [SerializeField] private Button creditsButton;
        [SerializeField] private Button exitButton;


        private void Start()
        {
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
    }
}
