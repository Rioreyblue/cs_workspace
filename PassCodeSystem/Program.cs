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
        Console.WriteLine("Enter a code to vaidate: ");
        int input = int.Parse(Console.ReadLine());
        int exact_code = 5932;
        bool eval = flase;

        while(true){
            //logic
            if(input == exact_code){
                eval = true;
                return eval;
            }else{
                Console.WriteLine("incorrect code. ");
            }

            //error validation
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INvalid. Please enter only interger as code.")
            Console.ResetColor();
        }
    }

    // function logic
    private static void getcodeDisplay() { }
}
