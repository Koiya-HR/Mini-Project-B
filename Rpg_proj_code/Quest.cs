namespace Rpg_proj;

public class Quest
{
    public string Description;
    public int ID;
    public string Name;

    public Item Reward;

    public bool started = false;
    public bool finished = false;

    public Quest(int id, string name, string description, Item reward)
    {
        Description = description;
        ID = id;
        Name = name;
        Reward = reward;
    }

    public void start_quest()
    {
        started = true;
        Console.WriteLine(Description);
    }

    public Item finish_quest()
    {
        // returns reward
        finished = true;
        Console.WriteLine($"{Name}: Completed!");
        Console.WriteLine($"Obtained a {Reward}");
        return Reward;

    }
}
