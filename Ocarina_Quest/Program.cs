// Link's music quest platform

//To Do:
//1. Make Song Class
//2. Create csv of songs
//3. Create a song maker/learner
//4. Custom song maker?

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
            var fileName = Path.Combine(directory.FullName, "Songs.txt");
            Console.WriteLine(ReadFile(fileName));


        }



        public static string ReadFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        //        public static List<string[]> ReadSongs(string fileName)
        //        {
        //            var soccerResults = new List<string[]>();
        //            using (var reader = new StreamReader(fileName))
        //            {
        //                string line = "";
        //                reader.ReadLine();
        //                while((line = reader.ReadLine()) != null)
        //                {
        //                    var gameResults = new GameResults();
        //                    string[] values = line.Split(',');
        //                    
        //                    DateTime gameDate;
        //                    if (DateTime.TryParse(values[0], out gameDate))
        //                    {
        //                        gameResults.GameDate = gameDate;
        //                    }
        //                    gameResults.TeamName = values[1];
        //                    HomeOrAway homeOrAway;
        //                    if(Enum.TryParse(values[2], out homeOrAway))
        //                    {
        //                        gameResults.HomeOrAway = homeOrAway;
        //                    }
        //                    int parseInt;
        //                    if(int.TryParse(values[3], out parseInt))
        //                    {
        //                        gameResults.Goals = parseInt;
        //                    }
        //                    if(int.TryParse(values[4], out parseInt))
        //                    {
        //                        gameResults.GoalAttempts = parseInt;
        //                    }
        //                    if(int.TryParse(values[5], out parseInt))
        //                    {
        //                        gameResults.ShotsOnGoal = parseInt;
        //                    }
        //                    if(int.TryParse(values[6], out parseInt))
        //                    {
        //                        gameResults.ShotsOffGoal = parseInt;
        //                    }
        //                    double possessionPercent;
        //                    if(double.TryParse(values[7], out possessionPercent))
        //                    {
        //                        gameResults.PossessionPercent = possessionPercent;
        //                    }
        //                    soccerResults.Add(values);
        //                }
        //            }
        //            return soccerResults;
        //        }


    }
}
