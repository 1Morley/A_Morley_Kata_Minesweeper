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
        public void GetPlayerMark(Player currentPlayer, out int row, out int column) 
        {
            GetItemCords($"{currentPlayer.Title()}'s Turn:", 3, 3, out row, out column);
        }

        public void EndGameDisplay(Player Winner)
        {
            string message;
            if(Winner == null)
            {
                message = "DONE: YOU BOTH LOSE :D";
            }
            else
            {
                message = $"DONE: {Winner.Title()} WIN :D";
            }
            Console.WriteLine(message);
        }

    }
}
