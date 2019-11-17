using System;
using Assets.Scripts.EndGameView;
using Assets.Scripts.Storage;

namespace Assets.Scripts.Core.EndGame
{
    public class EndGamePresenter : IEndGamePresenter
    {
        public event Action Restart = delegate { };

        private readonly IEndGameView _endGameView;

        public EndGamePresenter(IPrefabStorage prefabStorage)
        {
            _endGameView = prefabStorage.GetEndGameView();
            _endGameView.RestartClicked += () => Restart();
            _endGameView.Hide();
        }

        public void Show(GameResultType gameResultType)
        {
            _endGameView.Show();
        }

        public void Hide()
        {
            _endGameView.Hide();
        }
    }
}