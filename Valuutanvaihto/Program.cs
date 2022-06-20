/**
 * @Author Vytis Mikašauskas
 **/

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

            dataInputUnitOfWork.ProcessData(ReadData(), 100);
        }

        static List<CurrencyPairMVVM> ReadData()
        {
            var toReturn = File.ReadAllLines("/Data/data.txt");

            return toReturn.Select(line =>
                    {
                        var parts = line.Split('\t');
                        return new CurrencyPairMVVM(parts[0], parts[1], Convert.ToDecimal(parts[2]));
                    })
                .ToList();
        }
    }
}