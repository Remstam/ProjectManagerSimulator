using System;
using System.Collections.Generic;
using Assets.Scripts.Core.Difficulty;
using Code.Alex.Helper;
using Code.Alex.ScriptableObjects;
using Sirenix.Utilities;
using UnityEngine;

namespace Code.Alex
{
    public class LevelSetup : MonoBehaviour
    {
        [Header("Easy")] public LevelInfo easyStates;
        [Header("Medium")] public LevelInfo mediumStates;
        [Header("Hardcore")] public LevelInfo hardcodeStates;

        public event Action OnGameEnd = () => { };
        private Queue<BaseState> _queueStages;

        public LevelInfo GetSetupByDifficulty(DifficultyType type)
        {
            switch (type)
            {
                case DifficultyType.Easy:
                    return easyStates;
                case DifficultyType.Normal:
                    return mediumStates;
                case DifficultyType.Hard:
                    return hardcodeStates;
            }

            return easyStates;
        }

        public void Awake()
        {
            // todo add difficulty selector
            StartGame();
        }

        private void StartGame()
        {
            _queueStages = easyStates.states.ToQueue();
            _queueStages.ForEach(e => e.OnStateEnd += NextStage);
            NextStage();
        }

        private void NextStage()
        {
            if (_queueStages.Count == 0)
            {
                print("Game Over");
                OnGameEnd?.Invoke();
                return;
            }

            _queueStages.Dequeue().StartState();
        }
    }
}