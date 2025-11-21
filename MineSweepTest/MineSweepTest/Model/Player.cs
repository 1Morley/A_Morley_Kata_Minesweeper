using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class Player
    {
        public string Symbol {  get; private set; }

        public Player(string symbol)
        {
            Symbol = symbol;
        }

        public string Title()
        {
            return Symbol;
        }
    }
}
