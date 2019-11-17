using Assets.Scripts.CoffeeBar;
using Assets.Scripts.DeadlineView;
using Assets.Scripts.EndGameView;
using Assets.Scripts.View;

namespace Assets.Scripts.Storage
{
    public interface IPrefabStorage
    {
        IDifficultyPickerView GetDifficultyPickerView();
        ICoffeeBarView GetCoffeeBarView();
        IEndGameView GetEndGameView();
        IDeadlineBarView GetDeadlineBarView();
    }
}