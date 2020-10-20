using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Minimax_TPL
{
    /* 
    ----------------------------------------------------------------------------------------------------------------
     * GameBoard_TPL.CS -
    --------------------------------------------------------------------------------------------------------------------------
    Struct class controls all constructs of GameBoard including printing.
    --------------------------------------------------------------------------------------------------------------------------
    */
    struct GameBoard_TPL <T> where T: IComparable
    {
        // PUBLIC DECLARATIONS
        public T s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11,
                     s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22,
                     s23, s24, s25, s26, s27, s28, s29, s30, s31, s32, s33,
                     s34, s35, s36, s37, s38, s39, s40, s41, s42, s43, s44,
                     s45, s46, s47, s48, s49, s50, s51, s52, s53, s54, s55,
                     s56, s57, s58, s59, s60;

        public T filler; // empty filler space for cell
        /* 
----------------------------------------------------------------------------------------------------------------
* GameBoard_TPL constructor -
--------------------------------------------------------------------------------------------------------------------------
Constructs initial blank board.
--------------------------------------------------------------------------------------------------------------------------
*/
        public GameBoard_TPL(T _filler)
        {
            filler = _filler; // blank filler
            s1 = filler; s2 = filler; s3 = filler; s4 = filler; s5 = filler; s6 = filler; s7 = filler; s8 = filler; s9 = filler; s10 = filler; s11 = filler; s12 = filler; s13 = filler; s14 = filler; s15 = filler; // row 1
            s16 = filler; s17 = filler; s18 = filler; s19 = filler; s20 = filler; s21 = filler; s22 = filler; s23 = filler; s24 = filler; s25 = filler; s26 = filler; s27 = filler; s28 = filler; s29 = filler; s30 = filler; // row 2
            s31 = filler; s32 = filler; s33 = filler; s34 = filler; s35 = filler; s36 = filler; s37 = filler; s38 = filler; s39 = filler; s40 = filler; s41 = filler; s42 = filler; s43 = filler; s44 = filler; s45 = filler; // row 3
            s46 = filler; s47 = filler; s48 = filler; s49 = filler; s50 = filler; s51 = filler; s52 = filler; s53 = filler; s54 = filler; s55 = filler; s56 = filler; s57 = filler; s58 = filler; s59 = filler; s60 = filler; // row 4
      




        }
        /* 
----------------------------------------------------------------------------------------------------------------
* DisplayBoard -
--------------------------------------------------------------------------------------------------------------------------
This method constructs current board with the counter symbols in string format which will then be printed to the Console window.
--------------------------------------------------------------------------------------------------------------------------
*/
        public void DisplayBoard()
        {
            //  Console.Clear();
            for (int x = 1; x <= 60; x++)
              
            Console.WriteLine();
            for (int y = 1; y <= 1; y++)
            {
                Console.Write(y + " ");
                for (int x = 1; x <= 60; x++)
                {
		  Console.Write(this[x, y].CompareTo(counters.e)==0 ? " " : this[x, y].ToString());
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.WriteLine("  -   -   -   -   -   -   - ");
            }
            Console.WriteLine();
        }

        /*              for (int y = 1; y <= 60; y++)
----------------------------------------------------------------------------------------------------------------
* DisplayScoreBoard -
--------------------------------------------------------------------------------------------------------------------------
This method constructs current board with the counter symbols represented in integer format which will then be printed to the Console window.
--------------------------------------------------------------------------------------------------------------------------
*/
        public void DisplayScoreBoard()
        {
            //  Console.Clear();
            for (int x = 1; x <= 60; x++)
                Console.Write("  " + x + " ");
            Console.WriteLine();
              for (int y = 1; y <= 60; y++)
            {
                Console.Write(y + " ");
                for (int x = 1; x <= 60; x++)
                {
                    if (EqualityComparer<T>.Default.Equals(this[x, y], filler))
                        Console.Write(filler);
                    else
                        Console.Write(this[x, y]);
                    Console.Write(" | ");

                }
                Console.WriteLine();
                Console.WriteLine("  -   -   -   -   -   -   - ");
            }
            Console.WriteLine();
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* DisplayFinBoardToFile -
--------------------------------------------------------------------------------------------------------------------------
This method constructs current finished board ending in Win or Draw and then prints it to a file.
--------------------------------------------------------------------------------------------------------------------------
*/
        public void DisplayFinBoardToFile()
        {
	  // string path = @"C:/Users/Lewis/Desktop/files_150819/ttt_csharp_270719/Minimax_TPL/boards/finboards.txt";
            string path = @"data/finboards.txt";
            // This text is added only once to the file.
            // Create a file to write to.
	    // File.WriteAllText(@"C:/Users/Lewis/Desktop/files_150819/ttt_csharp_270719/Minimax_TPL/boards/finboards.txt", string.Empty);
            // File.WriteAllText(@"data/finboards.txt", string.Empty);
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(Environment.NewLine);
                //     System.IO.File.WriteAllText(@"C:/Users/Lewis/Desktop/files_150819/ttt_csharp_270719/Minimax_TPL/finboards.txt", string.Empty);
                for (int x = 1; x <= 60; x++)
                    sw.Write("  " + x + " ");
                sw.WriteLine();
                  for (int y = 1; y <= 60; y++)
                {
                    sw.Write(y + " ");
                    for (int x = 1; x <= 60; x++)
                    {
                        if (EqualityComparer<T>.Default.Equals(this[x, y], filler))
                            sw.Write(filler);
                        else
                            sw.Write(this[x, y]);
                        sw.Write(" | ");
                    }
                    sw.WriteLine();
                    sw.WriteLine("  -   -   -   -   -   -   - ");
                }
                sw.Write("^^ FIN BOARD FOR BOARD " + Program.cntr);
                sw.WriteLine();
            }
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* DisplayScoreBoardToFile -
--------------------------------------------------------------------------------------------------------------------------
This method constructs current finished score board ending in Win or Draw and then prints it to a file.
--------------------------------------------------------------------------------------------------------------------------
*/
        public void DisplayScoreBoardToFile()
        {
            string path = @"data/scoreboards.txt";
            // This text is added only once to the file.
            // Create a file to write to.
            // File.WriteAllText(@"C:/Users/Lewis/Desktop/files_150819/ttt_csharp_270719/Minimax_TPL/boards/scoreboards.txt", string.Empty);
             File.WriteAllText(@"data/scoreboards.txt", string.Empty);
            using (StreamWriter sw = new StreamWriter(path, true))
            {

                sw.Write(Environment.NewLine);
                //      System.IO.File.WriteAllText(@"C:/Users/Lewis/Desktop/files_150819/ttt_csharp_270719/Minimax_TPL/scoreboards.txt", string.Empty);
                for (int x = 1; x <= 60; x++)
                    sw.Write("  " + x + " ");
                sw.WriteLine();
                  for (int y = 1; y <= 60; y++)
                {
                    sw.Write(y + " ");
                    for (int x = 1; x <= 60; x++)
                    {
                        if (EqualityComparer<T>.Default.Equals(this[x, y], filler))
                            sw.Write(filler);
                        else
                            sw.Write(this[x, y]);
                        sw.Write(" | ");
                    }
                    sw.WriteLine();
                    sw.WriteLine("  -   -   -   -   -   -   - ");
                }
                sw.Write("^^ SCORE BOARD FOR BOARD " + Program.cntr);
                sw.WriteLine();
            }
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* IsFull -
--------------------------------------------------------------------------------------------------------------------------
This boolean method returns a true or false value confirming if the current board in play is full with no empty cells remaining.
--------------------------------------------------------------------------------------------------------------------------
*/
        // IF GameBoard_TPL IS FULL
        public bool IsFull(int size)
        {
            for (int x = 1; x <= size; x++)
                for (int y = 1; y <= size; y++)
                    if (EqualityComparer<T>.Default.Equals(this[x, y], filler))
                        return false;
            return true;
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* IsEmpty -
--------------------------------------------------------------------------------------------------------------------------
This boolean method returns a true or false value confirming if there any remaining empty cells in play on the current board.
--------------------------------------------------------------------------------------------------------------------------
*/
        public bool IsEmpty(int size)
        {
            for (int x = 1; x <= size; x++)
                for (int y = 1; y <= size; y++)
                    if (!EqualityComparer<T>.Default.Equals(this[x, y], filler))
                        return false;
            return true;
        }

        // CLONE A board OF THE CURRENT GAME BOARD
        /* 
----------------------------------------------------------------------------------------------------------------
* Clone -
--------------------------------------------------------------------------------------------------------------------------
This method makes a clone of the current board, either playing board (string) or score board (int).
--------------------------------------------------------------------------------------------------------------------------
*/
        public GameBoard_TPL<T> Clone()
        {
            GameBoard_TPL<T> g = new GameBoard_TPL<T>();
            for (int x = 1; x <= 60; x++)
                  for (int y = 1; y <= 60; y++)
                    g[x, y] = this[x,y];
            return g;
            
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* board[x,y] -> this[x,y] -
--------------------------------------------------------------------------------------------------------------------------
The method returns a coordinate position in an <int,int> format existing in the current board. 
--------------------------------------------------------------------------------------------------------------------------
*/
        public T this[int x, int y]
        {
            get
            {
                // Debug.Assert(1 <= x && x <= 3 && 1 <= y && y <= 3);
                /*
                if (!(1 <= x && x <= 7 && 1 <= y && y <= 7)) {
              Console.WriteLine("ERROR: illegal position on board: {0},{1}", x, y);
              Environment.Exit(98);
              // return counters.BORDER;
                }
                */
                if (x == 1 && y == 1)
                    return s1;
                if (x == 2 && y == 1)
                          return s2;
                      if (x == 3 && y == 1)
                          return s3;
                      if (x == 4 && y == 1)
                          return s4;
                      if (x == 5 && y == 1)
                          return s5;
                      if (x == 6 && y == 1)
                          return s6;
                      if (x == 7 && y == 1)
                          return s7;
                      if (x == 8 && y == 1)
                          return s8;
                      if (x == 9 && y == 1)
                          return s9;
                      if (x == 10 && y == 1)
                          return s10;
                      if (x == 11 && y == 1)
                          return s11;
                      if (x == 12 && y == 1)
                          return s12;
                      if (x == 13 && y == 1)
                          return s13;
                      if (x == 14 && y == 1)
                          return s14;
                      if (x == 15 && y == 1)
                          return s15;
                      if (x == 16 && y == 1)
                          return s16;
                      if (x == 17 && y == 1)
                          return s17;
                      if (x == 18 && y == 1)
                          return s18;
                      if (x == 19 && y == 1)
                          return s19;
                      if (x == 20 && y == 1)
                          return s20;
                      if (x == 21 && y == 1)
                          return s21;
                      if (x == 22 && y == 1)
                          return s22;                      
                      if (x == 23 && y == 1)
                          return s23;
                      if (x == 24 && y == 1)
                          return s24;
                      if (x == 25 && y == 1)
                          return s25;
                      if (x == 26 && y == 1)
                          return s26;
                      if (x == 27 && y == 1)
                          return s27;
                      if (x == 28 && y == 1)
                          return s28;
                      if (x == 29 && y == 1)
                          return s29;
                      if (x == 30 && y == 1)
                          return s30;
                      if (x == 31 && y == 1)
                          return s31;
                      if (x == 32 && y == 1)
                          return s32;
                      if (x == 33 && y == 1)
                          return s33;
                if (x == 34 && y == 1)
                    return s34;
                if (x == 35 && y == 1)
                    return s35;
                if (x == 36 && y == 1)
                    return s36;
                if (x == 37 && y == 1)
                    return s37;
                if (x == 38 && y == 1)
                    return s38;
                if (x == 39 && y == 1)
                    return s39;
                if (x == 40 && y == 1)
                    return s40;
                if (x == 41 && y == 1)
                    return s41;
                if (x == 42 && y == 1)
                    return s43;
                if (x == 43 && y == 1)
                    return s43;
                if (x == 44 && y == 1)
                    return s44;
                if (x == 45 && y == 1)
                    return s45;
                if (x == 46 && y == 1)
                    return s46;
                if (x == 47 && y == 1)
                    return s47;
                if (x == 48 && y == 1)
                    return s48;
                if (x == 49 && y == 1)
                    return s49;
                if (x == 50 && y == 1)
                    return s50;
                if (x == 51 && y == 1)
                    return s51;
                if (x == 52 && y == 1)
                    return s52;
                if (x == 53 && y == 1)
                    return s53;
                if (x == 54 && y == 1)
                    return s54;
                if (x == 55 && y == 1)
                    return s55;
                if (x == 56 && y == 1)
                    return s56;
                if (x == 57 && y == 1)
                    return s57;
                if (x == 58 && y == 1)
                    return s58;
                if (x == 59 && y == 1)
                    return s59;
                if (x == 60 && y == 1)
                    return s60;
                
                
                return filler;
            }
                  set
            {
                if (x == 1 && y == 1)
                     s1= value;
                if (x == 2 && y == 1)
                     s2= value;
                if (x == 3 && y == 1)
                     s3= value;
                if (x == 4 && y == 1)
                     s4= value;
                if (x == 5 && y == 1)
                     s5= value;
                if (x == 6 && y == 1)
                     s6= value;
                if (x == 7 && y == 1)
                     s7= value;
                if (x == 8 && y == 1)
                     s8= value;
                if (x == 9 && y == 1)
                     s9= value;
                if (x == 10 && y == 1)
                     s10= value;
                if (x == 11 && y == 1)
                     s11= value;
                if (x == 12 && y == 1)
                     s12= value;
                if (x == 13 && y == 1)
                     s13= value;
                if (x == 14 && y == 1)
                     s14= value;
                if (x == 15 && y == 1)
                     s15= value;
                if (x == 16 && y == 1)
                     s16= value;
                if (x == 17 && y == 1)
                     s17= value;
                if (x == 18 && y == 1)
                     s18= value;
                if (x == 19 && y == 1)
                     s19= value;
                if (x == 20 && y == 1)
                     s20= value;
                if (x == 21 && y == 1)
                     s21= value;
                if (x == 22 && y == 1)
                     s22= value;
                if (x == 23 && y == 1)
                     s23= value;
                if (x == 24 && y == 1)
                     s24= value;
                if (x == 25 && y == 1)
                     s25= value;
                if (x == 26 && y == 1)
                     s26= value;
                if (x == 27 && y == 1)
                     s27= value;
                if (x == 28 && y == 1)
                     s28= value;
                if (x == 29 && y == 1)
                     s29= value;
                if (x == 30 && y == 1)
                     s30= value;
                if (x == 31 && y == 1)
                     s31= value;
                if (x == 32 && y == 1)
                     s32= value;
                if (x == 33 && y == 1)
                     s33= value;
                if (x == 34 && y == 1)
                     s34= value;
                if (x == 35 && y == 1)
                     s35= value;
                if (x == 36 && y == 1)
                     s36= value;
                if (x == 37 && y == 1)
                     s37= value;
                if (x == 38 && y == 1)
                     s38= value;
                if (x == 39 && y == 1)
                     s39= value;
                if (x == 40 && y == 1)
                     s40= value;
                if (x == 41 && y == 1)
                     s41= value;
                if (x == 42 && y == 1)
                     s43= value;
                if (x == 43 && y == 1)
                     s43= value;
                if (x == 44 && y == 1)
                     s44= value;
                if (x == 45 && y == 1)
                     s45= value;
                if (x == 46 && y == 1)
                     s46= value;
                if (x == 47 && y == 1)
                     s47= value;
                if (x == 48 && y == 1)
                     s48= value;
                if (x == 49 && y == 1)
                     s49= value;
                if (x == 50 && y == 1)
                     s50= value;
                if (x == 51 && y == 1)
                     s51= value;
                if (x == 52 && y == 1)
                     s52= value;
                if (x == 53 && y == 1)
                     s53= value;
                if (x == 54 && y == 1)
                     s54= value;
                if (x == 55 && y == 1)
                     s55= value;
                if (x == 56 && y == 1)
                     s56= value;
                if (x == 57 && y == 1)
                     s57= value;
                if (x == 58 && y == 1)
                     s58= value;
                if (x == 59 && y == 1)
                     s59= value;
                if (x == 60 && y == 1)
                     s60= value;

            }
        }
              /* 
      ----------------------------------------------------------------------------------------------------------------
      * DisplayIntBoardToFile -
      --------------------------------------------------------------------------------------------------------------------------
      This method constructs the initial state of the board of the current board with the counter symbols
      in string format, which is then printed to a text file. 
      --------------------------------------------------------------------------------------------------------------------------
      */
                public void DisplayIntBoardToFile()
        {
            string path = @"data/intboards.txt";
            int number = Program.cntr;
            // ... Cases may not be duplicated.
            File.WriteAllText(@"data/intboards.txt", string.Empty);

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                switch (number)
                {
                    case 0:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e  | e | e |  O     | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 1:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e  | e | e |  O     | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 2:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | X | X | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 3:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | X | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | X | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 4:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | e | X | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e | e | e | X | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 5:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | X | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | O | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | O | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | X | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 6:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e | e |   X | X    | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e | e | e | X | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 7:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | e | O | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 8:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | X | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e | e | O | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 9:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | X | e | X |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e | e | O |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e | e | O |");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e | e | O |");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 10:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | e | X | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | e | X | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e | e | e | O | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e | e | O | O | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write("5  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | e | e | X | X  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 11:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | O | e | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | X | e |  e  | e | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 12:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | X | e  | e | e | X | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3 | X | e | O | e | O | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | e | O | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | O | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | e | X | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e | e | X | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 13:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | X | X | O | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | e |   X | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e | e | X | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 14:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | e | O | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | X | e | X | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | X | e | X | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 15:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | O | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 16:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | O | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 17:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | X | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | X | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 18:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 19:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | X | O | O | e | O | e | X |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | O | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | X | O | X | O | X | O | X |");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 20:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | X | O | O | e | O | e | X |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | O | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | X | O | X | O | X | O | X |");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 21:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | O | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 22:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | O |  O  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | O | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 23:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 24:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e | X | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e | e | e | O | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 25:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | O | O | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | X | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | O | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | X | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 26:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | O | e | O |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 27:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e | e | O | O | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e | e | e | O | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 28:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | e | X | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 29:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | e | X | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | O | e | e | X | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e | e | X | e | e | O | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 30:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | e | X | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | e | O | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 31:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | X | e | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e | e | X | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | O | e |  e  | e | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 32:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | O | e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3 | O | e | X | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | e | X | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | X | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | e | O | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 33:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | O | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e | e | X | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | O | O | X | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | e | O | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 34:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e | e | O | e | e | ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e | e | O | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e | e | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e | e | e | X | X | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | O | e | e | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | e | O | O | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | O | e | O | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 35:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e | O | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | X | O | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 36:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | X | O | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 37:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e | e | e | X | e | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 38:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2   | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5  | e |  e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 39:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | O | X | X  | e | X | e | O |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | X | e  | e |  e  | e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | O | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | X | e |  e  | e |  e  | e | e |  ");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | O | X |O  | X | O | X | O |");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    case 40:
                        sw.Write("see below");
                        sw.Write(Environment.NewLine); sw.Write("  1   2   3   4   5   6   7  ");
                        sw.Write(Environment.NewLine);
                        sw.Write("1 | O | X | X | O | X | O | O  |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("2 | X | e  | e |  e  | e | e | O |");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("3 | O | e |  e  | e | e | e | X |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("4 | X | e |  e  | e | e | e | O |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("5 | O | e |  e  | e | e | e | X |");
                        sw.Write(Environment.NewLine);
                        sw.Write("- - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("6 | X | e |  e  | e | e | e | X |");
                        sw.Write(Environment.NewLine);
                        sw.Write(" - - - - - - -");
                        sw.Write(Environment.NewLine);
                        sw.Write("7 | O | X |O  | X | O | X | O |");
                        sw.Write(Environment.NewLine); sw.Write("^^ INT BOARD FOR BOARD " + Program.cntr);
                        sw.Write(Environment.NewLine);
                        return;
                    default:
                        Environment.Exit(99);
                        break;
                }
            }
        }
    }
}
