using System;
using System.Collections;
using System.Collections.Generic;
using Alex;
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
        [SceneObjectsOnly]public RectTransform matchParent;

        public int maxPlayerMistakes;
        [MinMaxSlider(0.5f, 5f,true)]public Vector2 minMaxSpawnTime = new Vector2(0.5f, 5f);

        [Title("TimeLine Settings")] public float duration;
        public float boostCorrectMatching;
        public float boostIncorrectMatching;
        
        public event Action OnStateStart = () => { };
        public event Action OnStateEnd = () => { };

        private Queue<BaseFigure> _queueShuffledFigures = new Queue<BaseFigure>();
        private List<GameObject> _createdMatchObjects;

        public void StartState()
        {
            _queueShuffledFigures = baseFigures.ToShuffledQueue();
            
            LoadMatchIcons();
            
            OnStateStart?.Invoke();

            CoroutineChain.Start.Play(PlayStage());
        }

        private void LoadMatchIcons()
        {
            if (matchIcons == null)
            {
                Debug.Log("NO MATCH");
                return;
            }
            foreach (var easyMatchIcon in matchIcons)
            {
                var icon = FigureFactory.CreateFigure(easyMatchIcon.matchType, easyMatchIcon.matchColor, matchParent);
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
            OnStateEnd?.Invoke();
        }
    }
}