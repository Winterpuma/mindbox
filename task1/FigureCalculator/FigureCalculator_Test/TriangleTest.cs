using FigureCalculator;

namespace FigureCalculator_Test
{
	[TestClass]
	public class TriangleTest
	{
		private const double EPS = 0.0001;

		[TestMethod]
		public void Triangle_WithValidSides_GetArea()
		{
			var (a, b, c) = (2, 2.7, 3.5);
			var expectedArea = 2.68931;
			var triangle = new Triangle(a, b, c);

			var actualArea = triangle.Area;

			AssertExtension.DoubleAreEqual(expectedArea, actualArea, EPS);
		}

		[TestMethod]
		public void Triangle_SlimSides_GetArea()
		{
			var (a, b, c) = (1, 2.6, 3.5);
			var expectedArea = 0.65574;
			var triangle = new Triangle(a, b, c);

			var actualArea = triangle.Area;

			AssertExtension.DoubleAreEqual(expectedArea, actualArea, EPS);
		}

		[TestMethod]
		public void Triangle_WithZeroSide_ShouldThrowException()
		{
			var (a, b, c) = (1, 0, 3.5);

			Assert.ThrowsException<ArgumentException>(() => new Triangle(a, b, c));
		}

		[TestMethod]
		public void Triangle_WithNegativeSide_ShouldThrowException()
		{
			var (a, b, c) = (-2, 2.7, 3.5);

			Assert.ThrowsException<ArgumentException>(() => new Triangle(a, b, c));
		}

		[TestMethod]
		public void Triangle_NotExisting_ShouldThrowException()
		{
			var (a, b, c) = (1, 2.5, 3.5);

			Assert.ThrowsException<ArgumentException>(() => new Triangle(a, b, c));
		}

		[TestMethod]
		public void Triangle_RightTriangle_GetArea()
		{
			var (a, b, c) = (5, 4, 3);
			var expectedArea = 6;
			var triangle = new Triangle(a, b, c);

			var actualArea = triangle.Area;

			AssertExtension.DoubleAreEqual(expectedArea, actualArea, EPS);
		}

		[TestMethod]
		public void Triangle_RightTriangle_IsRight()
		{
			var (a, b, c) = (5, 4, 3);
			var triangle = new Triangle(a, b, c);

			var actual = triangle.IsRightTriangle;

			Assert.IsTrue(actual, "Given triangle is expected to be right but calculated that its not.");
		}

		[TestMethod]
		public void Triangle_NotRightTriangle_IsRight()
		{
			var (a, b, c) = (2, 2.6, 3.5);
			var triangle = new Triangle(a, b, c);

			var actual = triangle.IsRightTriangle;

			Assert.IsFalse(actual, "Given triangle is expected not to be right but calculated that it is.");
		}
	}
}