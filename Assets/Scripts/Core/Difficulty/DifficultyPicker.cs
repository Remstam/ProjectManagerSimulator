using System;
using Assets.Scripts.Storage;
using Assets.Scripts.View;

namespace Assets.Scripts.Core.Difficulty
{
    public class DifficultyPicker : IDifficultyPicker
    {
        public event Action<DifficultyType> DifficultyPicked = delegate { };

        private IDifficultyPickerView _view;

        public DifficultyPicker(IPrefabStorage storage)
        {
            _view = storage.GetDifficultyPickerView();
            _view.Clicked += x => DifficultyPicked(x);
        }

        public void Show()
        {
            _view.SetActive(true);
        }

        public void Hide()
        {
            _view.SetActive(false);
        }
    }
}