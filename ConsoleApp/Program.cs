using FigureAreaLib;
using FigureAreaLib.Figures;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            RunLib();
        }

        private static void RunLib()
        {
            Circle circle = new(20);
            Triangle triangle = new(3, 4, 5);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(triangle.CalculateArea());

            // Вычисление площади фигуры без знания типа фигуры в compile-time
            Console.WriteLine(UnknownFigure.CalculateArea(circle));
            Console.WriteLine(UnknownFigure.CalculateArea(triangle));

            // Проверку на то, является ли треугольник прямоугольным
            Console.WriteLine(triangle.IsRight() ? "Прямоугольный" : "Не прямоугольный");
        }
    }
}
