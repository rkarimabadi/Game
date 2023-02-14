using System;

namespace Game.sudoku
{
    public class SudokuGenerator
    {
        private int[,] board = new int[9, 9];

        //Generates a random Sudoku board 
        public int[,] GenerateSudoku()
        {
            Random random = new Random();
            int row, col;
            int num;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = 0;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    do
                    {
                        row = random.Next(9);
                        col = random.Next(9);
                        num = random.Next(9) + 1;
                    } while (!CanPlaceNum(row, col, num));

                    board[row, col] = num;
                }
            }

            return board;
        }

        //Checks if the given number can be placed in the given cell
        private  bool CanPlaceNum(int row, int col, int num)
        {
            //Check row
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num)
                {
                    return false;
                }
            }

            //Check column
            for (int i = 0; i < 9; i++)
            {
                if (board[i, col] == num)
                {
                    return false;
                }
            }

            //Check 3x3 square
            int sqRow = row - row % 3;
            int sqCol = col - col % 3;

            for (int i = sqRow; i < sqRow + 3; i++)
            {
                for (int j = sqCol; j < sqCol + 3; j++)
                {
                    if (board[i, j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
