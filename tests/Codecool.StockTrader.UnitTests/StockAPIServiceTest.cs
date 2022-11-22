using NUnit.Framework;

namespace Codecool.StockTrader.UnitTests
{
    [TestFixture]
    public class StockApiServiceTest
    {
        [Test]
        public void GetPriceExistingSymbolReturnsPriceAsDouble()
        {
        }

        [Test]
        public void GetPriceNonExistingSymbolThrowsArgumentException()
        {
        }

        [Test]
        public void GetPriceServerDownThrowsIoException()
        {
        }

        [Test]
        public void GetPriceMalformedResponseFromApiThrowsJsonReaderException()
        {
        }
    }
}
