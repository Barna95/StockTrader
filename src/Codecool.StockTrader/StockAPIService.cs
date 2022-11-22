using Newtonsoft.Json.Linq;

namespace Codecool.StockTrader
{
    /// <summary>
    ///     Stock price service that gets prices from iex
    /// </summary>
    public class StockApiService
    {
        private const string ApiPath = "https://run.mocky.io/v3/9e14e086-84c2-4f98-9e36-54928830c980?stock=";
        private readonly RemoteUrlReader _remoteUrlReader;

        public StockApiService(RemoteUrlReader remoteUrlReader)
        {
            _remoteUrlReader = remoteUrlReader;
        }

        /// <summary>
        ///     Get stock price from iex and return as a double
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public virtual double GetPrice(string symbol)
        {
            string url = ApiPath + symbol;
            string result = _remoteUrlReader.ReadFromUrl(url);
            JObject json = JObject.Parse(result);
            double price = json["price"]!.ToObject<double>();

            return price;
        }

        /// <summary>
        ///     Buys a share of the given stock at the current price. Returns false if the purchase fails.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public bool Buy(string symbol)
        {
            // Stub. No need to implement this
            return true;
        }
    }
}
