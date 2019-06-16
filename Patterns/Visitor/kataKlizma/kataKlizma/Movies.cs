using System;
using System.IO;
using System.Xml.Serialization;

namespace kataKlizma
{
    /// <summary>Szolgáltatást nyújtó osztály. Elfedi előlünk az adatbázist, ami most egy xml fájl.</summary>
    static public class Movies
    {
		/// <summary>Az első film.</summary>
		static public MovieBase FirstMovie { get; private set; }

		/// <summary>Itt csak betöltjük az adatokat fájlból.</summary>
		static Movies()
        {
            try
            {
                MovieXMLData[] movieXMLdb = (MovieXMLData[])XMLToObject("DataBase\\movies.xml", typeof(MovieXMLData[]));
				MovieBase movie = new NullMovie();
				for (int i = movieXMLdb.Length - 1; i >= 0; i--)
					movie = new Movie(movieXMLdb[i].url, movieXMLdb[i].title, movieXMLdb[i].lengthInSec, movieXMLdb[i].releaseDate, movie);
				FirstMovie = movie;
			}
            catch(Exception ex)
            {
                throw new MoviesException("Az adatbázis betöltése nem sikerült!", ex);
            }
        }

		/// <summary> XML fájlból osztály betöltése.
		/// </summary>
		/// <param name="pXMLFile">XML fájl.</param>
		/// <param name="pClassType">Osztály típus, amibe betöltjük az adatokat.</param>
		/// <returns>Az új objektum.</returns>
		public static object XMLToObject(string pXMLFile, Type pClassType)
		{
			XmlSerializer serializer = new XmlSerializer(pClassType);
			using (StreamReader reader = File.OpenText(pXMLFile))
			{
				return serializer.Deserialize(reader);
			}
		}
	}

	[Serializable]
    public class MoviesException : Exception
    {
        public MoviesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
