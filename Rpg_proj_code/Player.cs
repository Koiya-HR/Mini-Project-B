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


public class Player
{
    public int CurrentHitPoints;
    public Location CurrentLocation;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;
    public int Level = 1;

    public List<Item> Inventory {
        get;
        set;
    }

    public Player(int currenthp, Location location, Weapon weapon, int maxhp, string name)
    {
        CurrentHitPoints = currenthp;
        CurrentLocation = location;
        CurrentWeapon = weapon;
        MaximumHitPoints = maxhp;
        Name = name;
        Inventory = new List<Item>();
    }

    public void AddItemToInventory(Item item)
    {
        Inventory.Add(item);
    }

    public void Regenerate(int PotionValue)
    {
        CurrentHitPoints += PotionValue;
        CurrentHitPoints = Math.Min(CurrentHitPoints, MaximumHitPoints);
    }

    public void EquipWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
    }
}