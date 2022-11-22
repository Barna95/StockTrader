namespace Codecool.StockTrader
{
    public class Trader
    {
        private readonly StockApiService _stockService;

        public Trader(StockApiService stockService)
        {
            _stockService = stockService;
        }

        public bool Buy(string symbol, double bid)
        {
            double price = _stockService.GetPrice(symbol);

            bool result = price <= bid;

            if (result)
            {
                _stockService.Buy(symbol);
                FileLogger.Instance.Log($"Purchased {symbol} stock at ${bid}, since it's higher than the current price (${price}).");
            }
            else
            {
                FileLogger.Instance.Log($"Bid for {symbol} was ${bid} but the stock price is ${price}, no purchase was made.");
            }

            return result;
        }
    }
}
