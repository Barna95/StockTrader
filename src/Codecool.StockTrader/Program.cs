namespace Codecool.StockTrader
{
    public static class Program
    {
        public static void Main()
        {
            ILog logger = new FileLogger();
            var remoteUrlReader = new RemoteURLReader();
            StockAPIService stockService = new StockAPIService(remoteUrlReader);
            Trader trader = new Trader(stockService, logger);
            TradingApp app = new TradingApp(trader, logger);

            app.Start();
        }
    }
}
