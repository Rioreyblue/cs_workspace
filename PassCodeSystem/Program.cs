using System;

class Program
{
    //main getter
    static void Main()
    {
        string input_name = getValidInteger();

        bool input_code = getValidCode();

        getcodeDisplay(input_name, input_code);
    }

    //function input
    private static string getValidString(int input) {
        //for declaration
        string valid_input = "";

        wgile(true){
            Console.WriteLine(input);
        input = int.Parse(Console.ReadLine());

        if(input.ToLower() == "exit"){
            break;
        }
        if(input.tryParse(input, out valid_input)){
            break;
        }
        //invalid reasoning
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Please enter letter for name");
        Console.ResetColor();
        }
        return valid_input;
     }

    private static int getValidCode(){
        int exact_code = 5932;
        int val_input = 0 ;

        while(true){
            //logic for incorrect input
        Console.WriteLine("Enter a code to vaidate: ");
        string input = Console.ReadLine();
        
            if(!int.TryParse(input, out val_input)){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid. Please enter only integers as code.");
                Console.ResetColor();
                continue;
            }

            //logic for correct code
            if(val_input == exact_code)
            {
                return val_input;
            }
            else
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("incorrect code. ");
            Console.ResetColor();
            }
        }
    }

    // function logic
    private static void getcodeDisplay() { }
}
