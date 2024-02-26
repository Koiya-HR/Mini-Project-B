namespace Rpg_proj;

public class Program
{
    public static Main()
    {
        Console.WriteLine("Welcome adventurer, what is your name?\n");
        string PlayerName = Console.ReadLine() ?? "Hero";

        Player player1 = new(10, World.Locations[0], World.Weapons[0], 10, PlayerName);
        int MonstersKilled = 0;
        int QuestsCompleted = 0;


        while (true)
        {
            Console.WriteLine("What would you like to do (enter a number)?\n1: see game stats\n2: Move\n3: Fight\n4: Quit");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine($@"current location: {player1.CurrentLocation}\ncurrent weapon: {player1.CurrentWeapon}
                    monsters killed: {MonstersKilled}\nquests completed: {QuestsCompleted}");
                    }
                case "2":
                    {

                    }
            };

        }



    }
}
