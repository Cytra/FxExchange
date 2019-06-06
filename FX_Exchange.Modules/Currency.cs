using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Exchange.Modules
{
    public class Currency : ICurrency
    {
        public string Description { get; set; }
        public string ISO { get; set; }
        public decimal Amount { get; set; }
    }

    public interface ICurrency
    {
        string Description { get; set; }
        string ISO { get; set; }
        decimal Amount { get; set; }
    }
}
