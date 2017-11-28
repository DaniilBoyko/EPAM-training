using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Stock<T> : IObservable<T> where T : new()
    {
        private T info;

        public event EventHandler<T> changeInfo;

        public Stock()
        {
            info = new T();
        }

        public void Register(IObserver<T> observer) => changeInfo += observer.Update;

        public void Unregister(IObserver<T> observer) => changeInfo -= observer.Update;

        public void Notify()
        {
            changeInfo(this, info);
        }

        public void Market(T newInfo)
        {
            /*Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);*/
            info = newInfo;
            Notify();
        }
    }
}
