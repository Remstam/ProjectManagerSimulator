using System;
using System.Collections.Generic;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;
using Code.Alex.Helper;
using Code.Alex.ScriptableObjects;
using Sirenix.Utilities;

namespace Assets.Scripts.FigureProcessor
{
    public class FigureProcessor
    {
        public event Action OnGameEnd = () => { };
        private Queue<BaseState> _queueStages;

        public void Init(DifficultyType type, IStorage storage)
        {
            var states = storage.GetBaseStates(type);
            StartGame(states);
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
                OnGameEnd?.Invoke();
                return;
            }

            _queueStages.Dequeue().StartState();
        }
    }
}