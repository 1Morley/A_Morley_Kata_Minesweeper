using MineSweepTest.Model;
using MineSweepTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.Controller
{
    internal class TicTacToeController : IGameState
    {
        private bool isPlayerOne = true;
        private int winnerMarkId;
        private TicTacToeBoard board;
        private TicTacToeUI ui;

        public TicTacToeController()
        {
            ui = new TicTacToeUI();
        }
        public void DisplayEndResults()
        {
            ui.EndGameDisplay(winnerMarkId);
        }

        public void ShowGame()
        {
            ui.DisplayBoard(board.Board);
        }

        public void StartGame()
        {
            
            board = new TicTacToeBoard();
        }

        public bool TakeTurn()
        {
            ui.GetPlayerMark(isPlayerOne,out int row, out int column);
            if (board.PlaceMark(isPlayerOne, row, column))
            {
                if (board.isGameOver(out winnerMarkId))
                {
                    return true;
                }
                isPlayerOne = !isPlayerOne;
            }
            return false;
        }
    }
}
