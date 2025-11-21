using MineSweepTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class TicTacToeState : IGameState
    {
        private PlayerCollection PlayerCollection {  get; set; }
        private PlayerIterator PlayerSelect { get; set; }
        private Player winnerMarkId;
        private TicTacToeUI ui;

        private TicTacToeItem[,] Board { get; set; }
        private int filledItemCount;

        public TicTacToeState()
        {
            ui = new TicTacToeUI();
            Player[] players = new Player[] { new Player("O"), new Player("X") };
            PlayerCollection = new PlayerCollection(players);
            PlayerSelect = (PlayerIterator)PlayerCollection.CreateIterator();
        }
        public void DisplayEndResults()
        {
            ui.EndGameDisplay(winnerMarkId);
        }

        public void ShowGame()
        {
            ui.DisplayBoard(Board);
        }

        public void StartGame()
        {
            CreateBoard();
        }

        public bool TakeTurn()
        {
            Player CurrentPlayer = PlayerSelect.Next();
            while(true)
            {
                ui.GetPlayerMark(CurrentPlayer, out int row, out int column);
                if (PlaceMark(row, column))
                {
                    break;
                }
            }

            if (isGameOver(out winnerMarkId))
            {
                return true;
            }
            return false;
        }

        public void CreateBoard()
        {
            Board = new TicTacToeItem[3, 3];
            filledItemCount = 0;
            FillAllItems();
        }
        private void FillAllItems()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Board[row, column] = new TicTacToeItem();
                }
            }
        }

        public bool PlaceMark(int row, int column)
        {
            TicTacToeItem selectedItem = Board[row, column];
            if (selectedItem.EmptyItem())
            {
                selectedItem.Player = PlayerSelect.GetCurrent();
                filledItemCount++;
                return true;
            }
            return false;
        }

        public bool isGameOver(out Player foundWinner)
        {


            if (filledItemCount > 4)
            {
                Player[] AllWinPosibilities = { checkRow(), checkColumn(), checkDiagonal() };

                foreach (Player select in AllWinPosibilities)
                {
                    if (select != null)
                    {
                        foundWinner = select;
                        return true;
                    }
                }
            }

            foundWinner = null;
            return filledItemCount == Board.Length;

        }

        private Player checkRow()
        {
            for (int i = 0; i < 3; i++)
            {
                if (checkLine(1, 0, 0, i, out Player foundWin))
                {
                    //filled line
                    if (foundWin != null)
                    {
                        //is three in a row
                        return foundWin;
                    }
                }
            }
            return null;
        }
        private Player checkColumn()
        {
            for (int i = 0; i < 3; i++)
            {
                if (checkLine(0, 1, i, 0, out Player foundWin))
                {
                    //filled line
                    if (foundWin != null)
                    {
                        //is three in a row
                        return foundWin;
                    }
                }
            }
            return null;
        }

        private Player checkDiagonal()
        {
            bool leftFill = checkLine(1, 1, 0, 0, out Player leftWin);
            bool rightFill = checkLine(1, -1, 0, 2, out Player rightWin);

            if (leftFill)
            {
                return leftWin;
            }
            if (rightFill)
            {
                return rightWin;
            }
            return null;
        }


        private bool checkLine(int rowMod, int columnMod, int rowStart, int columnStart, out Player winnerPlayer)
        {
            winnerPlayer = null;
            for (int i = 0; i < 3; i++)
            {
                int rowSelect = rowStart + rowMod * i;
                int columnSelect = columnStart + columnMod * i;

                TicTacToeItem foundMark = Board[rowSelect, columnSelect];

                if (foundMark.Player == null)
                {
                    winnerPlayer = null;
                    return false;
                }

                if (i == 0)
                {
                    winnerPlayer = foundMark.Player;
                }

                if (winnerPlayer != foundMark.Player)
                {
                    winnerPlayer = null;
                }
            }
            return true;
        }
    }
}
