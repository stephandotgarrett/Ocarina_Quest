// Link's music quest platform

//To Do:
//1. Continue from new character creation
//2. Continue menu options (learner, lister)

using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Links
{
	class Program
	{
        private static List<Song> songs = new List<Song>();
		private static List<Song> contSongs = new List<Song>();

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
			songs = ReadSongs(fileName);

			string characterDirectory = Directory.GetCurrentDirectory();
			DirectoryInfo directory2 = new DirectoryInfo(characterDirectory);
			string contFile = Path.Combine(directory2.FullName, "Character.txt");
			contSongs = ReadSongs(contFile);

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
				using (var reader = new StreamReader(contFile))
				{
					name = reader.ReadLine();
				}
				if (name == "")
				{
					Console.Clear();
					Console.WriteLine("It looks like there are no previous players");
					RunMenu();
				}
				else if (name != "")
				{
					Console.WriteLine("");
					Console.WriteLine("Welcome back {0}!!!", name);
					ContinueMenu();
				}
			}
			else
			{
			}
		}

		public static void ContinueMenu()
		{
			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1) Learn Song");
			Console.WriteLine("2) List Song");

			string choice1 = Console.ReadLine();

			if (choice1 == "1")
			{

			}
			else if (choice1 == "2")
			{ }
            else
			{ }
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
