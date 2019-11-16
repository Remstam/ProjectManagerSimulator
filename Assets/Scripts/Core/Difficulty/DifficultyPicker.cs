using System;

namespace Assets.Scripts.Core.Difficulty
{
    public class DifficultyPicker : IDifficultyPicker
    {
        public event Action<DifficultyType> DifficultyPicked = delegate { };

        public void Show()
        {

        }

        public void Hide()
        {

        }
    }
}