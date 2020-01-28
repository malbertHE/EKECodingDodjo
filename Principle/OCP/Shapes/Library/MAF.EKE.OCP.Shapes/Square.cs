namespace MAF.EKE.OCP.Shapes
{
	/// <summary>Négyzet osztály.</summary>
	public class Square: Quadrilateral
	{
		/// <summary>Oldal szélesség alapján készít egy négyzetet, ahol A=(0,0) kezdőkoordinátával a további pontokat a fel, jobbra, le, balra módszerrel adjuk meg.</summary>
		/// <param name="pWidth">Négyzet oldala.</param>
		/// <returns>Négyzet objektum.</returns>
		public static Square CreateSquare(double pWidth)
		{
			Point A = new Point(0, 0);
			Point B = new Point(0, pWidth);
			Point C = new Point(pWidth, pWidth);
			Point D = new Point(pWidth, 0);
			return new Square(A, B, C, D);
		}

		/// <summary>Konstruktor, ami pontosan a négyszöget alkotó pontokat kéri be, a megfelelő sorrendben.</summary>
		/// <param name="pPointA">Az A pont, amit <see cref="A" property-ben kérhetünk majd vissza./></param>
		/// <param name="pPointB">A B pont, amit <see cref="B" property-ben kérhetünk majd vissza./></param>
		/// <param name="pPointC">A C pont, amit <see cref="C" property-ben kérhetünk majd vissza./></param>
		/// <param name="pPointD">A D pont, amit <see cref="D" property-ben kérhetünk majd vissza./></param>
		Square(Point pPointA, Point pPointB, Point pPointC, Point pPointD) : base(pPointA, pPointB, pPointC, pPointD)
		{
		}

		/// <summary>Négyzet területének kiszámítása.</summary>
		/// <returns>A négyzet relatív területe.</returns>
		public double AreaCalculation()
		{
			try
			{
				double width = Distance(0, 1);
				double result = width * width;
				if (double.IsInfinity(result))
					throw new OverflowException();
				return result;
			}
			catch(OverflowException ex)
			{
				throw new SquareException(Shape.C_OverflowError, ex);
			}
		}
	}

	[Serializable]
	public class SquareException : Exception
	{
		public SquareException(string message) : base(message)
		{
		}

		public SquareException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
