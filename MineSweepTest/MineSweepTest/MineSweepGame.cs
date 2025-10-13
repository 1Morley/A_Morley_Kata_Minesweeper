using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest
{
    public class MineSweepGame
    {
        public MineItem[,] Board;

        public MineSweepGame()
        {
            resetMineItemBoard(8, 8);
        }

        public void resetMineItemBoard(int row, int col)
        {
            Board = new MineItem[row, col]; // [2,3] == 2 arrays w/ 3 each
            for (int rowSelect = 0; rowSelect < Board.GetLength(0); rowSelect++)
            {
                for (int colSelect = 0; colSelect < Board.GetLength(1); colSelect++)
                {
                    Board[rowSelect, colSelect] = new MineItem() { BombRangeCount = 2};
                }
            }
        }
        public void markItem(int row, int col) {
            if (Board[row, col].Hidden)
            {
                Board[row, col].Marked = !Board[row, col].Marked;
            }
        }

        public bool selectItem(int row, int col)
        {
            Board[row, col].Hidden = false;
            Board[row, col].Marked = false;
            SetGridItemHidden(row, col);
            return Board[row, col].Bomb;
        }

        public void CreateBoard(int startRow, int startCol) {
            SetMines(startRow, startCol);
            CreateSafeSpace(startRow, startCol);
            UpdateBoardBombCount();
            selectItem(startRow, startCol);
        }

        private void SetMines(int startRow, int startCol) {
            Random rando = new Random();

            foreach (MineItem select in Board)
            {
                int result = rando.Next(1, 8);
                if (result == 1)
                {
                    select.Bomb = true;
                }   
            }
        }

        private void UpdateBoardBombCount() {
            for (int rowSelect = 0; rowSelect < Board.GetLength(0); rowSelect++)
            {
                for (int colSelect = 0; colSelect < Board.GetLength(1); colSelect++)
                {
                    SetBombCount(rowSelect, colSelect);
                }
            }
        }

        private void SetBombCount(int row, int col) {
            //1 1

            //00 01 02
            //10 xx 12
            //20 21 23

            int minRow = (row != 0)? row - 1: 0; 
            int minCol = (col != 0)? col - 1: 0; 

            int maxRow = (row != (Board.GetLength(0) - 1)) ? row + 1 : (Board.GetLength(0) - 1);
            int maxCol = (col != (Board.GetLength(1) - 1)) ? col + 1 : (Board.GetLength(1) - 1);

            int foundBombs = 0;

            for (int rowSelect = minRow; rowSelect <= maxRow; rowSelect++)
            {
                for (int colSelect = minCol; colSelect <= maxCol; colSelect++)
                {
                    if (Board[rowSelect, colSelect].Bomb) {
                        foundBombs++;
                    }
                }
            }

            Board[row,col].BombRangeCount = foundBombs;
        }

        private void CreateSafeSpace(int row, int col) {
            int rowSpace = 2;
            int colSpace = 3;

            int minRow = ((row - rowSpace) > 0) ? row - rowSpace : 0;
            int minCol = ((col - colSpace) > 0) ? col - colSpace : 0;

            int maxRow = (row < (Board.GetLength(0) - rowSpace)) ? row + 1 : (Board.GetLength(0) - 1);
            int maxCol = (col < (Board.GetLength(1) - colSpace)) ? col + 1 : (Board.GetLength(1) - 1);

            int foundBombs = 0;

            for (int rowSelect = minRow; rowSelect <= maxRow; rowSelect++)
            {
                for (int colSelect = minCol; colSelect <= maxCol; colSelect++)
                {
                    Board[rowSelect, colSelect].Bomb = false;
                }
            }
        }

        private void SetGridItemHidden(int row, int col) {
            if (Board[row, col].BombRangeCount == 0)
            {
                int minRow = (row != 0) ? row - 1 : 0;
                int minCol = (col != 0) ? col - 1 : 0;

                int maxRow = (row != (Board.GetLength(0) - 1)) ? row + 1 : (Board.GetLength(0) - 1);
                int maxCol = (col != (Board.GetLength(1) - 1)) ? col + 1 : (Board.GetLength(1) - 1);

                int foundBombs = 0;

                for (int rowSelect = minRow; rowSelect <= maxRow; rowSelect++)
                {
                    for (int colSelect = minCol; colSelect <= maxCol; colSelect++)
                    {
                        if (Board[rowSelect, colSelect].Hidden)
                        {
                            Board[rowSelect, colSelect].Hidden = false;
                            if (Board[rowSelect, colSelect].BombRangeCount == 0)
                            {
                                SetGridItemHidden(rowSelect, colSelect);
                            }
                        }
                    }
                }
            }
        }



    }
}
