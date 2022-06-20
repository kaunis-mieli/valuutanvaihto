using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuutanvaihto.Entities;

namespace Valuutanvaihto.Repositories
{
    internal class CurrencyRepo
    {
        private Dictionary<string, Currency> currencies = new Dictionary<string, Currency>();

        public Currency Insert(string code)
        {
            if (!currencies.ContainsKey(code))
            {
                currencies.Add(code, new Currency { Code = code });
            }

            return currencies[code];
        }

        public List<Currency> Get()
        {
            return currencies.Values.ToList();
        }
    }
}
