 //global variables
        int new_user_input;
        
        //user input
        Console.WriteLine("Enter integer input: ");
        string user_input = Console.ReadLine();
        
        //condition
        if(!int.TryParse(user_input, out new_user_input)){
            Console.WriteLine("Invalid input! Please select only Integer input.");
        }else{
            Console.WriteLine($"Exellent choice: {new_user_input}");
        }