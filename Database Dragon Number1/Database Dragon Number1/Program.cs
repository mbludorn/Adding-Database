using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============WELCOME TO THE DRAGON COMBAT SIMULATOR 5000=============");
            Console.WriteLine("In a land far far away in a time long long ago, there was a small town of peasants whom lived peacefully and happily for thousands and thousands of years.  They were a small race of people, consisting of farmers, shepards, drinkers, gardeners, dancers, and laughers.  They were not a violent race of people.\n\n\nHowever, there town lay at the base of a tall mountain, and at the very top of the mountain, there was a cave.  And in this cave lies a book, but not just any book.  This book holds the answers to every single problem that haunt these people.....a goldmine of eternal knowledge.\n\n\nThere is a problem though.  This book which holds all the knowledge of everything for these people just so happens to be guarded by a fierce, giant, fire-breathing dragon!\n\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You have been chosen by your people!!!  You have been deemed the strongest warrior of your town, and now must attain the book of all things knowledgable for your people!  You begin your trek up the mountain, climbing rocks and inclining slowly but surely.\n\n\nFinally after many a hard breaths and perspiration, you start to make out in the distance the dark abyss and eerie void of what is the dragon's cave.  As you make your way toward it, you become startled when you feel the ground under your feet begin to shake!\n\n\nStomp....Stomp...Stomp...STOMP! The dragon stands before you at the entrance of his lair.  You must now confront your enemy and help your people!!!!!\n\n\n\n");
            userAttack(3);
            //keep console open
            Console.ReadKey();
        }

        //functions go below here

        //create function for user attacks
        static void userAttack(int num)
        {
            //create variable for player and dragon hp
            int playerHP = 100;
            int dragonHP = 200;

            while (playerHP > 0 && dragonHP > 0)
            {
                Console.WriteLine("Player HP:  " + playerHP);
                Console.WriteLine("Dragon HP:  " + dragonHP);
                Console.WriteLine("\n\nChoose an attack!\n");
                Console.WriteLine("====Attacks====\n\n1.  Sword - attacks with sword for 20-35 damage with 70% hit chance\n2.  Magic - attacks with fireball that always hits at 10-15 damage\n3.  Heal - heal yourself for 10-20 HP\n\n");
                int choice = int.Parse(Console.ReadLine());

                //create new random generator
                Random rng = new Random();
                //run sword if user decides to choose sword attack
                if (choice == 1)
                {
                    //run sword's hit chance
                    int swordChance = rng.Next(0, 101);
                    //sword only attacks 70% of the time
                    if (swordChance >= 30)
                    {
                        //sword attacks anywhere from 20-35 hp
                        int sword = rng.Next(20, 36);
                        //take sword damage from dragon's health
                        dragonHP = dragonHP - sword;
                        Console.WriteLine("\n\nYou attack with your sword and cause " + sword + " damage to the dragon!");
                    }
                    //if sword hitchance is below 30, then it misses the dragon
                    else
                    {
                        Console.WriteLine("\n\nSorry you missed the dragon with your sword!");
                    }
                }
                //run magic if user chooses magic attack
                else if (choice == 2)
                {
                    //run magic attack at anywhere between 10 and 15 damage and take away from dragon's health
                    //magic attack hits 100% of the time
                    int magic = rng.Next(10, 16);
                    dragonHP = dragonHP - magic;
                    Console.WriteLine("\n\nYou blast a fireball at the dragon for a total of " + magic + " damage loss!");
                }
                //run heal if user chooses the heal choice
                else if (choice == 3)
                {
                    //run heal to heal player anywhere between 10 and 20 health points
                    //add heal back to player's health
                    int heal = rng.Next(10, 21);
                    playerHP = playerHP + heal;
                    Console.WriteLine("\n\nYou heal yourself for " + heal + " health points!");
                }
                //if user didnt choose one of the three moves, then tell player
                else
                {
                    Console.WriteLine("\n\nYou did not choose an appropriate move, and in the moment of your stupidity, the dragon attacks.");
                }

                Console.WriteLine("\n\nNow its the dragons turn to attack!");
                int dragonChance = rng.Next(0, 101);
                if (dragonChance >= 20)
                {
                    int dragonAttack = rng.Next(5, 16);
                    playerHP = playerHP - dragonAttack;
                    Console.WriteLine("The dragon hits with his fiery breath for a total of " + dragonAttack + " damage!\n\n\n");
                }
                else
                {
                    Console.WriteLine("The dragon misses you with his fiery breath!  You barely scrape by to fight again!");
                }
            }
            if (dragonHP <= 0)
            {
                Console.WriteLine("@CONGRATULATIONS!!!!! YOU HAVE DEFEATED THE GIANT, FIRE-BREATHING DRAGON!\n\nYou now make your way over the dying carcass and into the cave.  You come across a glowing book of some sort which you spot on a table.  This is the book of all things knowledgeable!  You grab the book and bring it back down the mountain to your townspeople whom are eagerly waiting for your arrival.  You pull the book out of your sack to show them that everything is going to be just peachy fine for the rest of eternity!  You and your townspeople celebrate over music and grog!!!!");
                Console.WriteLine("\n\n====================THE END====================");
            }
            else if (playerHP <= 0)
            {
                Console.WriteLine("@You have failed to defeat the dragon, as you have run out of health points.  And the book of all things knowledgeble stays guarded for at least another day...");
            }

        }

    }
}
