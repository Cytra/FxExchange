using FX_Exchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Exchange.Helpers
{
    public class BusinessLogicHelper : IBusinessLogicHelper
    {
        public CurrencyPair CurrencyPair { get; set; }
        public ICurrencyHelper CurrencyHelper { get; set; }

        public BusinessLogicHelper(CurrencyPair currencyPair, ICurrencyHelper currencyHelper)
        {
            CurrencyPair = currencyPair;
            CurrencyHelper = currencyHelper;
        }

        public decimal? ExchangeCurrencies()
        {
            List<Currency> currencyList = null;
            if (CurrencyHelper != null)
            {
                currencyList = CurrencyHelper.GetCurencies();
            }
            
            if (CurrencyPair != null && currencyList != null)
            {
                if (CurrencyPair.FirstCurrency.Iso == Enums.ISO.DKK && CurrencyPair.SecondCurrency.Iso == Enums.ISO.DKK)
                {
                    return CurrencyPair.Amount;
                }

                if (CurrencyPair.SecondCurrency.Iso == Enums.ISO.DKK)
                {
                    return currencyList.First(x => x.Iso == CurrencyPair.FirstCurrency.Iso).Amount / 100 * CurrencyPair.Amount;
                }

                var defaultResult = (currencyList.First(x => x.Iso == CurrencyPair.FirstCurrency.Iso).Amount / currencyList.First(x => x.Iso == CurrencyPair.SecondCurrency.Iso).Amount) * CurrencyPair.Amount;

                return defaultResult;
            }

            return null;
        }
    }

    public interface IBusinessLogicHelper
    {
        CurrencyPair CurrencyPair { get; set; }
        ICurrencyHelper CurrencyHelper { get; set; }
        decimal? ExchangeCurrencies();
    }
}
