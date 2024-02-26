namespace Rpg_proj;

public static class Move
{
public static void move(Player player1)
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
                break;
            }
        }
    }
}
