using System;

namespace Game.sudoku
{
    public class SudokuPuzzle
    {

        private readonly int[,] board;

        //The size of the sudoku game
        private readonly int _gridSize;

        public SudokuPuzzle(int gridSize)
        {
            _gridSize = gridSize;
            board = new int[_gridSize, _gridSize];
        }

        //Generates a random Sudoku board 
        public int[,] GenerateSudoku()
        {
            Random random = new Random();
            int row, col;
            int num;

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    board[i, j] = 0;
                }
            }

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    do
                    {
                        row = random.Next(_gridSize);
                        col = random.Next(_gridSize);
                        num = random.Next(_gridSize) + 1;
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
            for (int i = 0; i < _gridSize; i++)
            {
                if (board[row, i] == num)
                {
                    return false;
                }
            }

            //Check column
            for (int i = 0; i < _gridSize; i++)
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

        //Check for a win
        public bool CheckWin(int[,] GridValues)
        {
            //Check if all cells have been filled
            if (!GridValues.Cast<int>().All(value => value != 0))
            {
                return false;
            }

            //Check rows
            for (int row = 0; row < _gridSize; row++)
            {
                if (!CheckRow(GridValues, row))
                {
                    return false;
                }
            }

            //Check columns
            for (int col = 0; col < _gridSize; col++)
            {
                if (!CheckCol(GridValues, col))
                {
                    return false;
                }
            }

            //Check 3x3 squares
            for (int row = 0; row < _gridSize; row += 3)
            {
                for (int col = 0; col < _gridSize; col += 3)
                {
                    if (!CheckSquare(GridValues, row, col))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Check if a row is valid
        protected bool CheckRow(int[,] GridValues, int row)
        {
            var values = new List<int>();
            for (int col = 0; col < _gridSize; col++)
            {
                int value = GridValues[row, col];
                if (values.Contains(value))
                {
                    return false;
                }
                values.Add(value);
            }
            return true;
        }

        //Check if a column is valid
        protected bool CheckCol(int[,] GridValues, int col)
        {
            var values = new List<int>();
            for (int row = 0; row < _gridSize; row++)
            {
                int value = GridValues[row, col];
                if (values.Contains(value))
                {
                    return false;
                }
                values.Add(value);
            }
            return true;
        }

        //Check if a 3x3 square is valid
        protected bool CheckSquare(int[,] GridValues, int row, int col)
        {
            var values = new List<int>();
            for (int r = row; r < row + 3; r++)
            {
                for (int c = col; c < col + 3; c++)
                {
                    int value = GridValues[r, c];
                    if (values.Contains(value))
                    {
                        return false;
                    }
                    values.Add(value);
                }
            }
            return true;
        }
    }
}
