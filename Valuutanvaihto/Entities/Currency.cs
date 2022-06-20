using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valuutanvaihto.Entities
{
    internal class Currency
    {
        public string Code { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Currency currency &&
                   Code.Equals(currency.Code);
        }
    }
}
