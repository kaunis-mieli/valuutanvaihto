using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuutanvaihto.Entities;
using Valuutanvaihto.MVVM;
using Valuutanvaihto.Repositories;
using Valuutanvaihto.Helpers;

namespace Valuutanvaihto.UnitOfWorks
{
    internal class DataInputUnitOfWork
    {
        private readonly CurrencyRepo currencyRepo;
        private readonly RateRepo rateRepo;

        public DataInputUnitOfWork(CurrencyRepo currencyRepo, RateRepo rateRepo)
        {
            this.currencyRepo = currencyRepo;
            this.rateRepo = rateRepo;
        }

        public void ProcessData(List<CurrencyPairMVVM> currencyPairMVVMs, decimal baseQuantity)
        {
            var cachedCurrencies = currencyRepo.Get();

            foreach (var currencyPairMVVM in currencyPairMVVMs)
            {
                var baseCurrencyCode = MonkeyUserHelper.NormalizeCurrencyCode(currencyPairMVVM.BaseCurrencyCode);
                var quoteCurrencyCode = MonkeyUserHelper.NormalizeCurrencyCode(currencyPairMVVM.QuoteCurrencyCode);
                var rate = currencyPairMVVM.Rate / baseQuantity;

                AddIfDoesntExist(cachedCurrencies, baseCurrencyCode);
                AddIfDoesntExist(cachedCurrencies, quoteCurrencyCode);

                var baseCurrency = cachedCurrencies.FirstOrDefault(cachedCurrency => cachedCurrency.Code.Equals(baseCurrencyCode));
                var quoteCurrency = cachedCurrencies.FirstOrDefault(cachedCurrency => cachedCurrency.Code.Equals(quoteCurrencyCode));

                if (rateRepo.GetRate(baseCurrency, quoteCurrency) == null)
                {
                    rateRepo.AddRate(new CurrencyPair
                    {
                        BaseCurrency = baseCurrency,
                        QuoteCurrency = quoteCurrency,
                        Rate = rate
                    });
                }
                else
                {
                    throw new Exception($"Data process error: {baseCurrency}/{quoteCurrency} already exists.");
                }
            }
        }

        private void AddIfDoesntExist(List<Currency> cachedCurrencies, string code)
        {
            var currency = cachedCurrencies.FirstOrDefault(cachedCurrency => cachedCurrency.Code.Equals(code));

            if (currency == null)
            {
                cachedCurrencies.Add(currencyRepo.Insert(code));
            }
        }

    }
}
