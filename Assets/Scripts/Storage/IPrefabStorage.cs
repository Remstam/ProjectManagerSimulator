using Assets.Scripts.CoffeeBar;
using Assets.Scripts.View;

namespace Assets.Scripts.Storage
{
    public interface IPrefabStorage
    {
        IDifficultyPickerView GetDifficultyPickerView();
        ICoffeeBarView GetCoffeeBarView();
    }
}