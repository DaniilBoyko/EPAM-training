//// <copyright file="Program.cs" company="RelCode">Boyko Daniil</copyright>
namespace Library.Tests.ConsoleApp
{
    using System;
    using Models;

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
            BookListService bookListService = new BookListService();

            try
            {
                bookListService.AddBook(new Book("121-12-1231-2", "Daniil", "Adventures", "ASV", 2015, 891, 900));
                bookListService.AddBook(new Book("12341234421-2", "Kate", "History", string.Empty, 123, 192, 901));
                bookListService.AddBook(new Book("12341234421-2", "Arthur", "Sherlock Holmes", string.Empty, 1242, 1009, 922));
                bookListService.AddBook(new Book("12341234421-2", "Arthur", "Treasure island"));

                Console.WriteLine("-----BOOKS BEFORE REMOVE:\n");
                foreach (Book book in bookListService)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("-----BOOKS AFTER REMOVE:\n");
                bookListService.RemoveBook(new Book("12341234421-2", "Arthur", "Treasure island"));
                foreach (Book book in bookListService)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("-----FIND BOOK:\n");
                Book bk = bookListService.FindBookByTag(Book.Tag.CountPages, 891);
                Console.WriteLine(bk);

                Console.WriteLine("-----SORT BOOKS BY COUNT PAGES:\n");
                bookListService.SortDescendingByTag(Book.Tag.CountPages);
                foreach (Book book in bookListService)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("-----SAVE BOOKS TO \"BookListStorage.txt\"\n");
                bookListService.SetFileWorker(new BookListStorage());
                bookListService.SaveBooksToFile(AppDomain.CurrentDomain.BaseDirectory + "BookListStorage.txt");

                Console.WriteLine("-----LOAD BOOKS FROM \"BookListStorage.txt\"\n");
                BookListService bookListService2 = new BookListService();
                bookListService2.SetFileWorker(new BookListStorage());
                bookListService2.LoadBooksFromFile(AppDomain.CurrentDomain.BaseDirectory + "BookListStorage.txt");
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
} // namespace Library.Tests.ConsoleApp
