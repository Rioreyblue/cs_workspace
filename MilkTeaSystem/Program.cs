//         Console.WriteLine("===================================");
//         Console.WriteLine("Welcome to milktea selection");
//         Console.WriteLine("===================================");

//         Console.WriteLine("Select your Milktea");
//         Console.WriteLine("""A) Classic Pearl Milk Tea The OG. 
//                          Rich black tea blended with creamy milk and t
//                          opped with chewy brown sugar tapioca pearls.""")

//         Console.WriteLine("""B) Brown Sugar Deerskin / Tiger Milk Tea
// A caffeine-free or low-caffeine favorite. Fresh milk marbled with rich, smoky brown sugar syrup slow-cooked onto the sides of the cup, paired with pearls.""");
//         Console.WriteLine("""C) Taro Milk Tea with Pudding
// A sweet, creamy, and distinctively purple milk tea with a subtle nutty, vanilla-like flavor, paired with silky egg pudding.""");
//         Console.WriteLine("""D) Jasmine Green Milk Tea with Aloe Vera or Jelly
// A much lighter, highly aromatic, and refreshing floral green tea base blended with milk and paired with clean, refreshing toppings.""");


Console.WriteLine("===================================");
        Console.Write("Enter your choice (A-D): ");
        string choice = Console.ReadLine()?.ToUpper() ?? "";

        Console.WriteLine("===================================");

        string selectedMilktea = "";

        switch (choice)
        {
            case "A":
                selectedMilktea = "Classic Pearl Milk Tea";
                break;
            case "B":
                selectedMilktea = "Brown Sugar Deerskin / Tiger Milk Tea";
                break;
            case "C":
                selectedMilktea = "Taro Milk Tea with Pudding";
                break;
            case "D":
                selectedMilktea = "Jasmine Green Milk Tea with Aloe Vera or Jelly";
                break;
            default:
                Console.WriteLine("Invalid selection. Please restart and choose a valid option (A, B, C, or D).");
                return; // Exits the program if the choice is invalid
        }

        Console.WriteLine($"You selected: {selectedMilktea}");
        Console.WriteLine("===================================");

        // Next steps could go here (e.g., Size selection, Sugar level, Ice level)