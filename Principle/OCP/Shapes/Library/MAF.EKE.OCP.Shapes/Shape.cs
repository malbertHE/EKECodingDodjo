using System;
using System.Linq;

namespace MAF.EKE.OCP.Shapes
{
	/// <summary>Az alakzatok őse.</summary>
	public abstract class Shape
	{
        /// <summary>Ha valamely alakzat oldala túl nagy, akkor ezt a hibaüzenetet adja vissza az oldalméret kiszámító függvény.</summary>
        public const string C_OverflowError = "Az alakzat oldala túl nagy!";

        /// <summary>Ha a konstruktor paramétere null értéket kap, akkor ezt a hibát dobja.</summary>
        public const string C_ShapeParameterIsNullError = "Az alakzatot leíró pontok nincsenek megadva!";

        /// <summary>Ha a konstruktor paramétere olyan pont halmazt kap, amik nem egy dimenzióhoz tartoznak, akkor ezt a hibát dobja.</summary>
        public const string C_DimensionError = "Az alakzat pontjai nem egy dimenzióhoz tartoznak!";

        /// <summary>Ha az alakzat tartalmaz definiálatlan pontot, akkor ezt a hibát dobja.</summary>
        public const string C_PointNullError = "Az alakzatnak van definiálatlan pontja!";

        /// <summary>Ha olyan dimenzióba akarunk távolságot számítani, aminél nincs implementálva a távolságszámítás, akkor ezt a hibát dobja.</summary>
        public const string C_DistanceCalculatorError = "A {0}. dimenzió távolságszámítása nincs implementálva!";

        /// <summary>Pont ellenőrzésekor, ha nem létezik a megadott indexű pont, akkor ezt a hibát dobja.</summary>
        public const string C_NotExistPoint = "Az alakzatban nem létezik a következő indexű pont: {0}!";

        /// <summary>Az alakzat adott indexű pontja.</summary>
        /// <param name="idx">Index.</param>
        /// <returns>A megadott indexű pontja az alakzatnak.</returns>
        public Point this[int idx]
        {
            get { return points[idx]; }
        }

        /// <summary>Konstruktor, ami bekéri az alakzat pontjainak halmazát.
        /// A pontok halmazánál nem referenciát adunk át, hanem az adatokat másoljuk le.
        /// A kapott paraméter objektum további sorsa nem befolyásolja az alakzat objektum működését.</summary>
        /// <param name="pPoints">Pontok halmaza. Nem lehet null és csak azonos dimenzióhoz tartozó pontokat tartalmazhat.</param>
        public Shape(params Point[] pPoints)
        {
            CheckPointsError(pPoints);
            points = pPoints.ToArray(); 
        }

        /// <summary>Alakzat pontjainak lekérdezése.</summary>
        /// <returns>Az alakzat pontjai.</returns>
        public Point[] GetPoints()
		{
			return points.ToArray();
		}

        /// <summary>Az alakzat ebbe a dimenzióba tartozik.</summary>
        /// <returns>Dimenzió.</returns>
        public int GetDimension()
        {
            return points == null || points.Length == 0 ? 0 : points[0].Dimension;
        }

        /// <summary>Az alakzat két pontja közötti távolság.</summary>
        /// <param name="pPointIndex1">Az alakzat egyik pontjának indexe.</param>
        /// <param name="pPointIndex2">Az alakzat másik pontjának indexe.</param>
        /// <returns>A megadott indexű pontok közötti távolság.</returns>
        public double Distance(int pPointIndex1, int pPointIndex2)
        {
            CheckDimension(pPointIndex1, pPointIndex2);
            int dim = GetDimension();
            switch (dim)
            {
                case 2:
                    return CalcDistanceDim2(pPointIndex1, pPointIndex2);
                default:
                    throw new ShapeException(string.Format(C_DistanceCalculatorError, dim));
            }
        }

        /// <summary>Adott indexű dimenziók ellenőrzése. Ha az index nem létező pontra mutat, akkor <see cref="ShapeException"/> hibát dob.</summary>
        /// <param name="pPointIndex">Indexek.</param>
        public void CheckDimension(params int[] pPointIndex)
        {
            foreach(int idx in pPointIndex)
                if (points == null || idx < 0 || idx > points.Length - 1)
                    throw new ShapeException(string.Format(C_NotExistPoint, idx));
        }

        Point[] points;

        static void CheckPointsError(Point[] pPoints)
        {
            if (pPoints == null)
                throw new ShapeException(C_ShapeParameterIsNullError);

            if (pPoints.Length > 0)
            {
                if (pPoints[0] == null)
                    throw new ShapeException(C_PointNullError);
                for (int i = 1; i < pPoints.Length; i++)
                {
                    if (pPoints[i] == null)
                        throw new ShapeException(C_PointNullError);
                    if (pPoints[0].Dimension != pPoints[i].Dimension)
                        throw new ShapeException(C_DimensionError);
                }
            }
        }

        double CalcDistanceDim2(int pPointIndex1, int pPointIndex2)
        {
            try
            {
                double d = 
                    Math.Sqrt
                    (
                        Math.Pow(points[pPointIndex2][0] - points[pPointIndex1][0], 2)
                        +
                        Math.Pow(points[pPointIndex2][1] - points[pPointIndex1][1], 2)
                    );
                if (double.IsInfinity(d))
                    throw new OverflowException();
                return d;
            }
            catch (OverflowException ex)
            {
                throw new SquareException(C_OverflowError, ex);
            }
        }
    }

    [Serializable]
    public class ShapeException : Exception
    {
        public ShapeException(string message) : base(message)
        {
        }

        public ShapeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
