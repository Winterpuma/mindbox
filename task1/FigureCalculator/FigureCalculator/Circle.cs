using System.Diagnostics.Contracts;

namespace FigureCalculator
{
	public class Circle : IFigure
	{
		private readonly double _radius;
		private readonly Lazy<double> _area;

		public Circle(double radius)
		{
			if (radius <= 0)
				throw new ArgumentException("Radius should be positive value.");

			_radius = radius;
			_area = new Lazy<double>(() => Math.PI * _radius * _radius);
		}

		public double Area => _area.Value;
	}
}