using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Core.EndGame;
using Assets.Scripts.Core.GameCycle;
using Assets.Scripts.Storage;

namespace Assets.Scripts.Core
{
    public class GameLoop : IGameLoop
    {
        private readonly IStorage _storage;
        private readonly IDifficultyPicker _difficultyPicker;
        private readonly IGameMainCycle _mainCycle;
        private readonly IEndGamePresenter _endGamePresenter;

        public GameLoop(IStorage storage)
        {
            _storage = storage;
            _difficultyPicker = new DifficultyPicker();
            _mainCycle = new GameMainCycle();
            _endGamePresenter = new EndGamePresenter();

            _difficultyPicker.DifficultyPicked += OnDifficultyPicked;
            _mainCycle.GameEnded += OnGameEnded;
            _endGamePresenter.Restart += Run;
        }

        public void Run()
        {
            _endGamePresenter.Hide();
            _difficultyPicker.Show();

            _mainCycle.Reset();
        }

        private void OnDifficultyPicked(DifficultyType type)
        {
            _difficultyPicker.Hide();
            _mainCycle.Init(type, _storage);
        }

        private void OnGameEnded(GameResultType resultType)
        {
            _endGamePresenter.Show(resultType);
        }
    }
}