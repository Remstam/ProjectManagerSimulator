using Assets.Scripts.Core.Difficulty;

namespace Assets.Scripts.Core.EndGame
{
    public interface IEndGameDescription
    {
        GameResultType Result { get; }
        DifficultyType DifficultyType { get; }
        string Title { get; }
        string Description { get; }
    }
}