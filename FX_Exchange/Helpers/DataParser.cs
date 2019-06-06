using FX_Exchange.Enums;
using FX_Exchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Exchange.Helpers
{
    public class DataParser : IDataParser
    {
        public CurrencyPair ParseData(string input, IDataWriter loger, ICurrencyHelper currencyHelper)
        {
            CurrencyPair result = null;

            var currencies = currencyHelper.GetCurencies();
            try
            {
                var words = ParseString(input);
                if (ValidateData(loger, words) && currencies != null)
                {
                    result = new CurrencyPair();
                    ISO FirstIso;
                    if (Enum.TryParse(words[1], true, out FirstIso))
                    {
                        result.FirstCurrency = currencies.Where(x => x.Iso == FirstIso).First();
                    } 

                    ISO secondIso;
                    if (Enum.TryParse(words[2], true, out secondIso))
                    {
                        result.SecondCurrency = currencies.Where(x => x.Iso == secondIso).First();
                    }

                    decimal amount;
                    if (decimal.TryParse(words[3], out amount))
                    {
                        result.Amount = amount;
                    }

                } 
            }
            catch (Exception ex)
            {
                loger.WriteError(ex.ToString());
            }

            return result;
        }


        public List<string> ParseString(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input.Split(new char[] { ' ', '/' }).ToList();
            }
            return new List<string>();
        }

        public bool ValidateData(IDataWriter loger, List<string> words)
        {
            if (words.Count != 4)
            {
                loger.WriteError("Wrong input provided");
                return false;
            }


            if (words[0].ToLower() != "exchange")
            {
                loger.WriteError("Not specified command");
                return false;
            }

            ISO iso;
            if (!Enum.TryParse(words[1], true, out iso))
            {
                loger.WriteError("First currency not recognised");
                return false;
            }

            if (!Enum.TryParse(words[2], true, out iso))
            {
                loger.WriteError("Second currency not recognised");
                return false;
            }

            double amount;
            if (!double.TryParse(words[3], out amount))
            {
                loger.WriteError("Amount Not Recognised");
                return false;
            }

            return true;
        }
    }

    public interface IDataParser
    {
        List<string> ParseString(string input);
        CurrencyPair ParseData(string input, IDataWriter loger, ICurrencyHelper currencyHelper);
        bool ValidateData(IDataWriter loger, List<string> words);
    }
}
