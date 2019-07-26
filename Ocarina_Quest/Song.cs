using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Links
{
    class Song //Song class to hold values for making a list of songs
    {
        public string _songTitle { get; set; } //Holds value for song title
        public string _songNotes { get; set; } //Holds value for song notes for future use in song learning process
        public string _action { get; set; }  //Holds value for song action for future use in using songs to make available new songs to learn
        public bool _avail { get; set; } //Holds value for song availability (if it has been learned)
    }
}