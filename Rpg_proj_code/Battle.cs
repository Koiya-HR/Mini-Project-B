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
            // restore the monster hp to full at the start of fight
            currentMonster.CurrentHitPoints = currentMonster.MaximumHitpoints;
            while (true)
            {
                Console.WriteLine("press anything to continue");
                Console.ReadLine();

                int damageToMonster = World.RandomGenerator.Next(player1.CurrentWeapon.MaximumDamage) + player1.Level;
                currentMonster.CurrentHitPoints -= damageToMonster;
                // if statement to make it so monster cant have negative hp
                if (currentMonster.CurrentHitPoints < 0) { currentMonster.CurrentHitPoints = 0; }
                Console.WriteLine($"You hit the {currentMonster.Name} for {damageToMonster} damage. Enemy HP: ({currentMonster.CurrentHitPoints}/{currentMonster.MaximumHitpoints})");

                Console.WriteLine("press anything to continue");
                Console.ReadLine();

                if (currentMonster.CurrentHitPoints <= 0)
                // monster defeated
                {
                    player1.MonstersKilled += 1;
                    Random rand = new();
                    int gold_earned = rand.Next(1, 5);
                    player1.Gold += gold_earned;
                    Console.WriteLine($"You defeated the {currentMonster.Name}");
                    Console.WriteLine($"You obtained: {gold_earned} gold");

                    // check if player has a quest to kill the monsters here
                    foreach (Quest quest in World.Quests)
                    {
                        // if location is correct and quest is started and quest is not finished
                        if ((quest.Destination == player1.CurrentLocation) && quest.started && !quest.finished)
                        {
                            quest.monstes_left -= 1;
                            if (quest.monstes_left == 0)
                            {
                                quest.finish_quest(player1);
                            }
                            else
                            {
                                Console.WriteLine($"You need to kill {quest.monstes_left} more monster{(quest.monstes_left > 1 ? "s" : "")} to finish the {quest.Name}");
                                Console.WriteLine("press anything to continue");
                                Console.ReadLine();
                            }

                        }

                    }
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
