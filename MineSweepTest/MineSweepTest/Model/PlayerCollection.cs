using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class PlayerCollection : IterableCollection<Player>
    {
        public Player[] Players {  get; set; }
        public PlayerCollection(Player[] players)
        {
            Players = players;
        }
        public Iterator<Player> CreateIterator()
        {
            return new PlayerIterator(Players);
        }
    }
}
