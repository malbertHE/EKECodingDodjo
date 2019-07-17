using System;

namespace MAF.EKE.GOF1
{
	/// <summary>A dll által nyújtott szolgáltatás osztálya.
	/// Kis kitérő: Az osztály láthatósági köre érdekes kérdés. Pár évvel ezelőtt azt mondtam volna, hogy egy dll
	/// osztályai közzül minden privát, kivéve ami kifelé nyújt szolgáltatást. Ma már a TDD módszer miatt azt mondom,
	/// hogy lehetőleg minden osztályt úgy tervezz meg, mintha ő maga is egy szolgáltatást nyújtana kifelé. Ezzel 
	/// lehet biztosítani a projekt minnél nagyobb teszt lefedettségét. Természetesen bőven van kivétel, de azokról majd 
	/// a patterneknél...
	/// Az elrendezésmód nem az amit Bob bácsi javasol. Az osztály teljes olvashatósága érdekében előbb mindig annak 
	/// kéne lennie, amiből a későbbi részek építkeznek. Ekkor lehet úgy olvasni a programot mint egy könyvet. 
	/// Ez viszont szembe megy a GOF1-el, mert óhatatlanul is implementációra fogunk programozni, ha látjuk az implementációt.
	/// A GOF1 betartását nagyba segíti, ha elrejted az implementációt és csak a felületet tolod az osztály felhasználója elé.
	/// Az olvashatósága az osztálynak nagyban növelhető a felület megfelelő kommentálásával, ami szintén szembe megy
	/// Bob bácsi ajánlásaival. Erre csak annyit mondhatunk: "There is no Silver Bullet!"
	/// A felület megfelelő kommentálása mellet szól még C#-ban az intellisense. Használd, hogy mások használni tudják.
	/// </summary>
	public class QuadraticMatrix
	{
		#region Hibaüzenetek
		public const string C_MatrixIsNotQuadraticError = "A megadott mátrix nem négyzetes!";
		public const string C_NullError = "A megadott mátrixban inicializálatlan!";
		public const string C_SumOfTheMajorDiagonalError = "Főátló elemek összegének kiszámítása közben hiba történt!";
		public const string C_SumOfTheMinorDiagonalError = "Mellékátló elemek összegének kiszámítása közben hiba történt!";
		public const string C_SumOfAboveMajorDiagonalError = "Főátló feletti elemek összegének kiszámítása közben hiba történt!";
		public const string C_SumOfUnderMajorDiagonalError = "Főátló alatti elemek összegének kiszámítása közben hiba történt!";
		public const string C_SumOfAboveMinorDiagonalError = "Mellékátló feletti elemek összegének kiszámítása közben hiba történt!";
		public const string C_SumOfUnderMinorDiagonalError = "Mellékátló alatti elemek összegének kiszámítása közben hiba történt!";
		#endregion

		/// <summary>Konstruktor, ami leelenőrzi, hogy a megadott mátrix az valóban négyzetes legyen.
		/// Ellenkező esetben <see cref="QuadraticMatrixException"/> típusú hibaüzenetet fog dobni.
		/// A mátrix inicializálatlan részei 0-val lesznek egyenlők.</summary>
		/// <param name="pQuadraticMatrix">Négyzetes mátrix, amivel a létrehozott példány számolni fog.</param>
		public QuadraticMatrix(int[,] pQuadraticMatrix)
		{
			Init(pQuadraticMatrix); //A példa kedvéért szándékosan rejtünk el minden implementációt.
		}

		/// <summary>A mátrix főátlójának összegét számolja ki.</summary>
		/// <returns>főátló összege</returns>
		public int SumOfTheMajorDiagonal()
		{
			return ProtectedBlock(CalcSumOfTheMajorDiagonal, C_SumOfTheMajorDiagonalError);
		}

		/// <summary>A mátrix mellékátlójának összegét számolja ki.</summary>
		/// <returns>mellékátló összege</returns>
		public int SumOfTheMinorDiagonal()
		{
			return ProtectedBlock(CalcSumOfTheMinorDiagonal, C_SumOfTheMinorDiagonalError);
		}

		/// <summary>Mátrix főátló feletti elemek összegét számolja ki.</summary>
		/// <returns>főátló feletti elemek összege</returns>
		public int SumOfAboveMajorDiagonal()
		{
			return ProtectedBlock(CalcSumOfAboveMajorDiagonal, C_SumOfAboveMajorDiagonalError);
		}

		/// <summary>Mátrix főátló alatti elemek összegét számolja ki.</summary>
		/// <returns>főátló alatti elemek összege</returns>
		public int SumOfUnderMajorDiagonal()
		{
			return ProtectedBlock(CalcSumOfUnderMajorDiagonal, C_SumOfUnderMajorDiagonalError);
		}

		/// <summary>Mátrix mellékátló feletti elemek összegét számolja ki.</summary>
		/// <returns>mellékátló feletti elemek összege</returns>
		public int SumOfAboveMinorDiagonal()
		{
			return ProtectedBlock(CalcSumOfAboveMinorDiagonal, C_SumOfAboveMinorDiagonalError);
		}

		/// <summary>Mátrix mellékátló alatti elemek összegét számolja ki.</summary>
		/// <returns>mellékátló alatti elemek összege</returns>
		public int SumOfUnderMinorDiagonal()
		{
			return ProtectedBlock(CalcSumOfUnderMinorDiagonal, C_SumOfUnderMinorDiagonalError);
		}


		/* -------------------------------------------- Vízválasztó --------------------------------------------*/

		#region Privát rész! Ne nézz bele!

		int[,] matrix;
		int colLength;

		private void Init(int[,] pQuadraticMatrix)
		{
			matrix = pQuadraticMatrix ?? throw new QuadraticMatrixException(C_NullError);
			colLength = matrix.GetLength(0);

			if (MatrixIsNotQuadratic())
				throw new QuadraticMatrixException(C_MatrixIsNotQuadraticError);
		}

		private bool MatrixIsNotQuadratic()
		{
			return colLength != matrix.GetLength(1);			
		}

		/*Ezzel a füvvénnyel csak a try-catch ág beírását spóroljuk meg minden számítást végző függvényben. 
		  Cserébe viszont lassúbb lesz a program, mert késői kötés jön létre. Ez itt egy rossz döntés volt,
		  amit egy jövőbeni refaktorálásnál ki kell iktatni. 
		  A TDD módszer és a lustaság néha érdekes, de nem biztos, hogy a legjobb megoldásokat szüli.*/
		private int ProtectedBlock(Func<int> pCalcFunction, string pErrorText)
		{
			try
			{
				return pCalcFunction();
			}
			catch (Exception ex)
			{
				throw new QuadraticMatrixException(pErrorText, ex);
			}
		}

		private int CalcSumOfTheMajorDiagonal()
		{
			checked
			{
				int sum = 0;
				for (int i = 0; i < colLength; i++)
					sum += matrix[i, i];
				return sum;
			}
		}

		private int CalcSumOfTheMinorDiagonal()
		{
			checked
			{
				int sum = 0;
				int colNo = colLength - 1;
				for (int i = 0; i < colLength; i++)
				{
					sum += matrix[i, colNo];
					colNo--;
				}
				return sum;
			}
		}

		private int CalcSumOfAboveMajorDiagonal()
		{
			checked
			{
				int sum = 0;
				for (int i = 0; i < colLength; i++)
					for (int j = 0; j < i; j++)
						sum += matrix[j, i];
				return sum;
			}
		}

		private int CalcSumOfUnderMajorDiagonal()
		{
			checked
			{
				int sum = 0;
				for (int i = 0; i < colLength; i++)
					for (int j = i + 1; j < colLength; j++)
						sum += matrix[j, i];
				return sum;
			}
		}

		private int CalcSumOfAboveMinorDiagonal()
		{
			checked
			{
				int sum = 0;
				for (int i = 0; i < colLength - 1; i++)
					for (int j = 0; j < colLength - i - 1; j++)
						sum += matrix[i, j];
				return sum;
			}
		}

		private int CalcSumOfUnderMinorDiagonal()
		{
			checked
			{
				int sum = 0;
				for (int i = 1; i < colLength; i++)
					for (int j = colLength - i; j < colLength; j++)
						sum += matrix[i, j];
				return sum;
			}
		}

		#endregion
	}

	[Serializable]
	public class QuadraticMatrixException : Exception
	{
		public QuadraticMatrixException(string message) : base(message)
		{
		}

		public QuadraticMatrixException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
