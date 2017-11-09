﻿//// <copyright file="BookExistException.cs" company="RelCode">Boyko Daniil</copyright>
namespace Library.Models.Exceptions
{
    using System;

    /// <summary>
    /// Exception for book list service when book not exist.
    /// </summary>
    public class BookExistException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookExistException"/> class.
        /// </summary>
        /// <param name="message">message of exception</param>
        public BookExistException(string message) : base(message)
        {
        }
    }
}
