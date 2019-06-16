using System;
using kataKlizma;

namespace kata
{
    /// <summary>Maximumszámítás adott évre.</summary>
    class MaxLengthMoviesByYear : Visitor
    {
        /// <summary>A maximum érték.</summary>
        public int Max { get; private set; } = 0;

        /// <summary>Ezt az évet vizsgáljuk csak. Alapértelmezése az aktuális év.</summary>
        public int Year { get; set; } = DateTime.Now.Year;
        
        /// <summary>Látogatóba indulás.</summary>
        /// <param name="pMovieData">Akit meglátogatunk.</param>
        public override void Visit(MovieBase pMovieData)
        {
            /* Itt ez a megoldás szerintem rosszabb mint a lenti if.
                Max = Math.Max(Max, this.Year == pMovieData.ReleaseDate.Year ? pMovieData.LengthInSec : 0);
               Ugyanazt csinálja, de az elágazást csak félig tudtuk megszüntetni, míg az értékadás és függvényhívás minden esetbe megmaradt.
               Ehhez képest a lenti if, mintha olvashatóbb és gyorsabb futásidejű kódot eredményezne.
            */

            if (Max < pMovieData.LengthInSec && this.Year == pMovieData.ReleaseDate.Year)
                Max = pMovieData.LengthInSec;

            pMovieData.NextAcceptVisitor(this);
        }                    

    }
}
