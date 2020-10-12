using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C20_Ex02_Omry_308345826_Orna_043548734;

namespace WinFormsCheckers
{
    internal partial class FormGameSettings : Form
    {
        private string m_Player1Name;
        private string m_Player2Name;
        private eBoardSize m_BoardSize;
        private bool m_IsSinglePlayerMode = true;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }
        }

        public string Player2Name
        {
            get
            {
                return m_Player2Name;
            }
        }

        public eBoardSize BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public bool IsSinglePlayerMode
        {
            get
            {
                return m_IsSinglePlayerMode;
            }
        }

        private void checkBoxPlayer2_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            // in case the checkBox is checked
            // then the user can insert the name of the second player
            // else the second player checkbox isn't enabled 
            if(checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = string.Empty;
                m_IsSinglePlayerMode = false;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = "[Computer]";
                m_IsSinglePlayerMode = true;
            }
        }

        private void textBoxPlayer_TextChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (textBoxPlayer1.TextLength > 0 && textBoxPlayer2.TextLength > 0)
            {
                buttonDone.Enabled = true;
            }
            else
            {
                buttonDone.Enabled = false;
            }
        }

        private void buttonDone_Click(object i_Sender, EventArgs i_EventArgs)
        {
            setBoardSize();
            m_Player1Name = textBoxPlayer1.Text;
            m_Player2Name = textBoxPlayer2.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void setBoardSize()
        {
            if (radioButton6x6.Checked)
            {
                m_BoardSize = eBoardSize.Size6;
            }
            else if (radioButton8x8.Checked)
            {
                m_BoardSize = eBoardSize.Size8;
            }
            else
            {
                m_BoardSize = eBoardSize.Size10;
            }
        }
    }
}