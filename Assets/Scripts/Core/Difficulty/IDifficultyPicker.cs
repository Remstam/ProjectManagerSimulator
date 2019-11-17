using System;

namespace Assets.Scripts.Core.Difficulty
{
    public interface IDifficultyPicker
    {
        event Action<DifficultyType> DifficultyPicked;

        void Show();
        void Hide();
    }
}