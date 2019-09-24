using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MAF.EKE.OCP.Shapes.Test
{
	[TestClass]
	public class SquareTest
	{
        [TestMethod]
        public void TestCreateSquareWidth()
        {
            const int c_Width = 2;
            Square sq = Square.CreateSquare(c_Width);
            Assert.IsTrue(sq.A[0] == 0);
            Assert.IsTrue(sq.A[1] == 0);
            Assert.IsTrue(sq.B[0] == 0);
            Assert.IsTrue(sq.B[1] == c_Width);
            Assert.IsTrue(sq.C[0] == c_Width);
            Assert.IsTrue(sq.C[1] == c_Width);
            Assert.IsTrue(sq.D[0] == c_Width);
            Assert.IsTrue(sq.D[1] == 0);
        }

        [TestMethod]
        public void TestAreaCalculation()
        {
            Square sq = Square.CreateSquare(1);
            Assert.IsTrue(sq.AreaCalculation() == 1);
        }

        [TestMethod]
		public void TestAreaCalculationOverflowError()
		{
			Square sq = Square.CreateSquare(double.MaxValue);
			try
			{
				sq.AreaCalculation();
				Assert.Fail();
			}
			catch(SquareException ex)
			{
				Assert.IsTrue(ex.Message == Square.C_OverflowError);
				Assert.IsTrue(ex.InnerException.GetType() == typeof(OverflowException));
			}
		}		
	}
}
