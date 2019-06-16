using System;

namespace kataKlizma
{
	/// <summary>Egy lezáró elem. Csak azért van rá szükség, hogy kiküszöbölhessük az if feltételeket.</summary>
	public class NullMovie : MovieBase
	{
		/// <summary>Konstruktor. A privát változók csak itt kaphatnak értéket.</summary>
		/// <param name="pURL">A film url címe.</param>
		/// <param name="pTitle">A film címe.</param>
		/// <param name="pLengthInSec">A film hossza másodpercben.</param>
		/// <param name="pReleaseDate">A film megjelenésének dátuma.</param>
		/// <param name="pNextMovie">A következő film.</param>
		public NullMovie() : base(string.Empty, string.Empty, 0, DateTime.MinValue, null)
		{
		}

		/// <summary>Lágogató beengedése.</summary>
		/// <param name="pVisitor">látogató</param>
		public override void AcceptVisitor(Visitor pVisitor)
		{
			pVisitor.Visit(this);
		}

		/// <summary>Csak azért kell, hogy ne kelljen feltételeket használni a függvényekben.</summary>
		/// <param name="pVisitor">látogató</param>
		public override void NextAcceptVisitor(Visitor pVisitor)
		{
		}
	}
}