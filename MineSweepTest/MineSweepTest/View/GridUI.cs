using MineSweepTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.View
{
    internal abstract class GridUI<T> where T : IGridItem
    {
        public void DisplayBoard(T[,] board)
        {
            StringBuilder gridBuilder = new StringBuilder();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                int columnlength = board.GetLength(1);
                for (int column = 0; column < columnlength; column++)
                {
                    gridBuilder.Append(GetGridLabel(board[row, column]));
                }
                gridBuilder.Append($" |{row}\n");
            }
            gridBuilder.Append('\n');
            Console.WriteLine(GetColumnCountDisplay(board.GetLength(1)));
            Console.WriteLine();
            Console.WriteLine(gridBuilder.ToString());

        }

        private string GetColumnCountDisplay(int length)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                string endSpace = "|";
                string startSpace = "| ";
                if (i < 10)
                {
                    endSpace = " |";
                }
                builder.Append(startSpace);
                builder.Append(i);
                builder.Append(endSpace);

            }
            return builder.ToString();
        }
        internal string GetGridLabel(IGridItem selectedItem)
        {
            return $"[ {selectedItem.GetMark()} ]";
        }
        public void GetItemCords(string message, int rowSize, int columnSize, out int row, out int column)
        {
            Console.WriteLine(message);
            column = BasicUI.getInt("X:", 0, columnSize - 1);
            row = BasicUI.getInt("Y:", 0, rowSize - 1);

        }
    }
}
