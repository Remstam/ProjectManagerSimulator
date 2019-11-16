using System;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;

namespace Assets.Scripts.Core.GameCycle
{
    public interface IGameMainCycle
    {
        event Action<GameResultType> GameEnded;

        void Init(DifficultyType type, IStorage storage, IPrefabStorage prefabStorage);
        void Reset();
    }
}