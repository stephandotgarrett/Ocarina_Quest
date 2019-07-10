using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Links
{
    class Song
    {
        public string _songTitle { get; set; }
        public string _songNotes { get; set; }
        public string _action { get; set; }
        public bool _avail { get; set; }
    }
}