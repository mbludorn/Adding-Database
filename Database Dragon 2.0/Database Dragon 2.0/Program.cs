using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatGame2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //game dialogue
            Console.WriteLine("=============WELCOME TO THE DRAGON COMBAT SIMULATOR 5000=============\n\n");
            Console.WriteLine("In a land far far away in a time long long ago, there was a small town of peasants whom lived peacefully and happily for thousands and thousands of years.  They were a small race of people, consisting of farmers, shepards, drinkers, gardeners, dancers, and laughers.  They were not a violent race of people.\n\n\nHowever, there town lay at the base of a tall mountain, and at the very top of the mountain, there was a cave.  And in this cave lies a book, but not just any book.  This book holds the answers to every single problem that haunt these people.....a goldmine of eternal knowledge.\n\n\nThere is a problem though.  This book which holds all the knowledge of everything for these people just so happens to be guarded by a fierce, giant, fire-breathing dragon!\n\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("=============WELCOME TO THE DRAGON COMBAT SIMULATOR 5000=============\n\n");
            Console.WriteLine("You have been chosen by your people!!!  You have been deemed the strongest warrior of your town, and now must attain the book of all things knowledgable for your people!  You begin your trek up the mountain, climbing rocks and inclining slowly but surely.\n\n\nFinally after many a hard breaths and perspiration, you start to make out in the distance the dark abyss and eerie void of what is the dragon's cave.  As you make your way toward it, you become startled when you feel the ground under your feet begin to shake!\n\n\nStomp....Stomp...Stomp...STOMP! The dragon stands before you at the entrance of his lair.  You must now confront your enemy and help your people!!!!!\n\n");
            Console.WriteLine("Press any key to enter combat...");
            Console.ReadKey();
            Console.Clear();
            //call our functions by using all of our classes
            Game game = new Game();

            game.PlayGame();

            //add score to highscores

            //keep console open
            Console.ReadKey();
        }

         static void AddHighScore(int playerScore)
        {
            Console.WriteLine("Your Name: ");
            string playerName = Console.ReadLine();

            //create a gateway to the database
            MorganEntities db = new MorganEntities();
            
            //create a new highsccore object
            HighScore newHighScore =  new HighScore();

            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Game = "Dragon Combat 2.0";
            newHighScore.Name = playerName;
            newHighScore.Score = playerScore;

            //add it to the database
            db.HighScores.Add(newHighScore);

            //save our changes
            db.SaveChanges();
        }

        static void DisplayHighScores()
    {
        //clear the console
        Console.Clear();
        //write to the console
        Console.WriteLine("Dragon Combat 2.0 High Score");
        Console.WriteLine("-------------------------");

        //create a new connection to the database
        MorganEntities db = new MorganEntities();
        
        //get the high score list
        List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Dragon Combat 2.0").OrderByDescending(x => x.Score).Take(10).ToList();


    foreach (var highScore in highScoreList)
	{
        Console.WriteLine("{0}. {1} - {2} on {3}", highScoreList .IndexOf(highScore) + 1, highScore.Name, highScore.Score);
	}
        
    }
    }
}
    }
}
