using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class TicTacToeItem : IGridItem
    {
        public Player Player { get; set; }

        public bool EmptyItem()
        {
            return Player == null;
        }

        public string GetMark()
        {
            if (Player == null)
                return " ";

            return Player.Symbol;
        }
       
    }
}
