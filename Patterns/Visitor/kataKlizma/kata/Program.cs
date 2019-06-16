using System;
using kataKlizma;

namespace kata
{
    class Program
    {
        /*
         * Példaprogram. 
        */
        static void Main(string[] args)
        {
            /* Órán megvalósított megoldás. Itt figyelni kell, hogy az AcceptVisitor függvényt
			 * hamarabb kell meghívni, mint mielőtt lekérdezzük az eredményt. 
			 * Másképpen fogalmazva van olyan állapot amikor hibás értéket ad vissza.
			 * Kerülni kell azokat a megoldásokat, amikor egy osztálypéldányban egy függvény 
			 * hívástól függ annak helyes működése. A példányinicializálásról minden körülmény
			 * között gondoskodni kell (most tekintsünk el azoktól az esetektől amikor nem :) ). 
			 * Szintén problémát okozhat, ha többször is meghívjuk az AcceptVisitor függvényt.
			 * Pl. a Sum ha így van megvalósítva, a második hívásra már duplázódik a sum értéke. */
			MaxLengthMovies mlm = new MaxLengthMovies();
            Console.WriteLine($"Leghosszabb film (de ez nem jó eredmény): {mlm.Max}");
            Movies.FirstMovie.AcceptVisitor(mlm);
			Console.WriteLine($"Leghosszabb film: {mlm.Max}");

            //Egyszerűbb a használata és nincs hibás állapot.
            SumLengthMovies slm = new SumLengthMovies(Movies.FirstMovie);
			Console.WriteLine($"Filmek hossza összesen: {slm.SumInSec}");
            Console.WriteLine($"Még egyszer a filmek hossza összesen (akárhányszor hívhatom, mindig jó az eredmény): {slm.SumInSec}");

            SumLengthMovieByYear maxSlm = new SumLengthMovieByYear(Movies.FirstMovie, 2017);
            Console.WriteLine($"Filmek hossza összesen 2017: {maxSlm.SumInSec}");
            Console.WriteLine("Filmek hossza összesen {0}: {1}", "2017", maxSlm.SumInSec);

            MaxLengthMoviesByYear mlmByYear = new MaxLengthMoviesByYear();
            Movies.FirstMovie.AcceptVisitor(mlmByYear);
            Console.WriteLine("Leghosszabb film {0}. évben: {1}",mlmByYear.Year, mlmByYear.Max);

            Console.ReadKey();
        }

		/* Megj.:
		 * A kód megírásakor próbáltuk megnézni, hogyan lehet kerülni az elágazásokat.
		 * Az elágazások kerülése valamivel több kód írást és futás közben több memóriafoglalást eredményez cserébe
		 * általában átláthatóbb kódot eredményez, de mindenképpen tesztelhetőbb kódot.
		 * Ne feleldjük, hogy a teszteket az elágazások bonyolítják el!
		 */
    }
}
