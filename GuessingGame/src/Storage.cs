using System;
using System.IO;

namespace GuessingGame.Src
{
    public static class Storage
    {
        private static readonly string DataDir = "data";
        private static readonly string HighscoreFile = Path.Combine(DataDir, "highscore.txt");

        private static void InitStorage()
        {
            // Ensures the data directory exists
            if (!Directory.Exists(DataDir))
            {
                Directory.CreateDirectory(DataDir);
            }
        }

        public static int GetCurrentHighscore()
        {
            InitStorage();

            if (File.Exists(HighscoreFile))
            {
                string content = File.ReadAllText(HighscoreFile).Trim();
                if (int.TryParse(content, out int score))
                {
                    return score;
                }
            }
            
            return int.MaxValue; // Return the highest possible integer if no score exists yet
        }

        public static void SaveHighscore(int score)
        {
            InitStorage();
            File.WriteAllText(HighscoreFile, score.ToString());
        }
    }
}