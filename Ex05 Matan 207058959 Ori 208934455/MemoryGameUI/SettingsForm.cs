using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    public partial class SettingsForm : Form
    {
        private int m_BoardSizeButtonIndex = 0;
        private eGameBoardSize m_BoardSize = eGameBoardSize.fourOnFour;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;
        private bool v_isSettingsFormClosedByStartButton = false;

        public string FirstPlayerName
        {
            get => m_FirstPlayerName;
        }

        public string SecondPlayerName
        {
            get => m_SecondPlayerName;
        }

        public TextBox SecondPlayerNameTextBox
        {
            get => secondPlayerNameTextBox;
        }

        public bool IsSettingsFormClosedByStartButton
        {
            get => v_isSettingsFormClosedByStartButton;
        }


        public eGameBoardSize GameBoardSize
        {
            get => m_BoardSize;
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void changeOpponentTypeButton_Click(object sender, EventArgs e)
        {
            if (changeOpponentTypeButton.Text == "Against a Friend")
            {
                secondPlayerNameTextBox.Enabled = true;
                secondPlayerNameTextBox.Text = string.Empty;
                changeOpponentTypeButton.Text = "Against Computer";
            }
            else
            {
                secondPlayerNameTextBox.Enabled = false;
                secondPlayerNameTextBox.Text = "- computer -";
                changeOpponentTypeButton.Text = "Against a Friend";
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            int numberOfBoardSizeOptions = Enum.GetNames(typeof(eGameBoardSize)).Length;
            m_BoardSizeButtonIndex = (m_BoardSizeButtonIndex + 1) % numberOfBoardSizeOptions;
            m_BoardSize = (eGameBoardSize)m_BoardSizeButtonIndex;
            boardSizeButton.Text = m_BoardSize.GetDescription();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            m_FirstPlayerName = firstPlayerNameTextBox.Text;
            m_SecondPlayerName = secondPlayerNameTextBox.Text;
            v_isSettingsFormClosedByStartButton = true;
            Close();
        }
    }
}
