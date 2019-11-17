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

        public event Action OnGameEnd = () => { };
        private Queue<BaseState> _queueStages;

        public void Awake()
        {
            // todo add difficulty selector
            StartGame();
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
                print("Game Over");
                OnGameEnd?.Invoke();
                return;
            }

            _queueStages.Dequeue().StartState();
        }
    }
}