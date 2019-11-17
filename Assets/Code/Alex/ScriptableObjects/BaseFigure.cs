using System;
using Assets.Scripts.Core.GameCycle;
using Code.Alex.Helper;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Code.Alex.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable/Figure")]
    public class BaseFigure : ScriptableObject
    {
        [InfoBox("Объект, который описывает базовые компоненты для фигуры")] [SceneObjectsOnly]
        public RectTransform parent;

        [EnumPaging] public FigureType figureType;
        [EnumPaging] public FigureColor figureColor;
        [EnumPaging] public Ease moveAnimation;
        public Vector2 startFallSize;
        public Vector2 endFallSize;
        [EnumPaging] public Ease sizeChangeAnimation;
        public string text;
        public float fallTime;

        public event Action<BaseFigure> OnMoveEnd = e => { };

        private Vector3 _startPoint;
        private Vector2 _endPoint;

        public void DoBehaviour()
        {
            var instance = FigureFactory.CreateFigure(figureType, figureColor, parent);
            var parentRect = parent.rect;
            // setup spawn point
            var fRect = instance.Get<RectTransform>();
            var rndXPose = GenerateRnd(parent.rect.size.x);
            fRect.localPosition = new Vector2(rndXPose, fRect.rect.position.y - parentRect.yMin);
            _endPoint = new Vector2(rndXPose, -parentRect.size.y - parentRect.yMin);
            fRect.sizeDelta = startFallSize;

            // setup move figure
            var sizeChange = fRect.DOSizeDelta(endFallSize, fallTime).SetEase(sizeChangeAnimation);
            var fMove = fRect.DOLocalMove(_endPoint, fallTime).SetEase(moveAnimation)
                .OnComplete(() =>
                {
                    OnMoveEnd?.Invoke(this);
                    Debug.Log("destroy");
                    GameMainCycle._figureProcessor.CountMatchedFigures++;
                    instance.Dispose();
                });

            // setup DragNDrop
            var dragNDrop = instance.Add<DragNDrop>();
            dragNDrop.SetFigure(new Figure(figureColor, figureType, instance));
            dragNDrop.SetMoveTweener(fMove);
            dragNDrop.SetSizeTweener(sizeChange);

            // setup text
            var fText = instance.GetInChild<Text>();
            fText.text = text;
        }

        private float GenerateRnd(float endValue)
        {
            var lBorderRnd = endValue * -.5f + 50f;
            var rBorderRnd = endValue * .5f - 50f;
            return Random.Range(lBorderRnd, rBorderRnd);
        }
    }
}