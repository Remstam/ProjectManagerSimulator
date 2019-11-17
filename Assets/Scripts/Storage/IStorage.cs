using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Core.EndGame;
using Code.Alex.ScriptableObjects;

namespace Assets.Scripts.Storage
{
    public interface IStorage
    {
        List<BaseState> GetBaseStates(DifficultyType type);
        int[] GetCoffeeBarParams(DifficultyType type);
        int GetDeadlineTime(DifficultyType type);
        IEndGameDescription GetEndGameDescription(DifficultyType type, GameResultType result);
    }
}