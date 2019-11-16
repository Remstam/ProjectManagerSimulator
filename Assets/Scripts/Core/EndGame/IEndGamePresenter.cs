using System;

namespace Assets.Scripts.Core.EndGame
{
    public interface IEndGamePresenter
    {
        event Action Restart;

        void Show(GameResultType gameResultType);
        void Hide();
    }
}