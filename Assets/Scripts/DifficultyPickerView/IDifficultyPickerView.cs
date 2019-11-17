using System;
using Assets.Scripts.Core.Difficulty;

namespace Assets.Scripts.View
{
    public interface IDifficultyPickerView
    {
        event Action<DifficultyType> Clicked;

        void SetActive(bool isActive);
    }
}