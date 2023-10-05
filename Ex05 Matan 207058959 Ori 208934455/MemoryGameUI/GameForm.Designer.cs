
namespace MemoryGameUI
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelFirstPlayerName = new System.Windows.Forms.Label();
            this.labelDynamicCurrentPlayerName = new System.Windows.Forms.Label();
            this.labelSecondPlayerName = new System.Windows.Forms.Label();
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.timerGameForm = new System.Windows.Forms.Timer(this.components);
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFirstPlayerName
            // 
            this.labelFirstPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFirstPlayerName.AutoSize = true;
            this.labelFirstPlayerName.BackColor = System.Drawing.Color.Aquamarine;
            this.labelFirstPlayerName.Location = new System.Drawing.Point(1, 32);
            this.labelFirstPlayerName.Name = "labelFirstPlayerName";
            this.labelFirstPlayerName.Size = new System.Drawing.Size(67, 13);
            this.labelFirstPlayerName.TabIndex = 0;
            this.labelFirstPlayerName.Text = "player1name";
            // 
            // labelDynamicCurrentPlayerName
            // 
            this.labelDynamicCurrentPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDynamicCurrentPlayerName.AutoSize = true;
            this.labelDynamicCurrentPlayerName.Location = new System.Drawing.Point(84, 9);
            this.labelDynamicCurrentPlayerName.Name = "labelDynamicCurrentPlayerName";
            this.labelDynamicCurrentPlayerName.Size = new System.Drawing.Size(0, 13);
            this.labelDynamicCurrentPlayerName.TabIndex = 3;
            // 
            // labelSecondPlayerName
            // 
            this.labelSecondPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSecondPlayerName.AutoSize = true;
            this.labelSecondPlayerName.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelSecondPlayerName.Location = new System.Drawing.Point(1, 57);
            this.labelSecondPlayerName.Name = "labelSecondPlayerName";
            this.labelSecondPlayerName.Size = new System.Drawing.Size(67, 13);
            this.labelSecondPlayerName.TabIndex = 1;
            this.labelSecondPlayerName.Text = "player2name";
            // 
            // labelCurrentPlayer
            // 
            this.labelCurrentPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurrentPlayer.AutoSize = true;
            this.labelCurrentPlayer.Location = new System.Drawing.Point(1, 9);
            this.labelCurrentPlayer.Name = "labelCurrentPlayer";
            this.labelCurrentPlayer.Size = new System.Drawing.Size(76, 13);
            this.labelCurrentPlayer.TabIndex = 2;
            this.labelCurrentPlayer.Text = "Current Player:";
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelStats.Controls.Add(this.labelPlayer2Score);
            this.panelStats.Controls.Add(this.labelPlayer1Score);
            this.panelStats.Controls.Add(this.labelCurrentPlayer);
            this.panelStats.Controls.Add(this.labelDynamicCurrentPlayerName);
            this.panelStats.Controls.Add(this.labelFirstPlayerName);
            this.panelStats.Controls.Add(this.labelSecondPlayerName);
            this.panelStats.Location = new System.Drawing.Point(12, 21);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(260, 89);
            this.panelStats.TabIndex = 4;
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Location = new System.Drawing.Point(74, 57);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(67, 13);
            this.labelPlayer2Score.TabIndex = 5;
            this.labelPlayer2Score.Text = "player2score";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Location = new System.Drawing.Point(74, 32);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(67, 13);
            this.labelPlayer1Score.TabIndex = 4;
            this.labelPlayer1Score.Text = "player1score";
            // 
            // timerGameForm
            // 
            this.timerGameForm.Interval = 2000;
            this.timerGameForm.Tick += new System.EventHandler(this.timerGameForm_Tick);
            // 
            // GameForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 232);
            this.Controls.Add(this.panelStats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label firstPlayerNameLabel;
        private System.Windows.Forms.Label secondPlayerNameLabel;
        private System.Windows.Forms.Label labelFirstPlayerName;
        private System.Windows.Forms.Label labelDynamicCurrentPlayerName;
        private System.Windows.Forms.Label labelSecondPlayerName;
        private System.Windows.Forms.Label labelCurrentPlayer;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Timer timerGameForm;
    }
}