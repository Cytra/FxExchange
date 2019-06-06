using FX_Exchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_Exchange.Enums;

namespace FX_Exchange.Helpers
{
    public class CurrencyHelper : ICurrencyHelper
    {
        List<Currency> ICurrencyHelper.GetCurencies()
        {
            var result = new List<Currency>();
            result.Add(new Currency("Euro", ISO.EUR, 743.94m));
            result.Add(new Currency("Amerikanske dollar", ISO.USD, 663.11m));
            result.Add(new Currency("Britiske pund", ISO.GBP, 852.85m));
            result.Add(new Currency("Svenske kroner", ISO.SEK, 76.10m));
            result.Add(new Currency("Norske kroner", ISO.NOK, 78.40m));
            result.Add(new Currency("Schweiziske franc", ISO.CHF, 683.58m));
            result.Add(new Currency("Japanske yen", ISO.JPY, 5.9740m));
            result.Add(new Currency("Danish kroner", ISO.DKK, 1m));
            return result;
        }
    }

    public interface ICurrencyHelper
    {
        List<Currency> GetCurencies();
    }
}
