using Assets.Scripts.CoffeeBar;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Core.EndGame;
using Assets.Scripts.DeadlineView;
using Assets.Scripts.EndGameView;
using Assets.Scripts.View;
using Code.Alex;
using UnityEngine;

namespace Assets.Scripts.Storage
{
    public class StorageObj : MonoBehaviour, IStorage, IPrefabStorage
    {
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private LevelSetup _levelSetup;
        [SerializeField] private DifficultyPickerView _difficultyPickerViewPrefab;
        [SerializeField] private CoffeeBarView _coffeeBarView;
        [SerializeField] private EndGameView.EndGameView _endGameView;
        [SerializeField] private DeadlineBarView _deadlineBarView;

        public IDifficultyPickerView GetDifficultyPickerView()
        {
            var obj = Instantiate(_difficultyPickerViewPrefab, _canvasTransform, false);
            return obj;
        }

        public ICoffeeBarView GetCoffeeBarView()
        {
            var obj = Instantiate(_coffeeBarView, _canvasTransform, false);
            return obj;
        }

        public IEndGameView GetEndGameView()
        {
            var obj = Instantiate(_endGameView, _canvasTransform, false);
            return obj;
        }

        public IDeadlineBarView GetDeadlineBarView()
        {
            var obj = Instantiate(_deadlineBarView, _canvasTransform, false);
            return obj;
        }

        public int[] GetCoffeeBarParams(DifficultyType type)
        {
            var result = new int[3];
            var setup = _levelSetup.GetSetupByDifficulty(type);
            result[0] = setup.maxCoffeeValue;
            result[1] = setup.deltaCoffeeIncrease;
            result[2] = setup.deltaCoffeeDecreasePerSecond;
            return result;
        }

        public int GetDeadlineTime(DifficultyType type)
        {
            var setup = _levelSetup.GetSetupByDifficulty(type);
            return setup.deadlineTime;
        }

        public IEndGameDescription GetEndGameDescription(DifficultyType type, GameResultType result)
        {
            var setup = _levelSetup.GetSetupByDifficulty(type);
            return setup.GetEndGameDescription(result);
        }
    }
}