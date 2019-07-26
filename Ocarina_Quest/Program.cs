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

        //Function to run the main menu
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


            if (runChoice == "1") // Create new player option. Calls to read songs.txt and write continue list
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine();
                WriteSongs();
                contSongs = ReadSongs(songFile);
                ContinueMenu();
            }
            else if (runChoice == "2") // Continue option. First checks for previous player stored in the character.txt file
                                       //If player is not found, not found error is displayed. If player is found, runs continue menu
            {
                using (var reader = new StreamReader(contFile))
                {
                    name = reader.ReadLine();
                }
                if (name == "") // Delivers message if no stored player is found
                {
                    Console.Clear();
                    Console.WriteLine("It looks like there are no previous players");
                    RunMenu();
                }
                else if (name != "") // Runs continue if previous player is found
                {
                    ContinueMenu();
                }
            }
            else if (runChoice == "3") // Exit option
            {
            }
            else // Fault if player input is unrecognized
            {
                Console.WriteLine("That's not a valid option");
                RunMenu();
            }
        }

        //Function to run the secondary menu
        public static void ContinueMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome {0}!!!", name);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Learn Song");
            Console.WriteLine("2) List Song");
            Console.WriteLine("3) Back to Main");
            Console.WriteLine("4) Exit");

            string choice1 = Console.ReadLine();

            if (choice1 == "1") //Learn Song option
            {
                LearnSong();
            }
            else if (choice1 == "2") // List song option
            {
                Console.Clear();
                ListSongs(contSongs);
                Console.WriteLine("Would you like to learn any songs? y/n: ");
                string learnSong = Console.ReadLine();
                if (learnSong == "y") //Yes to learn a song
                {
                    LearnSong();
                }
                else if (learnSong == "n") // No, player does not want to learn song
                {
                    Console.WriteLine("Fair enough! Thanks!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    RunMenu();
                }
                else
                {
                    Console.WriteLine("It looks like something went wrong!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    RunMenu();
                }
            }
            else if (choice1 == "3") //Back to main menu option
            {
                RunMenu();
            }
            else if (choice1 == "4") // Exit option (Curently has an issue, sends to Something went wrong)
            {
            }
            else
            {
                Console.WriteLine("I'm sorry, that isn't a valid option");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                ContinueMenu();
            }
        }

        //Method to learn a new song. Player enters song title to compare to song list.
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
                    Console.WriteLine("Here are the songs you know now:");
                    WriteSongs();
                    ListSongs(contSongs);
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    ContinueMenu();
                }
                else if (title == song._songTitle.ToUpper() && song._avail == true)
                {
                    Console.WriteLine("It looks like you already know that one!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    ContinueMenu();
                }
            }
            Console.WriteLine("Something went wrong!!");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
            ContinueMenu();
                
            
        }

        // Function to print a list of songs to console
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

        // Function to write the list of songs to Character.txt file
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

        // Function to read a song file into a list of songs
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