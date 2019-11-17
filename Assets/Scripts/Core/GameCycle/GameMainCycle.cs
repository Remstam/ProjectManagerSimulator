using System;
using Assets.Scripts.CoffeeBar;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.DeadlineView;
using Assets.Scripts.Storage;

namespace Assets.Scripts.Core.GameCycle
{
    public class GameMainCycle : IGameMainCycle
    {
        public event Action<GameResultType> GameEnded = delegate { };

        private ICoffeeBar _coffeeBar;
        private IDeadlineBarModel _deadlineBar;
        public static FigureProcessor.FigureProcessor _figureProcessor;

        public void Init(DifficultyType type, IStorage storage, IPrefabStorage prefabStorage)
        {
            InitDeadlineBar(type, storage, prefabStorage);
            InitCoffeeBar(type, storage, prefabStorage);
            InitFigureProcessor(type, storage);
        }

        public void Reset()
        {

        }

        private void InitCoffeeBar(DifficultyType type, IStorage storage, IPrefabStorage prefabStorage)
        {
            if (_coffeeBar == null)
            {
                _coffeeBar = new CoffeeBarModel(prefabStorage);
                _coffeeBar.BarFault += OnBarFault;
            }

            _coffeeBar.Show();
            _coffeeBar.Init(type, storage);
        }

        private void InitDeadlineBar(DifficultyType type, IStorage storage, IPrefabStorage prefabStorage)
        {
            if (_deadlineBar == null)
            {
                _deadlineBar = new DeadlineBarModel(prefabStorage);
                _deadlineBar.DeadlineHappened += OnDeadlineHappened;
            }

            _deadlineBar.Init(type, storage);
            _deadlineBar.Show();
        }

        private void InitFigureProcessor(DifficultyType type, IStorage storage)
        {
            if (_figureProcessor == null)
            {
                _figureProcessor = new FigureProcessor.FigureProcessor();
                _figureProcessor.OnGameEnd += OnFigureProcessor;
            }

            _figureProcessor.Init(type, storage);
        }

        private void OnBarFault()
        {
            OnGameEnded(GameResultType.OutOfCoffee);
        }

        private void OnDeadlineHappened()
        {
            OnGameEnded(GameResultType.DeadlineApproached);
        }

        private void OnFigureProcessor(GameResultType resultType)
        {
            OnGameEnded(resultType);
        }

        private void OnGameEnded(GameResultType resultType)
        {
            _deadlineBar.Halt();
            _deadlineBar.Hide();

            _coffeeBar.Halt();
            _coffeeBar.Hide();

            GameEnded(resultType);
        }
    }
}