using Code.Alex.Helper;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Alex.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable/Figure")]
    public class BaseFigure : ScriptableObject 
    {
        [InfoBox("Объект, который описывает базовые компоненты для фигуры")] [SceneObjectsOnly]
        public Transform parent;

        [EnumPaging] public FigureType figureType;
        [EnumPaging] public FigureColor figureColor;
        [EnumPaging] public Ease fallingAnimation;
        public float size;
        public string text;
        public float speed;
    }
}