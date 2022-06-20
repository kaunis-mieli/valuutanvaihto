using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valuutanvaihto.Entities
{
    internal class CurrencyPair
    {
        public Currency BaseCurrency { get; set; }
        public Currency QuoteCurrency { get; set; }
        public decimal Rate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CurrencyPair pair &&
                   EqualityComparer<Currency>.Default.Equals(BaseCurrency, pair.BaseCurrency) &&
                   EqualityComparer<Currency>.Default.Equals(QuoteCurrency, pair.QuoteCurrency);
        }
    }
}
