namespace Codecool.StockTrader
{
    public static class Program
    {
        public static void Main()
        {
            var logger = new FileLogger();
            var remoteUrlReader = new RemoteUrlReader();
            StockApiService stockService = new StockApiService(remoteUrlReader);
            Trader trader = new Trader(stockService, logger);
            TradingApp app = new TradingApp(trader, logger);

            app.Start();
        }
    }
}
