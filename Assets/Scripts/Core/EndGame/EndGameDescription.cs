using UnityEngine;

namespace Assets.Scripts.Core.EndGame
{
    [CreateAssetMenu(fileName = "EndGameDesc", menuName = "Scriptable/EndGame desc")]
    public class EndGameDescription : ScriptableObject, IEndGameDescription
    {
        [SerializeField] private GameResultType _gameResultType;
        [SerializeField] private string _title;
        [SerializeField] private string _description;

        public GameResultType Result
        {
            get { return _gameResultType; }
            set { _gameResultType = value; }
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