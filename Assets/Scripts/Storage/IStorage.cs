using Assets.Scripts.Core.Difficulty;

namespace Assets.Scripts.Storage
{
    public interface IStorage
    {
        int[] GetCoffeeBarParams(DifficultyType type);
    }
}