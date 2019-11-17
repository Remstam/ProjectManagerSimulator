using System;

namespace Assets.Scripts.EndGameView
{
    public interface IEndGameView
    {
        event Action RestartClicked;

        void Init(string title, string description);
        void Show();
        void Hide();
    }
}