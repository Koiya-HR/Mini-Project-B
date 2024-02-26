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

    public int Restores_amount;

    public string Description;

    public Item(int id, string name, int restores_amount, string description)
    {
        ID = id;
        Name = name;
        Restores_amount = restores_amount;
        Description = description;

    }
}
