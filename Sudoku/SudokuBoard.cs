using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class SudokuBoard
    {
        int iterations = 0;
        int[,] board = new int[9, 9];

        public void Print()
        {
//            System.Threading.Thread.Sleep(1);
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

        public void GenerateSimple()
        {
            for( int i = 0 ; i < 81 ; i++)
            {
                int value = i;
                value += 3*(i/9);   // Shift rows
                value += i/27;      // Shift on block (3 rows)
                value %= 9;
                value ++;

                board[i/9,i%9] = value;
            }
        }


        private bool Verify(Del handler)
        {
            HashSet<int> used = new HashSet<int>();

            do
            {
                if (IsCellEmpty((CellCoordinate)handler.Target))
                    continue;

                if (!used.Add(GetCell((CellCoordinate)handler.Target)))
                    return false;

            } while (handler());

            return true;
        }

        public bool VerifyRow(int rowNumber)
        {
            CellCoordinate cell = new CellCoordinate(rowNumber, 0);
            Del handler = cell.MoveToNextCellInRow;

            return Verify(handler);
        }

        public bool VerifyColumn(int columnNumber)
        {
            CellCoordinate cell = new CellCoordinate(0, columnNumber);
            Del handler = cell.MoveToNextCellInColumn;

            return Verify(handler);
        }

        public bool VerifyBlock(int blockNumber)
        {
            int rowOffset = (blockNumber / 3) * 3;
            int columnOffset = (blockNumber % 3) * 3;

            CellCoordinate cell = new CellCoordinate(rowOffset, columnOffset);
            Del handler = cell.MoveToNextCellInBlock;

            return Verify(handler);
        }

        public void SwapRows(int row1, int row2)
        {
            int tmp;

            for (int i = 0; i < 9; i++)
            {
                tmp = board[row1, i];
                board[row1, i] = board[row2, i];
                board[row2, i] = tmp;
            }

        }

        public void SwapColumns(int column1, int column2)
        {
            int tmp;

            for (int i = 0; i < 9; i++)
            {
                tmp = board[i, column1];
                board[i, column1] = board[i, column2];
                board[i, column2] = tmp;
            }

        }

        public void SwapRowBlocks(int blockRow1, int blockRow2)
        {
            int rowOffset1 = blockRow1 * 3;
            int rowOffset2 = blockRow2 * 3;

            for (int i = 0; i < 3; i++)
            {
                SwapRows(rowOffset1 + i, rowOffset2 + i);
            }


        }

        public void DeleteRandomCells(int numberOfCellsToDelete)
        {
            
            foreach (int i in Enumerable.Range(1, numberOfCellsToDelete))
                DeleteRandomCell();
        }

        public void DeleteRandomCell()
        {     
            CellCoordinate cell = new CellCoordinate();
     
            do
            {
                cell.Randomize();

            } while ( IsCellEmpty(cell) );

            ClearCell(cell);
        }

        public bool VerifyBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                if ((VerifyRow(i) & VerifyColumn(i) & VerifyBlock(i)) == false)
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
                        if (!VerifyBoard())
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

            FillBoard(cell);

        }

        public void SetCell(CellCoordinate cell, int value)
        {
            board[cell.row, cell.column] = value;
        }

        public int GetCell(CellCoordinate cell)
        {
            return board[cell.row, cell.column];
        }

        public bool IncreaseCellValue(CellCoordinate cell)
        {
            if (board[cell.row, cell.column] < 9)
            {
                board[cell.row, cell.column]++;
                return true;
            }

            board[cell.row, cell.column] = 0;

            return false;
        }

        public void ClearCell(CellCoordinate cell)
        {
            board[cell.row, cell.column] = 0;
        }

        public bool IsCellEmpty(CellCoordinate cell)
        {
            return board[cell.row, cell.column] == 0;
        }

        public bool TrySetCell(CellCoordinate cell, int value)
        {
            SetCell(cell, value);

            return VerifyBoard();

        }

        public bool FillBoard(CellCoordinate cell)
        {

            if (IsCellEmpty(cell))
            {
                iterations++;

                foreach (int value in Enumerable.Range(1, 9))
                {
                    if (!TrySetCell(cell, value))
                        continue;

                    Print();

                    if (FillBoard(cell))
                        return true;

                }

                ClearCell(cell);

                return false;
            }

            if (cell.MoveToNextCellInGrid())
                return FillBoard(cell);
            return true;

        }

    }
}
