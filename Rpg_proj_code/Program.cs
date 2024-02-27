using System.Runtime.InteropServices.Marshalling;

namespace Rpg_proj;

public class Program
{
    static bool stillPlaying = true;
    static void Main()
    {
        Console.WriteLine("Welcome adventurer, what is your name?\n");
        string PlayerName = Console.ReadLine() ?? "Hero";

        Player player1 = new(100, World.Locations[0], World.Weapons[0], 100, PlayerName);

        while (stillPlaying)
        {
            Console.WriteLine("What would you like to do (enter a number)?\n1: see game stats\n2: Move\n3: Fight\n4: Quit");
            if (player1.CurrentLocation == World.LocationByID(1))
            {
                Console.WriteLine("5: visit the Town Square shop");
            }
            string choice = Console.ReadLine() ?? "invalid";
            if (choice == "5" && player1.CurrentLocation == World.LocationByID(1))
            {
                Shop.shop(player1);
            }
            switch (choice)
            {
                case "1":
                    {
                        Console.WriteLine($"current location: {player1.CurrentLocation.Name}\ncurrent weapon: {player1.CurrentWeapon.Name}\n\n"
                        + $"current hp: {player1.CurrentHitPoints}\nmonsters killed: {player1.MonstersKilled}\n\n"
                        + $"current level: {player1.Level}\nexperience: [{player1.currentExperience}/{player1.experienceThreshold}]\n\n"
                        + $"quests completed: {player1.QuestsCompleted}\ncurrent gold: {player1.Gold}");
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
            if (player1.winGame())
            {
                Console.WriteLine("you completed the adventure and saved the Town!");
                stillPlaying = false;
            }
        }
    }
}
