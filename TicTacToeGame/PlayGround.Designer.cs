namespace TicTacToe
{
    partial class PlayGround
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.computerTimer = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnTile9 = new System.Windows.Forms.Button();
            this.btnTile8 = new System.Windows.Forms.Button();
            this.btnTile7 = new System.Windows.Forms.Button();
            this.btnTile6 = new System.Windows.Forms.Button();
            this.btnTile5 = new System.Windows.Forms.Button();
            this.btnTile4 = new System.Windows.Forms.Button();
            this.btnTile3 = new System.Windows.Forms.Button();
            this.btnTile2 = new System.Windows.Forms.Button();
            this.btnTile1 = new System.Windows.Forms.Button();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblComputer = new System.Windows.Forms.Label();
            this.tabTicTacToe = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabTicTacToe.SuspendLayout();
            this.SuspendLayout();
            // 
            // computerTimer
            // 
            this.computerTimer.Tick += new System.EventHandler(this.computerTimer_Tick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblDifficulty);
            this.tabPage1.Controls.Add(this.btnRestart);
            this.tabPage1.Controls.Add(this.btnTile9);
            this.tabPage1.Controls.Add(this.btnTile8);
            this.tabPage1.Controls.Add(this.btnTile7);
            this.tabPage1.Controls.Add(this.btnTile6);
            this.tabPage1.Controls.Add(this.btnTile5);
            this.tabPage1.Controls.Add(this.btnTile4);
            this.tabPage1.Controls.Add(this.btnTile3);
            this.tabPage1.Controls.Add(this.btnTile2);
            this.tabPage1.Controls.Add(this.btnTile1);
            this.tabPage1.Controls.Add(this.lblPlayer);
            this.tabPage1.Controls.Add(this.lblComputer);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(649, 757);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tic Tac Toe game";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDifficulty.Location = new System.Drawing.Point(9, 125);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(70, 28);
            this.lblDifficulty.TabIndex = 12;
            this.lblDifficulty.Text = "label1";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(9, 690);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(205, 61);
            this.btnRestart.TabIndex = 11;
            this.btnRestart.Text = "RESTART GAME";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnTile9
            // 
            this.btnTile9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile9.Location = new System.Drawing.Point(431, 512);
            this.btnTile9.Name = "btnTile9";
            this.btnTile9.Size = new System.Drawing.Size(205, 161);
            this.btnTile9.TabIndex = 10;
            this.btnTile9.Text = "btnTile9";
            this.btnTile9.UseVisualStyleBackColor = true;
            this.btnTile9.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile8
            // 
            this.btnTile8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile8.Location = new System.Drawing.Point(220, 512);
            this.btnTile8.Name = "btnTile8";
            this.btnTile8.Size = new System.Drawing.Size(205, 161);
            this.btnTile8.TabIndex = 9;
            this.btnTile8.Text = "btnTile8";
            this.btnTile8.UseVisualStyleBackColor = true;
            this.btnTile8.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile7
            // 
            this.btnTile7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile7.Location = new System.Drawing.Point(9, 512);
            this.btnTile7.Name = "btnTile7";
            this.btnTile7.Size = new System.Drawing.Size(205, 161);
            this.btnTile7.TabIndex = 8;
            this.btnTile7.Text = "btnTile7";
            this.btnTile7.UseVisualStyleBackColor = true;
            this.btnTile7.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile6
            // 
            this.btnTile6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile6.Location = new System.Drawing.Point(431, 345);
            this.btnTile6.Name = "btnTile6";
            this.btnTile6.Size = new System.Drawing.Size(205, 161);
            this.btnTile6.TabIndex = 7;
            this.btnTile6.Text = "btnTile6";
            this.btnTile6.UseVisualStyleBackColor = true;
            this.btnTile6.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile5
            // 
            this.btnTile5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile5.Location = new System.Drawing.Point(220, 345);
            this.btnTile5.Name = "btnTile5";
            this.btnTile5.Size = new System.Drawing.Size(205, 161);
            this.btnTile5.TabIndex = 6;
            this.btnTile5.Text = "btnTile5";
            this.btnTile5.UseVisualStyleBackColor = true;
            this.btnTile5.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile4
            // 
            this.btnTile4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile4.Location = new System.Drawing.Point(9, 345);
            this.btnTile4.Name = "btnTile4";
            this.btnTile4.Size = new System.Drawing.Size(205, 161);
            this.btnTile4.TabIndex = 5;
            this.btnTile4.Text = "btnTile4";
            this.btnTile4.UseVisualStyleBackColor = true;
            this.btnTile4.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile3
            // 
            this.btnTile3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile3.Location = new System.Drawing.Point(431, 178);
            this.btnTile3.Name = "btnTile3";
            this.btnTile3.Size = new System.Drawing.Size(205, 161);
            this.btnTile3.TabIndex = 4;
            this.btnTile3.Text = "btnTile3";
            this.btnTile3.UseVisualStyleBackColor = true;
            this.btnTile3.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile2
            // 
            this.btnTile2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile2.Location = new System.Drawing.Point(220, 178);
            this.btnTile2.Name = "btnTile2";
            this.btnTile2.Size = new System.Drawing.Size(205, 161);
            this.btnTile2.TabIndex = 3;
            this.btnTile2.Text = "btnTile2";
            this.btnTile2.UseVisualStyleBackColor = true;
            this.btnTile2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTile1
            // 
            this.btnTile1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTile1.Location = new System.Drawing.Point(9, 178);
            this.btnTile1.Name = "btnTile1";
            this.btnTile1.Size = new System.Drawing.Size(205, 161);
            this.btnTile1.TabIndex = 2;
            this.btnTile1.Text = "btnTile1";
            this.btnTile1.UseVisualStyleBackColor = true;
            this.btnTile1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayer.Location = new System.Drawing.Point(9, 10);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(70, 28);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "label1";
            // 
            // lblComputer
            // 
            this.lblComputer.AutoSize = true;
            this.lblComputer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblComputer.Location = new System.Drawing.Point(9, 53);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(70, 28);
            this.lblComputer.TabIndex = 1;
            this.lblComputer.Text = "label1";
            // 
            // tabTicTacToe
            // 
            this.tabTicTacToe.Controls.Add(this.tabPage1);
            this.tabTicTacToe.Location = new System.Drawing.Point(12, 12);
            this.tabTicTacToe.Name = "tabTicTacToe";
            this.tabTicTacToe.SelectedIndex = 0;
            this.tabTicTacToe.Size = new System.Drawing.Size(657, 790);
            this.tabTicTacToe.TabIndex = 2;
            // 
            // PlayGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 814);
            this.Controls.Add(this.tabTicTacToe);
            this.Name = "PlayGround";
            this.Text = "Tic Tac Toe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayGround_FormClosed);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabTicTacToe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer computerTimer;
        private TabPage tabPage1;
        private Label lblDifficulty;
        private Button btnRestart;
        private Button btnTile9;
        private Button btnTile8;
        private Button btnTile7;
        private Button btnTile6;
        private Button btnTile5;
        private Button btnTile4;
        private Button btnTile3;
        private Button btnTile2;
        private Button btnTile1;
        private Label lblPlayer;
        private Label lblComputer;
        private TabControl tabTicTacToe;
    }
}