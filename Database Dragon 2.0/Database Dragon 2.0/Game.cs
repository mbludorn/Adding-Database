﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatGame2._0
{
    class Game
    {
        //create properties for player and enemy
        public Player player { get; set; }
        public Enemy enemy { get; set; }

        //create a constructor that intializes the player and enemy
        public Game()
        {
            //creating the Player and Enemy
            this.player = new Player("Drew", 100);
            this.enemy = new Enemy("Puff the Dragon", 200);
        }

        //create methods
        //create function for displaying current hp of player and enemy
        public void DisplayCombatInfo()
        {
            //display current hp of both player and enemy
            Console.WriteLine("==========Current Health==========\n");
            Console.WriteLine("Player HP:  " + player.playerHP);
            Console.WriteLine("Dragon HP:  " + enemy.dragonHP);
        }
        //create function to run the game
        public void PlayGame()
        {       
            //create round counter
            int roundCount = 1;

            while (this.player.IsAlive && this.enemy.IsAlive)
            {
                
                Console.WriteLine("=============WELCOME TO THE DRAGON COMBAT SIMULATOR 5000=============\n\n");
                //show user what round
                Console.WriteLine("==============ROUND " + roundCount + "==============\n\n");
                //display HPs
                DisplayCombatInfo();
                //player attacks enemy
                this.enemy.TakeDamage(this.player.playerDoAttack());
                //enemy attacks player
                this.player.TakeDamage(this.enemy.enemyDoAttack());
                //add one to the round counter
                roundCount++;
                Console.WriteLine("\nPress any key to continue to the next round of combat!");
                Console.ReadKey();
                Console.Clear();
            }
            //game ends
            if (!this.player.IsAlive)
            {
                Console.WriteLine(@"You have failed to defeat the dragon, as you have run out of health points.  And the book of all things knowledgeble stays guarded for at least another day...");
            }
            else
            {
                Console.WriteLine("CONGRATULATIONS!!!!! YOU HAVE DEFEATED THE GIANT, FIRE-BREATHING DRAGON!\n\nYou now make your way over the dying carcass and into the cave.  You come across a glowing book of some sort which you spot on a table.  This is the book of all things knowledgeable!  You grab the book and bring it back down the mountain to your townspeople whom are eagerly waiting for your arrival.  You pull the book out of your sack to show them that everything is going to be just peachy fine for the rest of eternity!  You and your townspeople celebrate over music and grog!!!!");
                Console.WriteLine("\n\n====================THE END====================");
            }
            AddHighScore(roundCount);
            DisplayHighScores();
        }
