﻿namespace SafeBot
{
    partial class SafeBotForm
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
            this.Hider = new System.Windows.Forms.Timer(this.components);
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Hider
            // 
            this.Hider.Enabled = true;
            this.Hider.Tick += new System.EventHandler(this.Hider_Tick);
            // 
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // SafeBotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SafeBot.Properties.Resources.SB;
            this.ClientSize = new System.Drawing.Size(15, 15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SafeBotForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SafeBot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SafeBot_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SafeBot_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SafeBot_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Hider;
        private System.Windows.Forms.Timer Updater;
    }
}