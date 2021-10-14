using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace CSF2TheLongestNight
{
    class Tester
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Can you survive until dawn?\n\n");
            Console.Title = "The Longest Night";

            int score = 0;

            Weapon combatKnife = new Weapon(2, 10, "Combat Knife", 40, false);
            Weapon handgun = new Weapon(5, 15, "Handgun", 10, false);
            Weapon shotgun = new Weapon(11, 27, "Shotgun", 30, true);

            Player player = new Player("The Rookie",
                60, 5, 100, 100, PlayableHumans.TheRookie, combatKnife);

            bool exit = false;

            do
            {

                Console.WriteLine(GetRoom());

                Zombie z1 = new Zombie();

                Zombie z2 = new Zombie("Alpha Zombie", 25, 25, 50, 20, 2, 8, "There's something different about this one. There are no bite marks on it, so it couldn't have been infected from another zombie.", true);

                Crawler c1 = new Crawler();

                Tyrant t1 = new Tyrant();

                Enemy[] enemies = { z1, z2, t1, c1 };

                Random rand = new Random();
                Enemy enemy = enemies[rand.Next(enemies.Length)];

                Console.WriteLine("\nIn this room: " + enemy.Name);

                bool reload = false;

                do
                {
                    Console.WriteLine("\nSelect:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "E) Enemy Info\n" +
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
                            Console.WriteLine(player);
                            Console.WriteLine("Enemies defeated: " + score);
                            break;

                        case ConsoleKey.E:
                            Console.WriteLine(enemy);
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.Q:
                            Console.WriteLine("You really want to give up all hope?");
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
                "The room is large and dimly lit. You can barely make out a receptionist desk and computer. Looking around, you notice there are several other doors in this room.\n",
                "You enter a long, dark hallway. The smell of blood hits you like a truck...\n",
                "There doesn't appear to be anything of importance in this room, just some files and office equipment.\n",
                "As you enter this room, the doorknob breaks and you can't shut or lock the door. Hopefully you don't need to keep anything out of here...\n",
                "This door leads outside to a courtyard. It's raining and despite being in the middle of a city, all you can hear is the rain coming down on you...\n",
                "You decide to take a look around outside and find a ladder heading down into a dark hole. At the bottom, there is a small, musty room filled with corpses. Is someone purposefully feeding these zombies?\n",
                "Entering the bathroom, you hear a noise from the inside of a locker. Readying your weapon, you quickly pull open the door, but it was just a rat...\n",
                "This room is filled with smoke and you see the small glow of a fire in the corner. The small fire seems to be moving and isn't taking its time.\n",
                "As you enter the basement, you hear loud gurgling noises all around you - almost like choking...\n"
            };//END STRING

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;

        }//END GETROOM
    }//END CLASS
}//END NAMESPACE
