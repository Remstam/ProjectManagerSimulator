using System;
using Assets.Scripts.CoffeeBar;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;

namespace Assets.Scripts.Core.GameCycle
{
    public class GameMainCycle : IGameMainCycle
    {
        public event Action<GameResultType> GameEnded = delegate { };

        private ICoffeeBar _coffeeBar;

        public void Init(DifficultyType type, IStorage storage, IPrefabStorage prefabStorage)
        {
            InitCoffeeBar(type, storage, prefabStorage);
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

            _coffeeBar.Init(type, storage);
        }

        private void OnBarFault()
        {
            OnGameEnded(GameResultType.OutOfCoffee);
        }

        private void OnGameEnded(GameResultType resultType)
        {
            _coffeeBar.Halt();

            GameEnded(resultType);
        }
    }
}