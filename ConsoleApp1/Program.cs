using RestSharp;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "url del api";
            var client = new HttpClient();
            NumeroOrden orden = new NumeroOrden()
            {
                numeroOrden = "123456"
            };

            var data = JsonSerializer.Serialize<NumeroOrden>(orden);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync(url, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                var postResult = JsonSerializer.Deserialize<NumeroOrden>(result);
            }
            
        }


        public class NumeroOrden
        {
            public string numeroOrden { get; set; }
        }
    }
}