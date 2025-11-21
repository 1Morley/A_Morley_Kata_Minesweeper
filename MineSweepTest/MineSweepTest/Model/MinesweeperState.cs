using MineSweepTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class MinesweeperState : IGameState
    {
        public MinesweeperItem[,] Board { get; set; }
        private Random rando;
        private int bombCount;
        private int foundBombCount;
        private MinesweeperUI ui;
        private bool win = false;

        public MinesweeperState()
        {
            ui = new MinesweeperUI();
        }


        public void DisplayEndResults()
        {
            ui.EndGameDisplay(win);
        }

        public void ShowGame()
        {
            ui.DisplayBoard(Board);
        }

        public void StartGame()
        {
            ui.GetGridSize(out int rowSize,out int columnSize);
            ui.SelectItemCords(rowSize, columnSize, out int firstRow, out int firstColumn);
            CreateGame(rowSize, columnSize, firstRow, firstColumn);
        }

        public bool TakeTurn()
        {
            if (ui.SelectOrMarkSelect())
            {
                return SelectItem();
            }
            else
            {
                MarkItem();
                return false;
            }

        }

        public bool SelectItem()
        {
            ui.SelectItemCords(getBoardRowSize(), getBoardColumnSize(), out int row, out int column);
            bool bomb = SelectItem(row, column);
            if (bomb)
            {
                win = false;
                return true;
            }
            if (AreAllBombsFound())
            {
                win = true;
                return true;
            }
            return false;
        }
        public void MarkItem()
        {
            ui.MarkItemCords(getBoardRowSize(), getBoardColumnSize(), out int row, out int column);
            MarkItem(row, column);
        }


        public void CreateGame(int row, int column, int firstRowSelect, int firstColumnSelect)
        {
            foundBombCount = 0;
            bombCount = 0;
            rando = new Random();
            Board = new MinesweeperItem[row, column];
            FillAllItems();
            SetupBoard(firstRowSelect, firstColumnSelect);
            SelectItem(firstRowSelect, firstColumnSelect);
        }

        private void FillAllItems()
        {
            for (int row = 0; row < getBoardRowSize(); row++)
            {
                for (int column = 0; column < getBoardColumnSize(); column++)
                {

                    Board[row, column] = new MinesweeperItem();

                }
            }
        }

        private void SetupBoard(int firstRowSelect, int firstColumnSelect)
        {
            for (int row = 0; row < getBoardRowSize(); row++)
            {
                for (int column = 0; column < getBoardColumnSize(); column++)
                {

                    int safetyRow = 1;
                    int safetyColumn = 1;

                    if (!(row >= firstRowSelect - safetyRow && row <= firstRowSelect + safetyRow) && !(column >= firstColumnSelect - safetyColumn && column <= firstColumnSelect + safetyColumn))
                    {
                        TryPlaceBomb(row, column);
                    }

                }
            }
        }

        private void TryPlaceBomb(int row, int column)
        {
            MinesweeperItem foundItem = Board[row, column];
            if (foundItem.BombRangeCount < 4)
            {
                int randoResult = rando.Next(1, 4);
                if (randoResult == 1)
                {
                    bombCount++;
                    foundItem.Bomb = true;
                    IncreaseNearBombCount(row, column);
                }
            }
        }

        private void IncreaseNearBombCount(int bombRow, int bombColumn)
        {
            for (int rowMod = -1; rowMod < 2; rowMod++)
            {
                int rowChecked = bombRow + rowMod;
                if (rowChecked >= 0 && rowChecked < getBoardRowSize())
                {
                    for (int columnMod = -1; columnMod < 2; columnMod++)
                    {
                        int columnChecked = bombColumn + columnMod;
                        if (columnChecked >= 0 && columnChecked < getBoardColumnSize())
                        {
                            MinesweeperItem found = Board[rowChecked, columnChecked];
                            found.BombRangeCount++;
                        }
                    }
                }
            }
        }

        public void MarkItem(int row, int column)
        {
            MinesweeperItem foundItem = Board[row, column];
            if (foundItem.Hidden)
            {
                foundItem.Marked = !foundItem.Marked;
                if (foundItem.Bomb)
                {
                    if (foundItem.Marked)
                    {
                        foundBombCount++;
                    }
                    else
                    {
                        foundBombCount--;
                    }
                }
            }
        }

        public bool SelectItem(int row, int column)
        {
            MinesweeperItem foundItem = Board[row, column];
            foundItem.Hidden = false;
            foundItem.Marked = false;
            SetGridItemHidden(row, column);
            return foundItem.Bomb;
        }

        private void SetGridItemHidden(int row, int column)
        {
            if (Board[row, column].BombRangeCount == 0)
            {
                int minRow = row != 0 ? row - 1 : 0;
                int minCol = column != 0 ? column - 1 : 0;

                int maxRow = row != getBoardRowSize() - 1 ? row + 1 : getBoardRowSize() - 1;
                int maxCol = column != getBoardColumnSize() - 1 ? column + 1 : getBoardColumnSize() - 1;

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

        public int getBoardRowSize()
        {
            return Board.GetLength(0);
        }
        public int getBoardColumnSize()
        {
            return Board.GetLength(1);
        }


        public bool AreAllBombsFound()
        {
            return bombCount == foundBombCount;
        }





    }
}
