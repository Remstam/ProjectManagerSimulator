using System.Collections.Generic;
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
        [Header("Easy")] public List<BaseState> easyStates;
        [Header("Medium")] public List<BaseState> mediumStates;
        [Header("Hardcore")] public List<BaseState> hardcodeStates;
    }
}