using System;

namespace Assets.Scripts.DeadlineView
{
    public interface IDeadlineBarView
    {
        event Action SlideCompleted;

        void Init(int deadlineTime);
        void Show();
        void Hide();
        void Halt();
    }
}