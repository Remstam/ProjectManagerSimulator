namespace Code.Alex.Helper
{
    public struct Figure
    {
        public FigureType FigureType { get; }
        public FigureColor FigureColor { get; }

        public FactoryProduct Product { get; }

        public Figure(FigureColor figureColor, FigureType figureType, FactoryProduct product)
        {
            FigureColor = figureColor;
            FigureType = figureType;
            Product = product;
        }
    }
}