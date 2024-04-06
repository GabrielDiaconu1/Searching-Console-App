using System;
using System.IO;
/**
 *I, Gabriel Diaconu, 000799618 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 *author: Gabriel Diaconu
 *date: October 18 2023
 *What is this program? This program reads data from a file, creates media objects and allows users to interact with this media data.
 **Why? This program is helpful for the user and even provides a searching function based on a provided search key. 
 **/
namespace Lab3A
{
    /// <summary>
    /// Represents a book as a type of media that can be encrypted and decrypted.
    /// </summary>
    public class Book : Media, IEncryptable
    {
        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Gets or sets the summary of the book.
        /// </summary>
        public string Summary {  get; set; }
        /// <summary>
        /// Initializes a new instance of the Book class with the specified title, year, author, and summary.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="year">The year of publication.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="summary">A brief summary of the book.</param>

        public Book(string title, int year, string author, string summary) : base(title, year)
        {
            this.Title = title;
            this.Year = year;
            this.Author = author;
            this.Summary = summary;
            
        }
        /// <summary>
        /// Returns a string representation of the book.
        /// </summary>
        public override string ToString()
        {
            return $"Title: {this.Title}, Year: {this.Year},Author: {this.Author}";
        }
        /// <summary>
        /// Encrypts the book's summary.
        /// </summary>
        /// <returns>An encrypted version of the summary.</returns>
        public string Encrypt()
        {
            
            return "";
        }
        /// <summary>
        /// Decrypts the book's summary.
        /// </summary>
        /// <returns>A decrypted version of the summary.</returns>
        public string Decrypt()
        {
            

            char[] inputArray = Summary.ToCharArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                char c = inputArray[i];

                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    // Decrypt using the same Caesar cipher logic
                    inputArray[i] = (char)(((c - offset - 13 + 26) % 26) + offset);
                }
            }

            

            // Update the decrypted Summary property
            return new string(inputArray);

            
        }
    }
}
