using System;

namespace yedek
{
    class Program
    {
        static char[,] board = {{'O','O','O','.','.','.','.','.'},
                             {'O','O','O','.','.','.','.','.'},
                             {'O','O','O','.','.','.','.','.'},
                             {'.','.','.','.','.','.','.','.'},
                             {'.','.','.','.','.','.','.','.'},
                             {'.','.','.','.','.','X','X','X'},
                             {'.','.','.','.','.','X','X','X'},
                             {'.','.','.','.','.','X','X','X'}};

        static int cursorx = 12;
        static int cursory = 7;
        static int boardindexX = 5;
        static int boardindexY = 5;
        static int round = 1;
        static char turn = 'X';

        static bool flag = true;
        static bool flag2;
        static bool flagO;
        static bool jump = true;
        static byte counter;
        static void Main(string[] args)
        {

            Board(cursorx, cursory);
            while (flag)
            {
                turn = 'X';
                Board(cursorx, cursory);

                counter = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 'X')
                        {
                            counter++;
                            if (counter == 9)
                            {
                                flag = false;
                                Console.SetCursorPosition(23, 6);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("THE WINNER: X");
                            }
                        }
                    }
                }
                if (flag == false)
                    break;

                counter = 0;
                for (int i = 5; i < 8; i++)
                {
                    for (int j = 5; j < 8; j++)
                    {
                        if (board[i, j] == 'O')
                        {
                            counter++;
                            if (counter == 9)
                            {
                                flag = false;
                                Console.SetCursorPosition(23, 6);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("THE WINNER: O");
                            }
                        }
                    }
                }
                if (flag == false)
                    break;


                flag2 = true;
                while (flag2)
                {
                    turn = 'X';
                    var userinput = Console.ReadKey(true).Key;
                    switch (userinput)
                    {
                        case ConsoleKey.DownArrow:
                            //navigate down
                            if (cursory < 9)
                            {
                                cursory = (byte)(cursory + 1);
                                boardindexY++;
                            }
                            else cursory = 9;
                            break;
                        case ConsoleKey.UpArrow:
                            //navigate up
                            if (cursory > 2)
                            {
                                cursory = (byte)(cursory - 1);
                                boardindexY--;
                            }
                            else cursory = 2;
                            break;
                        case ConsoleKey.LeftArrow:
                            //navigate left
                            if (cursorx > 2)
                            {
                                cursorx = (byte)(cursorx - 2);
                                boardindexX--;
                            }
                            else cursorx = 2;
                            break;
                        case ConsoleKey.RightArrow:
                            //navigate right
                            if (cursorx < 16)
                            {
                                cursorx = (byte)(cursorx + 2);
                                boardindexX++;
                            }
                            else cursorx = 16;
                            break;

                    }

                    Console.SetCursorPosition(cursorx, cursory);


                    bool move = true;
                    while ((userinput == ConsoleKey.Z && board[boardindexY, boardindexX] == 'X') && move)
                    {
                        
                        Board(cursorx, cursory);

                        userinput = Console.ReadKey(true).Key;
                        if (jump == false && userinput == ConsoleKey.C)
                        {
                            round++;
                            flag2 = false;
                            break;
                        }
                        if (boardindexX == 7 && userinput == ConsoleKey.RightArrow) move = false;
                        if (boardindexY == 7 && userinput == ConsoleKey.DownArrow) move = false;
                        if (boardindexY == 0 && userinput == ConsoleKey.UpArrow) move = false;
                        if (boardindexX == 0 && userinput == ConsoleKey.LeftArrow) move = false;

                        if (move && userinput == ConsoleKey.LeftArrow)
                        {
                            if (board[boardindexY, boardindexX - 1] == '.')
                            {
                                cursorx = cursorx - 2;
                                boardindexX--;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {

                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY, boardindexX + 1] = '.';
                                    flag2 = false;
                                    round++;
                                    break;
                                }
                                else
                                    break;
                            }

                            else if (board[boardindexY, boardindexX - 1] == 'X' && board[boardindexY, boardindexX - 2] == '.')
                            {
                                cursorx = cursorx - 4;
                                boardindexX -= 2;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {
                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY, boardindexX + 2] = '.';
                                    userinput = ConsoleKey.Z;
                                    jump = false;
                                }

                                else
                                    break;
                            }
                        }

                        else if (move && userinput == ConsoleKey.RightArrow)
                        {
                            if (board[boardindexY, boardindexX + 1] == '.')
                            {
                                cursorx = cursorx + 2;
                                boardindexX++;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {
                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY, boardindexX - 1] = '.';
                                    flag2 = false;
                                    round++;
                                    break;
                                }
                                else
                                    break;
                            }
                            else if (board[boardindexY, boardindexX + 1] == 'X' && board[boardindexY, boardindexX + 2] == '.')
                            {
                                cursorx = cursorx + 4;
                                boardindexX += 2;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {
                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY, boardindexX - 2] = '.';
                                    userinput = ConsoleKey.Z;
                                    jump = false;
                                }
                                else
                                    break;

                            }
                        }

                        else if (move && userinput == ConsoleKey.UpArrow)
                        {
                            if (board[boardindexY - 1, boardindexX] == '.')
                            {
                                cursory = cursory - 1;
                                boardindexY--;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {
                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY + 1, boardindexX] = '.';
                                    flag2 = false;
                                    round++;
                                    break;
                                }
                                else
                                    break;
                            }
                            else if (board[boardindexY - 1, boardindexX] == 'X' && board[boardindexY - 2, boardindexX] == '.')
                            {
                                cursory = cursory - 2;
                                boardindexY -= 2;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {
                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY + 2, boardindexX] = '.';
                                    userinput = ConsoleKey.Z;
                                    jump = false;
                                }
                                else
                                    break;

                            }
                        }

                        else if (move && userinput == ConsoleKey.DownArrow)
                        {
                            if (board[boardindexY + 1, boardindexX] == '.')
                            {
                                cursory = cursory + 1;
                                boardindexY++;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {
                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY - 1, boardindexX] = '.';
                                    flag2 = false;
                                    round++;
                                    break;
                                }
                                else
                                    break;
                            }
                            else if (board[boardindexY + 1, boardindexX] == 'X' && board[boardindexY + 2, boardindexX] == '.')
                            {
                                cursory = cursory + 2;
                                boardindexY += 2;
                                Console.SetCursorPosition(cursorx, cursory);
                                userinput = Console.ReadKey(true).Key;
                                if (userinput == ConsoleKey.X)
                                {
                                    board[boardindexY, boardindexX] = 'X';
                                    board[boardindexY - 2, boardindexX] = '.';
                                    userinput = ConsoleKey.Z;
                                    jump = false;
                                }
                                else
                                    break;

                            }
                        }
                    }
                }

                turn = 'O';
                Board(cursorx, cursory);
                System.Threading.Thread.Sleep(600);
                flagO = true;
                while (flagO)
                {
                    Random rand = new Random();
                    int rightordown = rand.Next(1, 3);
                    int boardindexox = rand.Next(0, 8);
                    int boardindexoy = rand.Next(0, 8);

                    if (rightordown == 1 && board[boardindexoy, boardindexox] == 'O')
                    {
                        //right                        
                        if (boardindexox < 6 && board[boardindexoy, boardindexox + 1] == 'O' && board[boardindexoy, boardindexox + 2] == '.')
                        {
                            flagO = false;
                            board[boardindexoy, boardindexox + 2] = 'O';
                            board[boardindexoy, boardindexox] = '.';
                            boardindexox += 2;

                            if (boardindexox < 6 && board[boardindexoy, boardindexox + 1] == 'O' && board[boardindexoy, boardindexox + 2] == '.')
                            {
                                board[boardindexoy, boardindexox + 2] = 'O';
                                board[boardindexoy, boardindexox] = '.';
                            }
                            else if (boardindexoy < 6 && board[boardindexoy + 1, boardindexox] == 'O' && board[boardindexoy + 2, boardindexox] == '.')
                            {
                                board[boardindexoy + 2, boardindexox] = 'O';
                                board[boardindexoy, boardindexox] = '.';
                            }
                            else
                                break;
                        }

                        ///left
                        else if (((boardindexoy == 3 || boardindexoy == 4) && (boardindexox == 6 || boardindexox == 7)) && board[boardindexoy, boardindexox - 1] == '.')
                        {
                            flagO = false;
                            board[boardindexoy, boardindexox - 1] = 'O';
                            board[boardindexoy, boardindexox] = '.';
                        }

                        else if (boardindexox < 7 && board[boardindexoy, boardindexox + 1] == '.')
                        {
                            flagO = false;
                            board[boardindexoy, boardindexox + 1] = 'O';
                            board[boardindexoy, boardindexox] = '.';
                        }
                       

                    }
                    else if (rightordown == 2 && board[boardindexoy, boardindexox] == 'O')
                    {
                        //down                        
                        if (boardindexoy < 6 && board[boardindexoy + 1, boardindexox] == 'O' && board[boardindexoy + 2, boardindexox] == '.')
                        {
                            flagO = false;
                            board[boardindexoy + 2, boardindexox] = 'O';
                            board[boardindexoy, boardindexox] = '.';
                            boardindexoy += 2;

                            if (boardindexoy < 6 && board[boardindexoy + 1, boardindexox] == 'O' && board[boardindexoy + 2, boardindexox] == '.')
                            {
                                board[boardindexoy + 2, boardindexox] = 'O';
                                board[boardindexoy, boardindexox] = '.';
                            }
                            else if (boardindexox < 6 && board[boardindexoy, boardindexox + 1] == 'O' && board[boardindexoy, boardindexox + 2] == '.')
                            {
                                board[boardindexoy, boardindexox + 2] = 'O';
                                board[boardindexoy, boardindexox] = '.';

                            }
                            else
                                break;
                        }

                        else if (((boardindexox == 3 || boardindexox == 4) && (boardindexoy == 6 || boardindexoy == 7)) && board[boardindexoy - 1, boardindexox] == '.')
                        {
                            flagO = false;
                            board[boardindexoy - 1, boardindexox] = 'O';
                            board[boardindexoy, boardindexox] = '.';
                        }

                        else if (boardindexoy < 7 && board[boardindexoy + 1, boardindexox] == '.')
                        {
                            flagO = false;
                            board[boardindexoy + 1, boardindexox] = 'O';
                            board[boardindexoy, boardindexox] = '.';
                        }                   
                    }
                }
            }

            Console.ReadLine();
        }


        private static void Board(int cursorx, int cursory)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  1 2 3 4 5 6 7 8");
            Console.WriteLine(" +- - - - - - - -+");
            Console.WriteLine("1|               |");
            Console.WriteLine("2|               |");
            Console.WriteLine("3|               |");
            Console.WriteLine("4|               |");
            Console.WriteLine("5|               |");
            Console.WriteLine("6|               |");
            Console.WriteLine("7|               |");
            Console.WriteLine("8|               |");
            Console.WriteLine(" +- - - - - - - -+ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(23, 4);
            Console.Write("Round: " + round);
            Console.SetCursorPosition(23, 5);
            Console.WriteLine("Turn: " + turn);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.SetCursorPosition(2, i + 2);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 2; i <= 9; i++)
            {
                Console.SetCursorPosition(17, i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(cursorx, cursory);

            

        }
    }
}

