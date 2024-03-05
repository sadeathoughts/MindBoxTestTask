namespace FigureAreaLib.Figures
{
    public class Circle : Figure
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            ValidateArguments(radius);
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        private static void ValidateArguments(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус круга не может быть меньше или равным 0");
            }
        }
    }
}
