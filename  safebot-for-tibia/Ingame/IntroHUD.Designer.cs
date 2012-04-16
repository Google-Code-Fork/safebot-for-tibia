namespace SafeBot.Ingame
{
    partial class IntroHUD
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
            this.label1 = new System.Windows.Forms.Label();
            this.Updt = new System.Windows.Forms.Timer(this.components);
            this.sett = new System.Windows.Forms.Label();
            this.HealerHP = new System.Windows.Forms.Label();
            this.HealerMP = new System.Windows.Forms.Label();
            this.ManaShield = new System.Windows.Forms.Label();
            this.Haste = new System.Windows.Forms.Label();
            this.Checker = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SafeBot Active";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Updt
            // 
            this.Updt.Enabled = true;
            this.Updt.Interval = 500;
            this.Updt.Tick += new System.EventHandler(this.TimerMW_Tick);
            // 
            // sett
            // 
            this.sett.AutoSize = true;
            this.sett.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sett.ForeColor = System.Drawing.Color.Yellow;
            this.sett.Location = new System.Drawing.Point(-1, 28);
            this.sett.Name = "sett";
            this.sett.Size = new System.Drawing.Size(29, 13);
            this.sett.TabIndex = 1;
            this.sett.Text = "Set:";
            this.sett.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HealerHP
            // 
            this.HealerHP.AutoSize = true;
            this.HealerHP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealerHP.ForeColor = System.Drawing.Color.Yellow;
            this.HealerHP.Location = new System.Drawing.Point(-1, 44);
            this.HealerHP.Name = "HealerHP";
            this.HealerHP.Size = new System.Drawing.Size(65, 13);
            this.HealerHP.TabIndex = 2;
            this.HealerHP.Text = "Healer HP:";
            this.HealerHP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HealerMP
            // 
            this.HealerMP.AutoSize = true;
            this.HealerMP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealerMP.ForeColor = System.Drawing.Color.Yellow;
            this.HealerMP.Location = new System.Drawing.Point(-1, 59);
            this.HealerMP.Name = "HealerMP";
            this.HealerMP.Size = new System.Drawing.Size(67, 13);
            this.HealerMP.TabIndex = 3;
            this.HealerMP.Text = "Healer MP:";
            this.HealerMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManaShield
            // 
            this.ManaShield.AutoSize = true;
            this.ManaShield.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManaShield.ForeColor = System.Drawing.Color.Yellow;
            this.ManaShield.Location = new System.Drawing.Point(-1, 76);
            this.ManaShield.Name = "ManaShield";
            this.ManaShield.Size = new System.Drawing.Size(108, 13);
            this.ManaShield.TabIndex = 4;
            this.ManaShield.Text = "Auto Mana Shield:";
            this.ManaShield.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Haste
            // 
            this.Haste.AutoSize = true;
            this.Haste.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Haste.ForeColor = System.Drawing.Color.Yellow;
            this.Haste.Location = new System.Drawing.Point(-1, 91);
            this.Haste.Name = "Haste";
            this.Haste.Size = new System.Drawing.Size(73, 13);
            this.Haste.TabIndex = 5;
            this.Haste.Text = "Auto Haste:";
            this.Haste.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Checker
            // 
            this.Checker.Tick += new System.EventHandler(this.Checker_Tick);
            // 
            // IntroHUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(132, 114);
            this.Controls.Add(this.Haste);
            this.Controls.Add(this.ManaShield);
            this.Controls.Add(this.HealerMP);
            this.Controls.Add(this.HealerHP);
            this.Controls.Add(this.sett);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IntroHUD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.MagicWallsWn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Updt;
        private System.Windows.Forms.Label sett;
        private System.Windows.Forms.Label HealerHP;
        private System.Windows.Forms.Label HealerMP;
        private System.Windows.Forms.Label ManaShield;
        private System.Windows.Forms.Label Haste;
        private System.Windows.Forms.Timer Checker;
    }
}