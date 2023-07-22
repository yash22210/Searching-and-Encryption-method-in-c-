using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Interface: Movie.cs
  Author:   Yash Patel
  Date:     July 18 , 2022
  Purpose:  This class is a subclass of movie which implements IEncryptable interface and media interface. it inherits Search() 
            directly from media class and overides the ToString() by adding aditional properties.

            I, Yash Patel, 000842226 certify that this material is my original work. No other person's work
            has been used without due acknowledgement.
*/

namespace Assignment3_Lab3A
{
        class Movie : Media, IEncryptable
        {
            /*Properties of a movie object*/
            public string TypeOfMedia { get; set; }
            public string DirectorOfMovie { get; set; } // director of the movie
            public string SummaryOfMovie { get; set; } // summary of the movie 
            /// <summary>
            /// Constructor  Initialize the properties of the Movie ojects 
            /// </summary>
            /// <param name="type">type of media</param>
            /// <param name="title">title of the movie</param>
            /// <param name="year">released year</param>
            /// <param name="director">director of the movie</param>
            /// <param name="summary">movie's summary</param>
            public Movie(string type, string title, int year, string director, string summary) : base(title, year)
            {
                DirectorOfMovie = director;
                SummaryOfMovie = summary;
                TypeOfMedia = type;
            }
        /// <summary>
        /// Implementing Rot13 encryption algorithm to return encrypted data
        /// </summary>
        /// <returns>Encrypted Strings</returns>
        public string Encrypt()
            {
                char[] summary = SummaryOfMovie.ToCharArray();
                int key = 13;
                for (int i = 0; i < summary.Length; i++)
                {
                    int value = (int)summary[i];
                    if (value >= 'A' && value <= 'Z')
                    {
                        if (value > 'M')
                        {
                            value = value + key - 26;
                        }
                        else
                        {
                            value += 13;
                        }
                    }
                    else if (value >= 'a' && value <= 'z')
                    {
                        if (value > 'm')
                        {
                            value = value + key - 26;
                        }
                        else
                        {
                            value += 13;
                        }
                    }
                    summary[i] = (char)value;
                }

                return new string(summary);
            }
            /// <summary>
            /// Implementing Rot13 decryption algorithm to return decrypted data
            /// </summary>
            /// <returns>Decrypted Strings</returns>

            public string Decrypt()
            {
                char[] summary = SummaryOfMovie.ToCharArray();

                int key = 13;

                for (int i = 0; i < summary.Length; i++)
                {
                    int value = (int)summary[i];
                    if (value >= 'A' && value <= 'Z')
                    {
                        if (value > 'M')
                        {
                            value -= 13;
                        }
                        else
                        {
                            value = value - key + 26;
                        }
                    }
                    else if (value >= 'a' && value <= 'z')
                    {
                        if (value > 'm')
                        {
                            value -= 13;
                        }
                        else
                        {
                            value = value - key + 26;
                        }
                    }
                    summary[i] = (char)value;
                }

                return new string(summary);
            }
        /// <summary>
        /// Displaying a movie by its properties
        /// </summary>
        /// <returns>Displaying of a movie</returns>
        public override string ToString()
            {

               return $"{TypeOfMedia} Title: {Title} ({Year})\nDirector: {DirectorOfMovie}\n-------------------------------";
        }

        }
}
