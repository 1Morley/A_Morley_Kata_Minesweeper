using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal class PlayerIterator: Iterator<Player>
    {
        private int _currentPlayerTurn;
        private int CurrentPlayerTurn
        {
            get {  return _currentPlayerTurn; }
            set
            {
                if(value >= (Players.Length))
                {
                    _currentPlayerTurn = 0;
                }
                else
                {
                    _currentPlayerTurn = value;
                }
            }
        }
        private Player[] Players {  get; set; }

        public PlayerIterator(Player[] players)
        {
            Players = players;
        }
        public bool HasNext()
        {
            if ((CurrentPlayerTurn - 1) < Players.Length)
            {
                return true;
            }
            return false;
        }

        public Player Next()
        {
            CurrentPlayerTurn++;
            return GetCurrent();
        }

        public Player GetCurrent()
        {
            return Players[CurrentPlayerTurn];
        }
    }
}
