namespace Space_Invaders
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lilguy = new System.Windows.Forms.Button();
            this.moveLilGuy = new System.Windows.Forms.Timer(this.components);
            this.moveBullet = new System.Windows.Forms.Timer(this.components);
            this.moveEnemies = new System.Windows.Forms.Timer(this.components);
            this.moveBullet2 = new System.Windows.Forms.Timer(this.components);
            this.GameOverLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lilguy
            // 
            this.lilguy.BackColor = System.Drawing.Color.Green;
            this.lilguy.FlatAppearance.BorderSize = 0;
            this.lilguy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lilguy.Location = new System.Drawing.Point(225, 425);
            this.lilguy.Name = "lilguy";
            this.lilguy.Size = new System.Drawing.Size(50, 20);
            this.lilguy.TabIndex = 0;
            this.lilguy.UseVisualStyleBackColor = false;
            this.lilguy.Click += new System.EventHandler(this.lilguy_Click);
            this.lilguy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lilguy_previewKeyDown);
            // 
            // moveLilGuy
            // 
            this.moveLilGuy.Tick += new System.EventHandler(this.moveLilGuy_Tick);
            // 
            // moveBullet
            // 
            this.moveBullet.Interval = 25;
            this.moveBullet.Tick += new System.EventHandler(this.moveBullet_Tick);
            // 
            // moveEnemies
            // 
            this.moveEnemies.Interval = 750;
            this.moveEnemies.Tick += new System.EventHandler(this.moveEnemies_Tick);
            // 
            // moveBullet2
            // 
            this.moveBullet2.Interval = 25;
            this.moveBullet2.Tick += new System.EventHandler(this.moveBullet2_Tick);
            // 
            // GameOverLine
            // 
            this.GameOverLine.Enabled = false;
            this.GameOverLine.FlatAppearance.BorderSize = 0;
            this.GameOverLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GameOverLine.Location = new System.Drawing.Point(0, 410);
            this.GameOverLine.Name = "GameOverLine";
            this.GameOverLine.Size = new System.Drawing.Size(510, 10);
            this.GameOverLine.TabIndex = 1;
            this.GameOverLine.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 459);
            this.Controls.Add(this.GameOverLine);
            this.Controls.Add(this.lilguy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "score: 0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lilguy;
        private System.Windows.Forms.Timer moveLilGuy;
        private System.Windows.Forms.Timer moveBullet;
        private System.Windows.Forms.Timer moveEnemies;
        private System.Windows.Forms.Timer moveBullet2;
        private System.Windows.Forms.Button GameOverLine;

    }
}

