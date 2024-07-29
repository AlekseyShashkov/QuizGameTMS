using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace View
{
    [RequireComponent(typeof(Button))]
    public class ScaleButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private bool use = true;
        private Vector3 defaultScale;
        [SerializeField] private float holdScale = 0.8f;
        [SerializeField] private float releseScale = 1.2f;
        [SerializeField] private float durationEffect = 0.3f;
        private Tween currentTween;


        public void OnPointerDown(PointerEventData eventData)
        {
            if (!use)
            {
                return;
            }

            defaultScale = transform.localScale;
            currentTween?.Kill();
            currentTween = transform.DOScale(holdScale, durationEffect);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!use)
            {
                return;
            }

            currentTween?.Kill();
            currentTween = DOTween.Sequence()
                           .Append(transform.DOScale(releseScale, durationEffect))
                           .Append(transform.DOScale(defaultScale, durationEffect));
        }

    }
}
