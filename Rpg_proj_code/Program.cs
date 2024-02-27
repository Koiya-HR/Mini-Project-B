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
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine($"current location: {player1.CurrentLocation.Name}\ncurrent weapon: {player1.CurrentWeapon.Name}\ncurrent hp: {player1.CurrentHitPoints}\nmonsters killed: {player1.MonstersKilled}\nquests completed: {player1.QuestsCompleted}"
                        +$"\ncurrent gold {player1.Gold}");
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
                stillPlaying = false;
            }
        }
    }
}
