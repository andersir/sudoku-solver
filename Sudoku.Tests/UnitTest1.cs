using System;
using Xunit;
using Sudoku;

namespace Sudoku.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckCellInitialzer()
        {
            CellCoordinate cell = new CellCoordinate(); 

            Assert.Equal(0, cell.row);
            Assert.Equal(0, cell.column);
        }

        [Fact]
        public void CheckCellInitialzerWithValues()
        {
            CellCoordinate cell = new CellCoordinate(3, 4);

            Assert.Equal(3, cell.row);
            Assert.Equal(4, cell.column);
        }

        [Fact]
        public void CheckCellMoveInGrid()
        {
            CellCoordinate cell = new CellCoordinate(3, 4);

            Assert.True(cell.MoveToNextCellInGrid());

            Assert.Equal(3, cell.row);
            Assert.Equal(5, cell.column);
        }

        [Fact]
        public void CheckCellMoveInGridWrap()
        {
            CellCoordinate cell = new CellCoordinate(3, 8);

            Assert.True(cell.MoveToNextCellInGrid());

            Assert.Equal(4, cell.row);
            Assert.Equal(0, cell.column);
        }

        [Fact]
        public void CheckCellMoveInGridLastCell()
        {
            CellCoordinate cell = new CellCoordinate(8, 8);

            Assert.False(cell.MoveToNextCellInGrid());

        }

    

    }
}
