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
        int valid_input;
        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine().ToLower(), out valid_input))
        {
            if(valid_input == "exit")
            break;
            Console.ForegroundColor = ConsoleColor.Red;
            //restriction
            Console.WriteLine("Invalid input, only put numbers only!);
            Console.ResetColor();
            Console.Write(prompt);
        }
        return valid_input;
    }
}
