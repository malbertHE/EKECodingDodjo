using kataKlizma;

namespace kata
{
    /// <summary>Szolgáltatás kiegészítés <see cref="Visitor"/> segítségével.
    /// Jelen kiegészítés összegzi a filmek hosszát.</summary>
    class SumLengthMovieByYear : Visitor
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
        /// a <see cref="SumInSec"/> mindig képes legyen visszaadni a helyes értéket.
        /// A <see cref="MaxLengthMoviesByYear"/> osztállyal ellentétben itt a konstruktor kapja meg az évet. 
        /// Ez viszont azt eredményezi, hogy egy példány csak egyféle évet kezel. Akár haszna is lehet, kérdés, hogy mi volt az igény.</summary>
        /// <param name="pFirstMovie">Az első film. Ettől kezdve a hátralévőket fogja összegezni a
        /// <see cref="SumInSec"/></param>
        public SumLengthMovieByYear(MovieBase pFirstMovie, int year) //ahány év annyi példányt kell létrehozni
        {
            firstMovie = pFirstMovie;
            this.year = year;
        }

        /// <summary>A látogató útra indul.</summary>
        /// <param name="pMovieData">Őt látogatjuk meg.</param>
        public override void Visit(MovieBase pMovieData)
        {
            sumInSec += year == pMovieData.ReleaseDate.Year ? pMovieData.LengthInSec : 0;
            pMovieData.NextAcceptVisitor(this);
        }

        int sumInSec = 0;
        MovieBase firstMovie;
        int year;
    }
}
