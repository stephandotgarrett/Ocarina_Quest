// Link's music quest platform

//To Do:
//1. create stream writer after initial parse to save character (andy)
//2. 
//3. Create a song maker/learner
//4. 
//5. create menu (create player, continue player)

using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Links
{
	class Program
	{
		static void Main(string[] args)
		{

			string currentDirectory = Directory.GetCurrentDirectory();
			DirectoryInfo directory = new DirectoryInfo(currentDirectory);
			string fileName = Path.Combine(directory.FullName, "Songs.txt");

			List<Song> songs = new List<Song>(ReadSongs(fileName));

			DisplayMenu();

		}


		public static void DisplayMenu()
		{

			Console.WriteLine("");
			Console.WriteLine("Welcome To Ocarina Quest!!");
			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1) Create new player");
			Console.WriteLine("2) Continue ");

			int choice = Console.ReadLine();
		}

		public static List<Song> ReadSongs(string fileName)
		{
			var songs = new List<Song>();
			using (var reader = new StreamReader(fileName))
			{
				string line = "";
				reader.ReadLine();
				while ((line = reader.ReadLine()) != null)
				{
					var song = new Song();
					string[] values = line.Split(',');

					string songTitle = values[0];
					song._songTitle = songTitle;

					string songNotes = values[1];
					song._songNotes = songNotes;

					string action = values[2];
					song._action = action;

					bool avail;
					if (Boolean.TryParse(values[3], out avail))
					{
						song._avail = avail;
					}

					songs.Add(song);
				}
			}
			return songs;
		}



	}
}
