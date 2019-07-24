// Link's music quest platform

//To Do:
//1. Continue from new character creation
//2. Continue menu options (learner, lister)

using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Links
{
    class Program
    {
        private static List<Song> songs = new List<Song>();
        private static List<Song> contSongs = new List<Song>();
        private static string name = "";
        private static string currentDirectory = Directory.GetCurrentDirectory();
        private static DirectoryInfo directory = new DirectoryInfo(currentDirectory);
        private static string songFile = Path.Combine(directory.FullName, "Songs.txt");
        private static string contFile = Path.Combine(directory.FullName, "Character.txt");


        static void Main(string[] args)
        { 
            // Assign and Read files to song lists
            songs = ReadSongs(songFile);
            contSongs = ReadSongs(contFile);

            // Load run menu to start app
            RunMenu();
        }

        public static void RunMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome To Ocarina Quest!!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Create new player");
            Console.WriteLine("2) Continue ");
            Console.WriteLine("3) Exit");

            string runChoice = Console.ReadLine();

            if (runChoice == "1")
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine();
                WriteSongs();
                contSongs = ReadSongs(songFile);
                ContinueMenu();
            }
            else if (runChoice == "2")
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
                    ContinueMenu();
                }
            }
            else if (runChoice == "3")
            {
            }
            else
            {
                Console.WriteLine("That's not a valid option");
                RunMenu();
            }
        }

        public static void ContinueMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome {0}!!!", name);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Learn Song");
            Console.WriteLine("2) List Song");

            string choice1 = Console.ReadLine();

            if (choice1 == "1")
            {
                LearnSong();
            }
            else if (choice1 == "2")
            {
                Console.Clear();
                ListSongs(contSongs);
                Console.WriteLine("Would you like to learn any songs? y/n: ");
                string learnSong = Console.ReadLine();
                if (learnSong == "y")
                {
                    LearnSong();
                }
                else if (learnSong == "n")
                {
                    Console.WriteLine("Fair enough! Thanks!");
                    RunMenu();
                }
            }
            else
            {
                Console.WriteLine("I'm sorry, that isn't a valid option");
                ContinueMenu();
            }
        }

        public static void LearnSong()
        {
            Console.Clear();
            ListSongs(contSongs);
            Console.WriteLine("Which song?");
            string title = Console.ReadLine().ToUpper();
            foreach (Song song in contSongs)
            {
                if (title == song._songTitle.ToUpper() && song._avail == false)
                {
                    song._avail = true;
                    Console.Clear();
                    Console.WriteLine("Awesome! You learned {0}!", song._songTitle);
                    WriteSongs();
                    ListSongs(contSongs);
                    Console.ReadLine();
                    ContinueMenu();
                }
                else if (title == song._songTitle.ToUpper() && song._avail == true)
                {
                    Console.WriteLine("It looks like you already know that one!");
                    Console.ReadLine();
                    ContinueMenu();
                }
            }
            Console.WriteLine("Something went wrong!!");
            Console.ReadLine();
            ContinueMenu();
                
            
        }

        public static void ListSongs(List<Song> songs)
        {
            foreach (Song song in songs)
            {
                if (song._avail == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(song._songTitle + " Learned");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(song._songTitle + " Not Learned");
                    Console.ResetColor();
                }
            }
        }

        public static void WriteSongs()
        {
            using (StreamWriter sw = new StreamWriter("Character.txt"))
            {
                sw.WriteLine(name);
                foreach (Song song in contSongs)
                {
                    sw.WriteLine(song._songTitle + "," + song._songNotes + "," + song._action + ", " + song._avail);
                }
            }
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