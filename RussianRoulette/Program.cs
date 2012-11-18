using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RussianRoulette
{
    class startNewGame
    {
        

        public void newGame()
        {
            string myChoice;
            int numberOfchambers;
            int bulletChamber;
            int chamber;
            startNewGame theGame = new startNewGame();
            numberOfchambers = 6;
            bulletChamber = theGame.setBulletChamber(numberOfchambers);
            chamber = theGame.setChamber(numberOfchambers);

            do
            {

                //Get the player choice
                myChoice = theGame.playerChoice();                
                switch (myChoice)
                {
                    //Spin
                    case "1":
                        Console.WriteLine("\r\nYou spin the barrel\r\n");

                        //Reset odds
                        bulletChamber = theGame.setBulletChamber(numberOfchambers);
                        break;

                    //Shoot
                    case "2":
                        if (bulletChamber == chamber)
                        {
                            Console.WriteLine("\r\nBang! You're dead!");
                            theGame.thePlayer = 0;
                        }
                        else
                        {
                            Console.WriteLine("\r\nYou live.... This time.\r\n");
                            if (chamber < 5)
                            {
                                chamber = ++chamber;
                            }
                            else
                            {
                                chamber = 0;
                            }
                        }
                            break;

                    //Shoot captor in the face
                    case "3":
                            Console.WriteLine("With shaky hand you aim your gun at your captor....\r\n");
                            Console.WriteLine("Press enter to continue..");
                            Console.ReadLine();
                            if (bulletChamber == chamber)
                            {
                                Console.WriteLine("You pull the trigger and BAM! You kablowed your captors head clear off!\r\n");
                                Console.WriteLine("Congradulations! You won!");
                                theGame.thePlayer = 2;
                            }
                            else
                            {
                                Console.WriteLine("You pull the trigger... and click, Your captor knows you tried to kill him and kablow your head esploded!\r\n");
                                Console.WriteLine("You loser, you lost the game!");
                                theGame.thePlayer = 0;
                            }
                                
                        break;
                }
            }while(theGame.thePlayer != 0 && theGame.thePlayer != 2);

        }

        private int thePlayer = -1;

        private int m_bulletChamber = -1;
        private int[] m_chamber = new int[1];
        private static readonly Random randy = new Random();

        public int setBulletChamber(int numberOfChambers)
        {            
            m_bulletChamber = randy.Next(numberOfChambers);

            return m_bulletChamber;
        }

        public int setChamber(int numberOfChambers)
        {            
            m_chamber = new int[numberOfChambers];
            for (int i = 0; i < m_chamber.Length; i++)
            {
                m_chamber[i] = i;
            }

            int chamber = randy.Next(0, m_chamber.Length);

            return chamber;
        }


        string playerChoice(){
            string myChoice;
            string[] phrases = new string[] {
                "\r\nYou pick up the gun, what would you like to do?\r\n",
                "\r\nYou look nervous... what would you like to do?\r\n",
                "\r\nWith sweaty palms you pick up the gun, what would you like to do?\r\n",
            };
            string[] lines = new string[] {                
                "1 - Spin the barrel",
                "2 - Take the shot",
                "3 - Shoot your captor\r\n"
            };
            Random ran = new Random();

            Console.WriteLine(phrases[ran.Next(3)]);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.Write("(1, 2, 3): ");            
            myChoice = Console.ReadLine();
   
            return myChoice;
        }


    }

    class MainClass
    {
        static void Main(string[] args)
        {
            string playAgain;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            //Print the game title
            Console.WriteLine(gameTitle);                        
            do
            {
                Console.Write("New Game? y/n :");
                playAgain = Console.ReadLine();
                switch (playAgain)
                {
                    case "y":
                    case "Y":
                        startNewGame newGame = new startNewGame();
                        Console.WriteLine("The game has started...");
                        newGame.newGame();
                        break;
                    case "n":
                    case "N":
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("{0} is not a valid choice", playAgain);
                        break;

                }
            }while(playAgain != "n" && playAgain != "N");

            //Exit the application            
        }

        private static string gameTitle = @"
            ,___________________________________________/7_ 
           |-_______------. `\                             |
       _,/ | _______)     |___\____________________________|
  .__/`((  | _______      | (/))_______________=.
     `~) \ | _______)     |   /----------------_/
       `__y|______________|  /
       / ________ __________/
      / /#####\(  \  /     ))
     / /#######|\  \(     //            
    / /########|.\_______//`
   / /###(\)###||`------``
  / /##########|| .----.--.--.-----.-----.|__|.---.-.-----.
 / /###########|| |   _|  |  |__ --|__ --||  ||  _  |     |
( (############|| |__| |_____|_____|_____||__||___._|__|__|
 \ \####(/)####)) 
  \ \#########//                    __ __         __         
   \ \#######//  .----.-----.--.--.|  |  |.-----.|  |_.-----.
    `---|_|--`   |   _|  _  |  |  ||  |  ||  -__||   _|  -__|
       ((_))     |__| |_____|_____||__|__||_____||____|_____|
        `-`";
    }
}
