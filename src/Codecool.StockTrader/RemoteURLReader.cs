using System.Net.Http;

namespace Codecool.StockTrader
{
    public class RemoteUrlReader
    {
        public string ReadFromUrl(string endpoint)
        {
            using var client = new HttpClient();
            using var responseMessage = client.GetAsync(endpoint).Result;
            using var httpContent = responseMessage.Content;
            var s = httpContent.ReadAsStringAsync().Result;

            return s;
        }
    }
}
