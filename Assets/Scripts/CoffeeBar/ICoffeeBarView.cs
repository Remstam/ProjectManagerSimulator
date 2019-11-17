using System;

namespace Assets.Scripts.CoffeeBar
{
    public interface ICoffeeBarView
    {
        event Action BarFault;

        void Init(int maxValue, int deltaInc, int deltaDec);
        void Show();
        void Hide();
        void Halt();
    }
}