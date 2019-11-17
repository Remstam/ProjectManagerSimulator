using System;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;

namespace Assets.Scripts.DeadlineView
{
    public class DeadlineBarModel : IDeadlineBarModel
    {
        public event Action DeadlineHappened = delegate { };

        private readonly IDeadlineBarView _view;

        public DeadlineBarModel(IPrefabStorage prefabStorage)
        {
            _view = prefabStorage.GetDeadlineBarView();
            _view.SlideCompleted += () => DeadlineHappened();
            _view.Hide();
        }

        public void Init(DifficultyType type, IStorage storage)
        {
            var deadlineTime = storage.GetDeadlineTime(type);
            _view.Init(deadlineTime);
            _view.Show();
        }

        public void Show()
        {
            _view.Show();
        }

        public void Hide()
        {
            _view.Hide();
        }

        public void Halt()
        {
            _view.Halt();
        }
    }
}