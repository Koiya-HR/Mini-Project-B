namespace Rpg_proj;

public class Quest
{
    public string Description;
    public int ID;
    public string Name;

    public Quest(int id, string name, string description)
    {
        Description = description;
        ID = id;
        Name = name;
    }
}
