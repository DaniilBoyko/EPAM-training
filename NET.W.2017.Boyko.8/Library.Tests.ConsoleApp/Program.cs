using System;
using Library.Models;

namespace Library.Tests.ConsoleApp
{
    /// <summary>
    /// Show all abilities of Library
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Startup point of the program
        /// </summary>
        /// <param name="args">array of arguments</param>
        public static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "sdf/asdf/23!_/ / istStorage.txt";
            BookListService bookListService = new BookListService();

            try
            {
                bookListService.AddBook(new Book("121-12-1231-2", "Daniil", "Adventures", "ASV", 2015, 891, 900));
                bookListService.AddBook(new Book("12341234421-2", "Kate", "History", "ASV", 123, 192, 901));
                bookListService.AddBook(new Book("12341234421-2", "Arthur", "Sherlock Holmes", "ASV", 1242, 1009, 922));
                bookListService.AddBook(new Book("12341234421-2", "Arthur", "Treasure island", "ASV", 1242, 1009, 922));

                Console.WriteLine("-----BOOKS BEFORE REMOVE:\n");
                foreach (Book book in bookListService)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("-----BOOKS AFTER REMOVE:\n");
                bookListService.RemoveBook(new Book("12341234421-2", "Arthur", "Treasure island", "ASV", 1242, 1009, 922));
                foreach (Book book in bookListService)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("-----FIND BOOK:\n");
                Book bk = bookListService.FindBookByTag(book => book.CountPages == 891);
                Console.WriteLine(bk);

                Console.WriteLine("-----SORT BOOKS BY PRICE:\n");
                bookListService.Sort(new BookComparer());
                foreach (Book book in bookListService)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("-----SAVE BOOKS TO \"BookListStorage.txt\"\n");
                var bookStorage = new BookListStorage(path);
                bookListService.SaveBooksToFile(bookStorage);

                Console.WriteLine("-----LOAD BOOKS FROM \"BookListStorage.txt\"\n");
                BookListService bookListService2 = new BookListService();
                bookListService2.LoadBooksFromFile(bookStorage);
                foreach (Book book in bookListService2)
                {
                    Console.WriteLine(book);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }   
        } // !Main
    } // !class Program
} // !namespace Library.Tests.ConsoleApp
