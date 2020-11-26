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
            this.scoreLabel = new System.Windows.Forms.Label();
            this.addTowerButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.immortality = new PanPrstenuDveVeze.Buff();
            this.doublepoints = new PanPrstenuDveVeze.Buff();
            this.instakill = new PanPrstenuDveVeze.Buff();
            this.canvas1 = new PanPrstenuDveVeze.Canvas();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreLabel.Location = new System.Drawing.Point(951, 39);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(83, 29);
            this.scoreLabel.TabIndex = 7;
            this.scoreLabel.Text = "Score:";
            // 
            // addTowerButton
            // 
            this.addTowerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addTowerButton.Location = new System.Drawing.Point(1203, 21);
            this.addTowerButton.Margin = new System.Windows.Forms.Padding(4);
            this.addTowerButton.Name = "addTowerButton";
            this.addTowerButton.Size = new System.Drawing.Size(117, 68);
            this.addTowerButton.TabIndex = 8;
            this.addTowerButton.Text = "+";
            this.addTowerButton.UseVisualStyleBackColor = true;
            this.addTowerButton.Click += new System.EventHandler(this.AddTowerButton_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // immortality
            // 
            this.immortality.Location = new System.Drawing.Point(573, 15);
            this.immortality.Margin = new System.Windows.Forms.Padding(5);
            this.immortality.Name = "immortality";
            this.immortality.Size = new System.Drawing.Size(231, 80);
            this.immortality.TabIndex = 11;
            // 
            // doublepoints
            // 
            this.doublepoints.Location = new System.Drawing.Point(335, 15);
            this.doublepoints.Margin = new System.Windows.Forms.Padding(5);
            this.doublepoints.Name = "doublepoints";
            this.doublepoints.Size = new System.Drawing.Size(231, 80);
            this.doublepoints.TabIndex = 10;
            // 
            // instakill
            // 
            this.instakill.Location = new System.Drawing.Point(96, 15);
            this.instakill.Margin = new System.Windows.Forms.Padding(5);
            this.instakill.Name = "instakill";
            this.instakill.Size = new System.Drawing.Size(231, 80);
            this.instakill.TabIndex = 9;
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.Color.White;
            this.canvas1.Location = new System.Drawing.Point(16, 102);
            this.canvas1.Margin = new System.Windows.Forms.Padding(5);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(1684, 887);
            this.canvas1.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(876, 77);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 17);
            this.messageLabel.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1716, 1004);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.immortality);
            this.Controls.Add(this.doublepoints);
            this.Controls.Add(this.instakill);
            this.Controls.Add(this.addTowerButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.canvas1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label messageLabel;
    }
}

