namespace WinFormsCheckers
{
    internal partial class FormCheckersGame
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
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.lablePlayer2Score = new System.Windows.Forms.Label();
            this.flowLayoutPanelPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelPlayers = new System.Windows.Forms.TableLayoutPanel();
            this.timerComputerMove = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanelPlayers.SuspendLayout();
            this.tableLayoutPanelPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.labelPlayer1.Location = new System.Drawing.Point(2, 0);
            this.labelPlayer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(51, 13);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Player 1: ";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.BackColor = System.Drawing.SystemColors.Control;
            this.labelPlayer1Score.Location = new System.Drawing.Point(57, 0);
            this.labelPlayer1Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(13, 13);
            this.labelPlayer1Score.TabIndex = 1;
            this.labelPlayer1Score.Text = "0";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.BackColor = System.Drawing.SystemColors.Control;
            this.labelPlayer2.Location = new System.Drawing.Point(74, 0);
            this.labelPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(48, 13);
            this.labelPlayer2.TabIndex = 2;
            this.labelPlayer2.Text = "Player 2:";
            this.labelPlayer2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lablePlayer2Score
            // 
            this.lablePlayer2Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lablePlayer2Score.AutoSize = true;
            this.lablePlayer2Score.BackColor = System.Drawing.SystemColors.Control;
            this.lablePlayer2Score.Location = new System.Drawing.Point(126, 0);
            this.lablePlayer2Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lablePlayer2Score.Name = "lablePlayer2Score";
            this.lablePlayer2Score.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lablePlayer2Score.Size = new System.Drawing.Size(14, 13);
            this.lablePlayer2Score.TabIndex = 3;
            this.lablePlayer2Score.Text = "0";
            // 
            // flowLayoutPanelPlayers
            // 
            this.flowLayoutPanelPlayers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanelPlayers.AutoSize = true;
            this.flowLayoutPanelPlayers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelPlayers.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelPlayers.Controls.Add(this.labelPlayer1);
            this.flowLayoutPanelPlayers.Controls.Add(this.labelPlayer1Score);
            this.flowLayoutPanelPlayers.Controls.Add(this.labelPlayer2);
            this.flowLayoutPanelPlayers.Controls.Add(this.lablePlayer2Score);
            this.flowLayoutPanelPlayers.Location = new System.Drawing.Point(27, 3);
            this.flowLayoutPanelPlayers.Name = "flowLayoutPanelPlayers";
            this.flowLayoutPanelPlayers.Size = new System.Drawing.Size(142, 13);
            this.flowLayoutPanelPlayers.TabIndex = 4;
            // 
            // tableLayoutPanelPlayers
            // 
            this.tableLayoutPanelPlayers.AutoSize = true;
            this.tableLayoutPanelPlayers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelPlayers.ColumnCount = 1;
            this.tableLayoutPanelPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPlayers.Controls.Add(this.flowLayoutPanelPlayers, 0, 0);
            this.tableLayoutPanelPlayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelPlayers.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanelPlayers.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPlayers.Name = "tableLayoutPanelPlayers";
            this.tableLayoutPanelPlayers.RowCount = 1;
            this.tableLayoutPanelPlayers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPlayers.Size = new System.Drawing.Size(197, 19);
            this.tableLayoutPanelPlayers.TabIndex = 5;
            // 
            // timerComputerMove
            // 
            this.timerComputerMove.Interval = 500;
            this.timerComputerMove.Tick += new System.EventHandler(this.timerComputerMove_Tick);
            // 
            // FormCheckersGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(213, 293);
            this.Controls.Add(this.tableLayoutPanelPlayers);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormCheckersGame";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.flowLayoutPanelPlayers.ResumeLayout(false);
            this.flowLayoutPanelPlayers.PerformLayout();
            this.tableLayoutPanelPlayers.ResumeLayout(false);
            this.tableLayoutPanelPlayers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label lablePlayer2Score;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPlayers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPlayers;
        private System.Windows.Forms.Timer timerComputerMove;
    }
}