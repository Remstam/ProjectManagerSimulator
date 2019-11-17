using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DeadlineView
{
    public class DeadlineBarView : MonoBehaviour, IDeadlineBarView
    {
        private const int MaxSliderValue = 100;

        public event Action SlideCompleted = delegate { };

        [SerializeField] private Slider _slider;

        private Tweener _tween;

        public void Init(int deadlineTime)
        {
            _slider.value = _slider.maxValue;

            KillTween();
            _tween = _slider.DOValue(0f, deadlineTime).
                    SetEase(Ease.Linear).
                    OnComplete(() => SlideCompleted());
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Halt()
        {
            KillTween();
        }

        private void Start()
        {
            _slider.maxValue = MaxSliderValue;
            _slider.value = _slider.maxValue;
            _slider.wholeNumbers = false;
        }

        private void KillTween()
        {
            if (_tween == null)
                return;

            _tween.Kill();
            _tween = null;
        }
    }
}