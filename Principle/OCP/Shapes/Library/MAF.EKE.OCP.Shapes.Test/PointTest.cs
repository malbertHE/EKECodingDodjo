using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MAF.EKE.OCP.Shapes.Test
{
	[TestClass]
	public class PointTest
	{
		[TestMethod]
		public void TestPoint()
		{			
			Point point;
			point = new Point();
			Assert.IsTrue(point.GetDimensionsValues().Length == 0);
			point = new Point(new double[] { });
			Assert.IsTrue(point.GetDimensionsValues().Length == 0);
            double[] values = new double[] { 1, 2, 3 };
			point = new Point(values);
			values[0] = 8;
            double[] pointValues = point.GetDimensionsValues();
			Assert.IsTrue(pointValues.Length == 3);
			Assert.IsTrue(pointValues[0] == 1);
			Assert.IsTrue(pointValues[1] == 2);
			Assert.IsTrue(pointValues[2] == 3);
			pointValues[0] = 9;
			Assert.IsTrue(point.GetDimensionsValues()[0] == 1);
		}

        [TestMethod]
        public void TestPointLength()
        {
            Point point = new Point(new double[] { 1, 2, 3 });
            Assert.IsTrue(point.Dimension == 3);
        }
	}
}
