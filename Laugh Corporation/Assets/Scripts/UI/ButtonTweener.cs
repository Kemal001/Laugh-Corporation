using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class ButtonTweener : MonoBehaviour
    {
        [SerializeField]
        private float pressedScale = 0.9f;
        [SerializeField]
        private float pressedDuration = 0.1f;
        [SerializeField]
        private Ease pressedEase = Ease.OutBack;
    
        [Space]
        [SerializeField]
        private float releasedScale = 1f;
        [SerializeField]
        private float releasedDuration = 0.1f;
        [SerializeField]
        private Ease releasedEase = Ease.OutBack;

        private bool isSelected = false;

        public void PlayHoldAnimation()
        {
            //scale up ease out
            transform.DOScale(pressedScale, pressedDuration).SetEase(pressedEase);
            isSelected = true;
        }

        public void PlayReleaseAnimation()
        {
            if(isSelected)
            {
                //scale down ease out
                transform.DOScale(releasedScale, releasedDuration).SetEase(releasedEase);
                isSelected = false;
            }
        }
    }
}
