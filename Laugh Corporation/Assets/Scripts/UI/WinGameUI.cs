using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class WinGameUI : MonoBehaviour
    {
        public static WinGameUI Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        [SerializeField] private GameObject window;
        [SerializeField] private TextMeshProUGUI letter;
        [SerializeField] private TextMeshProUGUI nextLevelButtonText;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button mainMenuButton;

        public void OpenWindow(float LaughFuelValue)
        {
            var currentLevel = PlayerPrefs.GetInt("Level");

            if (LaughFuelValue > 0.9)
                letter.text = "A";
            else if (LaughFuelValue > 0.8)
                letter.text = "B";
            else
                letter.text = "C";
            
            if (currentLevel >= 3)
                nextLevelButtonText.text = "Coming Soon";
            else
                nextLevelButton.onClick.AddListener(NextLeveL);
            
            mainMenuButton.onClick.AddListener(MainMenu);
            
            window.SetActive(true);
        }

        private void NextLeveL()
        {
            SceneManager.LoadScene("MapScene");
        }
        
        private void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
