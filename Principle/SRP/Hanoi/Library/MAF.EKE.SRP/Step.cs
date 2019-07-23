namespace MAF.EKE.SRP
{
	/// <summary>A Hanoi egy lépésének tárolója.</summary>
	public class Step
	{
		/// <summary>Korong száma.</summary>
		public ulong KorongSzáma { get; private set; }

		/// <summary>Rúd név. Erről a nevű korongról emelte le a legfelső korongot.</summary>
		public char Rúdról { get; private set; }

		/// <summary>Rúd név. Erre a rúdra tette rá a leemelt korongot.</summary>
		public char Rúdra { get; private set; }

		/// <summary>Konstruktor, ami a lépésinformációkat kéri be.</summary>
		/// <param name="pKorongSzáma">Korong száma.</param>
		/// <param name="pRúdról">Rúd név. Erről a nevű korongról emelte le a legfelső korongot.</param>
		/// <param name="pRúdra">Rúd név. Erre a rúdra tette rá a leemelt korongot.</param>
		public Step(ulong pKorongSzáma, char pRúdról, char pRúdra)
		{
			KorongSzáma = pKorongSzáma;
			Rúdról = pRúdról;
			Rúdra = pRúdra;
		}
	}
}
