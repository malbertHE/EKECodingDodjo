using System;

namespace kataKlizma
{
	/// <summary>A szolgáltatást nyújtó film osztály. Gyakorlatilag egy privát tároló, egyetlen szolgáltatással, a film lejátszásával.</summary>
	public class Movie: MovieBase
	{
		/// <summary>Konstruktor. A privát változók csak itt kaphatnak értéket.</summary>
		/// <param name="pURL">A film url címe.</param>
		/// <param name="pTitle">A film címe.</param>
		/// <param name="pLengthInSec">A film hossza másodpercben.</param>
		/// <param name="pReleaseDate">A film megjelenésének dátuma.</param>
		/// <param name="pNextMovie">A következő film.</param>
		public Movie(string pURL, string pTitle, int pLengthInSec, DateTime pReleaseDate, MovieBase pNextMovie):
			base(pURL, pTitle, pLengthInSec, pReleaseDate, pNextMovie)
        {
		}

		/// <summary>Film lejátszása. Ez egy üres metódus, nincs megvalósítva, mert most nem ez a cél.</summary>
		public string Play()
        {
			//Ide jönne a lejátszás.
			return $"Nézd meg ezt a(z) '{Title}' filmet itt: {URL}";
        }

		/// <summary>Csak azért van rá szükség, hogy ne kelljen feltételeket írni a függvényekbe.</summary>
		/// <param name="pVisitor">látogató</param>
		public override void NextAcceptVisitor(Visitor pVisitor)
		{
			NextMovie.AcceptVisitor(pVisitor);
		}

		/// <summary>Látogató beengedése.</summary>
		/// <param name="pVisitor">Látogató.</param>
		public override void AcceptVisitor(Visitor pVisitor)
		{
			/* 
			 * A látogató viszi az aktuális objektumot!
			 * Ezen a szinten nagyon fontos a jól megtervezett osztály. Ilyen osztályban lehetőleg csak privát set legyen.
			 * Ha szükség van adatmódosításra is, akkor körültekintően kell eljárni, mert a látogatók nem boríthatják fel
			 * az osztály működését!!!
			 * Ha a látogató módosíthatna adatot, akkor több probléma is megjelenne. Adatvédelem, biztonság, szálkezelés stb.
             * Erre megoldás a játszótér, de ezt sokkal nehezebb kivitelezni. A legjobb megoldás, ha ilyen esetben csak adatot
             * kérhetnek le, de módosítani nem módosíthatnak.
			 */
			pVisitor.Visit(this);
		}

	}
}
