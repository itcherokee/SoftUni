namespace DistanceCalculatorRestClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class DistanceCalculatorClient
    {
        public static void Main()
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:48554/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var data = new { x1 = 3, y1 = 2, x2 = 34, y2 = -23 };
                HttpResponseMessage response = await client.PostAsJsonAsync("api/distance", data);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Content.ReadAsAsync<double>().Result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                Console.Read();
            }
        }
    }
}
