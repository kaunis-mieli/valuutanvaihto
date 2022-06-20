using Valuutanvaihto.Entities;
using Valuutanvaihto.MVVM;
using Valuutanvaihto.Repositories;
using Valuutanvaihto.UnitOfWorks;

namespace Valuutanvaihto
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            var currencyRepo = new CurrencyRepo();
            var rateRepo = new RateRepo();

            var dataInputUnitOfWork = new DataInputUnitOfWork(currencyRepo, rateRepo);

            dataInputUnitOfWork.ProcessData(new List<CurrencyPairMVVM>() { new CurrencyPairMVVM { BaseCurrencyCode = "EUR", QuoteCurrencyCode =  } }, 100);

            Console.WriteLine("Hello, World!");
        }
    }
}