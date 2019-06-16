using System;

namespace kataKlizma
{
    /// <summary>Tároló osztály. Csak azért van rá szükség, hogy az xml szerializáló be tudja tölteni fájlból az adatokat.</summary>
    public class MovieXMLData
    {
        public string url;
        public string title;
        public int lengthInSec;
        public DateTime releaseDate;
    }
}