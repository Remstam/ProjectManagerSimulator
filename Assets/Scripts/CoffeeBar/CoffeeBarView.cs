using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Input = UnityEngine.Input;

namespace Assets.Scripts.CoffeeBar
{
    public class CoffeeBarView : MonoBehaviour, ICoffeeBarView
    {
        public event Action BarFault = delegate { };

        [SerializeField] private Slider _slider;

        private int Value
        {
            get { return (int)_slider.value; }
            set
            {
                var val = Mathf.Clamp(value, 0, (int)_slider.maxValue);
                _slider.value = value;

                if (val == 0)
                    BarFault();
            }
        }

        private int _deltaInc;
        private int _deltaDec;
        private IEnumerator _routine;

        public void Init(int maxValue, int deltaInc, int deltaDec)
        {
            _deltaInc = deltaInc;
            _deltaDec = deltaDec;

            _slider.maxValue = maxValue;
            _slider.minValue = 0;
            _slider.wholeNumbers = true;

            Value = maxValue;

            StartCoroutine(_routine);
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
            StopCoroutine(_routine);
        }

        private void Awake()
        {
            _routine = DecRoutine();
        }

        private IEnumerator DecRoutine()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1f);
                Value -= _deltaDec;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Value += _deltaInc;
        }
    }
}