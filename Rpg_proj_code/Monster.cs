namespace Rpg_proj;

public class Monster
{
    public int ID;
    public string Name;
    public int CurrentHitPoints;
    public int MaximumDamage;
    public int MaximumHitpoints;

    public int gold_dropped_min;
    public int gold_dropped_max;

    public Monster(int id, string name, int maxdmg, int currenthp, int maxhp, int min_gold, int max_gold)
    {
        ID = id;
        Name = name;
        CurrentHitPoints = currenthp;
        MaximumDamage = maxdmg;
        MaximumHitpoints = maxhp;
        gold_dropped_min = min_gold;
        gold_dropped_max = max_gold;
    }
}
