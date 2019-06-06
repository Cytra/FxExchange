using FX_Exchange.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Exchange.Library.Helpers
{
    public class CurrencyHelper : ICurrencyHelper
    {
        public List<ICurrency> GetCurencies()
        {
            throw new NotImplementedException();
        }
    }

    public interface ICurrencyHelper
    {
        List<ICurrency> GetCurencies();
    }
}
