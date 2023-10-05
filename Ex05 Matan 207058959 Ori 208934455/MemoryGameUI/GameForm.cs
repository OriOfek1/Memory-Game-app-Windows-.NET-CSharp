using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MemoryGameLogic;
using Timer = System.Windows.Forms.Timer;

namespace MemoryGameUI
{
    public partial class GameForm : Form
    {
        private int m_MovesCount = 0;
        public Button[,] CardButtons { get; set; }

        public int MovesCount
        {
            get => m_MovesCount;
            set => m_MovesCount = value;
        }

        //public string 

        public Button FirstCardClicked { get; set; }

        public Button SecondCardClicked { get; set; }

        public int SelectedRow { get; set; }

        public int SelectedColumn { get; set; }

        public Timer TimerGameForm
        {
            get => timerGameForm;
        }

        public GameForm()
        {
            InitializeComponent();
            //timerGameForm.Tick += new EventHandler(TimerEventProcessor);
        }

        //private static void TimerEventProcessor(object i_Sender, EventArgs i_E)
        //{
            
        //}

        public event Action Activated;

        public void GameForm_Load()
        {
            int numOfRows = UILogic.NumberOfRows;
            int numOfColumns = UILogic.NumberOfColumns;
            string player1Name = UILogic.Player1.Name;
            string player2Name = UILogic.Player2.Name;

            labelFirstPlayerName.Text = player1Name;
            labelPlayer1Score.Text = UILogic.Player1.Score.ToString();
            labelSecondPlayerName.Text = player2Name;
            labelPlayer2Score.Text = UILogic.Player2.Score.ToString();
            labelDynamicCurrentPlayerName.Text = player1Name;
            labelDynamicCurrentPlayerName.BackColor = Color.Aquamarine;

            CardButtons = new Button[numOfRows, numOfColumns];

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    Button newCardButton = new Button
                    {
                        Size = new Size(90, 90),
                        Location = new Point(100 * j, (100 * i) + 50),
                    };

                    //newButton.Image =
                    //    Properties.Resources.ResourceManager.GetObject(
                    //        UILogic.GameBoard.LogicalGameBoard[i, j].ToString()) as Image;
                    newCardButton.BackgroundImageLayout = ImageLayout.Center;
                    newCardButton.Tag = new Point(i, j);

                    Controls.Add(newCardButton);

                    CardButtons[i, j] = newCardButton;

                    newCardButton.Click += cardButton_Click;
                }
            }

            panelStats.Top += 120;
            this.Height += 100;
        }

        private void cardButton_Click(object sender, EventArgs e)
        {
            Button clickedCard = (Button)sender;
            int cardButtonRow = (int)((Point)clickedCard.Tag).X;
            int cardButtonColumn = (int)((Point)clickedCard.Tag).Y;
            //string debugRowCol = string.Format(@"{0},{1}", cardButtonRow, cardButtonColumn);
            //Debug.WriteLine(debugRowCol);   // debug

            SelectedRow = cardButtonRow;
            SelectedColumn = cardButtonColumn;

            CardSelected(clickedCard);
            MovesCount++;

            if(Activated != null)
            {
                Activated.Invoke();
            }

            while (UILogic.Turn == eTurn.Player2 && UILogic.Player2.PlayerType == ePlayerType.Computer)
            {
                this.Update();

                if (this.Activated != null)
                {
                    Activated.Invoke();
                }

                timerGameForm.Start();
            }

            //if (MovesCount == 1)
            //{
            //    FirstCardClicked = clickedCard;

            //}
            //else if(MovesCount == 2)
            //{
            //    SecondCardClicked = clickedCard;
            //    if(Activated != null)
            //    {
            //        Activated.Invoke();
            //    }
            //}

        }

        public void CardSelected(Button i_clickedCardButton)
        {
            int cardButtonRow = (int)((Point)i_clickedCardButton.Tag).X;
            int cardButtonColumn = (int)((Point)i_clickedCardButton.Tag).Y;
            i_clickedCardButton.BackgroundImage = Properties.Resources.ResourceManager.GetObject(
                                                      UILogic.GameBoard.LogicalGameBoard[cardButtonRow, cardButtonColumn].ToString()) as Image;
            i_clickedCardButton.Enabled = false;
        }

        public void UpdateCurrentPlayerLabel(string i_CurrentPlayerName)
        {
            labelDynamicCurrentPlayerName.Text = i_CurrentPlayerName;
            if(labelFirstPlayerName.Text == i_CurrentPlayerName)
            {
                labelDynamicCurrentPlayerName.BackColor = Color.Aquamarine;
            }
            else
            {
                labelDynamicCurrentPlayerName.BackColor = Color.CornflowerBlue;
            }
        }

        public void UpdateCurrentPlayerScore(string i_PlayerName, int i_Score)
        {
            if(labelFirstPlayerName.Text == i_PlayerName)
            {
                labelPlayer1Score.Text = i_Score.ToString();
            }
            else
            {
                labelPlayer2Score.Text = i_Score.ToString();
            }
        }

        public void DisableAllBoard()
        {
            foreach(Button cardButton in CardButtons)
            {
                cardButton.Enabled = false;
            }
        }

        public void EnableAllBoard()
        {
            foreach (Button cardButton in CardButtons)
            {
                cardButton.Enabled = true;
            }
        }

        public void UpdateGameBoard()
        {
            int numOfRows = UILogic.NumberOfRows;
            int numOfColumns = UILogic.NumberOfColumns;
            for(int i = 0; i < numOfRows; i++)
            {
                for(int j = 0; j < numOfColumns; j++)
                {
                    Button newCardButton = CardButtons[i, j];
                    newCardButton.BackgroundImage = null;
                    newCardButton.Enabled = true;
                }
            }

            labelPlayer1Score.Text = UILogic.Player1.Score.ToString();
            labelPlayer2Score.Text = UILogic.Player2.Score.ToString();
        }

        private void timerGameForm_Tick(object sender, EventArgs e)
        {
            timerGameForm.Stop();

        }
    }
}
