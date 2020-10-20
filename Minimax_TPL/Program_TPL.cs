﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Minimax_TPL
{
    /* 
----------------------------------------------------------------------------------------------------------------
 * Program.CS -
--------------------------------------------------------------------------------------------------------------------------
*/
    /*
--------------------------------------------------------------------------------------------------------------------------
Consts -
--------------------------------------------------------------------------------------------------------------------------
Static class that creates constant variables that are used to inform search in other classes.
--------------------------------------------------------------------------------------------------------------------------
*/
    static class Consts
    {
        public const int MAX_SCORE = 1001;
        public const int MIN_SCORE = -1001;
        public const int NO_OF_DIRS = 3;
        public static readonly int[] DIRECTIONS = { 1, 9, 10 };
    }
    /*
--------------------------------------------------------------------------------------------------------------------------
counters -
--------------------------------------------------------------------------------------------------------------------------
This enum creates instances of counters to be used to board in gameplay.
--------------------------------------------------------------------------------------------------------------------------
*/
    public enum counters
    {
        X,
        BORDER,
        N,
        e,
    }
    /*
--------------------------------------------------------------------------------------------------------------------------
Program -
--------------------------------------------------------------------------------------------------------------------------
Main program handles exection and chooses mode of game selected, i.e. 1 - PLAYER V PC, 2 - PC V PC, etc.
--------------------------------------------------------------------------------------------------------------------------
*/
    // MAIN EXECUTION
    class Program
    {
        public static int no_of_cores_for_parallelism; // specify number of cores to utilise parallelism in TPL variant
        public static int cntr;
        public static void Main(string[] args)
        {
            // MENU CHOICE PROMPT
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            DisplayMenu();
            int menuChoice  = 2;  // HWL: hard-wire input so that you can redirect output to a file
           /*
           --------------------------------------------------------------------------------------------------------------------------
           Command line arguments for program -
           --------------------------------------------------------------------------------------------------------------------------
           */
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Argument [{i}] = [{args[i]}]");
                cntr = int.Parse(args[0]);
                no_of_cores_for_parallelism = int.Parse(args[1]);            
            }
            Console.WriteLine("board: " + args[0] + " cores: " + args[1]);
            /*
          --------------------------------------------------------------------------------------------------------------------------
          End of command line arguments
          --------------------------------------------------------------------------------------------------------------------------
          */
            // SELECTION 1 HUMAN V AI
            if (menuChoice == 1)
            {
                Console.Write("\nEnter your name: ");
                string name = Console.ReadLine();
                Console.Write("Would you like to be B or W? ");
                counters counter;
                char new_counter;
                while (!(char.TryParse(Console.ReadKey().KeyChar.ToString().ToUpper(), out new_counter) && (new_counter == 'W' || new_counter == 'B')))
                    Console.Write("\nInvalid counter. Enter 'B' or 'W': ");
                if (new_counter == 'X')
                {
                    counter = counters.X;
                }
                else if (new_counter == 'X')
                {
                    counter = counters.X;
                }
                else
                {
                    counter = counters.e;
                }

                Player_TPL Player_TPL = new HumanPlayer_TPL(name, counter);
                Player_TPL computer = new AIPlayer_TPL(Player_TPL.otherCounter);
                Game_TPL Game_TPL;
                if (counter == counters.X)
                    Game_TPL = new Game_TPL(Player_TPL, computer);
                else
                    Game_TPL = new Game_TPL(computer, Player_TPL);
            }
            // SELECTION 2 AI V AI
            if (menuChoice == 2)
            {
                counters counter;
                counter = counters.X;
                Player_TPL Player_TPL = new AIPlayer_TPL(counter);
                Player_TPL computer = new AIPlayer_TPL(Player_TPL.otherCounter);
                Game_TPL Game_TPL;
                if (counter == counters.X)
                    Game_TPL = new Game_TPL(Player_TPL, computer);
                else
                    Game_TPL = new Game_TPL(computer, Player_TPL);
            }
            // SELECTION 3 HUMAN V HUMAN
            if (menuChoice == 3)
            {
                Console.Write("\nEnter name for X: ");
                string xName = Console.ReadLine();
                Console.Write("Enter name for O: ");
                string oName = Console.ReadLine();
                Player_TPL xPlayer_TPL = new HumanPlayer_TPL(xName, counters.X);
                Player_TPL oPlayer_TPL = new HumanPlayer_TPL(oName, counters.X);
                Game_TPL Game_TPL = new Game_TPL(xPlayer_TPL, oPlayer_TPL); // play Game_TPL execution
            }
            // SELECTION 4 EXIT
            Environment.Exit(0);
        }
        /*
--------------------------------------------------------------------------------------------------------------------------
DisplayMenu -
--------------------------------------------------------------------------------------------------------------------------
A method that displays the menu options to console.
--------------------------------------------------------------------------------------------------------------------------
*/
        static void DisplayMenu()
        {
            // menu centered
            Console.Clear();
      }
    }
}