using MineSweepTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.View
{
    internal class TicTacToeUI : GridUI<TicTacToeItem>
    {

    internal override string GetGridLabel(TicTacToeItem selectedItem)
        {
            switch (selectedItem.MarkId)
            {
                default:
                    return "[ ]";
                case 1:
                    return "[O]";
                case 2:
                    return "[X]";

            }

        }

        public void GetPlayerMark(bool playerOne, out int row, out int column) 
        {
            string mark = (playerOne) ? "O" : "X";
            GetItemCords($"Place {mark} on:", 3, 3, out row, out column);
        }

        public void EndGameDisplay(int gameResult)
        {
            switch (gameResult)
            {
                case 0:
                    Console.WriteLine("DONE: YOU BOTH LOSE :D");
                    break;
                case 1:
                    Console.WriteLine("DONE: CIRCLES WIN :D");
                    break;
                case 2:
                    Console.WriteLine("DONE: CROSSES WIN :D");
                    break;

            }
        }

    }
}
