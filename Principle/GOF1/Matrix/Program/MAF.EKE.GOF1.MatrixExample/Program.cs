using System;

namespace MAF.EKE.GOF1.MatrixExample
{
	class Program
	{
		static Random rnd = new Random();
		static int matrixSize;
		static int[,] matrix;

		private static void CreateMatrix()
		{
			matrixSize = rnd.Next(2, 6);
			matrix = new int[matrixSize, matrixSize];
			for (int i = 0; i < matrixSize; i++)
				for (int j = 0; j < matrixSize; j++)
					matrix[i,j] = rnd.Next(-9, 10);
		}

		private static void WriteMatrix()
		{
			Console.WriteLine("A létrehozott mátrix:");
			for(int i = 0; i < matrixSize; i++)
			{
				for(int j = 0; j < matrixSize; j++)
					Console.Write(matrix[i, j] < 0 ? $" {matrix[i, j]}" : $"  {matrix[i, j]}");
				Console.WriteLine();
			}
		}

		private static void WriteCalculations()
		{
			QuadraticMatrix qm = new QuadraticMatrix(matrix);
			Console.WriteLine("Mátrix főátlójának összege: {0}", qm.SumOfTheMajorDiagonal());
			Console.WriteLine("Mátrix mellékátlójának összege: {0}", qm.SumOfTheMinorDiagonal());
			Console.WriteLine("Mátrix főátló feletti elemeinek összege: {0}", qm.SumOfAboveMajorDiagonal());
			Console.WriteLine("Mátrix főátló alatti elemeinek összege: {0}", qm.SumOfUnderMajorDiagonal());
			Console.WriteLine("Mátrix mellékátló feletti elemeinek összege: {0}", qm.SumOfAboveMinorDiagonal());
			Console.WriteLine("Mátrix mellékátló alatti elemeinek összege: {0}", qm.SumOfUnderMinorDiagonal());
		}

		static void Main(string[] args)
		{
			Console.WriteLine("A példa program felépít egy minimum 2x2-es maximum 5x5 ös négyzetes mátrixot, ahol a mátrix értékei véletlen számok," +
				"[-9, 9] intervallumban!"); /*Megjegyzés: két literál összefűzése már fordítás időben kiértékelődik, ezért ez így a helyes, ha tartalmaz
			                                  változót is, akkor már pl. string.Concat használata jobb.*/

			CreateMatrix();
			WriteMatrix();
			WriteCalculations();

			Console.ReadLine();

		}
	}
}
