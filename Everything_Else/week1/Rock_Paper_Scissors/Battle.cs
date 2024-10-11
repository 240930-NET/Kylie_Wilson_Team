class Battle
{
    // Start the game
    public static void Directions()
    {
        Console.WriteLine("Would you like to play?");

        Console.WriteLine("Rock");
        Console.WriteLine("Paper");
        Console.WriteLine("Scissors");
    }
    public static string Input()
    {
        while (true)
        {
            Console.WriteLine("Pick a weapon");
            string UserAnswer = Console.ReadLine();
            //    Switch statement syntax is similar to if statements. 
            switch (UserAnswer)
            {
                case "paper": return "paper";
                case "rock": return "rock";
                case "scissors": return "scissors";
                // Got from w3schools. https://www.w3schools.com/c/ref_keyword_default.php#:~:text=Definition%20and%20Usage,does%20not%20need%20a%20break.
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    public static string Computer()
    {
        string[] ComputerAnswer = {
            "Paper",
            "Rock",
            "Scissors"
        };

        // Create a new instance of the Random class
        Random randint = new Random();
        int random = randint.Next(ComputerAnswer.Length);

        return ComputerAnswer[random];
    }

    public static void Rules(string user_choice, string Computer)
    {
        if (user_choice == Computer)
        {
            Console.WriteLine("It is a tie.");
        }
        else if (user_choice == "scissors" && Computer == "paper")
        {
            Console.WriteLine("You won!");
        }
        else if (user_choice == "paper" && Computer == "rock")
        {
            Console.WriteLine("You won!");
        }
        else if (user_choice == "rock" && Computer == "scissors")
        {
            Console.WriteLine("You won!");
        }
        else
        {
            Console.WriteLine("The computer won!");}
    }
    }