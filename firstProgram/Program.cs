
/*
Console.WriteLine("Hello, I'm gonna show you some data types: \n");

string[] types = {"String", "Char", "Int", "Decimal", "Bool"};

for (int i = 1; i <= types.Length; i++)
{
    Console.WriteLine($"{i} - { types[i - 1]}");
}
*/



/*
******************************* main program *******************************
*/

using System.Xml.Linq;

// 1. Get user's name
string userName = getName();

// Statistics
List<string> statistics = new List<string>();

// 2. Go to Menu and start the game
openMenu(userName);


/*
 ******************************* methods *******************************
*/

string getName()
{
    Console.WriteLine("Please, type your name");
    userName = basicValidation();

    Console.Clear();
    Console.WriteLine($"Hi {userName}, are you ready to play a Math game? Type any key to continue");
    Console.ReadLine();

    return userName;
}

string basicValidation()
{
    string input = Console.ReadLine().Trim();

    while (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Invalid input, please try again...");
        input = Console.ReadLine().Trim();
    }

    return input.ToLower();
}

void openMenu(string userName)
{
    bool isGameActive = true;

    // Start the Game
    do
    {
        // User Interface
        Console.Clear();
        Console.WriteLine("Menu, please enter a letter to choose an action:");
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine("\n A - Addition \n M - Multiplication \n S - Subtraction \n D - Division \n Q - Quit the Game \n V - View Statistics");
        Console.WriteLine("---------------------------------------------------------------------------");

        string action = basicValidation();

        // general input validation
        while (action != "a" && action != "m" && action != "s" && action != "d" && action != "q" && action != "v")
        {
            Console.WriteLine($"Dear {userName}, '{action}' is not valid, please try again...");
            action = basicValidation();
        }

        // List Menu Actions 
        switch (action)
        {
            case "q":
                isGameActive = false;
                break;

            case "v":
                viewStatistics(userName);
                break;

            default:
                game(action, userName);
                break;
        }
    }
    while (isGameActive);

    // End of the game
    quitGame(userName);
}

void game(string typeOfGame, string userName)
{
    int operations = 5;
    int score = 0;
    Random rndNum = new Random();
    int num1 = 0;
    int num2 = 0;
    int res = 0;

    for (int i = 0; i < operations; i++)
    {
        // 1. set numbers and results
        Console.Clear();    

        switch (typeOfGame)
        {
            case "a":
                num1 = rndNum.Next(10, 100);
                num2 = rndNum.Next(10, 100);
                res = num1 + num2;
                Console.WriteLine("Addition Game");
                Console.WriteLine($"\n{i+1}. {num1} + {num2} = ?");
                break;

            case "m":
                num1 = rndNum.Next(10, 20);
                num2 = rndNum.Next(5, 12);
                res = num1 * num2;
                Console.WriteLine("Multiplication Game");
                Console.WriteLine($"\n{i + 1}. {num1} * {num2} = ?");  
                break;

            case "s":
                num1 = rndNum.Next(35, 100);
                num2 = rndNum.Next(10, 30);
                res = num1 - num2;
                Console.WriteLine("Subtraction Game");
                Console.WriteLine($"\n{i + 1}. {num1} - {num2} = ?");
                break;

            case "d":
                do
                {
                    num1 = rndNum.Next(20, 100);
                    num2 = rndNum.Next(1, 10);
                }
                while (num1 % num2 != 0); 
                
                res = num1 / num2;
                Console.WriteLine("Division Game");
                Console.WriteLine($"\n{i + 1}. {num1} / {num2} = ?");
                break;
        }

        // 2.show the operation and get result from user
        string stringUserRes = Console.ReadLine();
        int intUserRes;

        // Inserire un ciclo while per il controllo del dato
        while (string.IsNullOrWhiteSpace(stringUserRes) || !Int32.TryParse(stringUserRes, out intUserRes))
        {
            Console.WriteLine("Invalid input, please try again...");
            stringUserRes = Console.ReadLine();
        }
        intUserRes = Int32.Parse(stringUserRes);


        // 4. compare result and update the score
        if (intUserRes == res)
        {
            Console.WriteLine("Your answer was correct! Type any key to continue");
            Console.ReadLine();
            score++;
        }
        else
        {
            Console.WriteLine("I'm sorry, your answer was not correct. Type any key to continue");
            Console.ReadLine();
        }
    }

    // Updating statistics
    statistics.Add($"Player: {userName} | Time: {DateTime.Now} | Game: {typeOfGame} | Score: {score} out of {operations}");

    // Showing final score
    Console.WriteLine($"\nYour final score is {score} out of {operations}");
    Console.WriteLine("Type any key to back to menu");
    Console.ReadLine();
}

void quitGame(string userName)
{
    Console.Clear();
    Console.WriteLine($"Bye {userName}, see you next time");
}

void viewStatistics(string userName)
{
    Console.Clear();
    Console.WriteLine($"Statistics");
    Console.WriteLine("---------------------------------------------------------------------------");
    
    if (statistics.Count < 1)
    {
        Console.WriteLine("There are no statistics yet.");
    }
    else
    {
        foreach (var record in statistics)
        {
            Console.WriteLine(record);
        }
    }
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("Type any key to back to Menu");
    Console.ReadLine();
}