using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace UI
{
    public class LaughFuelUI : MonoBehaviour
    {
        public static LaughFuelUI Instance;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        [SerializeField] private Image fuelImage;

        public void UpdateUI()
        {
            fuelImage.DOFillAmount(fuelImage.fillAmount+0.17f,0.5f);
        }
    }
}
