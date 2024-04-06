using System.Collections.Generic;
using System.IO;
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
    /// Main program class for Lab3A.
    /// </summary>
  
    internal class Program
    {
        static List<Media> mediaList = new List<Media>();

        static void Main(string[] args)
        {
            /// <summary>
            /// Reads data from a file and populates the mediaList.
            /// </summary>
            void dataReader()
            {
                // Read data from a text file, split it into sections, and create media objects.
                string[] files = File.ReadAllLines("data.txt");
                for (int i = 0; i < files.Length; i++)
                {
                    string[] sections = files[i].Split(new[] { '|' });

                    if (sections.Length < 4)
                    {
                        
                        continue;
                    }

                    string mediaType = sections[0];
                    string title = sections[1];
                    string year = sections[2];

                    switch (mediaType)
                    {
                        case "SONG":
                            if (sections.Length >= 5)
                            {
                                string album = sections[3];
                                string artist = sections[4];
                                Song song = new Song(title, album, artist, int.Parse(year));
                                mediaList.Add(song);
                            }
                            break;

                        case "BOOK":
                            if (i + 1 < files.Length)
                            {
                                string author = sections[3];
                                string summary = files[i + 1];
                                Book book = new Book(title, int.Parse(year), author, summary);
                                mediaList.Add(book);
                                i++; // Skip the next line (summary)
                            }
                            break;

                        case "MOVIE":
                            if (i + 1 < files.Length)
                            {
                                string director = sections[3];
                                string summary = files[i + 1];
                                Movie movie = new Movie(title, int.Parse(year), director, summary);
                                mediaList.Add(movie);
                                i++; // Skip the next line (summary)
                            }
                            break;

                        default:
                            Console.WriteLine("Not a valid media type");
                            break;
                    }
                }
            }
            {
                // Call the dataReader function to read and process data.
                dataReader();
                bool continueSelecting = true;

                while (continueSelecting)
                {
                    Console.WriteLine("Select a category: \n 1 for List All Books\n 2 for List All Movies\n 3 for List All Songs\n 4 for List All Media\n 5 for Search All Media by Title \n 0 to exit");
                    int category = int.Parse(Console.ReadLine());
                    string searchKey;

                    switch (category)
                    {
                        case 0:
                            continueSelecting = false;
                            break;
                        case 1:
                            Console.WriteLine("List All Books:");
                            foreach (Media media in mediaList)
                            {
                                if (media is Book)
                                {
                                    Book book = (Book)media;
                                    Console.WriteLine(book.ToString());
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("List All Movies:");
                            foreach (Media media in mediaList)
                            {
                                if (media is Movie)
                                {
                                    Movie movie = (Movie)media; // Cast to Movie
                                    Console.WriteLine(movie.ToString()); // This will display the summary
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("List All Songs:");
                            foreach (Media media in mediaList)
                            {
                                if (media is Song)
                                {
                                    Console.WriteLine(media);
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("List All Media:");
                            foreach (Media media in mediaList)
                            {
                                Console.WriteLine(media);
                            }
                            break;
                        case 5:
                            Console.Write("Enter a title to search for: ");
                            searchKey = Console.ReadLine();
                            Console.WriteLine("Search All Media by Title:");
                            foreach (Media media in mediaList)
                            {
                                if (media.Search(searchKey))
                                {
                                    if (media is Movie)
                                    {
                                        Console.WriteLine(media);
                                        Movie movie = (Movie)media; // Cast to Movie
                                         // This will display the decrypted summary
                                        Console.WriteLine(movie.Decrypt()); // Display the decrypted summary
                                        
                                    }
                                    else if(media is Book)
                                    {
                                        Console.WriteLine(media);
                                        Book book = (Book)media;
                                        Console.WriteLine(book.Decrypt());

                                    }
                                    else
                                    {
                                        Console.WriteLine(media); // For other media types, use the default ToString
                                    }
                                }
                            }
                            break;
                    }
                }
                 
                }

            }
        }
    }
