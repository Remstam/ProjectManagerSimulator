using System;
using System.Collections.Generic;
using Assets.Scripts.Core.Difficulty;
using Code.Alex.Helper;
using Code.Alex.ScriptableObjects;
using Sirenix.Utilities;
using UnityEngine;

namespace Code.Alex
{
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