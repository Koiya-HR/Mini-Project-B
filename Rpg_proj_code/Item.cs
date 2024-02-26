namespace Rpg_proj;

public class Item
{
    public int ID
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public Item(int id, string name)
    {
        ID = id;
        Name = name;
    }
}
