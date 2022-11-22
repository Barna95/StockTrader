namespace Codecool.StockTrader
{
    public static class Program
    {
        public static void Main()
        {
            var remoteUrlReader = new RemoteUrlReader();
            StockApiService stockService = new StockApiService(remoteUrlReader);
            Trader trader = new Trader(stockService);
            TradingApp app = new TradingApp(trader);

            app.Start();
        }
    }
}
