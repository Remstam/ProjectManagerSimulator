using Assets.Scripts.Core;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Core.EndGame;

namespace Assets.Scripts.Storage
{
    public interface IStorage
    {
        int[] GetCoffeeBarParams(DifficultyType type);
        int GetDeadlineTime(DifficultyType type);
        IEndGameDescription GetEndGameDescription(DifficultyType type, GameResultType result);
    }
}