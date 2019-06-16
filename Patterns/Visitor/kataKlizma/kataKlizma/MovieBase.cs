using System;

namespace kataKlizma
{
	/// <summary>A filmek ősosztálya.</summary>
    public abstract class MovieBase
    {
		/// <summary>A látogató beengedéséhez a függvény.</summary>
		/// <param name="pVisitor">Látogató.</param>
        public abstract void AcceptVisitor(Visitor pVisitor);

		/// <summary>Csak azért kell, hogy ne kelljen if feltételeket írni.</summary>
		/// <param name="pVisitor">látogató</param>
		public abstract void NextAcceptVisitor(Visitor pVisitor);

		/// <summary>Következő film.</summary>
		public MovieBase NextMovie { get; private set; } = null;

		/// <summary>A film url címe.</summary>
		public string URL { get; private set; } = string.Empty;

		/// <summary>A film címe.</summary>
		public string Title { get; private set; } = string.Empty;

		/// <summary>A film hossza másodpercbens.</summary>
		public int LengthInSec { get; private set; } = 0;

		/// <summary>A film megjelenésének időpontja.</summary>
		public DateTime ReleaseDate { get; private set; } = DateTime.MinValue;

		/// <summary>Konstruktor. A privát változók csak itt kaphatnak értéket.</summary>
		/// <param name="pURL">A film url címe.</param>
		/// <param name="pTitle">A film címe.</param>
		/// <param name="pLengthInSec">A film hossza másodpercben.</param>
		/// <param name="pReleaseDate">A film megjelenésének dátuma.</param>
		/// <param name="pNextMovie">A következő film.</param>
		public MovieBase(string pURL, string pTitle, int pLengthInSec, DateTime pReleaseDate, MovieBase pNextMovie)
		{
			URL = pURL;
			Title = pTitle;
			LengthInSec = pLengthInSec;
			ReleaseDate = pReleaseDate;
			NextMovie = pNextMovie;
		}
	}
}
