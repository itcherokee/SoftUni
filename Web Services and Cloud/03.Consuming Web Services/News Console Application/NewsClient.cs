using System.Collections.Generic;

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

            ProccessRequest(search, count);
            Console.Read();
        }

        private static async void ProccessRequest(string search, int count)
        {
            var news = await PullNews(search, count);
            Console.WriteLine("Loading......");
            PrintNews(news);
        }

        private static void PrintNews(IEnumerable<Article> news)
        {
            if (news != null)
            {
                foreach (var article in news)
                {
                   Console.WriteLine("\n" + article.Title + "\n" + article.Url);
                }
            }
        }

        private static async Task<IEnumerable<Article>> PullNews(string search, int count)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/");
                string query = "search.json?q=" + search + "&count=" + count + "&title_only=1";
                var response = await client.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    var articles = new JavaScriptSerializer().Deserialize<IEnumerable<Article>>(result.Result);
                    return articles;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
        }

    }
}
