using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.EndGameView
{
    public class EndGameView : MonoBehaviour, IEndGameView
    {
        public event Action RestartClicked = delegate { };

        [SerializeField] private Text _title;
        [SerializeField] private Text _description;
        [SerializeField] private Button _restart;

        private void Start()
        {
            _restart.onClick.AddListener(() => RestartClicked());
        }

        public void Init(string title, string description)
        {
            _title.text = title;
            _description.text = description;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}