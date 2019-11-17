using System;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;

namespace Assets.Scripts.CoffeeBar
{
    public class CoffeeBarModel : ICoffeeBar
    {
        public event Action BarFault = delegate { };

        private readonly ICoffeeBarView _view;

        public CoffeeBarModel(IPrefabStorage prefabStorage)
        {
            _view = prefabStorage.GetCoffeeBarView();
            _view.BarFault += () => BarFault();
        }

        public void Init(DifficultyType difficultyType, IStorage storage)
        {
            var args = storage.GetCoffeeBarParams(difficultyType);
            _view.Init(args[0], args[1], args[2]);
        }

        public void Halt()
        {
            _view.Halt();
        }
    }
}