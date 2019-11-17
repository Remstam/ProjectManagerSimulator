using System;
using System.Collections.Generic;
using Assets.Scripts.Core.Difficulty;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class DifficultyPickerView : MonoBehaviour, IDifficultyPickerView
    {
        public event Action<DifficultyType> Clicked = delegate { };

        [SerializeField] private List<DifficultyButton> _buttons;

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void Start()
        {
            foreach (var button in _buttons)
                button.Clicked += x => Clicked(x);
        }
    }
}