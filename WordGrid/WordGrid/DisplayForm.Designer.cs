namespace WordGrid
{
    partial class Display
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Reset = new System.Windows.Forms.ToolStripButton();
            this.Score = new System.Windows.Forms.Label();
            this.ScoreMax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridPanel.AutoSize = true;
            this.gridPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridPanel.Location = new System.Drawing.Point(130, 104);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(2);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(525, 528);
            this.gridPanel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Reset
            // 
            this.Reset.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Reset.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.ForeColor = System.Drawing.Color.Yellow;
            this.Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(134, 22);
            this.Reset.Text = "NOUVELLE PARTIE";
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(123, 49);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(39, 42);
            this.Score.TabIndex = 2;
            this.Score.Text = "0";
            // 
            // ScoreMax
            // 
            this.ScoreMax.AutoSize = true;
            this.ScoreMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreMax.Location = new System.Drawing.Point(660, 120);
            this.ScoreMax.Name = "ScoreMax";
            this.ScoreMax.Size = new System.Drawing.Size(24, 25);
            this.ScoreMax.TabIndex = 3;
            this.ScoreMax.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(661, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "RECORD";
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 734);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScoreMax);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gridPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Display";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordGrid";
            this.Load += new System.EventHandler(this.Display_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Reset;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label ScoreMax;
        private System.Windows.Forms.Label label1;
    }
}

