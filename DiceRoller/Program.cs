bool runProgram = true;

Console.WriteLine("Welcome to the dice roller!");

while (runProgram == true)
{
    //Get input
    int sides = numberValidator("Enter the number of sides on each die. Must be greater than 0.");
    int numberOfDice = numberValidator("Enter the number of dice. Must be greater than 0.");

    //Roll dice
    List<int> dieResults = rollDie(sides, numberOfDice);
    int total = dieResults.Sum();

    //Print output
    foreach (int roll in dieResults)
    {
        Console.WriteLine(roll);
    }

    Console.WriteLine($"The total is {total}.");

    //Special Cases
    if (sides == 6 && numberOfDice == 2)
    {
        Console.WriteLine(specialCases6(dieResults));
    }
    else if (sides == 20)
    {
        Console.WriteLine(specialCases20(dieResults));
    }

    //Check to see if they want to roll again
    runProgram = checkLoop();

}

// Validates if an input 1) is a number and 2) is greater than zero
static int numberValidator(string prompt)
{
    while (true)
    {
        try
        {
            Console.WriteLine(prompt);
            bool isNumber = int.TryParse(Console.ReadLine(), out int output);
            if (output > 0)
            {
                return output;
                break;
            }
            else
            {
                throw new Exception("That number is out of range. Please enter a number greater than zero.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

//Rolls numDie number of numsides-sided dice
static List<int> rollDie(int numsides, int numDie) 
{
    Random rand = new Random();
    List<int> results = new List<int>();
    for (int i = 0; i < numDie; i++)
    {
        results.Add(rand.Next(numsides)+1);
    }
    return results;
}

//Gives special string output for the case of two six-sided dice
static string specialCases6(List<int> numbers)
{
    string result = "";
    if (numbers.Count(x => x == 1) ==2)
    {
        result += "Snake Eyes\n";
    }
    else if (numbers.Count(x => x == 6) == 2)
    {
        result += "Box Cars\n";
    }
    else if (numbers.Count(x => x == 1) == 1 && numbers.Count(x => x == 2) == 1)
    {
        result += "Ace Deuce\n";
    }

    if(numbers.Sum() == 7 || numbers.Sum() == 11)
    {
        result += "Win\n";
    }
    if (numbers.Sum() == 2 || numbers.Sum() == 3 || numbers.Sum() == 12)
    {
        result += "Craps\n";
    }

    return result;
}

//Gives special string output for the case of 20-sided dice
static string specialCases20(List<int> numbers)
{
    string result = "";
    if (numbers.Contains(20))
    {
        result += "Contains a Nat 20!!!";
    }
    else if (numbers.Contains(1))
    {
        result += "Contains a Nat 1 :(((";
    }
    return result;
}

//Checks to see if a user wants to continue. Output is t/f to continue program loop.
static bool checkLoop()
{
    while (true)
    {
        Console.WriteLine("Do you want to roll again? y/n");
        string input = Console.ReadLine();
        if (input.ToLower().Trim() == "y")
        {
            return true;
            break;
        }
        else if (input.ToLower().Trim() == "n")
        {
            return false;
            break;
        }
        else
        {
            Console.WriteLine("Please enter y or n.");
        }
    }
}
//Test special cases
//List<int> specialtest = new List<int>() { 20 };
//Console.WriteLine(specialCases20(specialtest));