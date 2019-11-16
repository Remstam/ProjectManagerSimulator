using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Alex.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable/State")]
    public class BaseState : ScriptableObject
    {
        [InfoBox("Объект, который описывает базовые последовательности уровней")] [ListDrawerSettings]
        public List<BaseFigure> baseFigures;

        public int maxPlayerMistakes;
        public int countUiFigures;

        [Title("TimeLine Settings")] public float duration;
        public float boostCorrectMatching;
        public float boostIncorrectMatching;
        [Title("Coffee Setup")] public float maxValue;
        public float deltaCoffeeIncrease;
    }
}