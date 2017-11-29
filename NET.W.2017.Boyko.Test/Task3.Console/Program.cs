using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock<StockInfo> stock = new Stock<StockInfo>();

            Broker broker = new Broker("Forex", stock);
            Bank bank = new Bank("BNT", stock);

            stock.Market(new StockInfo {Euro = 123, Usd = 12});
        }
    }
}
