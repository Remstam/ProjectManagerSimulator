using System;

namespace Assets.Scripts.Core.Difficulty
{
    public interface IDifficultyPicker
    {
        event Action<DifficultyType> DifficultyPicked;

        void Hide();
    }
}