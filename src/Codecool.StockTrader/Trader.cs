namespace Codecool.StockTrader
{
    public class Trader
    {
        private readonly StockApiService _stockService;
        private FileLogger _logger;

        public Trader(StockApiService stockService, FileLogger dbLogger)
        {
            _stockService = stockService;
            _logger = dbLogger;
        }

        public bool Buy(string symbol, double bid)
        {
            double price = _stockService.GetPrice(symbol);

            bool result = price <= bid;

            if (result)
            {
                _stockService.Buy(symbol);
                _logger.Log($"Purchased {symbol} stock at ${bid}, since it's higher than the current price (${price}).");
            }
            else
            {
                _logger.Log($"Bid for {symbol} was ${bid} but the stock price is ${price}, no purchase was made.");
            }

            return result;
        }
    }
}
