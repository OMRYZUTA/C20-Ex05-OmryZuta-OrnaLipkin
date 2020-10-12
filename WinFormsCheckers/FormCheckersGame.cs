using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using C20_Ex02_Omry_308345826_Orna_043548734;

namespace WinFormsCheckers
{
    internal partial class FormCheckersGame : Form
    {
        private readonly Game r_Game;
        private readonly Point r_StartLocation = new Point(20, 80);
        private readonly Button[,] r_Buttons;
        private bool m_IsWhiteButtonClicked = false;
        private bool m_SwitchTurn = true;
        private WhiteButton m_LastClickedWhiteButton = null;

        public FormCheckersGame(Game i_Game)
        {
            r_Game = i_Game;
            r_Game.ReportOverDelegates += Game_IsOver;
            r_Buttons = new Button[i_Game.Board.Size, i_Game.Board.Size];
            initializeBoard(i_Game.Board);
            InitializeComponent();
            labelPlayer1.Text = string.Format("{0} (X):", i_Game.PlayerX.Name);
            labelPlayer1.Tag = i_Game.PlayerX;
            labelPlayer2.Text = string.Format("{0} (O):", i_Game.PlayerO.Name);
            labelPlayer2.Tag = i_Game.PlayerO;
            highlightWhoseTurn();
        }

        private void initializeBoard(Board i_Board)
        {
            for (int i = 0; i < i_Board.Size; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    Button button = addButton(i_Board, i, j);
                    r_Buttons[i, j] = button;
                }
            }
        }

        private Button addButton(Board i_Board, int i_IIndex, int i_JIndex)
        {
            Position currentPosition = i_Board.GetPositionAt(i_IIndex, i_JIndex);
            Button button;
            if ((i_IIndex % 2 == 0 && i_JIndex % 2 == 0) || (i_IIndex % 2 != 0 && i_JIndex % 2 != 0))
            {
                button = createBlackButton(currentPosition);
            }
            else
            {
                button = createWhiteButton(currentPosition);
            }

            return button;
        }

        private Button createBlackButton(Position i_CurrentPosition)
        {
            BlackButton blackButton = new BlackButton(i_CurrentPosition, r_StartLocation);
            Controls.Add(blackButton);
            return blackButton;
        }

        private Button createWhiteButton(Position i_CurrentPosition)
        {
            WhiteButton whiteButton = new WhiteButton(i_CurrentPosition, r_StartLocation);
            Controls.Add(whiteButton);
            whiteButton.Click += new EventHandler(WhiteButton_Click);
            return whiteButton;
        }

        private void resetBoard(Board i_Board)
        {
            for (int i = 0; i < i_Board.Size; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    if (r_Buttons[i, j] is WhiteButton)
                    {
                        (r_Buttons[i, j] as WhiteButton).ResetPosition(i_Board.GetPositionAt(i, j));
                    }
                }
            }
        }

        private void WhiteButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            WhiteButton whiteButton = i_Sender as WhiteButton;

            if (m_IsWhiteButtonClicked)
            {
                doWhenWhiteButtonAlreadyClicked(whiteButton);
                r_Game.IsGameOver();
            }
            else
            {
                doWhenNothingAlreadyClicked(whiteButton);
            }
        }

        private void doWhenWhiteButtonAlreadyClicked(WhiteButton i_WhiteButton)
        {
            unclickButton(i_WhiteButton);
            if (m_LastClickedWhiteButton != i_WhiteButton && !tryToMakeMove(i_WhiteButton))
            {
                MessageBox.Show("Illegal Move!");
            }
        }

        private bool tryToMakeMove(WhiteButton i_WhiteButton)
        {
            bool answer = true;
            List<Move> legalMoves = r_Game.FindAllLegalMoves();
            string moveString = string.Format(
                "{0}>{1}",
                m_LastClickedWhiteButton.Position.ToString(),
                i_WhiteButton.Position.ToString());
            Player currentPlayer = r_Game.CurrentPlayer;
            Move move = currentPlayer.CheckIfLegalMove(legalMoves, moveString);
            if (move == null)
            {
                answer = false;
            }
            else
            {
                doWhenMoveNotNull(move);
            }

            return answer;
        }

        private void doWhenMoveNotNull(Move i_Move)
        {
            m_SwitchTurn = r_Game.ApplyMove(i_Move);

            if (r_Game.IsGameOver())
            {
                doWhenGameOver();
            }
            else
            {
                highlightWhoseTurn();
                applyComputerMoves();
            }
        }

        private void applyComputerMoves() // and follow up moves
        {
            if (m_SwitchTurn)
            {
                if (r_Game.CurrentPlayer.IsComputer)
                {
                    timerComputerMove.Enabled = true;
                }
            }
        }

        private void highlightWhoseTurn()
        {
            if (labelPlayer1.Tag == r_Game.CurrentPlayer)
            {
                labelPlayer1.BackColor = SystemColors.GradientInactiveCaption;
                labelPlayer2.BackColor = SystemColors.Control;
            }
            else
            {
                labelPlayer2.BackColor = SystemColors.GradientInactiveCaption;
                labelPlayer1.BackColor = SystemColors.Control;
            }
        }

        private void doWhenGameOver()
        {
            m_SwitchTurn = true;
            m_IsWhiteButtonClicked = false;
            m_LastClickedWhiteButton = null;
        }

        private void applyComputerPlay()
        {
            List<Move> legalMoves = r_Game.FindAllLegalMoves();
            Move move = r_Game.CurrentPlayer.ChooseMoveFromList(legalMoves);
            m_SwitchTurn = r_Game.ApplyMove(move);
            if (m_SwitchTurn)
            {
                highlightWhoseTurn();
            }
        }

        private void doWhenNothingAlreadyClicked(WhiteButton i_WhiteButton)
        {
            if (i_WhiteButton.Position.IsOccupiedByPlayer(r_Game.CurrentPlayer)
               && r_Game.FindLegalMovesFromPosition(i_WhiteButton.Position).Count > 0)
            {
                i_WhiteButton.IsClicked = true;
                m_IsWhiteButtonClicked = true;
                i_WhiteButton.BackColor = Color.Aqua;
                m_LastClickedWhiteButton = i_WhiteButton;
            }
            else
            {
                MessageBox.Show(this.Owner, "Please Try Again", "Unavailable position!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Game_IsOver(Game i_Game)
        {
            i_Game.CheckIfTieOrWin(out Player winner);
            winner.Score += r_Game.Board.CalculateScoreDifference();
            labelPlayer1Score.Text = i_Game.PlayerX.Score.ToString();
            lablePlayer2Score.Text = i_Game.PlayerO.Score.ToString();
            if (winner == null)
            {
                doWhenTie();
            }
            else
            {
                doWhenSomeOneWon(winner);
            }
        }

        private void doWhenSomeOneWon(Player i_Winner)
        {
            m_LastClickedWhiteButton.IsClicked = false;
            m_LastClickedWhiteButton.BackColor = Color.White;
            string message = string.Format(
                "{0} won!{1}Another Round?",
                i_Winner.Name,
                Environment.NewLine);
            string title = "Damka";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                r_Game.ResetGameState();
                highlightWhoseTurn();
                resetBoard(r_Game.Board);
            }
            else
            {
                Close();
            }
        }

        private void doWhenTie()
        {
            string message = @"Tie!
Another Round?";
            string title = "Damka";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                r_Game.ResetGameState();
            }
            else
            {
                Close();
            }
        }

        private void unclickButton(WhiteButton i_WhiteButton)
        {
            m_LastClickedWhiteButton.IsClicked = false;
            m_LastClickedWhiteButton.BackColor = Color.White;
            i_WhiteButton.IsClicked = false;
            m_IsWhiteButtonClicked = false;
        }

        private void timerComputerMove_Tick(object sender, EventArgs e)
        {
            timerComputerMove.Enabled = false; // disable
            applyComputerPlay();

            if (r_Game.IsGameOver())
            {
                doWhenGameOver();
            }
            else if (!m_SwitchTurn)
            {
                timerComputerMove.Enabled = true;
            }
        }
    }
}
