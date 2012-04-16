namespace SafeBot
{
    partial class getMove
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
            this.SuspendLayout();
            // 
            // getMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SafeBot.Properties.Resources.Tile1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(32, 32);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "getMove";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "getMove";
            this.Load += new System.EventHandler(this.getMove_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.getMove_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.getMove_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}