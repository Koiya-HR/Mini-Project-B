namespace Rpg_proj;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome adventurer, what is your name?\n");
        string PlayerName = Console.ReadLine() ?? "Hero";

        Player player1 = new(10, World.Locations[0], World.Weapons[0], 10, PlayerName);

        while (true)
        {

            Console.WriteLine("What would you like to do (enter a number)?\n1: see game stats\n2: Move\n3: Fight\n4: Quit");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine($"current location: {player1.CurrentLocation.Name}\ncurrent weapon: {player1.CurrentWeapon.Name}\nmonsters killed: {player1.MonstersKilled}\nquests completed: {player1.QuestsCompleted}");
                        break;
                    }
                case "2":
                    {
                        string compass = "From here you can go:\n";
                        if (player1.CurrentLocation.LocationToNorth != null)
                        {
                            compass += "    N\n    |\n";
                        }
                        if (player1.CurrentLocation.LocationToWest != null)
                        {
                            compass += "W---|";
                        }
                        else
                        {
                            compass += "    |";
                        }
                        if (player1.CurrentLocation.LocationToEast != null)
                        {
                            compass += "---E";
                        }
                        compass += "\n";
                        if (player1.CurrentLocation.LocationToSouth != null)
                        {
                            compass += "    |\n    S\n";
                        }

                        Console.WriteLine($"you are at: {player1.CurrentLocation.Name}");
                        Console.WriteLine(compass);
                        while (true)
                        {
                            string input = Console.ReadLine() ?? "invalid";

                            if (input.ToUpper() == "N" || input.ToUpper() == "E" || input.ToUpper() == "W" || input.ToUpper() == "S")
                            {
                                player1.Move(input.ToUpper());
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid direction. Please enter N, E, W, or S.");
                            }
                        }
                        break;
                    }
                case "3":
                    {
                        if (player1.CurrentLocation.MonsterLivingHere == null)
                        {
                            Console.WriteLine("there are no monsters living here");
                        }
                        else
                        {
                            // hier battle system maken
                            ;
                        }
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("Quitting game...");
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("invalid command");
                        break;
                    }
            };
        }
    }
}
