namespace FigureAreaLib.Figures
{
    public class Triangle : Figure
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Triangle(double a, double b, double c)
        {
            ValidateArguments(a, b, c);
            A = a;
            B = b;
            C = c;
        }

        public override double CalculateArea()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool IsRight()
        {
            return A == Math.Sqrt(Math.Pow(B, 2) + Math.Pow(C, 2)) ||
                B == Math.Sqrt(Math.Pow(A, 2) + Math.Pow(C, 2)) ||
                C == Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
        }

        private static void ValidateArguments(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Сторона треугольника не может быть меньше или равна 0");
            }
            else if (a > b + c || b > a + c || c > a + b)
            {
                throw new ArgumentException("Ни одна сторона треугольника, не может быть больше суммы двух других сторон");
            }
        }
    }
}
