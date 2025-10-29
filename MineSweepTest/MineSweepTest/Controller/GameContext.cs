using MineSweepTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Controller
{
    internal class GameContext
    {
        private IGameState gameState;

        public void SetGameState(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void PlayGame() 
        {
            gameState.StartGame();
            do 
            { 
                gameState.ShowGame();
            } while (!gameState.TakeTurn());

            gameState.ShowGame();
            gameState.DisplayEndResults();
        }
    }
}
