using System;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;

namespace Assets.Scripts.DeadlineView
{
    public interface IDeadlineBarModel
    {
        event Action DeadlineHappened;

        void Init(DifficultyType type, IStorage storage);
        void Show();
        void Hide();
        void Halt();
    }
}