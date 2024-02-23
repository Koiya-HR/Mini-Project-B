using Rpg_proj;

public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
    public Location LocationtoNorth;
    public Location LocationtoEast;
    public Location LocationtoSouth;
    public Location LocationtoWest;

    public Location(int id, string name, string description, Quest QuestAvailable, Monster LivingMonster)
    {
        ID = id;
        Name = name;
        Description = description;
        QuestAvailableHere = QuestAvailable;
        MonsterLivingHere = LivingMonster;
    }
}