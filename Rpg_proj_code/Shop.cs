namespace Rpg_proj;

public static class Shop
{
    public static void shop(Player player1)
    {

        Console.WriteLine("Welcome to the shop traveller, what would you like to purchase?");
        while (true)
        {
            Console.WriteLine("(0) exit shop");
            Console.WriteLine($"(1) Club (Weapon, max damage: {World.WeaponByID(2).MaximumDamage}): 200 gold");
            Console.WriteLine($"(2) big hp pot (Item, heals 10 hp): 100 gold");
            string choice = Console.ReadLine() ?? "invalid";
            switch (choice)
            {
                case "0":
                    Console.WriteLine("exiting shop...");
                    return;

                case "1" when player1.Gold >= 200:
                    player1.Gold -= 200;
                    player1.CurrentWeapon = World.WeaponByID(2);
                    Console.WriteLine($"You bought {World.WeaponByID(2)} for 200 gold.");
                    break;

                case "2" when player1.Gold >= 100:
                    player1.Gold -= 100;
                    player1.AddItemToInventory(World.items[1]);
                    Console.WriteLine($"You bought {World.items[1]} for 100 gold.");
                    break;

                default:
                    Console.WriteLine("Invalid choice or not enough gold.");
                    break;
            }
        }
    }
}
