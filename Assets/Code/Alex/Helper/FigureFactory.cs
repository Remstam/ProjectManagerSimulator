using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code.Alex.Helper
{
    public static class FigureFactory
    {
        public static readonly List<FactoryProduct> FactoryProducts = new List<FactoryProduct>();

        public static FactoryProduct CreateFigure(FigureType type, FigureColor color, Transform parent = null)
        {
            try
            {
                var figureLoad = Resources.Load<GameObject>(Path.Combine("Figures", type.ToString()));
                var instance = parent == null ? Object.Instantiate(figureLoad) : Object.Instantiate(figureLoad, parent);
                SetColor(instance.GetComponentInChildren<Image>(), color);
                var product = new FactoryProduct(instance);
                FactoryProducts.Add(product);
                return product;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
        }

        private static void SetColor(Image image, FigureColor figureColor)
        {
            switch (figureColor)
            {
                case FigureColor.Black:
                    image.color = Color.black;
                    break;
                case FigureColor.Blue:
                    image.color = Color.blue;
                    break;
                case FigureColor.Cyan:
                    image.color = Color.cyan;
                    break;
                case FigureColor.Green:
                    image.color = Color.green;
                    break;
                case FigureColor.Gray:
                    image.color = Color.green;
                    break;
                case FigureColor.Magenta:
                    image.color = Color.magenta;
                    break;
                case FigureColor.Red:
                    image.color = Color.red;
                    break;
                case FigureColor.White:
                    image.color = Color.white;
                    break;
                case FigureColor.Yellow:
                    image.color = Color.white;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}