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
                        Monster currentMonster = player1.CurrentLocation.MonsterLivingHere;
                        if (currentMonster == null)
                        {
                            Console.WriteLine("there are no monsters living here");
                        }
                        else
                        {
                            while (player1.CurrentHitPoints > 0 && currentMonster.CurrentHitPoints > 0)
                            {
                                Console.WriteLine($"you enter a fight with a {currentMonster}!\npress anything to continue");
                                Console.ReadLine();
                                int damageToMonster = World.RandomGenerator.Next(player1.CurrentWeapon.MaximumDamage) + player1.Level;
                                currentMonster.CurrentHitPoints -= damageToMonster;
                                Console.WriteLine($"You hit the {currentMonster.Name} for {damageToMonster} damage.");

                                if (currentMonster.CurrentHitPoints <= 0)
                                {
                                    Console.WriteLine($"You defeated the {currentMonster.Name}");
                                    break;
                                }

                                int damageToPlayer = World.RandomGenerator.Next(currentMonster.MaximumDamage);
                                player1.CurrentHitPoints -= damageToPlayer;
                                Console.WriteLine($"The {currentMonster.Name} hits you for {damageToPlayer} damage.");
                                if (player1.CurrentHitPoints <= 0)
                                {
                                    Console.WriteLine($"You were defeated by the {currentMonster}");
                                    Console.WriteLine("you respawn at home");
                                    player1.CurrentHitPoints = player1.MaximumHitPoints;
                                    player1.CurrentLocation = World.Locations[0];
                                    break;
                                }

                            }
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
