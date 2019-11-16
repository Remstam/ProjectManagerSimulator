using System;
using Assets.Scripts.Core.Difficulty;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class DifficultyButton : MonoBehaviour, IDifficultyButton
    {
        public event Action<DifficultyType> Clicked = delegate { };

        [SerializeField] private Button _button;
        [SerializeField] private DifficultyType _difficulty;

        private void Start()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            Clicked(_difficulty);
        }
    }
}