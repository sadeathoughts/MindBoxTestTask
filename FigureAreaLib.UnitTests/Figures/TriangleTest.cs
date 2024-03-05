namespace FigureAreaLib.UnitTests.Figures
{
    public class TriangleTest
    {
        [Fact]
        public void A3B4C5Equal6()
        {
            Triangle triangle = new(3, 4, 5);
            double result = triangle.CalculateArea();
            Assert.Equal(6, result);
        }

        [Fact]
        public void A6B8С10EqualRight()
        {
            Triangle triangle = new(6, 8, 10);
            bool result = triangle.IsRight();
            Assert.True(result);
        }

        [Fact]
        public void A0B5C2ThrowsInvalidArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Triangle triangle = new(0, 1, 2);
            });
        }

        [Fact]
        public void A2B2C10ThrowsInvalidArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Triangle triangle = new(2, 2, 10);
            });
        }
    }
}
