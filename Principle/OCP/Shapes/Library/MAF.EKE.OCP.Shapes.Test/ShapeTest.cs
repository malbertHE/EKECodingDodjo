using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MAF.EKE.OCP.Shapes.Test
{
	[TestClass]
	public class ShapeTest
	{
		class Shape2 : Shape { public Shape2(params Point[] pPoints):base(pPoints) {} }
        Random random = new Random();

        [TestMethod]
        public void TestShapeConstructorParameterIsNull()
        {
            try
            {
                Shape shape = new Shape2(null);
                Assert.Fail();
            }
            catch(ShapeException ex)
            {
                Assert.IsTrue(ex.Message == Shape.C_ShapeParameterIsNullError);
            }
        }

        [TestMethod]
        public void TestShape0Dimension()
        {
            Shape shape = new Shape2(new Point[] { new Point(null), new Point(new double[] { }) });
            Point[] points = shape.GetPoints();
            Assert.IsTrue(points.Length == 2);
            Assert.IsTrue(points[0].GetDimensionsValues().Length == 0);
            Assert.IsTrue(points[1].GetDimensionsValues().Length == 0);
        }

        private Point[] CreatePoints()
        {
            int index = 1;
            const int maxDim = 101;
            Point[] points = new Point[random.Next(1, maxDim)];
            int valuesCount = random.Next(1, maxDim);
            for (int i = 0; i < points.Length; i++)
            {
                double[] values = new double[valuesCount];
                for (int j = 0; j < values.Length; j++)
                {
                    values[j] = index;
                    index++;
                }
                points[i] = new Point(values);
            }
            return points;
        }

        private void MultiDimensionTest(Shape pShape)
        {
            int index = 1;
            Point[] points = pShape.GetPoints();
            foreach (Point point in points)
            {
                double[] values = point.GetDimensionsValues();
                foreach (int value in values)
                {
                    Assert.IsTrue(value == index, $"Alakzat pontjainak száma: {points.Length}; dimenziók száma: {values.Length}");
                    index++;
                }
            }
        }

        [TestMethod]
		public void TestShapeMultiDimension()
		{
			Shape shape = new Shape2(CreatePoints());
            MultiDimensionTest(shape);
        }

        [TestMethod]
        public void TestShapeData()
        {
            Point[] points = new Point[] { new Point(new double[] { 1, 2 }), new Point(new double[] { 3, 4 }) };
            Shape shape = new Shape2(points);
            points[0] = new Point(new double[] { 5, 6, 7 });

            Point[] shapePoints = shape.GetPoints();
            Assert.IsTrue(shapePoints.Length == 2);
            double[] dimensions = shapePoints[0].GetDimensionsValues();
            Assert.IsTrue(dimensions.Length == 2);
            Assert.IsTrue(dimensions[0] == 1);
            Assert.IsTrue(dimensions[1] == 2);
            Assert.IsTrue(shape[0][0] == 1);
            Assert.IsTrue(shape[0][1] == 2);
            dimensions = shapePoints[1].GetDimensionsValues();
            Assert.IsTrue(dimensions[0] == 3);
            Assert.IsTrue(dimensions[1] == 4);
            Assert.IsTrue(shape[1][0] == 3);
            Assert.IsTrue(shape[1][1] == 4);
        }

        [TestMethod]
        public void TestShapeDimension()
        {
            Point[] points = new Point[] { new Point(new double[] { 1, 2 }), new Point(new double[] { 3, 4, 5 }) };
            try
            {
                Shape shape = new Shape2(points);
                Assert.Fail();
            }
            catch(ShapeException ex)
            {
                Assert.IsTrue(ex.Message == Shape.C_DimensionError);
            }
        }

        [TestMethod]
        public void TestShapeExistPointNull()
        {
            Point[] points = new Point[] { new Point(new double[] { 1, 2 }), null };
            try
            {
                Shape shape = new Shape2(points);
                Assert.Fail();
            }
            catch (ShapeException ex)
            {
                Assert.IsTrue(ex.Message == Shape.C_PointNullError);
            }
        }

        [TestMethod]
        public void TestShaeGetDimension()
        {
            Shape shape = new Shape2(new Point());
            Assert.IsTrue(shape.GetDimension() == 0);
            shape = new Shape2(new Point(1));
            Assert.IsTrue(shape.GetDimension() == 1);
            shape = new Shape2(new Point(1,2,3));
            Assert.IsTrue(shape.GetDimension() == 3);
        }

        [TestMethod]
        public void TestShapeDistanceBadDimension()
        {
            Shape shape = new Shape2(new Point(1), new Point(2));
            try
            {
                shape.Distance(0, 1);
                Assert.Fail();
            }
            catch(ShapeException ex)
            {
                Assert.IsTrue(ex.Message == string.Format(Shape.C_DistanceCalculatorError, 1));
            }
        }

        [TestMethod]
        public void TestShapeCheckDimension()
        {
            Shape shape = new Shape2(new Point(1), new Point(2));
            shape.CheckDimension(0);
            shape.CheckDimension(1);
            shape.CheckDimension(0, 1);
            const int index = 2;
            try
            {
                shape.CheckDimension(index);
                Assert.Fail();
            }
            catch(ShapeException ex)
            {
                Assert.IsTrue(ex.Message == string.Format(Shape.C_NotExistPoint, index));
            }
        }

        [TestMethod]
        public void TestShapeDistanceBadDistance()
        {
            Shape shape = new Shape2(new Point(1), new Point(2));
            const int index = 3;
            try
            {
                shape.Distance(0, index);
                Assert.Fail();
            }
            catch (ShapeException ex)
            {
                Assert.IsTrue(ex.Message == string.Format(Shape.C_NotExistPoint, index));
            }
        }

        [TestMethod]
        public void TestShapeDistance()
        {
            Shape shape = new Shape2(new Point(1,1), new Point(1,2));
            Assert.IsTrue(shape.Distance(0, 1) == 1);
            shape = new Shape2(new Point(4, 1), new Point(1, 1));
            Assert.IsTrue(shape.Distance(0, 1) == 3);

        }
    }
}
