namespace Codecool.StockTrader
{
    public static class Program
    {
        public static void Main()
        {
            var urlToPass = "https://run.mocky.io/v3/9e14e086-84c2-4f98-9e36-54928830c980?stock=";
            var logger = new FileLogger();
            var remoteUrlReader = new RemoteURLReader();
            StockAPIService stockService = new StockAPIService(remoteUrlReader, urlToPass);
            Trader trader = new Trader(stockService, logger);
            TradingApp app = new TradingApp(trader, logger);

            app.Start();
        }
    }
}
