using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Interface: Book.cs
  Author:   Yash Patel
  Date:     July 18 , 2022
  Purpose:  This class is a subclass of movie which implements IEncryptable interface and media interface. it inherits Search() 
            directly from media class and overides the ToString() by adding aditional properties.

            I, Yash Patel, 000842226 certify that this material is my original work. No other person's work
            has been used without due acknowledgement.
*/

namespace Assignment3_Lab3A
{
    class Book : Media, IEncryptable
    {
        /*Properties of Book class*/
        public string TypeOfMedia { get; set; }
        public string AuthorOfBook { get; set; } // author of the book
        public string SummaryOfBook { get; set; } // book summary
        /// <summary>
        /// Constructor  initialize the properties of a book 
        /// </summary>
        /// <param name="type">type of media</param>
        /// <param name="title">title of a book</param>
        /// <param name="year">published year</param>
        /// <param name="author">author of a book</param>
        /// <param name="summary">book summary</param>
        public Book(string type, string title, int year, string author, string summary) : base(title, year)
        {
            TypeOfMedia = type;
            AuthorOfBook = author;
            SummaryOfBook = summary;
        }
        /// <summary>
        /// Implementing Rot13 encryption algorithm to return encrypted data
        /// </summary>
        /// <returns>Encrypted Strings</returns>
        public string Encrypt()
        {
            char[] summary = SummaryOfBook.ToCharArray();
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
            char[] summary = SummaryOfBook.ToCharArray();

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
        /// Displaying a book by its properties
        /// </summary>
        /// <returns>Displaying of a book</returns>
        public override string ToString()
        {

            return $"{TypeOfMedia} Title: {Title} ({Year})\nAuthor: {AuthorOfBook}\n-------------------------------";
        }

    }
}

