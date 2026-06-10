//function for main
//geter function
static void Main(){
    //safe number input for 1
    int input_1 = getValidInteger("Enter a first number: ");

    //safe operator input
    // string op = getValidOperator();

    //safe number input for 2
    int input_2 = getValidInteger("Enter a first number: ");
}

//input function
private static int getValidInteger(string prompt){
    int valid_input;
    Console.Write(prompt);

    Console.WriteLine(" Enter a first number: ")
    if(!int.TryParse(Console.Readline(), out valid_input)){
        Console.WriteLine("Invalid input, only put numbers: ");
        Console.Write(prompt);
    }
    return valid_input;
}