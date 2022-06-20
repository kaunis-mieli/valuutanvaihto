using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valuutanvaihto.Helpers
{
    internal class MonkeyUserHelper
    {
        public static string NormalizeCurrencyCode(string currencyCode)
        {
            return currencyCode.Trim().ToUpper();
        }
    }
}
