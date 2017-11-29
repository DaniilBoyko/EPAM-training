using System;

namespace Task3.Solution
{
    /// <summary>
    /// Model of bank.
    /// </summary>
    public class Bank : IObserver<StockInfo>
    {
        /// <summary>
        /// Name of the bank.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="name">name of the bank</param>
        /// <param name="observable">observable to register bank</param>
        public Bank(string name, IObservable<StockInfo> observable)
        {
            this.Name = name;
            observable.Register(this);
        }

        /// <inheritdoc></inheritdoc>
        public void Update(object sender, StockInfo info)
        {
            Console.WriteLine(
                info.Euro > 40 ? "Банк {0} продает евро;  Курс евро: {1}" : "Банк {0} покупает евро;  Курс евро: {1}",
                this.Name, info.Euro);
        }
    }
}
