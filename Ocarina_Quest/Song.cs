using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Links
{
    class Song //Song class to hold values for song title, song notes for future use, song action for using a song for future use, and song availability if song is learned.
    {
        public string _songTitle { get; set; }
        public string _songNotes { get; set; }
        public string _action { get; set; }
        public bool _avail { get; set; }
    }
}