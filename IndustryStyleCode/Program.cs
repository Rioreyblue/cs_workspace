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
        string op = getValidOperator();

        //safe number input for 2
        int input_2 = getValidInteger("Enter a second number: ");

        calculateAndDisplay(input_1, op, input_2);
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
    private static string getValidOperator()
    {
        Console.WriteLine("\nPlease select an operator [+], [-], [*], [/]. ");
        string input = Console.ReadLine()?.Trim().ToLower();

        while (true)
        {
            if (input == "+" || input == "-" || input == "*" || input == "/")
            {
                return input;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Please select a valid operation");
            Console.ResetColor();
        }
    }

    //function for display and calculation
    private static void calculateAndDisplay(int input_1, string op, int input_2)
    {
        double result = 0;
        string operationName = "";

        if (op == "+")
        {
            result = input_1 + input_2;
            operationName = "Addition";
        }
        else if (op == "-")
        {
            result = input_1 - input_2;
            operationName = "Subtraction";
        }
        else if (op == "*")
        {
            result = input_1 * input_2;
            operationName = "Multiplication";
        }
        else if (op == "/")
        {
            if (input_2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Division by zero is undefined.");
                Console.ResetColor();
                return;
            }

            result = (double)input_1 / input_2;
            operationName = "Division";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid Input!");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"The total {operationName} is : {result}");
        Console.ResetColor();
    }
}
