namespace Rpg_proj;

public static class Battle
{
    public static void battle(Player player1)
    {
        Monster currentMonster = player1.CurrentLocation.MonsterLivingHere;
        if (currentMonster == null)
        {
            Console.WriteLine("\nthere are no monsters living here");
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"you enter a fight with a {currentMonster.Name}!");
            while (player1.CurrentHitPoints > 0 && currentMonster.CurrentHitPoints > 0)
            {
                Console.WriteLine("press anything to continue");
                Console.ReadLine();

                int damageToMonster = World.RandomGenerator.Next(player1.CurrentWeapon.MaximumDamage) + player1.Level;
                currentMonster.CurrentHitPoints -= damageToMonster;
                Console.WriteLine($"You hit the {currentMonster.Name} for {damageToMonster} damage. Enemy HP: ({currentMonster.CurrentHitPoints}/{currentMonster.MaximumHitpoints})");

                Console.WriteLine("press anything to continue");
                Console.ReadLine();

                if (currentMonster.CurrentHitPoints <= 0)
                {
                    Console.WriteLine($"You defeated the {currentMonster.Name}");
                    break;
                }

                int damageToPlayer = World.RandomGenerator.Next(currentMonster.MaximumDamage);
                player1.CurrentHitPoints -= damageToPlayer;
                Console.WriteLine($"The {currentMonster.Name} hits you for {damageToPlayer} damage. Your HP: ({player1.CurrentHitPoints}/{player1.MaximumHitPoints})");
                if (player1.CurrentHitPoints <= 0)
                {
                    Console.WriteLine($"You were defeated by the {currentMonster}");
                    Console.WriteLine("you respawn at home");
                    player1.CurrentHitPoints = player1.MaximumHitPoints;
                    player1.CurrentLocation = World.Locations[0];
                    break;
                }

            }
        }
    }
}
