using System;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;

namespace Assets.Scripts.Core.GameCycle
{
    public class GameMainCycle : IGameMainCycle
    {
        public event Action<GameResultType> GameEnded = delegate { };
        
        public void Init(DifficultyType type, IStorage storage)
        {
            
        }

        public void Reset()
        {

        }
    }
}