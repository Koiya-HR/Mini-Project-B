namespace Rpg_proj;

public class Quest
{
    public string Description;
    public int ID;
    public string Name;

    public Item Reward;

    public Quest(int id, string name, string description, Item reward)
    {
        Description = description;
        ID = id;
        Name = name;
        Reward = reward;
    }
}
