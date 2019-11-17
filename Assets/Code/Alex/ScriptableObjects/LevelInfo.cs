using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Alex.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable/LevelInfo")]
    public class LevelInfo : ScriptableObject
    {
        public List<BaseState> states;

        [Title("Coffee Setup")] public int maxCoffeeValue;
        public int deltaCoffeeIncrease;
        public int deltaCoffeeDecreasePerSecond;
    }
}