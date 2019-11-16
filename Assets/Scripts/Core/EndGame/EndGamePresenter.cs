using System;

namespace Assets.Scripts.Core.EndGame
{
    public class EndGamePresenter : IEndGamePresenter
    {
        public event Action Restart = delegate { };

        public void Show(GameResultType gameResultType)
        {
            
        }

        public void Hide()
        {
            
        }
    }
}