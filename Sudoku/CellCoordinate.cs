using System;

namespace Sudoku
{
    public delegate bool Del();

    public struct CellCoordinate
    {
        public int row;
        public int column;


        public CellCoordinate(int row, int column)
        {
            if (row < 0 || row > 9 || column < 0 || column > 9)
                throw new ArgumentOutOfRangeException();

            this.row = row;
            this.column = column;
        }

        public void init()
        {
            row = 0;
            column = 0;
        }

        public void Randomize()
        {
            Random random = new Random();

            row = random.Next(0, 9);
            column = random.Next(0, 9);
        }

        public bool MoveToNextCellInGrid()
        {
            if (column < 8)
            {
                column++;
                return true;
            }

            if (row < 8)
            {
                column = 0;
                row++;
                return true;
            }

            return false;
        }

        public bool MoveToNextCellInRow()
        {
            if (column < 8)
            {
                column++;
                return true;
            }

            return false;
        }

        public bool MoveToNextCellInColumn()
        {
            if (row < 8)
            {
                row++;
                return true;
            }

            return false;
        }

        public bool MoveToNextCellInBlock()
        {
            int columnInBlock = column % 3;
            int rowInBlock = row % 3;

            if (columnInBlock < 2)
            {
                column++;
                return true;
            }

            if (rowInBlock < 2)
            {
                column = (column / 3) * 3;
                row++;
                return true;
            }

            return false;

        }

    }
}