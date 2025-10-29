using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class TicTacToeBoard
    {
        public TicTacToeItem[,] Board { get; private set; }
        private int filledItemCount;
        public TicTacToeBoard()
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

        public bool PlaceMark(bool firstPlayer, int row, int column)
        {
            TicTacToeItem selectedItem = Board[row, column];
            if (selectedItem.MarkId == 0)
            {
                selectedItem.MarkId = (firstPlayer ? 1 : 2);
                filledItemCount++;
                return true;
            }
            return false;
        }

        public bool isGameOver(out int winId)
        {


            if (filledItemCount > 4)
            {
                int[] AllWinPosibilities = { checkRow(), checkColumn(), checkDiagonal() };

                foreach (int select in AllWinPosibilities)
                {
                    if (select != 0)
                    {
                        winId = select;
                        return true;
                    }
                }
            }
            
            winId = 0;
            return filledItemCount == Board.Length;
            
        }

        private int checkRow()
        {
            for (int i = 0; i < 3; i++)
            {
                if (checkLine(1, 0, 0, i, out int foundWin))
                {
                    //filled line
                    if (foundWin != 0)
                    {
                        //is three in a row
                        return foundWin;
                    }
                }
            }
            return 0;
        }
        private int checkColumn()
        {
            for (int i = 0; i < 3; i++)
            {
                if (checkLine(0, 1, i, 0, out int foundWin))
                {
                    //filled line
                    if (foundWin != 0)
                    {
                        //is three in a row
                        return foundWin;
                    }
                }
            }
            return 0;
        }

        private int checkDiagonal()
        {
            bool leftFill = checkLine(1, 1, 0, 0, out int leftWin);
            bool rightFill = checkLine(1, -1, 0, 2, out int rightWin);

            if (leftFill && leftWin != 0)
            {
                return leftWin;
            }
            if (rightFill && rightWin != 0)
            {
                return rightWin;
            }
            return 0;
        }


        private bool checkLine(int rowMod, int columnMod, int rowStart, int columnStart, out int winMarkId)
        {
            int firstMarkId = 0;
            winMarkId = 0;
            for (int i = 0; i < 3; i++)
            {
                int rowSelect = rowStart + (rowMod * i);
                int columnSelect = columnStart + (columnMod * i);

                int foundMarkId = Board[rowSelect, columnSelect].MarkId;

                if(foundMarkId == 0)
                {
                    return false;
                }

                if(i == 0)
                {
                    firstMarkId = foundMarkId;
                }
                if(firstMarkId != foundMarkId)
                {
                    firstMarkId = 0;
                }
            }
            winMarkId = firstMarkId;
            return true;
        }
    }
}
