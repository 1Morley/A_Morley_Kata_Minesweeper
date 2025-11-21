using MineSweepTest.Model;
using MineSweepTest.View;
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

        public GameContext()
        {
            string[] optionList = { "minesweeper", "tic tac toe" };

            while (true)
            {
                int userInput = BasicUI.getIndexFromList(optionList, true);
                switch (userInput)
                {
                    case 0:
                        return;
                    case 1:
                        SetGameState(new MinesweeperState());
                        break;
                    case 2:
                        SetGameState(new TicTacToeState());
                        break;
                }
                PlayGame();
            }

        }

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
