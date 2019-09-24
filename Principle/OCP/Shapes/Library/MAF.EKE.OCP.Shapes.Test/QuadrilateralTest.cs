using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MAF.EKE.OCP.Shapes.Test
{
    [TestClass]
    public class QuadrilateralTest
    {
        class Quadrilateral2 : Quadrilateral { public Quadrilateral2(Point pPointA, Point pPointB, Point pPointC, Point pPointD) : 
                base(pPointA, pPointB, pPointC, pPointD) { } }

        [TestMethod]
        public void TestQuadrilateralConstructor()
        {
            const int a = 1;
            const int b = 2;
            const int c = 3;
            const int d = 4;
            Point A = new Point(a);
            Point B = new Point(b);
            Point C = new Point(c);
            Point D = new Point(d);
            Quadrilateral quadrilateral = new Quadrilateral2(A, B, C, D);
            Assert.IsTrue(quadrilateral.A[0] == A[0]);
            Assert.IsTrue(quadrilateral.B[0] == B[0]);
            Assert.IsTrue(quadrilateral.C[0] == C[0]);
            Assert.IsTrue(quadrilateral.D[0] == D[0]);
            Assert.IsTrue(quadrilateral.A[0] == a);
            Assert.IsTrue(quadrilateral.B[0] == b);
            Assert.IsTrue(quadrilateral.C[0] == c);
            Assert.IsTrue(quadrilateral.D[0] == d);
        }

        [TestMethod]
        public void TestQuadrilateralBadParams()
        {
            QuadrilateralPointsLengthErrorTest(null, new Point(null), new Point(null), new Point(null));
            QuadrilateralPointsLengthErrorTest(new Point(null), null, new Point(null), new Point(null));
            QuadrilateralPointsLengthErrorTest(new Point(null), new Point(null), null, new Point(null));
            QuadrilateralPointsLengthErrorTest(new Point(null), new Point(null), new Point(null), null);
        }

        void QuadrilateralPointsLengthErrorTest(Point pPointA, Point pPointB, Point pPointC, Point pPointD)
        {
            try
            {
                Quadrilateral quadrilateral = new Quadrilateral2(pPointA, pPointB, pPointC, pPointD);
                Assert.Fail();
            }
            catch (ShapeException ex)
            {
                Assert.IsTrue(ex.Message == Shape.C_PointNullError);
            }
        }
    }
}
