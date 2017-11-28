using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IObservable<T>
    {
        void Register(IObserver<T> observer);
        void Unregister(IObserver<T> observer);
        void Notify();
    }
}
