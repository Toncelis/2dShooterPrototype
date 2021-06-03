using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class RingIndicator : MonoBehaviour
    {
        [SerializeField] UnityEngine.UI.Image ring;

        [SerializeField] RectTransform rectTransform;

        [SerializeField] Animator myAnimator;
        float reloadAnimationInitialTime = 10;

        public void UpdateVisual()
        {
            rectTransform.rotation = Quaternion.Euler(Vector3.forward * 360 * (1f - ring.fillAmount) / 2);
        }

        public void UpdateVisual(float fillPercentage)
        {
            ring.fillAmount = fillPercentage;
            UpdateVisual();
        }

        public void Setup(float reloadTime)
        {
            myAnimator.speed = reloadAnimationInitialTime / reloadTime;
            UpdateVisual(1);
        }

        public void ReloadAnimation()
        {
            myAnimator.enabled = true;
        }
        public void ReloadAnimationEnds()
        { myAnimator.enabled = false; }
    }
}
