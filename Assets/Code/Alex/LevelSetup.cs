using System.Collections.Generic;
using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;
using Code.Alex.ScriptableObjects;
using UnityEngine;

namespace Code.Alex
{
    /// <summary>
    /// Управляет переключением уровней на низком уровне
    /// Хранит в себе все настройки уровней
    /// </summary>
    public class LevelSetup : MonoBehaviour
    {
        [Header("Easy")] public LevelInfo easyStates;
        [Header("Medium")] public LevelInfo mediumStates;
        [Header("Hardcore")] public LevelInfo hardcodeStates;

        public LevelInfo GetSetupByDifficulty(DifficultyType type)
        {
            switch (type)
            {
                case DifficultyType.Easy:
                    return easyStates;
                case DifficultyType.Normal:
                    return mediumStates;
                case DifficultyType.Hard:
                    return hardcodeStates;
            }

            return easyStates;
        }
    }
}