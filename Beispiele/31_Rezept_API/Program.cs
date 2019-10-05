using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Rezept_API
{
    /// <summary>
    /// The api is accessible at http://www.recipepuppy.com/about/api/.
    /// For example: http://www.recipepuppy.com/api/?i=onions,garlic&q=omelet&p=3
    /// Optional Parameters:
    /// i : comma delimited ingredients
    /// q : normal search query
    /// p : page
    /// format = xml : if you want xml instead of json
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rezeptsuche");
            Console.WriteLine("Zutaten (Komma getrennt)?");
            string ingredients = Console.ReadLine();
            Console.WriteLine("Suche nach welchem Gericht");
            string searchString = Console.ReadLine();

            // Url für die REST Abfrage
            string url = $"http://www.recipepuppy.com/api/?i={ingredients}&q={searchString}&p=1";
            var result = CallApi(url);

            if (result != null)
            {
                foreach (var item in result.results)
                {
                    Console.WriteLine(item.title.Replace("\n", ""));
                    Console.WriteLine(item.ingredients);
                    Console.WriteLine(item.href);
                    Console.WriteLine(item.thumbnail);
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        // Klassen generieren z.B. mit http://json2csharp.com/
        private static Result CallApi(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string response = httpClient.GetStringAsync(new Uri(url)).Result;
                    // String Daten in ein Objekt umwandeln
                    // Newtonsoft.Json muss über NuGet installiert werden
                    return JsonConvert.DeserializeObject<Result>(response);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
