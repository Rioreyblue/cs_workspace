//user input

Console.Write("Enter a first number: ");
int num1 = int.Parse(Console.ReadLine());

Console.Write("Enter an operator: ");
Console.WriteLine("""Please select an operator in the following:
{+}, {-}, {x}, {/}""");
string op = Console.ReadLine().ToLower();

Console.Write("Enter a second number: ");
int num2 = int.Parse(Console.ReadLine());

//all op(operator)
double totalSum = 0;
double totalSub = 0;
double totalMul = 0;
double totalDiv = 0;

//op formula

if(op == "+"){
    totalSum = num1 + num2;
    Console.WriteLine($"The total Sum is: {totalSum}");
}




//function
// private static string OperatorMsg(){
//     return "x";
// }