using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using C20_Ex02_Omry_308345826_Orna_043548734;

namespace WinFormsCheckers
{
    internal static class FormsManager
    {
        public static void RunCheckers()
        {
            FormGameSettings gameSettings = new FormGameSettings();
            gameSettings.ShowDialog();
            if (gameSettings.DialogResult == DialogResult.OK)
            {
                createGame(gameSettings);
            }
        }

        private static void createGame(FormGameSettings i_FormGameSettings)
        {
            Player player1 = new Player(i_FormGameSettings.Player1Name, ePieceType.X);
            eBoardSize boardSize = i_FormGameSettings.BoardSize;
            Player player2 = i_FormGameSettings.IsSinglePlayerMode ?
                                 new Player(ePieceType.O) :
                                 new Player(i_FormGameSettings.Player2Name, ePieceType.O);

            playCheckers(new Game(boardSize, player1, player2));
        }

        private static void playCheckers(Game i_Game)
        {
            i_Game.ResetGameState();
            FormCheckersGame checkersGame = new FormCheckersGame(i_Game);
            checkersGame.ShowDialog();            
        }
    }
}
