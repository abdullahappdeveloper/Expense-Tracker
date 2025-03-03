
namespace ExpenseManagmentSystem
{
    partial class Settings
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
            this.appThemeLabel = new System.Windows.Forms.Label();
            this.appThemeComboxBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appThemeLabel
            // 
            this.appThemeLabel.AutoSize = true;
            this.appThemeLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appThemeLabel.Location = new System.Drawing.Point(146, 109);
            this.appThemeLabel.Name = "appThemeLabel";
            this.appThemeLabel.Size = new System.Drawing.Size(141, 23);
            this.appThemeLabel.TabIndex = 0;
            this.appThemeLabel.Text = "App Theme : ";
            // 
            // appThemeComboxBox
            // 
            this.appThemeComboxBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appThemeComboxBox.FormattingEnabled = true;
            this.appThemeComboxBox.Location = new System.Drawing.Point(303, 109);
            this.appThemeComboxBox.Name = "appThemeComboxBox";
            this.appThemeComboxBox.Size = new System.Drawing.Size(176, 31);
            this.appThemeComboxBox.TabIndex = 1;
            this.appThemeComboxBox.SelectionChangeCommitted += new System.EventHandler(this.appThemeComboxBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.Controls.Add(this.titleText);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 48);
            this.panel1.TabIndex = 10;
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.White;
            this.titleText.Location = new System.Drawing.Point(262, 9);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(100, 28);
            this.titleText.TabIndex = 6;
            this.titleText.Text = "Settings";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.appThemeComboxBox);
            this.Controls.Add(this.appThemeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appThemeLabel;
        private System.Windows.Forms.ComboBox appThemeComboxBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleText;
    }
}