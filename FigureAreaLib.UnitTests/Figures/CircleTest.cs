namespace FigureAreaLib.UnitTests.Figures
{
    public class CircleTest
    {
        [Fact]
        public void Radius20Equal1256dot64()
        {
            Circle circle = new(20);
            double result = circle.CalculateArea();
            Assert.Equal(1256.64, Math.Round(result, 2));
        }

        [Fact]
        public void RadiusMinus2ThrowsInvalidArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Circle circle = new(-2);
            });
        }
    }
}
