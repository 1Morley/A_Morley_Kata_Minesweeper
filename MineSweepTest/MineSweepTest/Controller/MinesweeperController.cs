using MineSweepTest.Model;
using MineSweepTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Controller
{
    internal class MinesweeperController : IGameState
    {
        private MinesweeperBoard board;
        private MinesweeperUI ui;
        private bool win = false;

        public MinesweeperController()
        {
            ui = new MinesweeperUI();
        }


        public void DisplayEndResults()
        {
            ui.EndGameDisplay(win);
        }

        public void ShowGame()
        {
            ui.DisplayMinesweeperBoard(board.Board);
        }

        public void StartGame()
        {
            ui.GetGridSize(out int rowSize,out int columnSize);
            ui.SelectItemCords(rowSize, columnSize, out int firstRow, out int firstColumn);
            board = new MinesweeperBoard(rowSize, columnSize, firstRow, firstColumn);
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
            ui.SelectItemCords(board.getBoardRowSize(), board.getBoardColumnSize(), out int row, out int column);
            bool bomb = board.SelectItem(row, column);
            if (bomb)
            {
                win = false;
                return true;
            }
            if (board.AreAllBombsFound())
            {
                win = true;
                return true;
            }
            return false;
        }
        public void MarkItem()
        {
            ui.MarkItemCords(board.getBoardRowSize(), board.getBoardColumnSize(), out int row, out int column);
            board.MarkItem(row, column);
        }




    }
}
