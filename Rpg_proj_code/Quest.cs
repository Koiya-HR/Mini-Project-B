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
        Console.WriteLine("PRESS ENTER TO CONTINUE");
        Console.ReadLine();
    }

    public Item finish_quest()
    {
        // returns reward
        finished = true;
        Console.WriteLine($"{Name}: Completed!");
        Console.WriteLine($"Obtained a {Reward}");
        return Reward;

    }

    // public bool completed_2_quests()
    // {
    //     int count = 0;
    //     foreach (Quest quest in World.Quests)
    //     {

    //     }
    // }
}
