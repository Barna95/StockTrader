using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Moq;

namespace Codecool.StockTrader.UnitTests
{
    [TestFixture]
    public class StockApiServiceTest
    {
        [Test]
        public void GetPriceExistingSymbolReturnsPriceAsDouble()
        {
            // arrange
            const string exampleSymbol = "AAPL";
            const string exampleResponse = "{\"symbol\":\"AAPL\",\"price\":338.85}";
            const double expectedPrice = 338.85;

            // using NSubstitute
            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromUrl(Arg.Any<string>()).ReturnsForAnyArgs(exampleResponse);

            // using Moq
            var remoteUrlReaderMock = new Mock<RemoteURLReader>();
            remoteUrlReaderMock.Setup(x => x.ReadFromUrl(It.IsAny<string>())).Returns(exampleResponse);

            var stockApiService = new StockAPIService(remoteUrlReaderMock.Object);

            // act 
            double actualPrice = stockApiService.GetPrice(exampleSymbol);

            // assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void GetPriceNonExistingSymbolThrowsArgumentException()
        {
            // arrange
            const string nonexistingSymbol = "non-existing-symbol";
            const string exampleResponse = "{\"symbol\":\"AAPL\",\"price\":338.85}";

            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromUrl(Arg.Any<string>()).ReturnsForAnyArgs(exampleResponse);

            var stockApiService = new StockAPIService(remoteUrlReader);

            // act & assert
            Assert.Throws<ArgumentException>(() => stockApiService.GetPrice(nonexistingSymbol));
        }

        [Test]
        public void GetPriceServerDownThrowsIoException()
        {
            // arrange
            const string exampleSymbol = "AAPL";

            // using NSubstitute
            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromUrl(Arg.Any<string>()).ThrowsForAnyArgs<WebException>();

            var stockApiService = new StockAPIService(remoteUrlReader);

            // act & assert
            Assert.Throws<WebException>(() => stockApiService.GetPrice(exampleSymbol));
        }

        [Test]
        public void GetPriceMalformedResponseFromApiThrowsJsonReaderException()
        {
            // arrange
            const string exampleSymbol = "AAPL";
            const string malformedResponse = "\"{\"symbol\":";

            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromUrl(Arg.Any<string>()).ReturnsForAnyArgs(malformedResponse);

            var stockApiService = new StockAPIService(remoteUrlReader);

            // act & assert
            Assert.Throws<JsonReaderException>(() => stockApiService.GetPrice(exampleSymbol));
        }
    }
}
