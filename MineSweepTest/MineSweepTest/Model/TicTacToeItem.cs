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

        public IDisplay display { get; private set; }

        public TicTacToeItem()
        {
            display = new BoldDisplayDecor(new GridDisplayDecor(new PlainDisplay()));
        }
        public bool EmptyItem()
        {
            return Player == null;
        }

        public string GetMark()
        {
            //if (Player == null)
            //    return " ";

            //return Player.Symbol;

            string symbol = " ";

            if (Player != null)
            {
                symbol = Player.Symbol;
            }

            return display.FormatString(symbol);
        }
       
    }
}
