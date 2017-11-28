using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Broker : IObserver<StockInfo>
    {
        private IObservable<StockInfo> stock;

        public string Name { get; set; }

        public Broker(string name, IObservable<StockInfo> observable)
        {
            this.Name = name;
            stock = observable;
            stock.Register(this);
        }

        public void Update(object sender, StockInfo info)
        {
            if (info.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, info.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, info.USD);
        }

        public void StopTrade()
        {
            stock.Unregister(this);
            stock = null;
        }
    }
}
