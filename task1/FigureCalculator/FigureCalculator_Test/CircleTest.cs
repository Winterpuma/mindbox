using FigureCalculator;

namespace FigureCalculator_Test
{
	[TestClass]
	public class CircleTest
	{
		private const double EPS = 0.000001;

		[TestMethod]
		public void Circle_WithValidRadius_GetArea()
		{
			var radius = 3.3;
			var expectedArea = 34.211943996615;
			var circle = new Circle(radius);

			var actualArea = circle.Area;

			AssertExtension.DoubleAreEqual(expectedArea, actualArea, EPS);
		}

		[TestMethod]
		public void Circle_WithZeroRadius_ShouldThrowException()
		{
			var radius = 0;

			Assert.ThrowsException<ArgumentException>(() => new Circle(radius));
		}

		[TestMethod]
		public void Circle_WithNegativeRadius_ShouldThrowException()
		{
			var radius = -2;

			Assert.ThrowsException<ArgumentException>(() => new Circle(radius));
		}
	}
}