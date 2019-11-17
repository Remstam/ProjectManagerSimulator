namespace Code.Alex.Helper
{
    public struct Figure
    {
        public FigureType FigureType { get; }
        public FigureColor FigureColor { get; }

        public Figure(FigureColor figureColor, FigureType figureType)
        {
            FigureColor = figureColor;
            FigureType = figureType;
        }
    }
}