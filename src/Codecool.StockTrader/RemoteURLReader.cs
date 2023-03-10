using System.Net.Http;

namespace Codecool.StockTrader
{
    public class RemoteURLReader
    {
        public virtual string ReadFromUrl(string endpoint)
        {
            using var client = new HttpClient();
            using var responseMessage = client.GetAsync(endpoint).Result;
            using var httpContent = responseMessage.Content;
            var s = httpContent.ReadAsStringAsync().Result;

            return s;
        }
    }
}
