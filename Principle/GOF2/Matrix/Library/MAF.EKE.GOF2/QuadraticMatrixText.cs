using System;
using MAF.EKE.GOF1;

namespace MAF.EKE.GOF2
{
    public class QuadraticMatrixText
    {
		public QuadraticMatrixText(int[,] pQuadraticMatrix)
		{
			qm = new QuadraticMatrix(pQuadraticMatrix);
			/* Mivel kérés volt, hogy a szolgáltatás sebességre legyen optimalizálva, de a számítást nem ezen a szinten végezzük, ezért
			   csak egy optimalizálást végezhetünk, azt, hogy a számításokat csak egyszer futtatjuk és azokat eltároljuk.
			   Két dolgot tehetnénk meg. Kiszámoljuk itt a konstruktorba, vagy kiszámoljuk később. Ha később számolnánk ki, akkor 
			   figyelni kéne arra, hogy mi van akkor amikor még nincs kiszámolva de már meghívták valamelyik szöveget visszaadó függvényt.
			   Ehhez csak egy értelmes dolgot tehetnénk. Minden függvény elejére betennénk egy feltételt, hogy ha még nincs inicializálva
			   a szükséges változó, akkor futtassuk le. Mivel ezt az osztályt csak akkor van értelme példányosítani, ha hasznlni is akarjuk
			   a változóit (más szolgáltatása ugyanis nincs), ezért megspórolhatjuk a feltételeket, vagyis ez itt így szerintem a jobbik 
			   megoldás.*/
			matrixText = SetMatrixText(pQuadraticMatrix);
			calculationsText = SetCalculationsText();
		}

		public string MatrixText()
		{
			return matrixText;
		}

		public string CalculationsText()
		{
			return calculationsText;
		}

		public override string ToString()
		{
			return string.Concat(matrixText, CalculationsText());
		}

		QuadraticMatrix qm;
		readonly string matrixText;
		readonly string calculationsText;

		private string SetMatrixText(int[,] pQuadraticMatrix)
		{
			string text = $"Mátrix:{Environment.NewLine}";
			int matrixSize = pQuadraticMatrix.GetLength(0);
			for (int i = 0; i < matrixSize; i++)
			{
				for (int j = 0; j < matrixSize; j++)
					text = $"{text} {(pQuadraticMatrix[i, j] < 0 ? $" {pQuadraticMatrix[i, j]}" : $"  {pQuadraticMatrix[i, j]}")}";
				text = $"{text}{Environment.NewLine}";
			}
			return text;
		}

		private string SetCalculationsText()
		{
			return
				string.Concat(
					"Mátrix főátlójának összege: ", qm.SumOfTheMajorDiagonal(), Environment.NewLine,
					"Mátrix mellékátlójának összege: ", qm.SumOfTheMinorDiagonal(), Environment.NewLine,
					"Mátrix főátló feletti elemeinek összege: ", qm.SumOfAboveMajorDiagonal(), Environment.NewLine,
					"Mátrix főátló alatti elemeinek összege: ", qm.SumOfUnderMajorDiagonal(), Environment.NewLine,
					"Mátrix mellékátló feletti elemeinek összege: ", qm.SumOfAboveMinorDiagonal(), Environment.NewLine,
					"Mátrix mellékátló alatti elemeinek összege: ", qm.SumOfUnderMinorDiagonal(), Environment.NewLine);
		}
	}
}
