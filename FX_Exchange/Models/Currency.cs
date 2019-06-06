using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_Exchange.Enums;

namespace FX_Exchange.Models
{
    public class Currency
    {
        public string Description { get; set; }
        public ISO Iso { get; set; }
        public decimal Amount { get; set; }

        public Currency(string description, ISO iso, decimal amount)
        {
            Description = description;
            Iso = iso;
            Amount = amount;
        }
    }
}
