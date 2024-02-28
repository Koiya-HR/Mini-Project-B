using System.Runtime.InteropServices.Marshalling;

namespace Rpg_proj;

public class Program
{
    static bool stillPlaying = true;
    static void Main()
    {
        Console.WriteLine("Welcome adventurer, what is your name?\n");
        string PlayerName = Console.ReadLine() ?? "Hero";

        Player player1 = new(75, World.Locations[0], World.Weapons[0], 75, PlayerName);

        while (stillPlaying)
        {
            Console.WriteLine("What would you like to do (enter a number)?\n1: See game stats\n2: Move\n3: Fight\n4: Inventory\n5: Quit");

            if (player1.CurrentLocation == World.LocationByID(1))
            {
                Console.WriteLine("5: Visit the Town Square shop");
            }

            string choice = Console.ReadLine() ?? "Invalid";

            if (choice == "5" && player1.CurrentLocation == World.LocationByID(1))
            {
                Shop.shop(player1);
            }

            switch (choice)
            {
                case "1":
                    {
                        Console.WriteLine($"Current location: {player1.CurrentLocation.Name}\nCurrent weapon: {player1.CurrentWeapon.Name}\n\n"
                        + $"Current HP: {player1.CurrentHitPoints}\nMonsters killed: {player1.MonstersKilled}\n\n"
                        + $"Current level: {player1.Level}\nExperience: [{player1.currentExperience}/{player1.experienceThreshold}]\n\n"
                        + $"Quests completed: {player1.QuestsCompleted}\nCurrent gold: {player1.Gold}");

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    }
                case "2":
                    {
                        Move.move(player1);
                        break;
                    }
                case "3":
                    {
                        Battle.battle(player1);
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("Viewing inventory...");
                        player1.ViewInventory();
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("Quitting game...");
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid command");
                        break;
                    }
            };

            if (player1.winGame())
            {
                Console.WriteLine("You completed the adventure and saved the Town!");
                stillPlaying = false;
            }
        }
    }
}
