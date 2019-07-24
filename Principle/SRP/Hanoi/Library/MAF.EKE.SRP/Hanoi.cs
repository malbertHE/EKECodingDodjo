using System;
using System.Collections.Generic;

namespace MAF.EKE.SRP
{
	/// <summary>Hanoi logikát tartalmazó osztály. Három rúdból áll, melyeknek nevei: A, B, C.</summary>
    public class Hanoi
    {
		/// <summary>Az első rúd neve. Kezdetben ezen vannak a korongok.</summary>
		public const char C_RodNameA = 'A';

		/// <summary>A második rúd neve. A korongokat erre kell áthelyezni.</summary>
		public const char C_RodNameB = 'B';

		/// <summary>A harmadik rúd neve. Ez a segéd rúd.</summary>
		public const char C_RodNameC = 'C';

		/// <summary>Korongok száma összesen.</summary>
		public byte NumberOfDisks { get; private set; }

		/// <summary>A Hanoi számítás lépései a megfelelő lépéssorrendben.</summary>
		public IReadOnlyList<Step> SetpList { get { return steps.AsReadOnly(); } }

		/// <summary>Lépések számát adja vissza.</summary>
		public int NumberOfSteps { get { return steps.Count; } }

		/// <summary>Egy lépés adott elemének elkérése. Ha nem létezik ilyen indexű lépés, akkor <see cref="IndexOutOfRangeException"/> hibát dob.</summary>
		/// <param name="index">Adott elem indexe.</param>
		/// <returns>Az adott lépés adatai.</returns>
		public Step this[int index]
		{
			get
			{
				if (index < 0 || index >= steps.Count)
					throw new IndexOutOfRangeException();
				return steps[index];
			}
		}

		/// <summary>Konstruktor, ami megkapja a korongok számát és az alapján elvégzi a lépések számítását.</summary>
		/// <param name="pNumberOfSteps">Korongok száma.</param>
		public Hanoi(byte pNumberOfSteps)
		{
			NumberOfDisks = pNumberOfSteps;
			steps = CaclcHanoi(pNumberOfSteps, C_RodNameA, C_RodNameB, C_RodNameC);
		}

		List<Step> steps;

		List<Step> CaclcHanoi(uint N, char R1, char R2, char R3)
		{
			List<Step> rl = new List<Step>();
			HanoiA(N, R1, R2, R3, rl);
			return rl;
		}

		void HanoiA(uint N, char R1, char R3, char R2, List<Step> ResultList)
		{
			if (N < 1) return;
			HanoiA(N - 1, R1, R2, R3, ResultList);
			ResultList.Add(new Step(N, R1, R3));
			HanoiA(N - 1, R2, R3, R1, ResultList);
		}
    }
}
