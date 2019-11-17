using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Core.EndGame;
using Assets.Scripts.Core.GameCycle;
using Assets.Scripts.Storage;

namespace Assets.Scripts.Core
{
    public class GameLoop : IGameLoop
    {
        private readonly IStorage _storage;
        private readonly IPrefabStorage _prefabStorage;
        private readonly IDifficultyPicker _difficultyPicker;
        private readonly IGameMainCycle _mainCycle;
        private readonly IEndGamePresenter _endGamePresenter;
        private DifficultyType _difficultyType;
        
        public GameLoop(IStorage storage, IPrefabStorage prefabStorage)
        {
            _storage = storage;
            _prefabStorage = prefabStorage;
            _difficultyPicker = new DifficultyPicker(prefabStorage);
            _mainCycle = new GameMainCycle();
            _endGamePresenter = new EndGamePresenter(prefabStorage);

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
            _difficultyType = type;

            _difficultyPicker.Hide();
            _mainCycle.Init(type, _storage, _prefabStorage);
        }

        private void OnGameEnded(GameResultType resultType)
        {
            UnityEngine.Debug.LogWarning("GameEnded with" + resultType);

            var endGameDesc = _storage.GetEndGameDescription(_difficultyType, resultType);
            _endGamePresenter.Show(endGameDesc);
        }
    }
}