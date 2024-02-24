namespace Rpg_proj;

public class Monster
{
    public int ID;
    public string Name;
    public int CurrentHitPoints;
    public int MaximumDamage;
    public int MaximumHitpoints;

    public Monster(int id, string name, int maxdmg, int currenthp, int maxhp)
    {
        ID = id;
        Name = name;
        CurrentHitPoints = currenthp;
        MaximumDamage = maxdmg;
        MaximumHitpoints = maxhp;
    }
}
