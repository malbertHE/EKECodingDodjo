using System;
using kataKlizma;

namespace kata
{
	/// <summary>Maximum számítás, ahogy órán vettük.
	/// Nem tökéletes megoldás! Lásd az észrevételeket a Main függvényben!</summary>
    class MaxLengthMovies : Visitor
    {
		/// <summary>A maximum érték.</summary>
		public int Max { get; private set; } = 0;

		/// <summary>Látogatóba indulás.</summary>
		/// <param name="pMovieData">Akit meglátogatunk.</param>
		public override void Visit(MovieBase pMovieData)
        {
            /* Ha a sebesség számít, akkor ez a megoldás gyorsabb kéne legyen, hiszen itt egy feltétel vizsgálat van és esetleg egy értékadás, 
             * míg a lentebb megvalósított feltétel nélküli változatban van egy függvényhívás, a függvényen belül legalább egy összehasonlítás
             * és minden esetben egy értékadás. Viszont a lenti Math.Max változat átláthatóbb.
            if (Max < pMovieData.LengthInSec)
                Max = pMovieData.LengthInSec;
            */

            Max = Math.Max(Max, pMovieData.LengthInSec); //Így elkerülhető a feltételes 
            pMovieData.NextAcceptVisitor(this);
        }
	}
}
