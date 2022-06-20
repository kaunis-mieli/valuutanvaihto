using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valuutanvaihto.MVVM
{
    internal class CurrencyPairMVVM
    {
        public string BaseCurrencyCode { get; set; }
        public string QuoteCurrencyCode { get; set; }
        public decimal Rate { get; set; }

        public CurrencyPairMVVM(string baseCurrencyCode, string quoteCurrencyCode, decimal rate)
        {
            BaseCurrencyCode = baseCurrencyCode;
            QuoteCurrencyCode = quoteCurrencyCode;
            Rate = rate;
        }
    }
}
