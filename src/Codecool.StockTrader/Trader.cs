namespace Codecool.StockTrader
{
    public class Trader
    {
        private readonly StockAPIService _stockService;
        private ILog _logger;

        public Trader(StockAPIService stockService, ILog dbLogger)
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
