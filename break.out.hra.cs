namespace Breakout_Game
{
    partial class Form1
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
            this.txtScore = new System.Windows.Forms.Label();
            this.hrac = new System.Windows.Forms.PictureBox();
            this.mic = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hrac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(12, 9);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(87, 24);
            this.txtScore.TabIndex = 0;
            this.txtScore.Text = "Skóre: 0";
            this.txtScore.Click += new System.EventHandler(this.txtScore_Click);
            // 
            // hrac
            // 
            this.hrac.BackColor = System.Drawing.Color.White;
            this.hrac.Location = new System.Drawing.Point(342, 492);
            this.hrac.Name = "hrac";
            this.hrac.Size = new System.Drawing.Size(100, 32);
            this.hrac.TabIndex = 1;
            this.hrac.TabStop = false;
            this.hrac.Tag = "";
            this.hrac.Click += new System.EventHandler(this.player_Click);
            // 
            // mic
            // 
            this.mic.BackColor = System.Drawing.Color.Yellow;
            this.mic.Location = new System.Drawing.Point(378, 331);
            this.mic.Name = "mic";
            this.mic.Size = new System.Drawing.Size(25, 23);
            this.mic.TabIndex = 2;
            this.mic.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.mic);
            this.Controls.Add(this.hrac);
            this.Controls.Add(this.txtScore);
            this.Name = "Form1";
            this.Text = "Break Out Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.hrac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox mic;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox hrac;
    }
}

