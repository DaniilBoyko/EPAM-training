using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Bank : IObserver<StockInfo>
    {
        private IObservable<StockInfo> stock;

        public string Name { get; set; }

        public Bank(string name, IObservable<StockInfo> observable)
        {
            this.Name = name;
            stock = observable;
            stock.Register(this);
        }

        public void Update(object sender, StockInfo info)
        {
            if (info.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, info.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, info.Euro);
        }
    }
}
