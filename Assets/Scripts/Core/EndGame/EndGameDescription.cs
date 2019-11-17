using Assets.Scripts.Core.Difficulty;
using UnityEngine;

namespace Assets.Scripts.Core.EndGame
{
    public class EndGameDescription : IEndGameDescription
    {
        [SerializeField] private GameResultType _gameResultType;
        [SerializeField] private DifficultyType _difficultyType;
        [SerializeField] private string _title;
        [SerializeField] private string _description;

        public GameResultType Result
        {
            get { return _gameResultType; }
            set { _gameResultType = value; }
        }

        public DifficultyType DifficultyType
        {
            get { return _difficultyType; }
            set { _difficultyType = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}