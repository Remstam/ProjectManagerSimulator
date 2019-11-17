namespace Assets.Scripts.Core.EndGame
{
    public interface IEndGameDescription
    {
        GameResultType Result { get; }
        string Title { get; }
        string Description { get; }
    }
}