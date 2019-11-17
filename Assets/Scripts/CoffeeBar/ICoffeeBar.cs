using System;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;

namespace Assets.Scripts.CoffeeBar
{
    public interface ICoffeeBar
    {
        event Action BarFault;

        void Init(DifficultyType type, IStorage storage);
        void Halt();
    }
}