using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Interface: Program.cs
  Author:   Yash Patel
  Date:     July 18 , 2022
  Purpose:  This class is the main class which is used to test methods of all other classess and implement the task as per 
            user's selection.

            I, Yash Patel, 000842226 certify that this material is my original work. No other person's work
            has been used without due acknowledgement.
*/

namespace Assignment3_Lab3A
{
    internal class Program
    {
        static int count; // the actual length of the Media[]
         
        static void Main(string[] args)
        {
            Media[] media = ReadData();

            // if media is null that means reading data from the textfile is failed.
            if (media == null) 
            {
                Console.WriteLine("Program is terminated due to exception. Click any key to close.");
                Console.ReadKey();
            }
            else // run the program only when reading data is successfully
                ProcessUserInput(media);

        }
        /// <summary>
        /// Copy the items from the original Media[] into a new Media[]. Additionally, offering a menu so the consumer may choose.
        /// If the user enters 1, 2, 3, 4, or 5, the software will show the user a different set of data, and the loop will go on.
        /// If the user enters 6, the application will, however, end immediately.
        /// </summary>
        /// <param name="media">the original Media[]</param>
        private static void ProcessUserInput(Media[] media)
        {
            Media[] newMedia = new Media[count]; // create a new array based on the number of objects in Media[]
            for (int j = 0; j < count; j++)// copy objects
            {
                newMedia[j] = media[j];
            }
            DisplayMenu();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) == false)
                {
                    Console.WriteLine("*** Invalid Choice - Try Again ***");
                }
                else
                {
                    Console.Clear();
                    if (choice == 1)
                    {
                        ListBooks(newMedia);

                    }
                    else if (choice == 2)
                    {

                        ListMovies(newMedia);
                    }
                    else if (choice == 3)
                    {

                        ListSongs(newMedia);
                    }
                    else if (choice == 4)
                    {

                        ListMedia(newMedia);
                    }
                    else if (choice == 5)
                    {

                        SearchMedia(newMedia);

                    }
                    else if (choice == 6)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a number between 1 and 6 Please!");
                    }

                }
                Console.WriteLine("\n\nPress any key to continue......");
                Console.ReadKey();
                Console.Clear();
                DisplayMenu();
            }

        }
        /// <summary>
        /// Request string entries from the user. Display the items in the new Media if any type of media has a title 
        /// that includes the string.
        /// </summary>
        /// <param name="newMedia">new Media[]</param>

        private static void SearchMedia(Media[] newMedia)
        {
            Console.WriteLine("Enter a search string:                    ");
            string key = Console.ReadLine();
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------");
            bool result = false;
            foreach (Media m in newMedia)
            {
                if (m.Search(key) == true)
                {
                    result = true;
                    if (m is Book book)
                    {
                        Console.WriteLine(m);
                        book.SummaryOfBook = book.Decrypt();
                        Console.WriteLine("\n" + book.SummaryOfBook);

                    }
                    else if (m is Movie movie)
                    {
                        Console.WriteLine(m);
                        movie.SummaryOfMovie = movie.Decrypt();
                        Console.WriteLine("\n" + movie.SummaryOfMovie);


                    }
                    // else it could be the song
                    else
                    {
                        Console.WriteLine(m);
                    }
                }

            }
            if (result == false)
            {
                Console.WriteLine("\nSorry, we cannot find anything with your title!\n");
            }

        }
        /// <summary>
        /// List all the objects in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListMedia(Media[] media)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************  LIST ALL MEDIA  *****************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Media m in media)
            {
                Console.WriteLine(m);
            }
        }
        /// <summary>
        /// List all the songs in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListSongs(Media[] media)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************  LIST ALL THE SONGS  *****************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Media m in media)
            {
                if (m is Song song)
                {
                    Console.WriteLine(song);
                }
            }
        }
        /// <summary>
        /// List all the movies in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListMovies(Media[] media)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************  LIST ALL THE MOVIES  *****************************\n");
            Console.ForegroundColor = ConsoleColor.White; foreach (Media m in media)
            {
                if (m is Movie movie)
                {
                    Console.WriteLine(movie);
                }
            }
        }
        /// <summary>
        /// List all the books in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListBooks(Media[] media)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************  LIST ALL THE BOOKS  *****************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Media m in media)
            {
                if (m is Book book)
                {
                    Console.WriteLine(book);
                }
            }
        }
        /// <summary>
        /// Read the data from a text file name data.txt and divide it up into the various objects that make up a Media[].
        /// Return null if data reading fails. If not, send the Media[] back to the main function.
        /// </summary>
        private static Media[] ReadData()
        {
            // create an arry of length is 100 to retrive 100 data into the media between "SONG" ,"BOOK" and  "MOVIE"
            Media[] media = new Media[100];

            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("Data.txt", FileMode.Open);
                sr = new StreamReader(fs);
                string content = sr.ReadToEnd(); // read the whole file and store it into variable content
                string[] sep1 = { "-----" }; // seprator 1 -> "-----"
                string[] largeParts = content.Split(sep1, StringSplitOptions.RemoveEmptyEntries);// use "-----" to separate the data
                count = largeParts.Length - 1; // assign value to the length of new Movie[]
                for (int i = 0; i < largeParts.Length; i++)
                {
                    string[] singleParts = largeParts[i].Split('|'); // use char '|' to sepatate each smaller part
                    string type = singleParts[0];
                    if (type.Trim() == "BOOK")

                    {
                        SeperateBook(type, media, i, singleParts);
                    }
                    else if (type.Trim() == "MOVIE")

                    {
                        SeperateMoive(type, media, i, singleParts);
                    }
                    else if (type.Trim() == "SONG")
                    {
                        SeperateSong(type, media, i, singleParts);

                    }
                }
            }
            catch (Exception ex) // Catch the exception and stop the application from crashing if reading data fails.
            {
                Console.WriteLine($"Exception loading media from file due to {ex.Message}");
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (sr != null)
                {
                    sr.Close();
                }
            }
            return media;
        }
        /// <summary>
        /// Create an object of Song when the title is SONG and save separate data in its properties. then keep it in the Media[].
        /// </summary>
        /// <param name="type">type of media</param>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="singlePart">the part sepatated by char '|'</param>
        private static void SeperateSong(string type, Media[] media, int i, string[] singlePart)
        {
            string title = singlePart[1];
            if (int.TryParse(singlePart[2], out int year) == false)
            {
                Console.WriteLine("Failed to parse the year!");
            }
            string album = singlePart[3];
            string artist = singlePart[4];
            media[i] = new Song(type, title, year, album, artist);
        }
        /// <summary>
        /// It is necessary to separate director from summary by the string [] "\r\n" when title is MOVIE and the data 
        /// has been separated by the character "|". The next step is to attempt to decode summary and re-encrypt 
        /// it. Create a book object, and then place it in the Meida.
        /// </summary>
        /// <param name="type">type of the media</param>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="singlePart">data separated by char '|'</param>
        private static void SeperateMoive(string type, Media[] media, int i, string[] singlePart)
        {
            string title, creator;
            int year;
            string[] lastParts;
            AssignValues(singlePart, out title, out year, out lastParts, out creator);
            media[i] = new Movie(type, title, year, creator, "");
            string summary = TestAlgorithm(media, i, lastParts);
            media[i] = new Movie(type, title, year, creator, summary);
        }
        /// <summary>
        /// It is necessary to separate author from summary by the string [] "\r\n" when title is BOOK and the data 
        /// has been separated by the character "|". The next step is to attempt to decode summary and re-encrypt 
        /// it. Create a book object, and then place it in the Meida.
        /// </summary>
        /// <param name="type">type of the media</param>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="singlePart">data separated by char '|'</param>
        private static void SeperateBook(string type, Media[] media, int i, string[] singlePart)
        {
            string title, creator;
            int year;
            string[] lastParts;
            AssignValues(singlePart, out title, out year, out lastParts, out creator);
            media[i] = new Book(type, title, year, creator, "");
            string summary = TestAlgorithm(media, i, lastParts);
            media[i] = new Book(type, title, year, creator, summary);

        }
        /// <summary>
        /// To confirm the summary in the book or movie, execute encrypt() and decrypt().
        /// </summary>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="lastParts">summary part</param>
        /// <returns></returns>
        private static string TestAlgorithm(Media[] media, int i, string[] lastParts)
        {
            string summary1 = "";
            for (int k = 1; k < lastParts.Length; k++)
            {
                summary1 += lastParts[k] + "\n";
            }
            string summary3 = "";
            if (media[i] is Book book1)
            {
                book1.SummaryOfBook = summary1;
                string summary2 = book1.Decrypt();
                book1.SummaryOfBook = summary2;
                summary3 = book1.Encrypt();
            }

            return summary3;
        }
        /// <summary>
        /// Using the separated components, assign the characteristics for the book or movie.
        /// </summary>
        /// <param name="smallParts"></param>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="lastParts"></param>
        /// <param name="author"></param>
        private static void AssignValues(string[] smallParts, out string title, out int year, out string[] lastParts, out string author)
        {
            title = smallParts[1];
            if (int.TryParse(smallParts[2], out year) == false)
            {
                Console.WriteLine("Failed to parse the year!");
            }
            string combination = smallParts[3]; // add author to the summary

            string[] sep2 = { "\r\n" };
            lastParts = combination.Split(sep2, StringSplitOptions.RemoveEmptyEntries);
            author = lastParts[0];
        }

        /// <summary>
        /// Display the menu to users in order to get input from them
        /// </summary>
        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYash's Media Collection");
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. List All Movies");
            Console.WriteLine("3. List All Songs");
            Console.WriteLine("4. List All Media");
            Console.WriteLine("5. Search All Media by Title\n");
            Console.WriteLine("6. Exit Program\n");
            Console.WriteLine("Enter choice:  ");
        }
    }
}

