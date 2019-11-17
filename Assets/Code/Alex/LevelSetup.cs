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
                    OnGameEnd?.Invoke(GameResult.Lose);
                }
            }
        }

        public int CountMatchedFigures
        {
            get => _countMatchedFigures;
            set
            {
                _countMatchedFigures = value;
                if (_countMatchedFigures >= _currState.baseFigures.Count)
                {
                    print("All figures matched");
                    _countMatchedFigures = 0;
                    _currState.DisposeMatchedObjects();
                    NextStage();
                }
            }
        }

        public event Action<GameResult> OnGameEnd = e => { };

        private Queue<BaseState> _queueStages;
        private int _countPlayerMistakes;
        private BaseState _currState;
        private int _countMatchedFigures;

        public void Awake()
        {
            // todo add difficulty selector
            StartGame();

            // test subscribe
            OnGameEnd += GameEnd;
        }

        private void GameEnd(GameResult gameResult)
        {
//            foreach (var product in FigureFactory.FigureProducts)
//            {
//                product.Dispose();
//            }

//            foreach (var uiProduct in FigureFactory.UiProducts)
//            {
//                uiProduct.Dispose();
//            }
            print($"GAME OVER {gameResult}");

//            FigureFactory.FigureProducts.Clear();
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
                OnGameEnd?.Invoke(GameResult.Win);
            }
            else
            {
                _currState = _queueStages.Dequeue();
                _currState.StartState();
            }
        }
    }
}