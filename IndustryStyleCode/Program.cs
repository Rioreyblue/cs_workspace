using System;

class Program
{
    //function for main
    //geter function
    static void Main()
    {
        //safe number input for 1
        int input_1 = getValidInteger("Enter a first number: ");

        //safe operator input
        // string op = getValidOperator();

        //safe number input for 2
        int input_2 = getValidInteger("Enter a second number: ");
    }

    //input function
    private static int getValidInteger(string prompt)
    {
        int valid_input = 0;

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (int.TryParse(input, out valid_input))
            {
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input!");
            Console.ResetColor();
        }

        return valid_input;
    }

    //function for operation
}
