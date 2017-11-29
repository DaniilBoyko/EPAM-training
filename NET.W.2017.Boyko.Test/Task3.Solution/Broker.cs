using System;

namespace Task3.Solution
{
    /// <summary>
    /// Model for the broker.
    /// </summary>
    public class Broker : IObserver<StockInfo>
    {
        /// <summary>
        /// Store stock.
        /// </summary>
        private IObservable<StockInfo> _stock;

        /// <summary>
        /// Name of the broker.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Broker"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="observable"></param>
        public Broker(string name, Solution.IObservable<StockInfo> observable)
        {
            this.Name = name;
            _stock = observable;
            _stock.Register(this);
        }

        /// <inheritdoc></inheritdoc>
        public void Update(object sender, StockInfo info)
        {
            if (info.Usd > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, info.Usd);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, info.Usd);
        }

        /// <summary>
        /// Stop trade.
        /// </summary>
        public void StopTrade()
        {
            _stock.Unregister(this);
            _stock = null;
        }
    }
}
