using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Exchange.Models
{
    public class CurrencyPair
    {
        public Currency FirstCurrency { get; set; }
        public Currency SecondCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
