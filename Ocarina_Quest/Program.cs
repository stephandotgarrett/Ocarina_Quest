// Link's music quest platform

//To Do:
//1. Make Song Class
//2. Create csv of songs
//3. Create a song maker/learner
//4. Custom song maker?
//5. Create Character List

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

			RunMenu();

		}

		public static void RunMenu()
		{
			string name = "";
			string currentDirectory = Directory.GetCurrentDirectory();
			DirectoryInfo directory = new DirectoryInfo(currentDirectory);
			string fileName = Path.Combine(directory.FullName, "Songs.txt");
			List<Song> songs = new List<Song>(ReadSongs(fileName));

			string characterDirectory = Directory.GetCurrentDirectory();
			DirectoryInfo directory2 = new DirectoryInfo(characterDirectory);
			string contFile = Path.Combine(directory2.FullName, "Character.txt");
			List<Song> contSongs = new List<Song>(Continue(contFile));

			Console.WriteLine("");
			Console.WriteLine("Welcome To Ocarina Quest!!");
			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1) Create new player");
			Console.WriteLine("2) Continue ");

			string choice = Console.ReadLine();

			if (choice == "1")
			{
				Console.WriteLine("");
				Console.WriteLine("Please enter your name: ");
				name = Console.ReadLine();
				using (StreamWriter sw = new StreamWriter("Character.txt"))
				{
					sw.WriteLine(name);
					foreach (Song song in songs)
					{
						sw.WriteLine(song._songTitle + "," + song._songNotes + "," + song._action + ", " + song._avail);

					}
				}

			}
			else if (choice == "2")
			{
				if (name == "")
				{
					Console.Clear();
					Console.WriteLine("It looks like there are no previous players");
					RunMenu();
				}
				else
				{
					Console.WriteLine("");
					Console.WriteLine("Welcome back {0}!!!", name);
					ContinueMenu();
				}
				//            foreach (Song song in contSongs)
				//            {
				//              Console.WriteLine(song._songTitle + "," + song._songNotes + "," + song._action + ", " + song._avail);
				//            }
			}
			else
			{ }
		}

		public static void ContinueMenu()
		{

			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1) Learn Song");
			Console.WriteLine("2) List Song");
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

		public static List<Song> Continue(string fileName)
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
