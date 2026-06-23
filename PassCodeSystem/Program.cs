using System;

class Program
{
    //main getter
    static void Main()
    {
        string input_name = getValidString();

        int input_code = getValidCode();

        getcodeDisplay(input_name, input_code);
    }

    //function input
    private static string getValidString()
    {
        //for declaration
        string valid_input = "";

        while (true)
        {
            Console.WriteLine("Enter your name: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }
            if (input.tryParse(input, out _))
            {
                //invalid reasoning
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter letter for name");
                Console.ResetColor();
            }
            else
            {
                valid_input = input;
                break;
            }
        }
        return valid_input;
    }

    private static int getValidCode()
    {
        int exact_code = 5932; // Kept your key variable alive here
        int val_input = 0;

        while (true)
        {
            Console.WriteLine("Enter a code to validate: ");
            string input = Console.ReadLine();

            // 1. Checks if it's a valid integer format
            if (!int.TryParse(input, out val_input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid. Please enter only integers as code.");
                Console.ResetColor();
                continue;
            }

            // 2. Checks if the integer is the CORRECT code
            if (val_input == exact_code)
            {
                break; // Code matches! Break out of the loop and return it
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect code. Please try again.");
                Console.ResetColor();
            }
        }
        return val_input;
    }

    // function logic
    private static void getcodeDisplay(string name, int code)
    {
        int exact_code = 5932;
        //logic for correct code
        if (code == exact_code)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Hello{name}your Code verificastion Success!.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid Code dear{name}. Please try again.");
            Console.ResetColor();
        }
    }
}
