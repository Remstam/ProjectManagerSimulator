using Code.Alex.Helper;
using Code.Alex.ScriptableObjects;
using UnityEngine;

namespace Code
{
    public class MatchIconUi : MonoBehaviour
    {
        public MatchIcon matchFigure;

        public void Match(Figure figure)
        {
            var onlyColor = figure.FigureColor ==  matchFigure.matchColor&& figure.FigureType != matchFigure.matchType;
            var onlyType = figure.FigureColor !=   matchFigure.matchColor&& figure.FigureType == matchFigure.matchType;
            var colorNType = figure.FigureColor == matchFigure.matchColor&& figure.FigureType == matchFigure.matchType;

            if (onlyColor)
            {
                print(nameof(onlyColor));
            }
            else if (onlyType)
            {
                print(nameof(onlyType));
            }
            else if (colorNType)
            {
                print(nameof(colorNType));
            }
            else
            {
                print("Nothing");
            }
        }
    }
}