using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Library.Models;
using Library.Models.Services;

namespace Library.Tests.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService bookListService = new BookListService();

            try
            {
                bookListService.AddBook(new Book("121-12-1231-2", "Daniil", "Adventures", "ASV", 2015, 891, 900));
                bookListService.AddBook(new Book("12341234421-2", "Kate", "History", "", 123, 192, 901));
                bookListService.AddBook(new Book("12341234421-2", "Arthur", "Sherlock Holmes", "", 1242, 1009, 922));
                bookListService.AddBook(new Book("12341234421-2", "Arthur", "Treasure island"));

                Console.WriteLine("-----BOOKS BEFORE REMOVE:\n");
                foreach (Book book in bookListService)
                    Console.WriteLine(book);

                Console.WriteLine("-----BOOKS AFTER REMOVE:\n");
                bookListService.RemoveBook(new Book("12341234421-2", "Arthur", "Treasure island"));
                foreach (Book book in bookListService)
                    Console.WriteLine(book);

                Console.WriteLine("-----FIND BOOK:\n");
                Book bk = bookListService.FindBookByTag(Book.Tag.CountPages, 891);
                Console.WriteLine(bk);

                Console.WriteLine("-----SORT BOOKS BY COUNT PAGES:\n");
                bookListService.SortDescendingByTag(Book.Tag.CountPages);
                foreach (Book book in bookListService)
                    Console.WriteLine(book);

                Console.WriteLine("-----SAVE BOOKS TO \"BookListStorage.txt\"\n");
                bookListService.SetFileWorker(new BookListStorage());
                bookListService.SaveBooksToFile(AppDomain.CurrentDomain.BaseDirectory + "BookListStorage.txt");

                Console.WriteLine("-----LOAD BOOKS FROM \"BookListStorage.txt\"\n");
                BookListService bookListService2 = new BookListService();
                bookListService2.SetFileWorker(new BookListStorage());
                bookListService2.LoadBooksFromFile(AppDomain.CurrentDomain.BaseDirectory + "BookListStorage.txt");
                foreach (Book book in bookListService2)
                    Console.WriteLine(book);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
