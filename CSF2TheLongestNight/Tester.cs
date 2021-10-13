using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace TheLongestNight
{
    class Tester
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Longest Night\nCan you make it to dawn?");
            Console.Title = "The Longest Night";

            int score = 0;

            Weapon combatKnife = new Weapon(1, 8, "Combat Knife", 18, false);
            Weapon handgun = new Weapon(5, 15, "Handgun", 10, false);
            Weapon shotgun = new Weapon(11, 27, "Shotgun", 30, true);

            Player player = new Player("The Rookie",
                70, 5, 50, 40, PlayableHumans.TheRookie, combatKnife);

            bool exit = false;

            do
            {

                Console.WriteLine(GetRoom());

                Zombie z1 = new Zombie();

                Zombie z2 = new Zombie("Alpha Zombie", 25, 25, 50, 20, 2, 8, "There's something different about this one. It doesn't look like it was ever bitten. Something else must have turned it", true);

                Enemy[] enemies = { z1, z2 };

                Random rand = new Random();
                Enemy enemy = enemies[rand.Next(enemies.Length)];

                Console.WriteLine("\nIn this room: " + enemy.Name);

                bool reload = false;

                do
                {
                    Console.WriteLine("\nSelect:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) PlayerInfo\n" +
                        "E) EnemyInfo\n" +
                        "X) Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack");
                            Combat.DoBattle(player, enemy);

                            if (enemy.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", enemy.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!");

                            Console.WriteLine($"{enemy.Name} attacks you as you flee!");
                            Console.WriteLine();
                            Combat.DoAttack(enemy, player);
                            Console.WriteLine();
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Enemies defeated: " + score);
                            break;

                        case ConsoleKey.E:
                            Console.WriteLine("Enemy Info");
                            Console.WriteLine(enemy);
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.Q:
                            Console.WriteLine("No one likes a quitter!");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Not a valid action. Try again.");
                            break;
                    }//END SWITCH

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You have died... The truth behind the outbreak will never be heard.");
                        exit = true;
                    }//END PLAYER LIFE

                } while (!exit && !reload);

            } while (!exit);

            Console.WriteLine("You defeated " + score + " enemy" +
                (score == 1 ? "." : "s."));

        }//END MAIN

        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room is large and dimly lit. You can barely make out a receptionist desk and computer. Looking around, you notice there are several other doors in this room.",
                "You enter a long, dark hallway. The smell of blood hits you like a truck...",
                "There doesn't appear to be anything of importance in this room, just some files and office equipment.",
                "As you enter this room, the doorknob breaks and you can't shut or lock the door. Hopefully you don't need to keep anything out of here...",
                "This door leads outside to a courtyard. It's raining and despite being in the middle of a city, all you can hear is the rain coming down on you...",
                "You decide to take a look around outside and find a ladder heading down into a dark hole. At the bottom, there is a small, musty room filled with corpses. Is someone purposefully feeding these zombies?",
                "Entering the bathroom, you hear a noise from the inside of a locker. Readying your weapon, you quickly pull open the door, but it was just a rat...",
                "This room is filled with smoke and you see the small glow of a fire in the corner. The small fire seems to be moving though and isn't taking its time.",
                "As you enter the basement, you hear loud gurgling noises all around you - almost like choking..."
            };//END STRING

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;

        }//END GETROOM
    }//END CLASS
}//END NAMESPACE
