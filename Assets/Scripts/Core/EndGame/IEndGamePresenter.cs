using System;

namespace Assets.Scripts.Core.EndGame
{
    public interface IEndGamePresenter
    {
        event Action Restart;

        void Show(IEndGameDescription desc);
        void Hide();
    }
}