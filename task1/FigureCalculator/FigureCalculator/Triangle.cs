namespace FigureCalculator
{
	public class Triangle : IFigure
	{
		private readonly double _aLength;
		private readonly double _bLength;
		private readonly double _cLength;

		private readonly double _perimeter;
		private readonly Lazy<double> _area;
		private readonly Lazy<bool> _isRightTriangle;

		private const double EPS = 0.000001;

		public Triangle(double aLength, double bLength, double cLength)
		{
			_aLength = aLength;
			_bLength = bLength;
			_cLength = cLength;

			CheckTriangleSidesInput();
			CheckTriangleExistBySides();

			_perimeter = _aLength + _bLength + _cLength;

			_area = new Lazy<double>(() => GetArea());
			_isRightTriangle = new Lazy<bool>(() => GetIsRightTriangle());
		}

		public double Area => _area.Value;
		public bool IsRightTriangle => _isRightTriangle.Value;


		private double GetArea()
		{
			var p = _perimeter / 2;
			return Math.Sqrt(p * (p - _aLength) * (p - _bLength) * (p - _cLength));
		}

		private bool GetIsRightTriangle()
		{
			var hypotenuse = Math.Max(_aLength, Math.Max(_bLength, _cLength));

			double sideA, sideB;
			if (hypotenuse == _aLength)
			{
				sideA = _cLength;
				sideB = _bLength;
			}
			else if (hypotenuse == _bLength)
			{
				sideA = _aLength;
				sideB = _cLength;
			}
			else
			{
				sideA = _aLength;
				sideB = _bLength;
			}


			return Math.Abs((hypotenuse * hypotenuse) - ((sideA * sideA) + (sideB * sideB))) < EPS;
		}

		private void CheckTriangleSidesInput()
		{
			if (_aLength <= 0 || _bLength <= 0 || _cLength <= 0)
				throw new ArgumentException("All sides length should be positive values.");
		}

		private void CheckTriangleExistBySides()
		{
			if ((_aLength + _bLength <= _cLength ) || 
				(_aLength + _cLength <= _bLength )|| 
				(_bLength + _cLength <=  _aLength))
				throw new ArgumentException("Given sides length do not form a triangle. " +
					"Sum of any two sides should be greater then third one");
		}
	}
}
