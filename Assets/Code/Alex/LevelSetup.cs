using System;
using System.Collections.Generic;
using Code.Alex.Helper;
using Code.Alex.ScriptableObjects;
using Sirenix.Utilities;
using UnityEngine;

namespace Code.Alex
{
    public class LevelSetup : MonoBehaviour
    {
        [Header("Easy")] public List<BaseState> easyStates;
        [Header("Medium")] public List<BaseState> mediumStates;
        [Header("Hardcore")] public List<BaseState> hardcodeStates;
        public int MaxPlayerMistakes { get; set; } = 3;

        public int CountPlayerMistakes
        {
            get => _countPlayerMistakes;
            set
            {
                _countPlayerMistakes = value;
                if (_countPlayerMistakes == MaxPlayerMistakes)
                {
                    OnGameEnd?.Invoke();
                }
            }
        }

        public event Action OnGameEnd = () => { };
        
        private Queue<BaseState> _queueStages;
        private int _countPlayerMistakes;

        public void Awake()
        {
            // todo add difficulty selector
            StartGame();
            
            // test subscribe
            OnGameEnd += GameEnd;
        }

        private void GameEnd()
        {
            foreach (var product in FigureFactory.ListProducts)
            {
                product.Dispose();
            }
            FigureFactory.ListProducts.Clear();
            print("GameEnd");
        }

        private void StartGame()
        {
            _queueStages = easyStates.ToQueue();
            _queueStages.ForEach(e => e.OnStateEnd += NextStage);
            NextStage();
        }

        private void NextStage()
        {
            if (_queueStages.Count == 0)
            {
                OnGameEnd?.Invoke();
            }
            else
            {
                _queueStages.Dequeue().StartState();
            }
        }
    }
}