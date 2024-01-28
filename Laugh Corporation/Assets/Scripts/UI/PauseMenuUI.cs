using Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        public static PauseMenuUI Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        [SerializeField] private GameObject window;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;

        public void OpenWindow()
        {
            AudioSystem.Instance.PlayClickSound();
            
            resumeButton.onClick.AddListener(Resume);
            mainMenuButton.onClick.AddListener(MainMenu);
            
            window.SetActive(true);
        }

        private void Resume()
        {
            AudioSystem.Instance.PlayButtonSound();
            
            StateMachine.Instance.isRunnig = true;
            
            resumeButton.onClick.RemoveListener(Resume);
            mainMenuButton.onClick.RemoveListener(MainMenu);
            
            window.SetActive(false);
        }
        
        private void MainMenu()
        {
            AudioSystem.Instance.PlayButtonSound();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
