using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {


            var board = new SudokuBoard();

            board.Fill();

            board.swapRows(0, 2);
            board.swapColumns(0, 1);
            board.swapRows(3, 4);
            board.swapColumns(3, 5);
            board.swapRows(7, 8);
            board.swapRowFields(0, 1);
            board.swapColumns(7, 8);
            board.swapRowFields(1, 2);
            board.swapColumns(1, 2);

            board.swapRows(0, 2);
            board.swapColumns(0, 1);
            board.swapRows(3, 4);
            board.swapColumns(3, 5);
            board.swapRows(7, 8);
            board.swapRowFields(0, 1); board.swapRows(7, 8);
            board.swapRowFields(0, 1);
            board.swapColumns(7, 8);
            board.swapRowFields(1, 2);
            board.swapColumns(1, 2);

            board.swapRows(0, 2);
            board.swapColumns(0, 1);
            board.swapRows(3, 4);
            board.swapColumns(3, 5);
            board.swapRows(7, 8);
            board.swapRowFields(0, 1);
            board.swapColumns(7, 8);
            board.swapRowFields(1, 2);
            board.swapColumns(1, 2);

            board.swapRows(0, 2);
            board.swapColumns(0, 1);
            board.swapRows(3, 4);
            board.swapColumns(3, 5);
            board.swapRows(7, 8);
            board.swapRowFields(0, 1);
            board.swapColumns(7, 8);
            board.swapRowFields(1, 2);
            board.swapColumns(1, 2);

            board.swapColumns(0, 1);
            board.swapColumns(0, 2);
            board.swapRows(0, 1);


            for (int i = 0; i < 81 - 31; i++)
            {
                board.deleteRandomCell();
                board.Print();
            }



            //            board.setField();
            board.Solve();



            /* 
                        for( int i = 0 ; i < 9 ; i++)
                        if( !board.verifyRow(i) )
                        {
                            System.Console.WriteLine("Row "+ (i+1) +" incorrect");
                        }

                        for( int i = 0 ; i < 9 ; i++)
                        if( !board.verifyColumn(i) )
                        {
                            System.Console.WriteLine("Column "+ (i+1) +" incorrect");
                        }

                        for( int i = 0 ; i < 9 ; i++)
                        if( !board.verifyField(i) )
                        {
                            System.Console.WriteLine("Field "+ (i+1) +" incorrect");
                        }
                        */
        }
    }
}
