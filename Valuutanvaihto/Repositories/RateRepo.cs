using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuutanvaihto.Entities;

namespace Valuutanvaihto.Repositories
{
    internal class RateRepo
    {
        private List<CurrencyPair> rates = new List<CurrencyPair>();

        public void AddRate(CurrencyPair rate)
        {
            if(!rates.Any(_rate => _rate.Equals(rate)))
            {
                rates.Add(rate);
            }
        }

        public CurrencyPair? GetRate(Currency baseCurrency, Currency quoteCurrency)
        {
            return rates.FirstOrDefault(rate => rate.BaseCurrency.Equals(baseCurrency) &&
                rate.QuoteCurrency.Equals(quoteCurrency));
        }
    }
}
