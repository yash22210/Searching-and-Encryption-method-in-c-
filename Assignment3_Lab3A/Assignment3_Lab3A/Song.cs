using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Interface: Song.cs
  Author:   Yash Patel
  Date:     July 18 , 2022
  Purpose:  This class is a subclass of movie which implements IEncryptable interface and media interface. it inherits Search() 
            directly from media class and overides the ToString() by adding aditional properties.

            I, Yash Patel, 000842226 certify that this material is my original work. No other person's work
            has been used without due acknowledgement.
*/

namespace Assignment3_Lab3A
{
    class Song : Media
    {
        /*Properties of a song*/
        public string Type { get; set; }
        public string Album { get; set; } // which album of this song in
        public string Artist { get; set; } // who created this song
        /// <summary>
        /// Constructor  initialize the properties of a song
        /// </summary>
        /// <param name="type">type of media</param>
        /// <param name="title">title of the song</param>
        /// <param name="year">released year</param>
        /// <param name="album">wlbum name</param>
        /// <param name="artist">artist name</param>
        public Song(string type, string title, int year, string album, string artist) : base(title, year)
        {
            Type = type;
            Album = album;
            Artist = artist;
        }
        /// <summary>
        /// Displaying of a song by its properties
        /// </summary>
        /// <returns>representation of a song</returns>
        public override string ToString()
        {
            // return $"{Title,-35}{Year,-10}{Album,-30}{Artist}";

            return $"{Type} Title: {Title} ({Year})\nAlbum: {Album}  Artist: {Artist}\n-------------------------------";

        }
    }
}
