using System;
using System.Collections;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using FX_Exchange.Enums;
using FX_Exchange.Helpers;
using FX_Exchange.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace FX_Exchange.Test
{

    [TestClass]

    public class DataParserTests
    {

        [TestMethod]
        public void ParseData_string_Returns_ValidCurrencyPair()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var currencies = new List<Currency>();
                currencies.Add(new Currency("Amerikanske dollar", ISO.USD, 663.11m));
                currencies.Add(new Currency("Svenske kroner", ISO.SEK, 76.10m));
                mock.Mock<ICurrencyHelper>().Setup(x => x.GetCurencies()).Returns(currencies);
                mock.Mock<IDataWriter>();

                //Act
                var sut = mock.Create<DataParser>();
                var loger = mock.Create<IDataWriter>();
                var currencyHelper = mock.Create<ICurrencyHelper>();
                var result = sut.ParseData("exchange USD/SEK 1", loger, currencyHelper);
                var firstCur = currencies.Find(x => x.Iso == ISO.USD);

                //Assert
                Xunit.Assert.Equal(1, result.Amount);
                Xunit.Assert.Equal(currencies.Find(x => x.Iso == ISO.USD), result.FirstCurrency);
                Xunit.Assert.Equal(currencies.Find(x => x.Iso == ISO.SEK), result.SecondCurrency);
            }
        }

        [Theory]
        [ClassData(typeof(ParseStringTestDataGenerator))]
        public void ParseString_string_StringList(string input, List<string> expected)
        {

            //Arrange
            var dataparser = new DataParser();

            //Act
            var result = dataparser.ParseString(input);

            //Assert
            Xunit.Assert.Equal(expected,result);
        }
    }

    public class ParseStringTestDataGenerator : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"exchange", new List<string>() { "exchange" } },
            new object[] {"exchange EUR/USD 1", new List<string>() { "exchange", "EUR", "USD", "1" }},
            new object[] {"exchange/EUR/USD/1", new List<string>() { "exchange", "EUR", "USD", "1" }},
            new object[] {"exchange EUR USD 1", new List<string>() { "exchange", "EUR", "USD", "1" }},
            new object[] {string.Empty, new List<string>()},
            new object[] {null, new List<string>()}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
