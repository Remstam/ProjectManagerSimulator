using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Alex;
using Assets.Scripts.Core.GameCycle;
using Assets.Scripts.FigureProcessor;
using Code.Alex.Helper;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Code.Alex.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable/State")]
    public class BaseState : ScriptableObject
    {
        [InfoBox("Объект, который описывает базовые последовательности уровней")] [ListDrawerSettings]
        public List<BaseFigure> baseFigures;

        public List<MatchIcon> matchIcons;
        [SceneObjectsOnly] public RectTransform matchParent;

        [MinMaxSlider(0.5f, 5f, true)] public Vector2 minMaxSpawnTime = new Vector2(0.5f, 5f);

        public event Action OnStateStart = () => { };
        public event Action OnStateEnd = () => { };
        public event Action OnLastStageEnd = () => { };

        private Queue<BaseFigure> _queueShuffledFigures = new Queue<BaseFigure>();
        private List<FactoryProduct> _createdMatchObjects = new List<FactoryProduct>();

        public void StartState()
        {
            _queueShuffledFigures = baseFigures.ToShuffledQueue();

            LoadMatchIcons();

            OnStateStart?.Invoke();

            CoroutineChain.Start.Play(PlayStage());

            var last = _queueShuffledFigures.Last();
            last.OnMoveEnd += StageEnd;
        }

        private void LoadMatchIcons()
        {
            foreach (var easyMatchIcon in matchIcons)
            {
                var icon = FigureFactory.CreateUiFigure(easyMatchIcon.matchType, easyMatchIcon.matchColor, matchParent);
                _createdMatchObjects.Add(icon);
                var matchIconUi = icon.Add<MatchIconUi>();
                matchIconUi.matchFigure = easyMatchIcon;
                Destroy(icon.GetInChild<Text>().gameObject);
            }
        }

        private IEnumerator PlayStage()
        {
            while (_queueShuffledFigures.Count != 0)
            {
                _queueShuffledFigures.Dequeue().DoBehaviour();
                yield return new WaitForSeconds(Random.Range(minMaxSpawnTime.x, minMaxSpawnTime.y));
            }
        }

        public void DisposeMatchedObjects()
        {
            _createdMatchObjects.ForEach(e => e.Dispose());
        }

        private void StageEnd(BaseFigure figure)
        {
            figure.OnMoveEnd -= StageEnd;
            GameMainCycle._figureProcessor.CountMatchedFigures = int.MaxValue;
        }
    }
}