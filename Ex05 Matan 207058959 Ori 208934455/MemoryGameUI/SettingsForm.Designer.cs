
namespace MemoryGameUI
{
    partial class SettingsForm
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
            this.firstPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayeNameLabel = new System.Windows.Forms.Label();
            this.firstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.changeOpponentTypeButton = new System.Windows.Forms.Button();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPlayerNameLabel
            // 
            this.firstPlayerNameLabel.AutoSize = true;
            this.firstPlayerNameLabel.Location = new System.Drawing.Point(12, 9);
            this.firstPlayerNameLabel.Name = "firstPlayerNameLabel";
            this.firstPlayerNameLabel.Size = new System.Drawing.Size(92, 13);
            this.firstPlayerNameLabel.TabIndex = 0;
            this.firstPlayerNameLabel.Text = "First Player Name:";
            // 
            // secondPlayeNameLabel
            // 
            this.secondPlayeNameLabel.AutoSize = true;
            this.secondPlayeNameLabel.Location = new System.Drawing.Point(12, 39);
            this.secondPlayeNameLabel.Name = "secondPlayeNameLabel";
            this.secondPlayeNameLabel.Size = new System.Drawing.Size(110, 13);
            this.secondPlayeNameLabel.TabIndex = 3;
            this.secondPlayeNameLabel.Text = "Second Player Name:";
            // 
            // firstPlayerNameTextBox
            // 
            this.firstPlayerNameTextBox.Location = new System.Drawing.Point(134, 6);
            this.firstPlayerNameTextBox.Name = "firstPlayerNameTextBox";
            this.firstPlayerNameTextBox.Size = new System.Drawing.Size(133, 20);
            this.firstPlayerNameTextBox.TabIndex = 1;
            // 
            // secondPlayerNameTextBox
            // 
            this.secondPlayerNameTextBox.Enabled = false;
            this.secondPlayerNameTextBox.Location = new System.Drawing.Point(134, 36);
            this.secondPlayerNameTextBox.Name = "secondPlayerNameTextBox";
            this.secondPlayerNameTextBox.Size = new System.Drawing.Size(133, 20);
            this.secondPlayerNameTextBox.TabIndex = 4;
            this.secondPlayerNameTextBox.Text = "- computer -";
            // 
            // changeOpponentTypeButton
            // 
            this.changeOpponentTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeOpponentTypeButton.Location = new System.Drawing.Point(285, 36);
            this.changeOpponentTypeButton.Name = "changeOpponentTypeButton";
            this.changeOpponentTypeButton.Size = new System.Drawing.Size(105, 22);
            this.changeOpponentTypeButton.TabIndex = 2;
            this.changeOpponentTypeButton.Text = "Against a Friend";
            this.changeOpponentTypeButton.UseVisualStyleBackColor = true;
            this.changeOpponentTypeButton.Click += new System.EventHandler(this.changeOpponentTypeButton_Click);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(12, 71);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(61, 13);
            this.boardSizeLabel.TabIndex = 6;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startButton.Location = new System.Drawing.Point(315, 129);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // boardSizeButton
            // 
            this.boardSizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.boardSizeButton.Location = new System.Drawing.Point(12, 96);
            this.boardSizeButton.Name = "boardSizeButton";
            this.boardSizeButton.Size = new System.Drawing.Size(110, 65);
            this.boardSizeButton.TabIndex = 9;
            this.boardSizeButton.Text = "4 x 4";
            this.boardSizeButton.UseVisualStyleBackColor = false;
            this.boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(402, 164);
            this.Controls.Add(this.boardSizeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.changeOpponentTypeButton);
            this.Controls.Add(this.secondPlayerNameTextBox);
            this.Controls.Add(this.firstPlayerNameTextBox);
            this.Controls.Add(this.secondPlayeNameLabel);
            this.Controls.Add(this.firstPlayerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstPlayerNameLabel;
        private System.Windows.Forms.Label secondPlayeNameLabel;
        private System.Windows.Forms.TextBox firstPlayerNameTextBox;
        private System.Windows.Forms.TextBox secondPlayerNameTextBox;
        private System.Windows.Forms.Button changeOpponentTypeButton;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button boardSizeButton;
    }
}