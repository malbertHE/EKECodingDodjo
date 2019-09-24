using System.Linq;

namespace MAF.EKE.OCP.Shapes
{
    /// <summary>Alakzat egy pontjának kezelésére szolgáló osztály.</summary>
	public class Point
	{
        /// <summary>A dimenzió koordinátáinak értékei, a megfelelő sorrendben: x, y, z.</summary>
        /// <param name="idx">Sorrend: x=0, y=1, z=2</param>
        /// <returns>A dimenzió adott értéke.</returns>
        public double this[int idx]
        {
            get { return dimensionsValues[idx]; }
        }

        /// <summary>A pont ebbe a dimenzióba tartozik.</summary>
        public int Dimension { get { return dimensionsValues.Length; } }

        /// <summary>Konstruktor, ahol megadjuk a dimenzió egyes értékeit. Például egy dimenzió esetén az x koordináta, két dimenzió esetén az x,y koordináta.</summary>
        /// <param name="pDimensionsValue">Az egyes dimenziók értékei.</param>
		public Point(params double[] pDimensionsValue)
		{
			int length = pDimensionsValue == null ? 0 : pDimensionsValue.Length;
			dimensionsValues = new double[length];
			if (pDimensionsValue != null)
				pDimensionsValue.CopyTo(dimensionsValues, 0);
		}

        /// <summary>A dimenzió értékeinek lekérdezése.</summary>
        /// <returns>A dimenzió értékei.</returns>
		public double[] GetDimensionsValues()
		{
			return dimensionsValues.ToArray();
		}

		double[] dimensionsValues;
    }
}
