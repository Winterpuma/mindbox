namespace FigureCalculator_Test
{
	internal static class AssertExtension
	{
		public static void DoubleAreEqual(double expected, double actual, double EPS)
		{
			Assert.IsTrue(Math.Abs(expected - actual) < EPS, $"Not equal. Expected: {expected}. Actual: {actual}. Eps for comparison: {EPS}");
		}
	}
}
