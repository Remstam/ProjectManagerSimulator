using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core;
using Assets.Scripts.Core.EndGame;
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
        [Title("Deadline Setup")]
        public int deadlineTime;
        [Title("EndGame descriptions")]
        public List<EndGameDescription> endGameDescriptions;

        public IEndGameDescription GetEndGameDescription(GameResultType resultType)
        {
            var desc = endGameDescriptions.FirstOrDefault(x => x.Result == resultType);
            if (desc == null)
                return new EndGameDescription();

            return desc;
        }
    }
}