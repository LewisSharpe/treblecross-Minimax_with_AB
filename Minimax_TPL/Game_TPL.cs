using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minimax_TPL
{
    /* 
    ----------------------------------------------------------------------------------------------------------------
     * Game_TPL.CS -
    --------------------------------------------------------------------------------------------------------------------------
    Class controls flow of order of execution in the gameplay.
    --------------------------------------------------------------------------------------------------------------------------
    */
    class Game_TPL
    {
        // PUBLIC DECS      
        Process proc = Process.GetCurrentProcess();
        public static int nowcount = 0;
        bool stopMe = false;
        public static Stopwatch game_timer;
        public static GameBoard_TPL<counters> board = new GameBoard_TPL<counters>(counters.e);
        public static GameBoard_TPL<int> scoreBoard = new GameBoard_TPL<int>(21);
        public static GameBoard_TPL<counters> initial_board;
        static counters counter = counters.X; // initialise current counter
        static counters startingCounter; // state what was the initial starting counter in gameplay
        counters us = Flip(counter);
        private static Object ID_LOCK = new Object(); // lock to protect file update
        /* 
-------------------------------------------------------------------------------------------------------------------------
* Game constructor -
--------------------------------------------------------------------------------------------------------------------------
*/
        public Game_TPL(Player_TPL _xPlayer, Player_TPL _oPlayer)
        {
            if (Program.cntr == 1)
            {
                //File.WriteAllText(@"data/intboards.txt", string.Empty);
                //File.WriteAllText(@"data/finboards.txt", string.Empty);
                //File.WriteAllText(@"data/scoreboards.txt", string.Empty);
                //File.WriteAllText(@"data/TPLTST_Report.csv", string.Empty);
                //File.WriteAllText(@"data/printresult_stream.txt", string.Empty);
                // HWL: header for output to console
                lock (ID_LOCK)
                {
                    Console.WriteLine(" -*- outline -*- ");
                    Console.WriteLine("* LOG ");
                    Console.WriteLine("#### GAME START TIME: {0} ", DateTime.Now); // display start of game execution on the current board in play
                }
            }
            /* 
----------------------------------------------------------------------------------------------------------------
* skip to board x -
--------------------------------------------------------------------------------------------------------------------------
Jump to board x on start-up if Game board Program.cntr is 1.
--------------------------------------------------------------------------------------------------------------------------
*/
    //        if (Program.cntr == 1) Program.cntr = 3; // HWL: jump to board 7
             PlayGame(_xPlayer, _oPlayer, ref Program.cntr);
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* PlayGame -
--------------------------------------------------------------------------------------------------------------------------
The method runs the execution of the entire game, iterating the starting board each time. 
--------------------------------------------------------------------------------------------------------------------------
*/
        public void PlayGame(Player_TPL currentPlayer, Player_TPL otherPlayer, ref int cntr)
        {
	    Tuple<int, int> expectedMove = new Tuple<int, int>(2, 2);
	    // Create new stopwatch.
            Stopwatch stopwatch_minimax = new Stopwatch();
            // Begin timing.
            stopwatch_minimax.Start();
            switch (Program.cntr)
            {
                case 1:
                    startingCounter = counters.X; // state starting counter of gameplay
                    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.e; board[2, 1] = counters.e; board[3, 1] = counters.e; board[4, 1] = counters.e; board[5, 1] = counters.e; board[6, 1] = counters.e; board[7, 1] = counters.e; board[8, 1] = counters.e; board[9, 1] = counters.e; board[10, 1] = counters.e; board[11, 1] = counters.e;
                    board[12, 1] = counters.e; board[13, 1] = counters.e; board[14, 1] = counters.e; board[15, 1] = counters.e; board[16, 1] = counters.e; board[17, 1] = counters.e; board[18, 1] = counters.e; board[19, 1] = counters.e; board[20, 1] = counters.e; board[21, 1] = counters.e; board[22, 1] = counters.e;
                    board[23, 1] = counters.X; board[24, 1] = counters.X; board[25, 1] = counters.e; board[26, 1] = counters.e; board[27, 1] = counters.e; board[28, 1] = counters.e; board[29, 1] = counters.e; board[30, 1] = counters.e; board[31, 1] = counters.e; board[32, 1] = counters.e; board[33, 1] = counters.e;
                    board[34, 1] = counters.e; board[35, 1] = counters.e; board[36, 1] = counters.e; board[40, 1] = counters.e; board[41, 1] = counters.e; board[42, 1] = counters.e; board[43, 1] = counters.e; board[44, 1] = counters.e; board[45, 1] = counters.e; board[46, 1] = counters.e; board[47, 1] = counters.e;
                    board[48, 1] = counters.e; board[49, 1] = counters.e; board[50, 1] = counters.e; board[51, 1] = counters.e; board[52, 1] = counters.e; board[53, 1] = counters.e; board[54, 1] = counters.e; board[55, 1] = counters.e; board[56, 1] = counters.e; board[57, 1] = counters.e; board[58, 1] = counters.e;
                    board[59, 1] = counters.e; board[60, 1] = counters.e; 
                    break;
                case 2:
startingCounter = counters.X; // state starting counter of gameplay
		    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.e; board[2, 1] = counters.e; board[3, 1] = counters.e; board[4, 1] = counters.e; board[5, 1] = counters.e; board[6, 1] = counters.e; board[7, 1] = counters.e; board[8, 1] = counters.e; board[9, 1] = counters.e; board[10, 1] = counters.e; board[11, 1] = counters.e;
                    board[12, 1] = counters.e; board[13, 1] = counters.e; board[14, 1] = counters.e; board[15, 1] = counters.e; board[16, 1] = counters.e; board[17, 1] = counters.e; board[18, 1] = counters.e; board[19, 1] = counters.e; board[20, 1] = counters.e; board[21, 1] = counters.e; board[22, 1] = counters.e;
                    board[23, 1] = counters.e; board[24, 1] = counters.e; board[25, 1] = counters.e; board[26, 1] = counters.e; board[27, 1] = counters.e; board[28, 1] = counters.e; board[29, 1] = counters.e; board[30, 1] = counters.e; board[31, 1] = counters.e; board[32, 1] = counters.e; board[33, 1] = counters.e;
                    board[34, 1] = counters.e; board[35, 1] = counters.e; board[36, 1] = counters.e; board[40, 1] = counters.e; board[41, 1] = counters.e; board[42, 1] = counters.e; board[43, 1] = counters.e; board[44, 1] = counters.e; board[45, 1] = counters.e; board[46, 1] = counters.e; board[47, 1] = counters.e;
                    board[48, 1] = counters.X; board[49, 1] = counters.e; board[50, 1] = counters.X; board[51, 1] = counters.e; board[52, 1] = counters.e; board[53, 1] = counters.e; board[54, 1] = counters.e; board[55, 1] = counters.e; board[56, 1] = counters.e; board[57, 1] = counters.e; board[58, 1] = counters.e;
                    board[59, 1] = counters.e; board[60, 1] = counters.e;
                    break;
                case 3:            
                    startingCounter = counters.X; // state starting counter of gameplay
                    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.e; board[2, 1] = counters.e; board[3, 1] = counters.e; board[4, 1] = counters.e; board[5, 1] = counters.e; board[6, 1] = counters.e; board[7, 1] = counters.e; board[8, 1] = counters.e; board[9, 1] = counters.e; board[10, 1] = counters.e; board[11, 1] = counters.e;
                    board[12, 1] = counters.e; board[13, 1] = counters.e; board[14, 1] = counters.e; board[15, 1] = counters.e; board[16, 1] = counters.e; board[17, 1] = counters.e; board[18, 1] = counters.e; board[19, 1] = counters.e; board[20, 1] = counters.e; board[21, 1] = counters.e; board[22, 1] = counters.e;
                    board[23, 1] = counters.e; board[24, 1] = counters.e; board[25, 1] = counters.X; board[26, 1] = counters.X; board[27, 1] = counters.e; board[28, 1] = counters.X; board[29, 1] = counters.e; board[30, 1] = counters.e; board[31, 1] = counters.e; board[32, 1] = counters.e; board[33, 1] = counters.e;
                    board[34, 1] = counters.e; board[35, 1] = counters.e; board[36, 1] = counters.e; board[40, 1] = counters.e; board[41, 1] = counters.e; board[42, 1] = counters.e; board[43, 1] = counters.e; board[44, 1] = counters.e; board[45, 1] = counters.e; board[46, 1] = counters.e; board[47, 1] = counters.e;
                    board[48, 1] = counters.e; board[49, 1] = counters.e; board[50, 1] = counters.e; board[51, 1] = counters.e; board[52, 1] = counters.e; board[53, 1] = counters.e; board[54, 1] = counters.e; board[55, 1] = counters.e; board[56, 1] = counters.e; board[57, 1] = counters.e; board[58, 1] = counters.e;
                    board[59, 1] = counters.e; board[60, 1] = counters.e;
                    break;
                case 4:
                    startingCounter = counters.X; // state starting counter of gameplay
                    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.X; board[2, 1] = counters.e; board[3, 1] = counters.X; board[4, 1] = counters.N; board[5, 1] = counters.N; board[6, 1] = counters.N; board[7, 1] = counters.N; board[8, 1] = counters.N; board[9, 1] = counters.N; board[10, 1] = counters.N; board[11, 1] = counters.N;
                    board[12, 1] = counters.N; board[13, 1] = counters.N; board[14, 1] = counters.N; board[15, 1] = counters.N; board[16, 1] = counters.N; board[17, 1] = counters.N; board[18, 1] = counters.N; board[19, 1] = counters.N; board[20, 1] = counters.N; board[21, 1] = counters.N; board[22, 1] = counters.N;
                    board[23, 1] = counters.N; board[24, 1] = counters.N; board[25, 1] = counters.N; board[26, 1] = counters.N; board[27, 1] = counters.N; board[28, 1] = counters.N; board[29, 1] = counters.N; board[30, 1] = counters.N; board[31, 1] = counters.N; board[32, 1] = counters.N; board[33, 1] = counters.N;
                    board[34, 1] = counters.N; board[35, 1] = counters.N; board[36, 1] = counters.N; board[40, 1] = counters.N; board[41, 1] = counters.N; board[42, 1] = counters.N; board[43, 1] = counters.N; board[44, 1] = counters.N; board[45, 1] = counters.N; board[46, 1] = counters.N; board[47, 1] = counters.N;
                    board[48, 1] = counters.N; board[49, 1] = counters.N; board[50, 1] = counters.N; board[51, 1] = counters.N; board[52, 1] = counters.N; board[53, 1] = counters.N; board[54, 1] = counters.N; board[55, 1] = counters.N; board[56, 1] = counters.N; board[57, 1] = counters.N; board[58, 1] = counters.N;
                    board[59, 1] = counters.N; board[60, 1] = counters.N;
                    break;
                case 5:
                    startingCounter = counters.X; // state starting counter of gameplay
                    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.e; board[2, 1] = counters.e; board[3, 1] = counters.e; board[4, 1] = counters.e; board[5, 1] = counters.e; board[6, 1] = counters.e; board[7, 1] = counters.e; board[8, 1] = counters.e; board[9, 1] = counters.e; board[10, 1] = counters.e; board[11, 1] = counters.e;
                    board[12, 1] = counters.e; board[13, 1] = counters.e; board[14, 1] = counters.e; board[15, 1] = counters.e; board[16, 1] = counters.e; board[17, 1] = counters.e; board[18, 1] = counters.e; board[19, 1] = counters.e; board[20, 1] = counters.e; board[21, 1] = counters.e; board[22, 1] = counters.e;
                    board[23, 1] = counters.e; board[24, 1] = counters.e; board[25, 1] = counters.e; board[26, 1] = counters.e; board[27, 1] = counters.e; board[28, 1] = counters.e; board[29, 1] = counters.e; board[30, 1] = counters.e; board[31, 1] = counters.e; board[32, 1] = counters.e; board[33, 1] = counters.e;
                    board[34, 1] = counters.e; board[35, 1] = counters.e; board[36, 1] = counters.e; board[40, 1] = counters.e; board[41, 1] = counters.e; board[42, 1] = counters.e; board[43, 1] = counters.e; board[44, 1] = counters.e; board[45, 1] = counters.e; board[46, 1] = counters.e; board[47, 1] = counters.e;
                    board[48, 1] = counters.e; board[49, 1] = counters.e; board[50, 1] = counters.e; board[51, 1] = counters.e; board[52, 1] = counters.e; board[53, 1] = counters.e; board[54, 1] = counters.e; board[55, 1] = counters.e; board[56, 1] = counters.e; board[57, 1] = counters.e; board[58, 1] = counters.e;
                    board[59, 1] = counters.e; board[60, 1] = counters.e;
                    break;
                case 6:
                    startingCounter = counters.X; // state starting counter of gameplay
                    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.e; board[2, 1] = counters.e; board[3, 1] = counters.e; board[4, 1] = counters.e; board[5, 1] = counters.e; board[6, 1] = counters.e; board[7, 1] = counters.e; board[8, 1] = counters.e; board[9, 1] = counters.e; board[10, 1] = counters.e; board[11, 1] = counters.e;
                    board[12, 1] = counters.e; board[13, 1] = counters.e; board[14, 1] = counters.e; board[15, 1] = counters.e; board[16, 1] = counters.e; board[17, 1] = counters.e; board[18, 1] = counters.e; board[19, 1] = counters.e; board[20, 1] = counters.e; board[21, 1] = counters.e; board[22, 1] = counters.e;
                    board[23, 1] = counters.e; board[24, 1] = counters.e; board[25, 1] = counters.e; board[26, 1] = counters.e; board[27, 1] = counters.e; board[28, 1] = counters.e; board[29, 1] = counters.e; board[30, 1] = counters.e; board[31, 1] = counters.e; board[32, 1] = counters.e; board[33, 1] = counters.e;
                    board[34, 1] = counters.e; board[35, 1] = counters.e; board[36, 1] = counters.e; board[40, 1] = counters.e; board[41, 1] = counters.e; board[42, 1] = counters.e; board[43, 1] = counters.e; board[44, 1] = counters.e; board[45, 1] = counters.e; board[46, 1] = counters.e; board[47, 1] = counters.e;
                    board[48, 1] = counters.e; board[49, 1] = counters.e; board[50, 1] = counters.e; board[51, 1] = counters.e; board[52, 1] = counters.e; board[53, 1] = counters.e; board[54, 1] = counters.e; board[55, 1] = counters.e; board[56, 1] = counters.e; board[57, 1] = counters.e; board[58, 1] = counters.e;
                    board[59, 1] = counters.e; board[60, 1] = counters.e;
                    break;
                case 7:
                    startingCounter = counters.X; // state starting counter of gameplay
                    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.X; board[2, 1] = counters.e; board[3, 1] = counters.e; board[4, 1] = counters.e; board[5, 1] = counters.e; board[6, 1] = counters.e; board[7, 1] = counters.e; board[8, 1] = counters.e; board[9, 1] = counters.e; board[10, 1] = counters.e; board[11, 1] = counters.e; board[12, 1] = counters.e; board[13, 1] = counters.e; board[14, 1] = counters.e; board[15, 1] = counters.e;
                    board[1, 2] = counters.X; board[2, 2] = counters.e; board[3, 2] = counters.e; board[4, 2] = counters.e; board[5, 2] = counters.e; board[6, 2] = counters.e; board[7, 2] = counters.e; board[8, 2] = counters.e; board[9, 2] = counters.e; board[10, 2] = counters.e; board[11, 2] = counters.e; board[12, 2] = counters.e; board[13, 2] = counters.e; board[14, 2] = counters.e; board[15, 2] = counters.e;
                    board[1, 3] = counters.X; board[2, 3] = counters.e; board[3, 3] = counters.e; board[4, 3] = counters.e; board[5, 3] = counters.e; board[6, 3] = counters.e; board[7, 3] = counters.e; board[8, 3] = counters.e; board[9, 3] = counters.e; board[10, 3] = counters.e; board[11, 3] = counters.e; board[12, 3] = counters.e; board[13, 3] = counters.e; board[14, 3] = counters.e; board[15, 3] = counters.e;
                    board[1, 4] = counters.X; board[2, 4] = counters.e; board[3, 4] = counters.e; board[4, 4] = counters.e; board[5, 4] = counters.e; board[6, 4] = counters.e; board[7, 4] = counters.e; board[8, 4] = counters.e; board[9, 4] = counters.e; board[10, 4] = counters.e; board[11, 4] = counters.e; board[12, 4] = counters.e; board[13, 4] = counters.e; board[14, 4] = counters.e; board[15, 4] = counters.e;
                    board[1, 5] = counters.e; board[2, 5] = counters.e; board[3, 5] = counters.e; board[4, 5] = counters.e; board[5, 5] = counters.e; board[6, 5] = counters.e; board[7, 5] = counters.e; board[8, 5] = counters.e; board[9, 5] = counters.e; board[10, 5] = counters.e; board[11, 5] = counters.e; board[12, 5] = counters.e; board[13, 5] = counters.e; board[14, 5] = counters.e; board[15, 5] = counters.e;
                    board[1, 6] = counters.X; board[2, 6] = counters.e; board[3, 6] = counters.e; board[4, 6] = counters.e; board[5, 6] = counters.e; board[6, 6] = counters.e; board[7, 6] = counters.e; board[8, 6] = counters.e; board[9, 6] = counters.e; board[10, 6] = counters.e; board[11, 6] = counters.e; board[12, 6] = counters.e; board[13, 6] = counters.e; board[14, 6] = counters.e; board[15, 6] = counters.e;
                    board[1, 7] = counters.e; board[2, 7] = counters.e; board[3, 7] = counters.e; board[4, 7] = counters.e; board[5, 7] = counters.e; board[6, 7] = counters.e; board[7, 7] = counters.e; board[8, 7] = counters.e; board[9, 7] = counters.e; board[10, 7] = counters.e; board[11, 7] = counters.e; board[12, 7] = counters.e; board[13, 7] = counters.e; board[14, 7] = counters.e; board[15, 7] = counters.e;
                    board[1, 8] = counters.e; board[2, 8] = counters.e; board[3, 8] = counters.e; board[4, 8] = counters.e; board[5, 8] = counters.e; board[6, 8] = counters.e; board[7, 8] = counters.e; board[8, 8] = counters.e; board[9, 8] = counters.e; board[10, 8] = counters.e; board[11, 8] = counters.e; board[12, 8] = counters.e; board[13, 8] = counters.e; board[14, 8] = counters.e; board[15, 8] = counters.e;
                    board[1, 9] = counters.e; board[2, 9] = counters.e; board[3, 9] = counters.e; board[4, 9] = counters.e; board[5, 9] = counters.e; board[6, 9] = counters.e; board[7, 9] = counters.e; board[8, 9] = counters.e; board[9, 9] = counters.e; board[10, 9] = counters.e; board[11, 9] = counters.e; board[12, 9] = counters.e; board[13, 9] = counters.e; board[14, 9] = counters.e; board[15, 9] = counters.e;
                    board[1, 10] = counters.e; board[2, 10] = counters.e; board[3, 10] = counters.e; board[4, 10] = counters.e; board[5, 10] = counters.e; board[6, 10] = counters.e; board[7, 10] = counters.e; board[8, 10] = counters.e; board[9, 10] = counters.e; board[10, 10] = counters.e; board[11, 10] = counters.e; board[12, 10] = counters.e; board[13, 10] = counters.e; board[14, 10] = counters.e; board[15, 10] = counters.e;
                    board[1, 11] = counters.e; board[2, 11] = counters.e; board[3, 11] = counters.e; board[4, 11] = counters.e; board[5, 11] = counters.e; board[6, 11] = counters.e; board[7, 11] = counters.e; board[8, 11] = counters.e; board[9, 11] = counters.e; board[10, 11] = counters.e; board[11, 11] = counters.e; board[12, 11] = counters.e; board[13, 11] = counters.e; board[14, 11] = counters.e; board[15, 11] = counters.e;
                    board[1, 12] = counters.X; board[2, 12] = counters.e; board[3, 12] = counters.e; board[4, 12] = counters.e; board[5, 12] = counters.e; board[6, 12] = counters.e; board[7, 12] = counters.e; board[8, 12] = counters.e; board[9, 12] = counters.e; board[10, 12] = counters.e; board[11, 12] = counters.e; board[12, 12] = counters.e; board[13, 12] = counters.e; board[14, 12] = counters.e; board[15, 12] = counters.e;
                    board[1, 13] = counters.X; board[2, 13] = counters.e; board[3, 13] = counters.e; board[4, 13] = counters.e; board[5, 13] = counters.e; board[6, 13] = counters.e; board[7, 13] = counters.e; board[8, 13] = counters.e; board[9, 13] = counters.e; board[10, 13] = counters.e; board[11, 13] = counters.e; board[12, 13] = counters.e; board[13, 13] = counters.e; board[14, 13] = counters.e; board[15, 13] = counters.e;
                    board[1, 14] = counters.X; board[2, 14] = counters.e; board[3, 14] = counters.e; board[4, 14] = counters.e; board[5, 14] = counters.e; board[6, 14] = counters.e; board[7, 14] = counters.e; board[8, 14] = counters.e; board[9, 14] = counters.e; board[10, 14] = counters.e; board[11, 14] = counters.e; board[12, 14] = counters.e; board[13, 14] = counters.e; board[14, 14] = counters.e; board[15, 14] = counters.e;
                    board[1, 15] = counters.X; board[2, 15] = counters.e; board[3, 15] = counters.e; board[4, 15] = counters.e; board[5, 15] = counters.e; board[6, 15] = counters.e; board[7, 15] = counters.e; board[8, 15] = counters.e; board[9, 15] = counters.e; board[10, 15] = counters.e; board[11, 15] = counters.e; board[12, 15] = counters.e; board[13, 15] = counters.e; board[14, 15] = counters.e; board[15, 15] = counters.e;
                    break;
                case 8:
                    startingCounter = counters.X; // state starting counter of gameplay
                    currentPlayer.counter = counters.X; // HWL: set the current player here as well
                    board[1, 1] = counters.X; board[2, 1] = counters.X; board[3, 1] = counters.X; board[4, 1] = counters.X; board[5, 1] = counters.e; board[6, 1] = counters.e; board[7, 1] = counters.e; board[8, 1] = counters.e; board[9, 1] = counters.e; board[10, 1] = counters.e; board[11, 1] = counters.e; board[12, 1] = counters.e; board[13, 1] = counters.e; board[14, 1] = counters.e; board[15, 1] = counters.e;
                    board[1, 2] = counters.X; board[2, 2] = counters.e; board[3, 2] = counters.e; board[4, 2] = counters.e; board[5, 2] = counters.e; board[6, 2] = counters.e; board[7, 2] = counters.e; board[8, 2] = counters.e; board[9, 2] = counters.e; board[10, 2] = counters.e; board[11, 2] = counters.e; board[12, 2] = counters.e; board[13, 2] = counters.e; board[14, 2] = counters.e; board[15, 2] = counters.e;
                    board[1, 3] = counters.X; board[2, 3] = counters.e; board[3, 3] = counters.e; board[4, 3] = counters.e; board[5, 3] = counters.e; board[6, 3] = counters.e; board[7, 3] = counters.e; board[8, 3] = counters.e; board[9, 3] = counters.e; board[10, 3] = counters.e; board[11, 3] = counters.e; board[12, 3] = counters.e; board[13, 3] = counters.e; board[14, 3] = counters.e; board[15, 3] = counters.e;
                    board[1, 4] = counters.X; board[2, 4] = counters.e; board[3, 4] = counters.e; board[4, 4] = counters.e; board[5, 4] = counters.e; board[6, 4] = counters.e; board[7, 4] = counters.e; board[8, 4] = counters.e; board[9, 4] = counters.e; board[10, 4] = counters.e; board[11, 4] = counters.e; board[12, 4] = counters.e; board[13, 4] = counters.e; board[14, 4] = counters.e; board[15, 4] = counters.e;
                    board[1, 5] = counters.e; board[2, 5] = counters.e; board[3, 5] = counters.e; board[4, 5] = counters.e; board[5, 5] = counters.e; board[6, 5] = counters.e; board[7, 5] = counters.e; board[8, 5] = counters.e; board[9, 5] = counters.e; board[10, 5] = counters.e; board[11, 5] = counters.e; board[12, 5] = counters.e; board[13, 5] = counters.e; board[14, 5] = counters.e; board[15, 5] = counters.e;
                    board[1, 6] = counters.e; board[2, 6] = counters.e; board[3, 6] = counters.e; board[4, 6] = counters.e; board[5, 6] = counters.e; board[6, 6] = counters.e; board[7, 6] = counters.e; board[8, 6] = counters.e; board[9, 6] = counters.e; board[10, 6] = counters.e; board[11, 6] = counters.e; board[12, 6] = counters.e; board[13, 6] = counters.e; board[14, 6] = counters.e; board[15, 6] = counters.e;
                    board[1, 7] = counters.e; board[2, 7] = counters.e; board[3, 7] = counters.e; board[4, 7] = counters.e; board[5, 7] = counters.e; board[6, 7] = counters.e; board[7, 7] = counters.e; board[8, 7] = counters.e; board[9, 7] = counters.e; board[10, 7] = counters.e; board[11, 7] = counters.e; board[12, 7] = counters.e; board[13, 7] = counters.e; board[14, 7] = counters.e; board[15, 7] = counters.e;
                    board[1, 8] = counters.e; board[2, 8] = counters.e; board[3, 8] = counters.e; board[4, 8] = counters.e; board[5, 8] = counters.e; board[6, 8] = counters.e; board[7, 8] = counters.e; board[8, 8] = counters.e; board[9, 8] = counters.e; board[10, 8] = counters.e; board[11, 8] = counters.e; board[12, 8] = counters.e; board[13, 8] = counters.e; board[14, 8] = counters.e; board[15, 8] = counters.e;
                    board[1, 9] = counters.e; board[2, 9] = counters.e; board[3, 9] = counters.e; board[4, 9] = counters.e; board[5, 9] = counters.e; board[6, 9] = counters.e; board[7, 9] = counters.e; board[8, 9] = counters.e; board[9, 9] = counters.e; board[10, 9] = counters.e; board[11, 9] = counters.e; board[12, 9] = counters.e; board[13, 9] = counters.e; board[14, 9] = counters.e; board[15, 9] = counters.e;
                    board[1, 10] = counters.e; board[2, 10] = counters.e; board[3, 10] = counters.e; board[4, 10] = counters.e; board[5, 10] = counters.e; board[6, 10] = counters.e; board[7, 10] = counters.e; board[8, 10] = counters.e; board[9, 10] = counters.e; board[10, 10] = counters.e; board[11, 10] = counters.e; board[12, 10] = counters.e; board[13, 10] = counters.e; board[14, 10] = counters.e; board[15, 10] = counters.e;
                    board[1, 11] = counters.e; board[2, 11] = counters.e; board[3, 11] = counters.e; board[4, 11] = counters.e; board[5, 11] = counters.e; board[6, 11] = counters.e; board[7, 11] = counters.e; board[8, 11] = counters.e; board[9, 11] = counters.e; board[10, 11] = counters.e; board[11, 11] = counters.e; board[12, 11] = counters.e; board[13, 11] = counters.e; board[14, 11] = counters.e; board[15, 11] = counters.e;
                    board[1, 12] = counters.e; board[2, 12] = counters.e; board[3, 12] = counters.e; board[4, 12] = counters.e; board[5, 12] = counters.e; board[6, 12] = counters.e; board[7, 12] = counters.e; board[8, 12] = counters.e; board[9, 12] = counters.e; board[10, 12] = counters.e; board[11, 12] = counters.e; board[12, 12] = counters.e; board[13, 12] = counters.e; board[14, 12] = counters.e; board[15, 12] = counters.e;
                    board[1, 13] = counters.e; board[2, 13] = counters.e; board[3, 13] = counters.e; board[4, 13] = counters.e; board[5, 13] = counters.e; board[6, 13] = counters.e; board[7, 13] = counters.e; board[8, 13] = counters.e; board[9, 13] = counters.e; board[10, 13] = counters.e; board[11, 13] = counters.e; board[12, 13] = counters.e; board[13, 13] = counters.e; board[14, 13] = counters.e; board[15, 13] = counters.e;
                    board[1, 14] = counters.e; board[2, 14] = counters.e; board[3, 14] = counters.e; board[4, 14] = counters.e; board[5, 14] = counters.e; board[6, 14] = counters.e; board[7, 14] = counters.e; board[8, 14] = counters.e; board[9, 14] = counters.e; board[10, 14] = counters.e; board[11, 14] = counters.e; board[12, 14] = counters.e; board[13, 14] = counters.e; board[14, 14] = counters.e; board[15, 14] = counters.e;
                    board[1, 15] = counters.e; board[2, 15] = counters.e; board[3, 15] = counters.e; board[4, 15] = counters.e; board[5, 15] = counters.e; board[6, 15] = counters.e; board[7, 15] = counters.e; board[8, 15] = counters.e; board[9, 15] = counters.e; board[10, 15] = counters.e; board[11, 15] = counters.e; board[12, 15] = counters.e; board[13, 15] = counters.e; board[14, 15] = counters.e; board[15, 15] = counters.e;
                    break;
                default:
                    Environment.Exit(99);
                    break;
            }

            { // HWL: main loop of running the game now here, rather than in GetMove()
                game_timer = Stopwatch.StartNew();
                int move = 0;
                int numTasks = 4;
                Tuple<int, Tuple<int, int>> bestRes;
                Tuple<int, int> bestMove;
                int bestScore;
                lock (ID_LOCK)
                {
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("** HWL: Running board {0} ", Program.cntr);
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("++LS Starting counter of game on Board " + Program.cntr + " was: " + startingCounter);
                }
                initial_board = board.Clone();
                board.DisplayBoard();
                counter = currentPlayer.counter;
                for (int i = 0; i < 40; i++)
                {
                    do
                    {
                        move++;
                        // parallel version needs to call the ParSearchWrapper
                        // bestRes = ParSearchWrap(board, counter, numTasks, scoreBoard, ref move);
                        // seq version
                        bestMove = currentPlayer.GetMove(board, counter, scoreBoard);
                        // bestScore = bestRes.Item1;
                        // bestMove  = bestRes.Item2;
                        // place the current piece
                 //     Debug.Assert(board[bestMove.Item1, bestMove.Item2] == counters.X || board[bestMove.Item1, bestMove.Item2] == counters.X);
                        board[bestMove.Item1, bestMove.Item2] = counter;
                        // opponent's turn
                        counter = Flip(counter);
                        if (IsOver(board, currentPlayer))
                        {
                            lock (ID_LOCK)
                            {
                                Console.WriteLine("++LS Starting counter of game on Board " + Program.cntr + " was: " + startingCounter);
                                Console.WriteLine("=========================================================================================================");
                                Console.WriteLine("-- Winning notification for Board " + Program.cntr + " :");
                                Console.WriteLine("=========================================================================================================");
                                Console.WriteLine(Program.no_of_cores_for_parallelism + "**CORES-- Game result: WINNER on Board " + Program.cntr + " is: counter " + counter + " with winning position " + new Tuple<int, int>(bestMove.Item1, bestMove.Item2));
                                Console.WriteLine(Program.no_of_cores_for_parallelism + "**CORES-- LS Elapsed game time: " + game_timer.Elapsed);
                                Console.WriteLine(Program.no_of_cores_for_parallelism + "**CORES-- Move" + move + " LS Memory consumption: " + proc.PrivateMemorySize64 + "bytes");
                                Console.WriteLine(Program.no_of_cores_for_parallelism + "**CORES-- Move" + move + " LS Garbage collection memory: {0}", GC.GetTotalMemory(false) + " bytes.");
                                Console.WriteLine(Program.no_of_cores_for_parallelism + "**CORES-- Move" + move + " LS Number of Garbage collection items: {0}", AIPlayer_TPL.mem2 + " items.");
                                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("-- Expected result on Board " + Program.cntr + " is: " + expectedMove + " with counter " + counter);
                                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("++ Initial starting board: ");
                                Game_TPL.initial_board.DisplayBoard();
                                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("========================================================================================================" + Environment.NewLine);
                            }
                                Environment.Exit(99);
                            /*
         ----------------------------------------------------------------------------------------------------------------
         if current board is finished, move on to next board in case sequence until no boards are left existing
         --------------------------------------------------------------------------------------------------------------------------
         */
         
                            i++;
                            if (i > 2 && i< 40) return;
                      //      Program.cntr++;
                            AIPlayer_TPL.move_addition.Clear(); // clear the list of made moves on current board
                            AIPlayer_TPL.all_Oplacedmoves.Clear();
                            AIPlayer_TPL.all_Xplacedmoves.Clear();
                            PlayGame(currentPlayer, otherPlayer, ref Program.cntr);
                            lock (ID_LOCK)
                            {
                                Console.WriteLine("========================================================================================================" + Environment.NewLine);
                            }
        /* 
        ----------------------------------------------------------------------------------------------------------------
        --------------------------------------------------------------------------------------------------------------------------
        */
                        }
                
                    }
                    while (!currentPlayer.Win(board, Flip(counter)) && !otherPlayer.Win(board, counter) && !board.IsFull(3));
                }

            }
            game_timer.Stop();
            return;
        }
        /* 
      ----------------------------------------------------------------------------------------------------------------
      * IsOver -
      --------------------------------------------------------------------------------------------------------------------------
      This boolean dictates wherever if there is win on the current board, and if not the search will continue.
      --------------------------------------------------------------------------------------------------------------------------
      */
        public static bool IsOver(GameBoard_TPL<counters> board, Player_TPL currentPlayer)
        {
            if (currentPlayer.Win(board, currentPlayer.counter) || board.IsFull(3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            /* 
                  ----------------------------------------------------------------------------------------------------------------
                  * Flip -
                  --------------------------------------------------------------------------------------------------------------------------
                  Construct flips the counter have each turn of play.
                  --------------------------------------------------------------------------------------------------------------------------
                  */
            public static counters Flip(counters counter)
        {
            if (counter == counters.X)
            {
                return counters.X;
            }
            else
            {
                return counters.X;
            }
        }
    }
}
