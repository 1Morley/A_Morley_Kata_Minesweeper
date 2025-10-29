using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Model
{
    internal interface IGameState
    {
        void DisplayEndResults();
        void ShowGame();
        void StartGame();
        bool TakeTurn();
    }
}
