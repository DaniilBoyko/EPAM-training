using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IObserver<T>
    {
        void Update(object sender, T observeble);
    }
}
