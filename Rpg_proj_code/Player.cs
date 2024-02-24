namespace Rpg_proj;

public class Player
{
    public int CurrentHitPoints;
    public Location CurrentLocation;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;

    public Player(int currenthp, Location location, Weapon weapon, int maxhp, string name)
    {
        CurrentHitPoints = currenthp;
        CurrentLocation = location;
        CurrentWeapon = weapon;
        MaximumHitPoints = maxhp;
        Name = name;
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
