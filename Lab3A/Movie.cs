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
    /// Represents a movie as a type of media that can be encrypted and decrypted.
    /// </summary>
    public class Movie : Media, IEncryptable
    {
        /// <summary>
        /// Gets or sets the director of the movie.
        /// </summary>
        public string Director { get; set; }
        /// <summary>
        /// Gets or sets a summary of the movie.
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Initializes a new instance of the Movie class with the specified title, year, director, and summary.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="year">The year of release.</param>
        /// <param name="director">The director of the movie.</param>
        /// <param name="summary">A brief summary of the movie.</param>
        public Movie(string title, int year, string director, string summary) : base(title, year)
        {
            this.Title = title;
            this.Year = year;
            this.Director = director;
            this.Summary = summary;

        }
        /// <summary>
        /// Returns a string representation of the movie.
        /// </summary>
        public override string ToString()
        {
            return $"Title: {this.Title}, Year: {this.Year}, Director: {this.Director}";
        }
        /// <summary>
        /// Encrypts the movie's summary.
        /// </summary>
        /// <returns>An encrypted version of the summary.</returns>
        public string Encrypt()
        {
            return "";
        }
        /// <summary>
        /// Decrypts the movie's summary.
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
