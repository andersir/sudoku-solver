using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            var board = new SudokuBoard();

            board.GenerateSimple();
            board.Print();

 
            board.SwapRows(0, 2);
            board.SwapColumns(0, 1);
            board.SwapRows(3, 4);
            board.SwapColumns(3, 5);
            board.SwapRows(7, 8);
            board.SwapRowBlocks(0, 1);
            board.SwapColumns(7, 8);
            board.SwapRowBlocks(1, 2);
            board.SwapColumns(1, 2);

            board.SwapRows(0, 2);
            board.SwapColumns(0, 1);
            board.SwapRows(3, 4);
            board.SwapColumns(3, 5);
            board.SwapRows(7, 8);
            board.SwapRowBlocks(0, 1);
            board.SwapRows(7, 8);
            board.SwapRowBlocks(0, 1);
            board.SwapColumns(7, 8);
            board.SwapRowBlocks(1, 2);
            board.SwapColumns(1, 2);

            board.SwapRows(0, 2);
            board.SwapColumns(0, 1);
            board.SwapRows(3, 4);
            board.SwapColumns(3, 5);
            board.SwapRows(7, 8);
            board.SwapRowBlocks(0, 1);
            board.SwapColumns(7, 8);
            board.SwapRowBlocks(1, 2);
            board.SwapColumns(1, 2);

            board.SwapRows(0, 2);
            board.SwapColumns(0, 1);
            board.SwapRows(3, 4);
            board.SwapColumns(3, 5);
            board.SwapRows(7, 8);
            board.SwapRowBlocks(0, 1);
            board.SwapColumns(7, 8);
            board.SwapRowBlocks(1, 2);
            board.SwapColumns(1, 2);

            board.SwapColumns(0, 1);
            board.SwapColumns(0, 2);
            board.SwapRows(0, 1);

            board.DeleteRandomCells(81-30);
            
            board.Print();

            board.Solve();

        }
    }
}
