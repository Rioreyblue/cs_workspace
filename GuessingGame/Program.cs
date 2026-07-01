using GuessingGame.Src;

while (true)
{
    GameLogic.PlayGame();

    Console.Write("\nDo you want to play again? (y/n): ");
    string playAgain = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;

    if (playAgain != "y")
    {
        Console.WriteLine("Thanks for playing! Goodbye.");
        break;
    }
}