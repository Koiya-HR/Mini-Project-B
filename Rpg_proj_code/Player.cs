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
    public int MonstersKilled = 0;
    public int QuestsCompleted = 0;

    public List<Item> Inventory
    {
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

    public void Move(string direction)
    {
        if (direction == "N" && CurrentLocation.LocationToNorth != null)
        {
            CurrentLocation = CurrentLocation.LocationToNorth;
        }
        else if (direction == "E" && CurrentLocation.LocationToEast != null)
        {
            CurrentLocation = CurrentLocation.LocationToEast;
        }
        else if (direction == "S" && CurrentLocation.LocationToSouth != null)
        {
            CurrentLocation = CurrentLocation.LocationToSouth;
        }
        else if (direction == "W" && CurrentLocation.LocationToWest != null)
        {
            CurrentLocation = CurrentLocation.LocationToWest;
        }
    }
}