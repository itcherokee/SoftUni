namespace NewsApplication
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    using Models;

    public class NewsClient
    {
        public static void Main()
        {
            Console.Write("Enter key word to serach:");
            var search = Console.ReadLine();
            Console.Write("Enter count of articles to retrieve (10):");
            int count;
            bool hasValue = int.TryParse(Console.ReadLine(), out count);
            count = hasValue ? count : 10;

            PullNews(search, count).Wait();

            Console.Read();
        }

        private static async Task PullNews(string search, int count)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/");
                string query = "search.json?q=" + search + "&count=" + count + "&title_only=1";
                HttpResponseMessage response = await client.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var json = new JavaScriptSerializer().Deserialize<Articles>(content);
                    if (json != null)
                    {
                        foreach (var article in json)
                        {
                            Console.WriteLine("\n" + article.Title + "\n" + article.Url);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
    }
}
