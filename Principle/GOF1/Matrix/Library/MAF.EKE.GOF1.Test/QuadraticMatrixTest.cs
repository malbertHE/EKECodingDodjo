using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MAF.EKE.GOF1.Test
{
	[TestClass]
	public class QuadraticMatrixTest
	{
		static int[][,] testData = new int[][,]
		{
			new int[,] { { 1 } },
			new int[,] { { 1, 2 }, 
				         { 3, 4 } },
			new int[,] { { 1, 2, 3 }, 
				         { 4, 5, 6 }, 
						 { 7, 8, 9 } },
			new int[,] { { 1, 0, 3 }, 
				         { 6, 3, 3 }, 
						 { 2, 1, 2 } },
			new int[,] { { 1, -1, 3 },
						 { -6, 3, 3 },
						 { -2, 1, -2 } }
		};

		[TestMethod]
		public void TestCreate()
		{			
			for(int i = 0; i < testData.Length; i++)
				TestCreateObject(testData[i]);
			TestCreateObject(new int[3, 3]);
		}

		private static void TestCreateObject(int[,] pMatrix)
		{
			QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
			Assert.IsFalse(qm == null);
		}

		[TestMethod]
		public void TestMatrixIsNotQuadratic()
		{
			MatrixIsNotQuadraticTest(new int[,] { { 1, 2, 3, 4 } });
			MatrixIsNotQuadraticTest(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			MatrixIsNotQuadraticTest(new int[,] { { 1 }, { 2 } });
			MatrixIsNotQuadraticTest(new int[3, 2]);
		}

		private static void MatrixIsNotQuadraticTest(int[,] pMatrix)
		{
			try
			{				
				QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
				Assert.Fail();
			}
			catch (QuadraticMatrixException ex)
			{
				Assert.IsTrue(ex.Message == QuadraticMatrix.C_MatrixIsNotQuadraticError);
			}
		}

		[TestMethod]
		public void TestMatrixIsNull()
		{
			try
			{
				QuadraticMatrix qm = new QuadraticMatrix(null);
				Assert.Fail();
			}
			catch (QuadraticMatrixException ex)
			{
				Assert.IsTrue(ex.Message == QuadraticMatrix.C_NullError);
			}
		}

		[TestMethod]
		public void TestSumOfTheMajorDiagonal()
		{
			SumOfTheDiagonalMajorTest(testData[0], 1);
			SumOfTheDiagonalMajorTest(testData[1], 5);
			SumOfTheDiagonalMajorTest(testData[2], 15);
			SumOfTheDiagonalMajorTest(testData[3], 6);
			SumOfTheDiagonalMajorTest(testData[4], 2);
		}

		private static void SumOfTheDiagonalMajorTest(int[,] pMatrix, int pResult)
		{
			QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
			Assert.IsTrue(qm.SumOfTheMajorDiagonal() == pResult);
		}

		[TestMethod]
		public void TestSumOfTheMinorDiagonal()
		{
			SumOfTheDiagonalMinorTest(testData[0], 1);
			SumOfTheDiagonalMinorTest(testData[1], 5);
			SumOfTheDiagonalMinorTest(testData[2], 15);
			SumOfTheDiagonalMinorTest(testData[3], 8);
			SumOfTheDiagonalMinorTest(testData[4], 4);
		}

		private static void SumOfTheDiagonalMinorTest(int[,] pMatrix, int pResult)
		{
			QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
			Assert.IsTrue(qm.SumOfTheMinorDiagonal() == pResult);
		}

		[TestMethod]
		public void TestSumOfAboveMajorDiagonal()
		{
			SumOfAboveDiagonalMajorTest(testData[0], 0);
			SumOfAboveDiagonalMajorTest(testData[1], 2);
			SumOfAboveDiagonalMajorTest(testData[2], 11);
			SumOfAboveDiagonalMajorTest(testData[3], 6);
			SumOfAboveDiagonalMajorTest(testData[4], 5);
		}

		private static void SumOfAboveDiagonalMajorTest(int[,] pMatrix, int pResult)
		{
			QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
			Assert.IsTrue(qm.SumOfAboveMajorDiagonal() == pResult);
		}

		[TestMethod]
		public void TestSumOfUnderMajorDiagonal()
		{
			SumOfUnderDiagonalMajorTest(testData[0], 0);
			SumOfUnderDiagonalMajorTest(testData[1], 3);
			SumOfUnderDiagonalMajorTest(testData[2], 19);
			SumOfUnderDiagonalMajorTest(testData[3], 9);
			SumOfUnderDiagonalMajorTest(testData[4], -7);
		}

		private static void SumOfUnderDiagonalMajorTest(int[,] pMatrix, int pResult)
		{
			QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
			Assert.IsTrue(qm.SumOfUnderMajorDiagonal() == pResult);
		}

		[TestMethod]
		public void TestSumOfAboveMinorDiagonal()
		{
			SumOfAboveDiagonalMinorTest(testData[0], 0);
			SumOfAboveDiagonalMinorTest(testData[1], 1);
			SumOfAboveDiagonalMinorTest(testData[2], 7);
			SumOfAboveDiagonalMinorTest(testData[3], 7);
			SumOfAboveDiagonalMinorTest(testData[4], -6);
		}

		private static void SumOfAboveDiagonalMinorTest(int[,] pMatrix, int pResult)
		{
			QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
			Assert.IsTrue(qm.SumOfAboveMinorDiagonal() == pResult);
		}

		[TestMethod]
		public void TestSumOfUnderMinorDiagonal()
		{
			SumOfUnderDiagonalMinorTest(testData[0], 0);
			SumOfUnderDiagonalMinorTest(testData[1], 4);
			SumOfUnderDiagonalMinorTest(testData[2], 23);
			SumOfUnderDiagonalMinorTest(testData[3], 6);
			SumOfUnderDiagonalMinorTest(testData[4], 2);
		}

		private static void SumOfUnderDiagonalMinorTest(int[,] pMatrix, int pResult)
		{
			QuadraticMatrix qm = new QuadraticMatrix(pMatrix);
			Assert.IsTrue(qm.SumOfUnderMinorDiagonal() == pResult);
		}

		[TestMethod]
		public void TestOverflow()
		{
			OverflowTest(int.MaxValue);
			OverflowTest(int.MinValue);
		}

		private static void OverflowTest(int pValue)
		{
			QuadraticMatrix qm = new QuadraticMatrix(new int[,] { { pValue, pValue, pValue }, { pValue, pValue, pValue }, { pValue, pValue, pValue } });
			OverflowFuncTest(QuadraticMatrix.C_SumOfTheMajorDiagonalError, qm.SumOfTheMajorDiagonal);
			OverflowFuncTest(QuadraticMatrix.C_SumOfTheMinorDiagonalError, qm.SumOfTheMinorDiagonal);
			OverflowFuncTest(QuadraticMatrix.C_SumOfAboveMajorDiagonalError, qm.SumOfAboveMajorDiagonal);
			OverflowFuncTest(QuadraticMatrix.C_SumOfUnderMajorDiagonalError, qm.SumOfUnderMajorDiagonal);
			OverflowFuncTest(QuadraticMatrix.C_SumOfAboveMinorDiagonalError, qm.SumOfAboveMinorDiagonal);
			OverflowFuncTest(QuadraticMatrix.C_SumOfUnderMinorDiagonalError, qm.SumOfUnderMinorDiagonal);
		}

		private static void OverflowFuncTest(string pErrorText, Func<int> pCalcFunc)
		{
			try
			{
				int i = pCalcFunc();
				Assert.Fail();
			}
			catch (QuadraticMatrixException ex)
			{
				Assert.IsTrue(ex.Message == pErrorText);
				Assert.IsTrue(ex.InnerException is OverflowException);
			}
		}
	}
}
