using System;
using System.Collections.Generic;


namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Hospital hospital = new Hospital();
            Arena arena = new Arena();
            Forest forest = new Forest();
            Store store = new Store();


            char fightOrFlee = 'a';
            char userInput;

            List<Location> locations = new List<Location> { hospital, forest, arena, store };

            while (player.GetState() == Character.State.Alive)
            {
                Console.WriteLine("Para qual local você deseja ir?\n");

                for (int i = 0; i < locations.Count; i++)
                {
                    Console.WriteLine($"Você pode ir para a {locations[i].Name}, para entrar nela digite {locations[i].Input}\n");
                }
                userInput = Convert.ToChar(Console.ReadLine());

                for (int i = 0; i < locations.Count; i++)
                {
                    if (CompareInput(userInput, locations[i].Input))
                    {
                        Console.WriteLine($"{locations[i].Name}\n {locations[i].Description} \n");


                        if (locations[i] == hospital)
                        {
                            // erro do hospital se repetindo, não consigo usar ele duas vezes
                            Console.WriteLine("Press A to heal your wounds, it will cost 2 coins");
                            userInput = Convert.ToChar(Console.ReadLine());
                            if (CompareInput(userInput, hospital.HealInput) && player.Coins >= 2)
                            {
                                hospital.Heal(player);
                                Console.WriteLine($"Your HP is now {player.ShowLifeBar()}\n");
                                player.UseHospital(hospital.PayValue);
                                Console.WriteLine($"You have {player.Coins} coins");
                            }
                            else
                            {
                                Console.WriteLine("Hmmm... it seems that you lack the money, we can't treat you for free");
                            }

                        }

                        if (locations[i] == store)
                        {
                            // não consigo utilizar a loja
                            for (int index = 0; index < store.Itens.Length; index++)
                            {
                                Item item = store.Itens[index];
                                Console.WriteLine($"{item.Name} custa {item.Value}\n {item.Description}");
                                Console.WriteLine($"Para comprar {item.Name} pressione {item.Input}\n");
                            }
                            userInput = Convert.ToChar(Console.ReadLine());


                            for (int index = 0; index < store.Itens.Length; index++)
                            {
                                Item item = store.Itens[index];
                                if (CompareInput(userInput, store.Itens[index].Input))
                                {
                                    if (player.Coins >= item.Value)
                                    {
                                        player.BuyItem(item.Value, item);
                                        Console.WriteLine($"Você agora possui um {item.Name}");
                                        Console.WriteLine($"You have {player.Coins} coins");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Not enough cash");
                                    }
                                }

                            }

                            break;
                        }

                        if (locations[i].GetType().IsSubclassOf(typeof(DangerZone)))
                        {
                            DangerZone dangerZone = (DangerZone)locations[i];
                            Enemy enemy = new Enemy(dangerZone.LocalLevel);


                            Console.WriteLine($"Enemies in this area have level {dangerZone.LocalLevel}");
                            while ((enemy.GetState() == Character.State.Alive))
                            {
                                Console.WriteLine($"Enemy HP is now {enemy.ShowLifeBar()}\n");
                                Console.WriteLine($"Your HP is now {player.ShowLifeBar()}\n");
                                Console.WriteLine("The enemy attacked you");
                                enemy.Attack(player);
                                Console.WriteLine($"Your HP is now {player.ShowLifeBar()}\n");
                                Console.WriteLine("You wish to run, use an item or fight? Press A to fight, press I to choose an item to use or any other key to run");
                                fightOrFlee = Convert.ToChar(Console.ReadLine());

                                if (fightOrFlee == 'a' || fightOrFlee == 'A')
                                {
                                    Console.WriteLine("YOU ATTACKED THE ENEMY");
                                    player.Attack(enemy);
                                }
                                else if (fightOrFlee == 'i' || fightOrFlee == 'I')
                                {
                                    Console.WriteLine($"[Input] - (quantidade) - Nome - Descrição");

                                    for (int j = 0; j < player.inventario.slots.Count; j++)
                                    {
                                        SlotDoInventario slot = player.inventario.slots[j];
                                        Console.WriteLine($"[{slot.item.Input}] - ({slot.quantidade}){slot.item.Name}: {slot.item.Description}");
                                    }
                                    userInput = Console.ReadKey().KeyChar;

                                    for (int j = 0; j < player.inventario.slots.Count; j++)
                                    {
                                        SlotDoInventario slot = player.inventario.slots[j];

                                        if (CompareInput(userInput,slot.item.Input))
                                        {
                                            slot.item.Use(enemy);
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("What a chicken!");
                                    break;
                                }

                                Console.WriteLine($"xp = {player.ExperiencePoints}");
                                Console.WriteLine($"You have {player.Coins} coins");
                            }
                        }

                        break;
                    }
                }
            }

            Console.WriteLine("You Died");
        }

        static bool CompareInput(char input, char inputToCompare)
        {
            return input == inputToCompare || input == inputToCompare.ToString().ToLowerInvariant().ToCharArray()[0];
        }
    }
}

