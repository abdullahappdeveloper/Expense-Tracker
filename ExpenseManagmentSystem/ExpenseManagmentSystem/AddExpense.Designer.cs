
namespace ExpenseManagmentSystem
{
    partial class AddExpense
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpense));
            this.gridview = new System.Windows.Forms.DataGridView();
            this.dateText = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.headText = new System.Windows.Forms.Label();
            this.expenseHeadcomboBox = new System.Windows.Forms.ComboBox();
            this.descriptionText = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.VendorTextBox = new System.Windows.Forms.TextBox();
            this.vendorText = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.amountText = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridview
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridview.Location = new System.Drawing.Point(0, 249);
            this.gridview.Name = "gridview";
            this.gridview.RowHeadersWidth = 51;
            this.gridview.RowTemplate.Height = 24;
            this.gridview.Size = new System.Drawing.Size(702, 254);
            this.gridview.TabIndex = 0;
            this.gridview.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CellClick);
            // 
            // dateText
            // 
            this.dateText.AutoSize = true;
            this.dateText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateText.Location = new System.Drawing.Point(12, 51);
            this.dateText.Name = "dateText";
            this.dateText.Size = new System.Drawing.Size(47, 19);
            this.dateText.TabIndex = 2;
            this.dateText.Text = "Date";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(16, 73);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(326, 32);
            this.dateTimePicker.TabIndex = 3;
            // 
            // headText
            // 
            this.headText.AutoSize = true;
            this.headText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headText.Location = new System.Drawing.Point(348, 51);
            this.headText.Name = "headText";
            this.headText.Size = new System.Drawing.Size(54, 19);
            this.headText.TabIndex = 4;
            this.headText.Text = "Head";
            // 
            // expenseHeadcomboBox
            // 
            this.expenseHeadcomboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenseHeadcomboBox.FormattingEnabled = true;
            this.expenseHeadcomboBox.Location = new System.Drawing.Point(353, 73);
            this.expenseHeadcomboBox.Name = "expenseHeadcomboBox";
            this.expenseHeadcomboBox.Size = new System.Drawing.Size(326, 31);
            this.expenseHeadcomboBox.TabIndex = 5;
            // 
            // descriptionText
            // 
            this.descriptionText.AutoSize = true;
            this.descriptionText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionText.Location = new System.Drawing.Point(12, 108);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(100, 19);
            this.descriptionText.TabIndex = 6;
            this.descriptionText.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(16, 130);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(326, 32);
            this.descriptionTextBox.TabIndex = 7;
            this.descriptionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnDescriptionEntered);
            // 
            // VendorTextBox
            // 
            this.VendorTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorTextBox.Location = new System.Drawing.Point(352, 130);
            this.VendorTextBox.Name = "VendorTextBox";
            this.VendorTextBox.Size = new System.Drawing.Size(326, 32);
            this.VendorTextBox.TabIndex = 9;
            this.VendorTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnVendorEntered);
            // 
            // vendorText
            // 
            this.vendorText.AutoSize = true;
            this.vendorText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorText.Location = new System.Drawing.Point(348, 108);
            this.vendorText.Name = "vendorText";
            this.vendorText.Size = new System.Drawing.Size(69, 19);
            this.vendorText.TabIndex = 8;
            this.vendorText.Text = "Vendor";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountTextBox.Location = new System.Drawing.Point(16, 187);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(326, 32);
            this.amountTextBox.TabIndex = 11;
            // 
            // amountText
            // 
            this.amountText.AutoSize = true;
            this.amountText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountText.Location = new System.Drawing.Point(12, 165);
            this.amountText.Name = "amountText";
            this.amountText.Size = new System.Drawing.Size(73, 19);
            this.amountText.TabIndex = 10;
            this.amountText.Text = "Amount";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.SystemColors.Info;
            this.saveButton.Location = new System.Drawing.Point(353, 180);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 42);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.Save);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.Info;
            this.DeleteButton.Location = new System.Drawing.Point(467, 180);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(98, 42);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.Delete);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.SystemColors.Info;
            this.clearButton.Location = new System.Drawing.Point(579, 180);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(98, 42);
            this.clearButton.TabIndex = 14;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.Clear);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.Controls.Add(this.titleText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 48);
            this.panel1.TabIndex = 15;
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.ForeColor = System.Drawing.Color.White;
            this.titleText.Location = new System.Drawing.Point(262, 9);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(165, 28);
            this.titleText.TabIndex = 6;
            this.titleText.Text = "Add Expense";
            // 
            // AddExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountText);
            this.Controls.Add(this.VendorTextBox);
            this.Controls.Add(this.vendorText);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.expenseHeadcomboBox);
            this.Controls.Add(this.headText);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dateText);
            this.Controls.Add(this.gridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddExpense";
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridview;
        private System.Windows.Forms.Label dateText;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label headText;
        private System.Windows.Forms.ComboBox expenseHeadcomboBox;
        private System.Windows.Forms.Label descriptionText;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox VendorTextBox;
        private System.Windows.Forms.Label vendorText;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label amountText;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleText;
    }
}