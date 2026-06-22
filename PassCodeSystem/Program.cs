using System;

class Program
{
    //main getter
    static void Main()
    {
        string input_name = getValidInteger();

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
            Console.WriteLine(Enter your name: );
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }
            if (input.tryParse(input, out valid_input))
            {
                break;
            }
            else
            {
                //invalid reasoning
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter letter for name");
                Console.ResetColor();
            }
        }
        return valid_input;
    }

    private static int getValidCode()
    {
        int val_input = 0;

        while (true)
        {
            //logic for incorrect input
            Console.WriteLine("Enter a code to vaidate: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out val_input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid. Please enter only integers as code.");
                Console.ResetColor();
                continue;
            }
            else
            {
                // Console.ForegroundColor = ConsoleColor.Red;
                // Console.WriteLine("incorrect code. ");
                // Console.ResetColor();
                break;
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
