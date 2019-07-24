using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Links
{
	class Character
	{
		public List<Song> _songs { get; set; }
		public string _name { get; set; }
		public string _fileName { get; set; }

		public Character(string name, List<Song> songs)
		{
			_name = name;
			_songs = songs;
		}
	}
}

