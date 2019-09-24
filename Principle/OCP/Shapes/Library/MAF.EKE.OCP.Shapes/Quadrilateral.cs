using System;

namespace MAF.EKE.OCP.Shapes
{
    /// <summary>Négyszög alakzatok osztálya.</summary>
    public abstract class Quadrilateral: Shape
    {
        /// <summary>A négyszög első pontja.</summary>
        public Point A { get { return this[0]; } }

        /// <summary>A négyszög második pontja.</summary>
        public Point B { get { return this[1]; } }

        /// <summary>A négyszög harmadik pontja.</summary>
        public Point C { get { return this[2]; } }

        /// <summary>A négyszög negyedik pontja.</summary>
        public Point D { get { return this[3]; } }

        /// <summary>Konstruktor, ami pontosan a négyszöget alkotó pontokat kéri be, a megfelelő sorrendben.</summary>
        /// <param name="pPointA">Az A pont, amit <see cref="A" property-ben kérhetünk majd vissza./></param>
        /// <param name="pPointB">A B pont, amit <see cref="B" property-ben kérhetünk majd vissza./></param>
        /// <param name="pPointC">A C pont, amit <see cref="C" property-ben kérhetünk majd vissza./></param>
        /// <param name="pPointD">A D pont, amit <see cref="D" property-ben kérhetünk majd vissza./></param>
        public Quadrilateral(Point pPointA, Point pPointB, Point pPointC, Point pPointD):base(pPointA, pPointB, pPointC, pPointD)
        {
        }
    }

    [Serializable]
    public class QuadrilateralException : Exception
    {
        public QuadrilateralException(string message) : base(message)
        {
        }

        public QuadrilateralException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
