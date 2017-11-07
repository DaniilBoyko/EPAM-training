using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Interfaces
{
    public interface IFileWorker
    {
        List<Book> ReadBooksFromFile(string path);
        void WriteBooksToFile(List<Book> books, string path);
    }
}
