namespace Rpg_proj;

public class Quest
{
    public string Description;
    public int ID;
    public string Name;

    public Item Reward;

    public int monstes_left = 3;

    public Location Destination;

    public bool started = false;
    public bool finished = false;

    public Quest(int id, string name, string description, Item reward, Location destination)
    {
        Description = description;
        ID = id;
        Name = name;
        Reward = reward;
        Destination = destination;
    }

    public void start_quest()
    {
        started = true;
        Console.WriteLine("---- QUEST ACCEPTED ----");
        Console.WriteLine(Description);
        Console.WriteLine("press anything to continue");
        Console.ReadLine();
    }

    public void finish_quest(Player player)
    {
        // returns reward
        finished = true;
        Console.WriteLine($"{Name}: Completed!");
        Console.WriteLine($"Obtained a {Reward.Name}");
        Console.WriteLine("Press anything to continue...");
        Console.ReadLine();

        player.QuestsCompleted += 1;


        // add reward to players inventory

        if (player.QuestsCompleted == 2)
        {
            Console.WriteLine("You have completed 2 Quests, you can now cross the bridge to the east!");
            Console.WriteLine("Press anything to continue...");
            Console.ReadLine();

        }
    }
}
