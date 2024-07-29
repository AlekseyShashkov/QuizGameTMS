using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    [RequireComponent(typeof(Button))]
    public class StaggerEffect : MonoBehaviour, IButtonEffect
    {
        [SerializeField] private bool use = true;
        [SerializeField] private int vibrato = 10;
        [SerializeField] private float duration = 0.8f;       
        [SerializeField] private float elasticity = 1.0f;
        [SerializeField] private Vector3 punch = new(100.0f, 0.0f, 0.0f);

        public void Notify(bool correct)
        {
            if (!use || correct)
            {
                return;
            }

            transform.DOKill();
            transform.DOPunchPosition(punch, duration, vibrato, elasticity, false);
        }
    }
}