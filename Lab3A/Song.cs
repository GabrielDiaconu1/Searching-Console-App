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
    /// Represents a song as a type of media that can be encrypted and decrypted.
    /// </summary>
    public class Song : Media, IEncryptable
    {
        /// <summary>
        /// Gets or sets the album of the song.
        /// </summary>
        public string Album { get; set; }
        /// <summary>
        /// Gets or sets the artist of the song.
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// Gets or sets a summary of the song.
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Initializes a new instance of the Song class with the specified title, album, artist, and year.
        /// </summary>
        /// <param name="title">The title of the song.</param>
        /// <param name="album">The album to which the song belongs.</param>
        /// <param name="artist">The artist who performed the song.</param>
        /// <param name="year">The year of the song's release.</param>
        public Song(string title, string album, string artist, int year) : base(title, year)
        {
            this.Title = title;
            this.Album = album;
            this.Artist = artist;
            

        }
        /// <summary>
        /// Returns a string representation of the song.
        /// </summary>
        public override string ToString()
        {
            return $"Title: {this.Title}, Album: {this.Album}, Artist: {this.Artist}";
        }
        /// <summary>
        /// Encrypts the song's summary.
        /// </summary>
        /// <returns>An encrypted version of the summary.</returns>
        public string Encrypt()
        {

            return "";
        }
        /// <summary>
        /// Decrypts the song's summary.
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
