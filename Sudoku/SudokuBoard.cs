using System;
using System.Linq;

namespace Sudoku
{
    class SudokuBoard
    {
        int iterations = 0;
        int[,] board = new int[9, 9];

        public void Print()
        {
            System.Threading.Thread.Sleep(10);
            System.Console.Clear();
            /* 
            board[3, 3] = 0;
          board[3, 4] = 0;
          board[3, 5] = 7;
*/
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                    System.Console.Write("+-------+-------+-------+" + Environment.NewLine);

                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0)
                        System.Console.Write("| ");

                    if (board[i, j] == 0)
                        System.Console.Write("  ");
                    else
                        System.Console.Write(board[i, j] + " ");
                }
                System.Console.Write("|" + Environment.NewLine);
            }
            System.Console.Write("+-------+-------+-------+" + Environment.NewLine);
            System.Console.WriteLine(iterations);

        }

        public void Fill()
        {
            int value = 1;

            for (int i = 0; i < 9; i++)
            {

                if (i % 3 == 0 && i != 0)
                    value++;

                for (int j = 0; j < 9; j++)
                {
                    value = ((value - 1) % 9) + 1;

                    board[i, j] = value++;


                }
                value += 3;


            }

        }

        public bool verifyRow(int rowNumber)
        {
            int[] row = new int[9];

            for (int i = 0; i < 9; i++)
            {
                if (board[rowNumber, i] == 0)
                    continue;
                row[board[rowNumber, i] - 1]++;
            }

            foreach (int number in row)
                if (number > 1)
                    return false;

            return true;
        }

        public bool verifyColumn(int columnNumber)
        {
            int[] row = new int[9];

            for (int i = 0; i < 9; i++)
            {
                if (board[i, columnNumber] == 0)
                    continue;
                row[board[i, columnNumber] - 1]++;
            }

            foreach (int number in row)
                if (number > 1)
                    return false;

            return true;
        }

        public bool verifyBlock(int fieldNumber)
        {
            int[] row = new int[9];

            int rowOffset = (fieldNumber / 3) * 3;
            int columnOffset = (fieldNumber % 3) * 3;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (board[rowOffset + i, columnOffset + j] == 0)
                        continue;

                    row[board[rowOffset + i, columnOffset + j] - 1]++;
                }

            foreach (int number in row)
                if (number > 1)
                    return false;

            return true;
        }

        public void swapRows(int row1, int row2)
        {
            int tmp;

            for (int i = 0; i < 9; i++)
            {
                tmp = board[row1, i];
                board[row1, i] = board[row2, i];
                board[row2, i] = tmp;
            }

        }

        public void swapColumns(int column1, int column2)
        {
            int tmp;

            for (int i = 0; i < 9; i++)
            {
                tmp = board[i, column1];
                board[i, column1] = board[i, column2];
                board[i, column2] = tmp;
            }

        }

        public void swapRowFields(int rowField1, int rowField2)
        {
            int rowOffset1 = rowField1 * 3;
            int rowOffset2 = rowField2 * 3;

            for (int i = 0; i < 3; i++)
            {
                swapRows(rowOffset1 + i, rowOffset2 + i);
            }


        }

        public void deleteRandomCell()
        {
            Random random = new Random(1);

            int rowNumber;
            int columnNumber;

            do
            {
                rowNumber = random.Next(0, 9);
                columnNumber = random.Next(0, 9);

            } while (board[rowNumber, columnNumber] == 0);

            board[rowNumber, columnNumber] = 0;
        }

        public bool verifyBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                if ((verifyRow(i) & verifyColumn(i) & verifyBlock(i)) == false)
                    return false;
            }
            return true;
        }

        public bool setField()
        {
            iterations++;
            Print();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != 0)
                        continue;

                    int n;
                    for (n = 0; n < 9; n++)
                    {
                        board[i, j] = n + 1;
                        if (!verifyBoard())
                            continue;

                        if (setField())
                            break;
                    }

                    if (n == 9)
                    {
                        board[i, j] = 0;
                        return false;
                    }
                }

            return true;

        }

        public void Solve()
        {
            CellCoordinate cell = new CellCoordinate();

            fillBoard(cell);

        }

        public void setCell(CellCoordinate cell, int value)
        {
            board[cell.row, cell.column] = value;
        }
        public bool increaseCellValue(CellCoordinate cell)
        {
            if (board[cell.row, cell.column] < 9)
            {
                board[cell.row, cell.column]++;
                return true;
            }

            board[cell.row, cell.column] = 0;

            return false;
        }

        public void clearCell(CellCoordinate cell)
        {
            board[cell.row, cell.column] = 0;
        }
        public void clearCellDebug(CellCoordinate cell)
        {
            System.Console.WriteLine(cell.row + " " + cell.column + " -> " + board[cell.row, cell.column]);
            
            if ( board[cell.row, cell.column] != 0 )
                throw new ApplicationException();

            board[cell.row, cell.column] = 0;
        }

        public bool isCellEmpty(CellCoordinate cell)
        {
            return board[cell.row, cell.column] == 0;
        }

        public bool trySetCell(CellCoordinate cell, int value)
        {
            setCell(cell, value);

            return verifyBoard();
            
        }

        public bool fillBoard(CellCoordinate cell)
        {

            if (isCellEmpty(cell))
            {
                iterations++;

                foreach (int value in Enumerable.Range(1, 9))
                {
                    if (!trySetCell(cell, value))
                        continue;

                    Print();
 
                    if (fillBoard(cell))
                        return true;
                    
                }

                clearCell(cell);

                return false;
            }


            if (cell.MoveToNextCellInGrid())
                return fillBoard(cell);
            return true;



        }

    }
}
