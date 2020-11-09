namespace PanPrstenuDveVeze
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.canvas1 = new PanPrstenuDveVeze.Canvas();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.addTowerButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.instakill = new PanPrstenuDveVeze.Buff();
            this.doublepoints = new PanPrstenuDveVeze.Buff();
            this.immortality = new PanPrstenuDveVeze.Buff();
            this.SuspendLayout();
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.Color.White;
            this.canvas1.Location = new System.Drawing.Point(12, 83);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(1263, 721);
            this.canvas1.TabIndex = 0;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreLabel.Location = new System.Drawing.Point(713, 32);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(65, 24);
            this.scoreLabel.TabIndex = 7;
            this.scoreLabel.Text = "Score:";
            // 
            // addTowerButton
            // 
            this.addTowerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addTowerButton.Location = new System.Drawing.Point(902, 17);
            this.addTowerButton.Name = "addTowerButton";
            this.addTowerButton.Size = new System.Drawing.Size(88, 55);
            this.addTowerButton.TabIndex = 8;
            this.addTowerButton.Text = "+";
            this.addTowerButton.UseVisualStyleBackColor = true;
            // 
            // instakill
            // 
            this.instakill.Location = new System.Drawing.Point(72, 12);
            this.instakill.Name = "instakill";
            this.instakill.Size = new System.Drawing.Size(173, 65);
            this.instakill.TabIndex = 9;
            // 
            // doublepoints
            // 
            this.doublepoints.Location = new System.Drawing.Point(251, 12);
            this.doublepoints.Name = "doublepoints";
            this.doublepoints.Size = new System.Drawing.Size(173, 65);
            this.doublepoints.TabIndex = 10;
            // 
            // immortality
            // 
            this.immortality.Location = new System.Drawing.Point(430, 12);
            this.immortality.Name = "immortality";
            this.immortality.Size = new System.Drawing.Size(173, 65);
            this.immortality.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 816);
            this.Controls.Add(this.immortality);
            this.Controls.Add(this.doublepoints);
            this.Controls.Add(this.instakill);
            this.Controls.Add(this.addTowerButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.canvas1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Canvas canvas1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button addTowerButton;
        private System.Windows.Forms.Timer gameTimer;
        private Buff instakill;
        private Buff doublepoints;
        private Buff immortality;
    }
}

