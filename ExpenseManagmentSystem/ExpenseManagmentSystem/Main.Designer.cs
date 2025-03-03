
namespace ExpenseManagmentSystem
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.AdExpenseButton = new System.Windows.Forms.Button();
            this.AdHeadsButton = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.LedgerButton = new System.Windows.Forms.Button();
            this.CostReportButton = new System.Windows.Forms.Button();
            this.AddProjectButton = new System.Windows.Forms.Button();
            this.openProjectName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maxiMiseButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.titleText = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dashBoardButton = new System.Windows.Forms.Button();
            this.formspanel = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdExpenseButton
            // 
            this.AdExpenseButton.BackColor = System.Drawing.Color.Turquoise;
            this.AdExpenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdExpenseButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdExpenseButton.ForeColor = System.Drawing.Color.White;
            this.AdExpenseButton.Location = new System.Drawing.Point(12, 147);
            this.AdExpenseButton.Name = "AdExpenseButton";
            this.AdExpenseButton.Size = new System.Drawing.Size(176, 53);
            this.AdExpenseButton.TabIndex = 13;
            this.AdExpenseButton.Text = "Add Expense";
            this.AdExpenseButton.UseVisualStyleBackColor = false;
            this.AdExpenseButton.Click += new System.EventHandler(this.AddExpense);
            // 
            // AdHeadsButton
            // 
            this.AdHeadsButton.BackColor = System.Drawing.Color.Turquoise;
            this.AdHeadsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdHeadsButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdHeadsButton.ForeColor = System.Drawing.Color.White;
            this.AdHeadsButton.Location = new System.Drawing.Point(12, 206);
            this.AdHeadsButton.Name = "AdHeadsButton";
            this.AdHeadsButton.Size = new System.Drawing.Size(176, 53);
            this.AdHeadsButton.TabIndex = 14;
            this.AdHeadsButton.Text = "Add Head";
            this.AdHeadsButton.UseVisualStyleBackColor = false;
            this.AdHeadsButton.Click += new System.EventHandler(this.AddHead);
            // 
            // AddUserButton
            // 
            this.AddUserButton.BackColor = System.Drawing.Color.Turquoise;
            this.AddUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddUserButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserButton.ForeColor = System.Drawing.Color.White;
            this.AddUserButton.Location = new System.Drawing.Point(12, 383);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(176, 53);
            this.AddUserButton.TabIndex = 15;
            this.AddUserButton.Text = "Add User";
            this.AddUserButton.UseVisualStyleBackColor = false;
            this.AddUserButton.Click += new System.EventHandler(this.AddUser);
            // 
            // LedgerButton
            // 
            this.LedgerButton.BackColor = System.Drawing.Color.Turquoise;
            this.LedgerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LedgerButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerButton.ForeColor = System.Drawing.Color.White;
            this.LedgerButton.Location = new System.Drawing.Point(12, 324);
            this.LedgerButton.Name = "LedgerButton";
            this.LedgerButton.Size = new System.Drawing.Size(176, 53);
            this.LedgerButton.TabIndex = 16;
            this.LedgerButton.Text = "Ledger Report";
            this.LedgerButton.UseVisualStyleBackColor = false;
            this.LedgerButton.Click += new System.EventHandler(this.ShowLedgerReport);
            // 
            // CostReportButton
            // 
            this.CostReportButton.BackColor = System.Drawing.Color.Turquoise;
            this.CostReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CostReportButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostReportButton.ForeColor = System.Drawing.Color.White;
            this.CostReportButton.Location = new System.Drawing.Point(12, 265);
            this.CostReportButton.Name = "CostReportButton";
            this.CostReportButton.Size = new System.Drawing.Size(176, 53);
            this.CostReportButton.TabIndex = 18;
            this.CostReportButton.Text = "Cost Report";
            this.CostReportButton.UseVisualStyleBackColor = false;
            this.CostReportButton.Click += new System.EventHandler(this.ShowCostReport);
            // 
            // AddProjectButton
            // 
            this.AddProjectButton.BackColor = System.Drawing.Color.Turquoise;
            this.AddProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProjectButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProjectButton.ForeColor = System.Drawing.Color.White;
            this.AddProjectButton.Location = new System.Drawing.Point(12, 442);
            this.AddProjectButton.Name = "AddProjectButton";
            this.AddProjectButton.Size = new System.Drawing.Size(176, 53);
            this.AddProjectButton.TabIndex = 19;
            this.AddProjectButton.Text = "Projects";
            this.AddProjectButton.UseVisualStyleBackColor = false;
            this.AddProjectButton.Click += new System.EventHandler(this.AddProject);
            // 
            // openProjectName
            // 
            this.openProjectName.AutoSize = true;
            this.openProjectName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openProjectName.Location = new System.Drawing.Point(525, 88);
            this.openProjectName.Name = "openProjectName";
            this.openProjectName.Size = new System.Drawing.Size(70, 23);
            this.openProjectName.TabIndex = 20;
            this.openProjectName.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.maxiMiseButton);
            this.panel1.Controls.Add(this.minimizeButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.titleText);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 72);
            this.panel1.TabIndex = 21;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // maxiMiseButton
            // 
            this.maxiMiseButton.BackColor = System.Drawing.Color.White;
            this.maxiMiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.maxiMiseButton.FlatAppearance.BorderSize = 0;
            this.maxiMiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxiMiseButton.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxiMiseButton.ForeColor = System.Drawing.Color.Turquoise;
            this.maxiMiseButton.Location = new System.Drawing.Point(889, 0);
            this.maxiMiseButton.Name = "maxiMiseButton";
            this.maxiMiseButton.Size = new System.Drawing.Size(31, 34);
            this.maxiMiseButton.TabIndex = 13;
            this.maxiMiseButton.Text = "+";
            this.maxiMiseButton.UseVisualStyleBackColor = false;
            this.maxiMiseButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.White;
            this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.Color.Turquoise;
            this.minimizeButton.Location = new System.Drawing.Point(853, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(31, 34);
            this.minimizeButton.TabIndex = 12;
            this.minimizeButton.Text = "-";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.MiniMizeForm);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Turquoise;
            this.closeButton.Location = new System.Drawing.Point(924, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(36, 34);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // titleText
            // 
            this.titleText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleText.AutoSize = true;
            this.titleText.BackColor = System.Drawing.Color.White;
            this.titleText.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.Turquoise;
            this.titleText.Location = new System.Drawing.Point(265, 18);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(330, 28);
            this.titleText.TabIndex = 6;
            this.titleText.Text = "Expense Management App";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Turquoise;
            this.panel2.Controls.Add(this.SettingsButton);
            this.panel2.Controls.Add(this.dashBoardButton);
            this.panel2.Controls.Add(this.AdExpenseButton);
            this.panel2.Controls.Add(this.AddUserButton);
            this.panel2.Controls.Add(this.AdHeadsButton);
            this.panel2.Controls.Add(this.AddProjectButton);
            this.panel2.Controls.Add(this.LedgerButton);
            this.panel2.Controls.Add(this.CostReportButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 640);
            this.panel2.TabIndex = 22;
            // 
            // dashBoardButton
            // 
            this.dashBoardButton.BackColor = System.Drawing.Color.Turquoise;
            this.dashBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashBoardButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashBoardButton.ForeColor = System.Drawing.Color.White;
            this.dashBoardButton.Location = new System.Drawing.Point(12, 88);
            this.dashBoardButton.Name = "dashBoardButton";
            this.dashBoardButton.Size = new System.Drawing.Size(176, 53);
            this.dashBoardButton.TabIndex = 20;
            this.dashBoardButton.Text = "Dash Board";
            this.dashBoardButton.UseVisualStyleBackColor = false;
            this.dashBoardButton.Click += new System.EventHandler(this.ShowDashBoard);
            // 
            // formspanel
            // 
            this.formspanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formspanel.BackColor = System.Drawing.Color.Gray;
            this.formspanel.Location = new System.Drawing.Point(205, 72);
            this.formspanel.Name = "formspanel";
            this.formspanel.Size = new System.Drawing.Size(755, 568);
            this.formspanel.TabIndex = 23;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Turquoise;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Location = new System.Drawing.Point(12, 501);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(176, 53);
            this.SettingsButton.TabIndex = 21;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.ShowSetting);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 640);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.formspanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.openProjectName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Management System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AdExpenseButton;
        private System.Windows.Forms.Button AdHeadsButton;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button LedgerButton;
        private System.Windows.Forms.Button CostReportButton;
        private System.Windows.Forms.Button AddProjectButton;
        private System.Windows.Forms.Label openProjectName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel formspanel;
        private System.Windows.Forms.Button dashBoardButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button maxiMiseButton;
        private System.Windows.Forms.Button SettingsButton;
    }
}