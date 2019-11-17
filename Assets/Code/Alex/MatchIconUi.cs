using System;
using Code.Alex.Helper;
using Code.Alex.ScriptableObjects;
using UnityEngine;

namespace Code.Alex
{
    public class MatchIconUi : MonoBehaviour
    {
        public MatchIcon matchFigure;

        private LevelSetup _levelSetup;
        private void Start()
        {
            _levelSetup = FindObjectOfType<LevelSetup>();
        }

        public void Match(Figure figure)
        {
            var onlyColor = figure.FigureColor == matchFigure.matchColor && figure.FigureType != matchFigure.matchType;
            var onlyType = figure.FigureColor != matchFigure.matchColor && figure.FigureType == matchFigure.matchType;
            var colorNType = figure.FigureColor == matchFigure.matchColor && figure.FigureType == matchFigure.matchType;

            // todo write change level if all figures matched
            
            if (onlyColor)
            {
                _levelSetup.CountMatchedFigures++;
//                FigureFactory.FigureProducts.Remove(figure.Product);
                print(nameof(onlyColor));
            }
            else if (onlyType)
            {
                _levelSetup.CountMatchedFigures++;
//                FigureFactory.FigureProducts.Remove(figure.Product);
                print(nameof(onlyType));
            }
            else if (colorNType)
            {
                _levelSetup.CountMatchedFigures++; 
//                FigureFactory.FigureProducts.Remove(figure.Product);
                print(nameof(colorNType));
            }
            else
            {
                print("Nothing");
                _levelSetup.CountMatchedFigures++;
                _levelSetup.CountPlayerMistakes++;
            }
//            print(FigureFactory.FigureProducts.Count);
            
//            if (FigureFactory.FigureProducts.Count == 0)
//            {
//                FindObjectOfType<LevelSetup>().CountMatchedFigures = int.MaxValue;
//            }
        }
    }
}