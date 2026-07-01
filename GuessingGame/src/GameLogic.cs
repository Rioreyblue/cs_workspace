using System;

namespace GuessingGame.Src
{
    public static class GameLogic
    {
        public static void PlayGame()
        {
            Console.WriteLine("\n✨ Welcome to the High-Low Guessing Game! ✨");

            // 1. The Random Class
            Random random = new Random();
            int secretNumber = random.Next(1, 101); // Generates a number between 1 and 100
            int guessCount = 0;

            int currentRecord = Storage.GetCurrentHighscore();

            if (currentRecord != int.MaxValue)
            {
                Console.WriteLine($"The current all-time record is: {currentRecord} guesses. Can you beat it?");
            }
            else
            {
                Console.WriteLine("No high score recorded yet. Set the first one!");
            }

            // 2. The Main Game Loop
            while (true)
            {
                Console.Write("Enter your guess (1-100): ");
                string userInput = Console.ReadLine()?.Trim() ?? string.Empty;

                // 3. Input Validation (Using TryParse to prevent 'banana' from crashing the app)
                if (!int.TryParse(userInput, out int guess))
                {
                    Console.WriteLine("❌ Input Error: Please enter a valid whole number.");
                    continue; // Restarts loop without adding to guessCount
                }

                guessCount++;

                // 4. Conditional Statements
                if (guess < secretNumber)
                {
                    Console.WriteLine("📈 Too low!");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("📉 Too high!");
                }
                else
                {
                    Console.WriteLine($"🎉 Correct! You found it in {guessCount} guesses!");
                    break;
                }
            }

            // 5. Level-Up: High Score Logic
            if (guessCount < currentRecord)
            {
                Console.WriteLine($"🏆 New High Score! You beat the old record of {currentRecord}!");
                Storage.SaveHighscore(guessCount);
            }
            else
            {
                Console.WriteLine($"Good effort! The record stands at {currentRecord} guesses.");
            }
        }
    }
}