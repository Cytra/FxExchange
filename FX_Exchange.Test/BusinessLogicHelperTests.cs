using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using FX_Exchange.Enums;
using FX_Exchange.Helpers;
using FX_Exchange.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FX_Exchange.Test
{
    [TestClass]
    public class BusinessLogicHelperTests
    {
        [TestMethod]
        public void ExchangeCurrencies_DKKDKK_Returns_SameNumber()
        {
            using (var mock = AutoMock.GetStrict())
            {
                //Arrange
                var currencies = new List<Currency>();
                currencies.Add(new Currency("Danish kroner", ISO.DKK, 1));
                mock.Mock<ICurrencyHelper>().Setup(x => x.GetCurencies()).Returns(currencies);

                //Act
                var sut = mock.Create<BusinessLogicHelper>();
                sut.CurrencyPair = new CurrencyPair() { FirstCurrency = new Currency("Danish kroner", ISO.DKK, 1), SecondCurrency = new Currency("Danish kroner", ISO.DKK, 1), Amount = 100 };
                var result = sut.ExchangeCurrencies();

                //Assert
                Assert.AreEqual(100m, result);
            }

        }

        [TestMethod]
        public void ExchangeCurrencies_EURDKK_Returns_7_4394()
        {
            using (var mock = AutoMock.GetStrict())
            {
                //Arrange
                var currencies = new List<Currency>();
                currencies.Add(new Currency("Euro", ISO.EUR, 743.94m));
                currencies.Add(new Currency("Danish kroner", ISO.DKK, 1));
                mock.Mock<ICurrencyHelper>().Setup(x => x.GetCurencies()).Returns(currencies);

                //Act
                var sut = mock.Create<BusinessLogicHelper>();
                sut.CurrencyPair = new CurrencyPair() { FirstCurrency = new Currency("Euro", ISO.EUR, 743.94m), SecondCurrency = new Currency("Danish kroner", ISO.DKK, 1), Amount = 1 };
                var result = sut.ExchangeCurrencies();

                //Assert
                Assert.AreEqual(7.4394m, result);
            }

        }

        [TestMethod]
        public void ExchangeCurrencies_EURUSD_Returns_1_121895()
        {
            using (var mock = AutoMock.GetStrict())
            {
                //Arrange
                var currencies = new List<Currency>();
                currencies.Add(new Currency("Euro", ISO.EUR, 743.94m));
                currencies.Add(new Currency("Amerikanske dollar", ISO.USD, 663.11m));
                currencies.Add(new Currency("Danish kroner", ISO.DKK, 1));
                mock.Mock<ICurrencyHelper>().Setup(x => x.GetCurencies()).Returns(currencies);

                //Act
                var sut = mock.Create<BusinessLogicHelper>();
                sut.CurrencyPair = new CurrencyPair() { FirstCurrency = new Currency("Euro", ISO.EUR, 743.94m), SecondCurrency = new Currency("Amerikanske dollar", ISO.USD, 663.11m), Amount = 1 };
                var result = sut.ExchangeCurrencies();

                //Assert
                Assert.AreEqual(1.1218953114867819818732940236M, result);
            }

        }

        [TestMethod]
        public void ExchangeCurrencies_null_Returns_null()
        {
            using (var mock = AutoMock.GetStrict())
            {
                //Arrange
                var currencies = new List<Currency>();
                currencies.Add(new Currency("Euro", ISO.EUR, 743.94m));
                currencies.Add(new Currency("Amerikanske dollar", ISO.USD, 663.11m));
                currencies.Add(new Currency("Danish kroner", ISO.DKK, 1));
                mock.Mock<ICurrencyHelper>().Setup(x => x.GetCurencies()).Returns(currencies);

                //Act
                var sut = mock.Create<BusinessLogicHelper>();
                sut.CurrencyPair = null;
                var result = sut.ExchangeCurrencies();

                //Assert
                Assert.AreEqual(null, result);
            }
        }

        [TestMethod]
        public void ExchangeCurrencies_EURUSD_Returns_null()
        {
            //Arrange
            var businessLogicHelper = new BusinessLogicHelper(new CurrencyPair() { FirstCurrency = new Currency("Euro", ISO.EUR, 743.94m), SecondCurrency = new Currency("Amerikanske dollar", ISO.USD, 663.11m), Amount = 1 }, null);
            //Act

            var result = businessLogicHelper.ExchangeCurrencies();

            //Assert
            Assert.AreEqual(null, result);


        }
    }
}
