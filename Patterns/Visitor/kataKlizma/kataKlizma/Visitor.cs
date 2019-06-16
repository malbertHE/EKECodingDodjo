namespace kataKlizma
{
    /// <summary>A látogatóval szemben támasztott elvárások osztálya.</summary>
    public abstract class Visitor
    {
        /// <summary>Metódus a látogatáshoz.</summary>
        /// <param name="pMovieData">Ezt az objektumot látogatja meg.</param>
        public abstract void Visit(MovieBase pMovieData);

		/* Órán használtuk a GetResult értékét, ami az eredményt adta vissza.
		 * Én ezt mellőzöm, mert jelen példában nincs fontos szerepe.
		 * Akkor van csak szerepe, ha közvetlenül egy Visitor típusból akarom
		 * lekérdezni az eredményt és az eredmény az karakterlánccá konvertálható,
		 * vagyis nem szükséges tudnunk, hogy mi van benne.
		 * Ha az eredmények nagyon eltérőek, pl. egyikben szöveg van másikban lista
		 * stb. akkor ez már problémát okozhat a felhasználásakor.
		 * Ráadásul honnan tudnánk, hogy a látogató milyen eredményt állít elő. 
		 * Ha pedig nem tudjuk, akkor miért készülünk fel arra, hogy visszaadjunk
		 * valamit. 
		 * Ettől függetlenül van eset amikor hasznos lehet, de ez mindig helyzetfüggő.
		 */
		//public abstract object GetResult();
	}
}