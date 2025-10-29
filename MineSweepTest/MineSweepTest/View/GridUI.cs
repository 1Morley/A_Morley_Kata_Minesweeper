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
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    Console.Write(GetGridLabel(board[row, column]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        internal abstract string GetGridLabel(T selectedItem);

        public void GetItemCords(string message, int rowSize, int columnSize, out int row, out int column)
        {
            Console.WriteLine(message);
            column = BasicUI.getInt("X:", 0, columnSize - 1);
            row = BasicUI.getInt("Y:", 0, rowSize - 1);

        }
    }
}
