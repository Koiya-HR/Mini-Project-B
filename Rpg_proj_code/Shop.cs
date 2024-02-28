namespace Rpg_proj;

public static class Shop
{
    public static void shop(Player player1)
    {

        Console.WriteLine($"Welcome to the shop traveller, what would you like to purchase? Current gold {player1.Gold}");
        while (true)
        {
            Console.WriteLine("(0) Exit shop");
            Console.WriteLine($"(1) Club (Weapon, max damage: {World.WeaponByID(2)!.MaximumDamage}): 25 gold");
            Console.WriteLine($"(2) big hp pot (Item, heals 10 hp): 10 gold");
            string choice = Console.ReadLine() ?? "invalid";
            switch (choice)
            {
                case "0":
                    Console.WriteLine("Exiting shop...");
                    return;

                case "1" when player1.Gold >= 25:
                    player1.Gold -= 25;
                    Weapon prev_weapon = player1.CurrentWeapon!;
                    player1.CurrentWeapon = World.WeaponByID(2)!;
                    Console.WriteLine($"You bought {World.WeaponByID(2)!.Name} for 25 gold.");
                    Console.WriteLine($"Weapon damge {prev_weapon.MaximumDamage} -> {player1.CurrentWeapon.MaximumDamage}");
                    break;

                case "2" when player1.Gold >= 10:
                    player1.Gold -= 10;
                    player1.AddItemToInventory(World.items[1]);
                    Console.WriteLine($"You bought {World.items[1].Name} for 10 gold.");
                    break;

                default:
                    Console.WriteLine("Invalid choice or not enough gold.");
                    break;
            }
        }
    }
}
