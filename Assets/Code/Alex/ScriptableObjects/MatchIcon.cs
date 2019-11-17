using Code.Alex.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Alex.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable/Match")]
    public class MatchIcon : ScriptableObject
    {
        [InfoBox("Объект в котором задаются параметры исходных фигу для матчинга")]
        [EnumPaging] public FigureType matchType;
        [EnumPaging] public FigureColor matchColor;
    }
}