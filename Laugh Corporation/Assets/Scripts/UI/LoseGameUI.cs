using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LoseGameUI : MonoBehaviour
    {
        public static LoseGameUI Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        [SerializeField] private GameObject window;
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button mainMenuButton;

        public void OpenWindow()
        {
            AudioSystem.Instance.PlayAntiLaughSound();
            
            restartLevelButton.onClick.AddListener(RestartLeveL);
            mainMenuButton.onClick.AddListener(MainMenu);
            
            window.SetActive(true);
        }

        private void RestartLeveL()
        {
            AudioSystem.Instance.PlayButtonSound();
            SceneManager.LoadScene("MapScene");
        }
        
        private void MainMenu()
        {
            AudioSystem.Instance.PlayButtonSound();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
