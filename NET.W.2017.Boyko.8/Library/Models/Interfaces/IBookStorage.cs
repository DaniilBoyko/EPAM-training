using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Interfaces
{
    public interface IBookStorage
    {
        IEnumerable<Book> ReadBooks(string path);

        void WriteBooks(IEnumerable<Book> books, string path);
    }
}
