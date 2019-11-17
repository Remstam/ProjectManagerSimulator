using System;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;
using Code.Alex.Helper;
using Code.Alex.ScriptableObjects;
using Sirenix.Utilities;

namespace Assets.Scripts.FigureProcessor
{
    public class FigureProcessor
    {
        public event Action<GameResultType> OnGameEnd = e => { };

        private Queue<BaseState> _queueStages;
        private int _countPlayerMistakes;
        private BaseState _currState;
        private int _countMatchedFigures;

        public int MaxPlayerMistakes { get; set; } = 3;

        public int CountPlayerMistakes
        {
            get => _countPlayerMistakes;
            set
            {
                _countPlayerMistakes = value;
                if (_countPlayerMistakes == MaxPlayerMistakes)
                {
                    OnGameEnd?.Invoke(GameResultType.TooManyMisses);
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
                    UnityEngine.Debug.Log("All figures matched");
                    _countMatchedFigures = 0;
                    _currState.DisposeMatchedObjects();
                    NextStage();
                }
            }
        }

        public void Init(DifficultyType type, IStorage storage)
        {
            var states = storage.GetBaseStates(type);
            StartGame(states);

            OnGameEnd += GameEnd;
        }

        private void GameEnd(GameResultType gameResult)
        {
            //            foreach (var product in FigureFactory.FigureProducts)
            //            {
            //                product.Dispose();
            //            }

            //            foreach (var uiProduct in FigureFactory.UiProducts)
            //            {
            //                uiProduct.Dispose();
            //            }
            UnityEngine.Debug.Log($"GAME OVER {gameResult}");

            //            FigureFactory.FigureProducts.Clear();
        }

        private void StartGame(List<BaseState> states)
        {
            _queueStages = states.ToQueue();
            _queueStages.ForEach(e => e.OnStateEnd += NextStage);
            NextStage();
        }

        private void NextStage()
        {
            if (_queueStages.Count == 0)
            {
                OnGameEnd?.Invoke(GameResultType.Won);
            }
            else
            {
                _currState = _queueStages.Dequeue();
                _currState.StartState();
            }
        }
    }
}