using MineSweepTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Controller
{
    internal class GameSelectorController
    {
        public GameSelectorController() {
            GameContext player = new GameContext();
            string[] optionList = {"minesweeper", "tic tac toe" };


            while (true) {
                int userInput = BasicUI.getIndexFromList(optionList, true);
                switch (userInput)
                {
                    case 0:
                        return;
                    case 1:
                        player.SetGameState(new MinesweeperController());
                        break;
                    case 2:
                        player.SetGameState(new TicTacToeController());
                        break;
                }
                player.PlayGame();
            }
        }
    }
}
