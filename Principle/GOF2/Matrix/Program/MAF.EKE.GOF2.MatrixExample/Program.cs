using System;

namespace MAF.EKE.GOF2.MatrixExample
{
	class Program
	{
		static Random rnd = new Random();
		static int[,] matrix;

		private static void CreateMatrix()
		{
			int matrixSize = rnd.Next(2, 6);
			matrix = new int[matrixSize, matrixSize];
			for (int i = 0; i < matrixSize; i++)
				for (int j = 0; j < matrixSize; j++)
					matrix[i, j] = rnd.Next(-9, 10);
		}

		private static void Write()
		{
			QuadraticMatrixText qmt = new QuadraticMatrixText(matrix);
			Console.WriteLine(qmt.ToString());
		}

		static void Main(string[] args)
		{
			Console.WriteLine("A példa program felépít egy minimum 2x2-es maximum 5x5 ös négyzetes mátrixot, ahol a mátrix értékei véletlen számok," +
				"[-9, 9] intervallumban!");

			CreateMatrix();
			Write();

			Console.ReadLine();
		}

	}
}
