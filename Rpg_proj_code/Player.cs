using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace Rpg_proj;


public class Player
{
    public int CurrentHitPoints;
    public int currentExperience = 0;
    public int Level = 1;
    public Location CurrentLocation;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;
    public int MonstersKilled = 0;
    public int QuestsCompleted = 0;
    public int Gold = 10;
    public int experienceThreshold = 50;

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

        bool moved = false;
        if (direction == "N" && CurrentLocation.LocationToNorth != null)
        {
            CurrentLocation = CurrentLocation.LocationToNorth;
            moved = true;
        }
        else if (direction == "E" && CurrentLocation.LocationToEast != null)
        {
            CurrentLocation = CurrentLocation.LocationToEast;
            moved = true;
        }
        else if (direction == "S" && CurrentLocation.LocationToSouth != null)
        {
            CurrentLocation = CurrentLocation.LocationToSouth;
            moved = true;
        }
        else if (direction == "W" && CurrentLocation.LocationToWest != null)
        {
            CurrentLocation = CurrentLocation.LocationToWest;
            moved = true;
        }

        if (moved == true)
        {
            if (CurrentLocation.QuestAvailableHere != null)
            {
                if (CurrentLocation.QuestAvailableHere.started == false)
                    CurrentLocation.QuestAvailableHere.start_quest();
            }
        }
    }

    public bool winGame()
    {
        if (QuestsCompleted == World.Quests.Count())
        {
            Console.WriteLine("You've completed all the quests and saved the village.\nGood job adventurer!");
            return true;
        }
        return false;
    }

    public void gainEXP()
    {
        int expToGain = World.RandomGenerator.Next(15, 25);
        currentExperience += expToGain;

        Console.WriteLine($"You've gained {expToGain} experience!");
    }

    public void checkLevelUp()
    {
        if (currentExperience >= experienceThreshold)
        {
            Level += 1;
            currentExperience -= experienceThreshold;
            Console.WriteLine($"You leveled up to level {Level}");

            experienceThreshold = Convert.ToInt32(5 * Math.Pow(Level, 2) + (50 * Level) + 100 - currentExperience);
            LevelUpStats();
            Console.WriteLine($"New max health: [{CurrentHitPoints}/{MaximumHitPoints}]");
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }
    }

    public void LevelUpStats()
    {
            MaximumHitPoints += Convert.ToInt32(MaximumHitPoints/10);
            CurrentHitPoints = MaximumHitPoints;
            Gold += 50;
    }
}