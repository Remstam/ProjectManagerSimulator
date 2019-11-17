using System;
using Assets.Scripts.Core.Difficulty;

namespace Assets.Scripts.View
{
    public interface IDifficultyButton
    {
        event Action<DifficultyType> Clicked;
    }
}