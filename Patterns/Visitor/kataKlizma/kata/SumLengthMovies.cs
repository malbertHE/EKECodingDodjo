using kataKlizma;

namespace kata
{
	/// <summary>Szolgáltatás kiegészítés <see cref="Visitor"/> segítségével.
	/// Jelen kiegészítés összegzi a filmek hosszát.</summary>
    class SumLengthMovies : Visitor
    {
		/// <summary>Ezen keresztül kérhetjük le a filmek összhosszát.
		/// Mindig friss értéket ad vissza!</summary>
		public int SumInSec
		{
			get
			{
				sumInSec = 0;
				firstMovie.AcceptVisitor(this);
				return sumInSec;
			}
		}

		/// <summary>Konstruktor. A cél, hogy biztosítsuk az inicializálást, vagyis, hogy
		/// a <see cref="SumInSec"/> mindig képes legyen visszaadni a helyes értéket.</summary>
		/// <param name="pFirstMovie">Az első film. Ettől kezdve a hátralévőket fogja összegezni a
		/// <see cref="SumInSec"/></param>
		public SumLengthMovies(MovieBase pFirstMovie)
		{
			firstMovie = pFirstMovie;
		}

		/// <summary>A látogató útra indul.</summary>
		/// <param name="pMovieData">Őt látogatjuk meg.</param>
		public override void Visit(MovieBase pMovieData)
        {
			sumInSec += pMovieData.LengthInSec;
			pMovieData.NextAcceptVisitor(this);
		}

		int sumInSec = 0;
		MovieBase firstMovie;

	}
}
