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
        Console.WriteLine("Welcome to milktea selection");
        Console.WriteLine("===================================");

        Console.WriteLine("Select your Milktea");
        Console.WriteLine("""
                          A) Classic Pearl Milk Tea The OG. 
                             Rich black tea blended with creamy milk and 
                             topped with chewy brown sugar tapioca pearls.
                          """);
        Console.WriteLine("""
                          B) Brown Sugar Deerskin / Tiger Milk Tea
                             A caffeine-free or low-caffeine favorite. Fresh milk marbled with rich, 
                             smoky brown sugar syrup slow-cooked onto the sides of the cup, paired with pearls.
                          """);
        Console.WriteLine("""
                          C) Taro Milk Tea with Pudding
                             A sweet, creamy, and distinctively purple milk tea with a subtle nutty, 
                             vanilla-like flavor, paired with silky egg pudding.
                          """);
        Console.WriteLine("""
                          D) Jasmine Green Milk Tea with Aloe Vera or Jelly
                             A much lighter, highly aromatic, and refreshing floral green tea base 
                             blended with milk and paired with clean, refreshing toppings.
                          """);

        Console.WriteLine("===================================");
        Console.Write("Enter your choice (A-D): ");
        string choice = Console.ReadLine()?.ToUpper() ?? "";
        Console.WriteLine("===================================");

        string selectedMilktea = "";
        double basePrice = 0.0;

        // 1. Process Drink Selection & Base Price
        switch (choice)
        {
            case "A":
                selectedMilktea = "Classic Pearl Milk Tea";
                basePrice = 5.00;
                break;
            case "B":
                selectedMilktea = "Brown Sugar Tiger Milk Tea";
                basePrice = 5.50;
                break;
            case "C":
                selectedMilktea = "Taro Milk Tea with Pudding";
                basePrice = 5.75;
                break;
            case "D":
                selectedMilktea = "Jasmine Green Milk Tea";
                basePrice = 5.25;
                break;
            default:
                Console.WriteLine("Invalid selection. Please restart the application.");
                return;
        }

        // 2. Size Customization
        Console.WriteLine("Select Size:");
        Console.WriteLine("1) Regular (Base Price)");
        Console.WriteLine("2) Large (+$1.00)");
        Console.Write("Enter choice (1-2): ");
        string sizeChoice = Console.ReadLine() ?? "";
        
        string selectedSize = "Regular";
        double sizeUpscale = 0.0;

        if (sizeChoice == "2")
        {
            selectedSize = "Large";
            sizeUpscale = 1.00;
        }
        Console.WriteLine("===================================");

        // 3. Sugar Level Customization
        Console.WriteLine("Select Sugar Level:");
        Console.WriteLine("1) 0% (No Sugar)\n2) 30% (Less Sweet)\n3) 50% (Half Sweet)\n4) 100% (Normal Sweet)");
        Console.Write("Enter choice (1-4): ");
        string sugarChoice = Console.ReadLine() ?? "";
        
        string selectedSugar = sugarChoice switch
        {
            "1" => "0%",
            "2" => "30%",
            "3" => "50%",
            _ => "100%" // Defaults to normal sweetness if input is empty or invalid
        };
        Console.WriteLine("===================================");

        // 4. Ice Level Customization
        Console.WriteLine("Select Ice Level:");
        Console.WriteLine("1) No Ice\n2) Easy Ice (70%)\n3) Regular Ice (100%)");
        Console.Write("Enter choice (1-3): ");
        string iceChoice = Console.ReadLine() ?? "";

        string selectedIce = iceChoice switch
        {
            "1" => "No Ice",
            "2" => "Easy Ice",
            _ => "Regular Ice"
        };
        Console.WriteLine("===================================");

        // 5. Final Calculation and Receipt
        double totalPrice = basePrice + sizeUpscale;

        Console.WriteLine("         ORDER SUMMARY             ");
        Console.WriteLine("===================================");
        Console.WriteLine($"Item:  {selectedMilktea}");
        Console.WriteLine($"Size:  {selectedSize}");
        Console.WriteLine($"Sugar: {selectedSugar}");
        Console.WriteLine($"Ice:   {selectedIce}");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Total Price: ${totalPrice:F2}");
        Console.WriteLine("===================================");
        Console.WriteLine("      Thank you for ordering!      ");

        