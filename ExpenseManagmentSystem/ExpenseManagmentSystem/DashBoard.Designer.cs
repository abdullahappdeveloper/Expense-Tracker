
namespace ExpenseManagmentSystem
{
    partial class DashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.projectOverview = new System.Windows.Forms.Label();
            this.totalExpensesText = new System.Windows.Forms.Label();
            this.totalExpenses = new System.Windows.Forms.Label();
            this.currentMonthExpenses = new System.Windows.Forms.Label();
            this.currentMonth = new System.Windows.Forms.Label();
            this.lastMonthExpenses = new System.Windows.Forms.Label();
            this.lastMonth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.headspieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.topheadsTable = new System.Windows.Forms.TableLayoutPanel();
            this.SrNo1 = new System.Windows.Forms.Label();
            this.top5headName1 = new System.Windows.Forms.Label();
            this.top5headAmount1 = new System.Windows.Forms.Label();
            this.top5headAmount2 = new System.Windows.Forms.Label();
            this.top5headName2 = new System.Windows.Forms.Label();
            this.SrNo2 = new System.Windows.Forms.Label();
            this.SrNo3 = new System.Windows.Forms.Label();
            this.SrNo4 = new System.Windows.Forms.Label();
            this.top5headName3 = new System.Windows.Forms.Label();
            this.top5headName4 = new System.Windows.Forms.Label();
            this.top5headAmount3 = new System.Windows.Forms.Label();
            this.top5headAmount4 = new System.Windows.Forms.Label();
            this.SrNo5 = new System.Windows.Forms.Label();
            this.top5headName5 = new System.Windows.Forms.Label();
            this.top5headAmount5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.headspieChart)).BeginInit();
            this.topheadsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectOverview
            // 
            this.projectOverview.AutoSize = true;
            this.projectOverview.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectOverview.ForeColor = System.Drawing.Color.Black;
            this.projectOverview.Location = new System.Drawing.Point(26, 27);
            this.projectOverview.Name = "projectOverview";
            this.projectOverview.Size = new System.Drawing.Size(117, 23);
            this.projectOverview.TabIndex = 1;
            this.projectOverview.Text = "OverView :";
            // 
            // totalExpensesText
            // 
            this.totalExpensesText.AutoSize = true;
            this.totalExpensesText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalExpensesText.ForeColor = System.Drawing.Color.Black;
            this.totalExpensesText.Location = new System.Drawing.Point(26, 64);
            this.totalExpensesText.Name = "totalExpensesText";
            this.totalExpensesText.Size = new System.Drawing.Size(141, 21);
            this.totalExpensesText.TabIndex = 2;
            this.totalExpensesText.Text = "Total Expenses :";
            // 
            // totalExpenses
            // 
            this.totalExpenses.AutoSize = true;
            this.totalExpenses.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalExpenses.ForeColor = System.Drawing.Color.Black;
            this.totalExpenses.Location = new System.Drawing.Point(171, 62);
            this.totalExpenses.Name = "totalExpenses";
            this.totalExpenses.Size = new System.Drawing.Size(99, 23);
            this.totalExpenses.TabIndex = 3;
            this.totalExpenses.Text = "1,244,000";
            // 
            // currentMonthExpenses
            // 
            this.currentMonthExpenses.AutoSize = true;
            this.currentMonthExpenses.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMonthExpenses.ForeColor = System.Drawing.Color.Black;
            this.currentMonthExpenses.Location = new System.Drawing.Point(171, 101);
            this.currentMonthExpenses.Name = "currentMonthExpenses";
            this.currentMonthExpenses.Size = new System.Drawing.Size(99, 23);
            this.currentMonthExpenses.TabIndex = 5;
            this.currentMonthExpenses.Text = "1,244,000";
            // 
            // currentMonth
            // 
            this.currentMonth.AutoSize = true;
            this.currentMonth.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMonth.ForeColor = System.Drawing.Color.Black;
            this.currentMonth.Location = new System.Drawing.Point(26, 103);
            this.currentMonth.Name = "currentMonth";
            this.currentMonth.Size = new System.Drawing.Size(109, 21);
            this.currentMonth.TabIndex = 4;
            this.currentMonth.Text = "August 2024";
            this.currentMonth.Click += new System.EventHandler(this.label4_Click);
            // 
            // lastMonthExpenses
            // 
            this.lastMonthExpenses.AutoSize = true;
            this.lastMonthExpenses.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastMonthExpenses.ForeColor = System.Drawing.Color.Black;
            this.lastMonthExpenses.Location = new System.Drawing.Point(171, 139);
            this.lastMonthExpenses.Name = "lastMonthExpenses";
            this.lastMonthExpenses.Size = new System.Drawing.Size(99, 23);
            this.lastMonthExpenses.TabIndex = 7;
            this.lastMonthExpenses.Text = "1,244,000";
            // 
            // lastMonth
            // 
            this.lastMonth.AutoSize = true;
            this.lastMonth.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastMonth.ForeColor = System.Drawing.Color.Black;
            this.lastMonth.Location = new System.Drawing.Point(26, 141);
            this.lastMonth.Name = "lastMonth";
            this.lastMonth.Size = new System.Drawing.Size(80, 21);
            this.lastMonth.TabIndex = 6;
            this.lastMonth.Text = "July 2024";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(371, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Top 5 Heads :";
            // 
            // headspieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.headspieChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.headspieChart.Legends.Add(legend1);
            this.headspieChart.Location = new System.Drawing.Point(375, 215);
            this.headspieChart.Name = "headspieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "headsOverview";
            this.headspieChart.Series.Add(series1);
            this.headspieChart.Size = new System.Drawing.Size(300, 252);
            this.headspieChart.TabIndex = 9;
            this.headspieChart.Text = "chart1";
            // 
            // topheadsTable
            // 
            this.topheadsTable.ColumnCount = 3;
            this.topheadsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.topheadsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.topheadsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.topheadsTable.Controls.Add(this.SrNo1, 0, 0);
            this.topheadsTable.Controls.Add(this.top5headName1, 1, 0);
            this.topheadsTable.Controls.Add(this.top5headAmount1, 2, 0);
            this.topheadsTable.Controls.Add(this.top5headAmount2, 2, 1);
            this.topheadsTable.Controls.Add(this.top5headName2, 1, 1);
            this.topheadsTable.Controls.Add(this.SrNo2, 0, 1);
            this.topheadsTable.Controls.Add(this.SrNo3, 0, 2);
            this.topheadsTable.Controls.Add(this.SrNo4, 0, 3);
            this.topheadsTable.Controls.Add(this.top5headName3, 1, 2);
            this.topheadsTable.Controls.Add(this.top5headName4, 1, 3);
            this.topheadsTable.Controls.Add(this.top5headAmount3, 2, 2);
            this.topheadsTable.Controls.Add(this.top5headAmount4, 2, 3);
            this.topheadsTable.Controls.Add(this.SrNo5, 0, 4);
            this.topheadsTable.Controls.Add(this.top5headName5, 1, 4);
            this.topheadsTable.Controls.Add(this.top5headAmount5, 2, 4);
            this.topheadsTable.Location = new System.Drawing.Point(375, 49);
            this.topheadsTable.Name = "topheadsTable";
            this.topheadsTable.RowCount = 5;
            this.topheadsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.topheadsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.topheadsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.topheadsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.topheadsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.topheadsTable.Size = new System.Drawing.Size(289, 150);
            this.topheadsTable.TabIndex = 10;
            // 
            // SrNo1
            // 
            this.SrNo1.AutoSize = true;
            this.SrNo1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrNo1.Location = new System.Drawing.Point(3, 0);
            this.SrNo1.Name = "SrNo1";
            this.SrNo1.Size = new System.Drawing.Size(17, 20);
            this.SrNo1.TabIndex = 3;
            this.SrNo1.Text = "1";
            // 
            // top5headName1
            // 
            this.top5headName1.AutoSize = true;
            this.top5headName1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headName1.Location = new System.Drawing.Point(39, 0);
            this.top5headName1.Name = "top5headName1";
            this.top5headName1.Size = new System.Drawing.Size(53, 20);
            this.top5headName1.TabIndex = 4;
            this.top5headName1.Text = "label8";
            // 
            // top5headAmount1
            // 
            this.top5headAmount1.AutoSize = true;
            this.top5headAmount1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headAmount1.Location = new System.Drawing.Point(203, 0);
            this.top5headAmount1.Name = "top5headAmount1";
            this.top5headAmount1.Size = new System.Drawing.Size(53, 20);
            this.top5headAmount1.TabIndex = 5;
            this.top5headAmount1.Text = "label9";
            // 
            // top5headAmount2
            // 
            this.top5headAmount2.AutoSize = true;
            this.top5headAmount2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headAmount2.Location = new System.Drawing.Point(203, 30);
            this.top5headAmount2.Name = "top5headAmount2";
            this.top5headAmount2.Size = new System.Drawing.Size(61, 20);
            this.top5headAmount2.TabIndex = 6;
            this.top5headAmount2.Text = "label10";
            // 
            // top5headName2
            // 
            this.top5headName2.AutoSize = true;
            this.top5headName2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headName2.Location = new System.Drawing.Point(39, 30);
            this.top5headName2.Name = "top5headName2";
            this.top5headName2.Size = new System.Drawing.Size(61, 20);
            this.top5headName2.TabIndex = 7;
            this.top5headName2.Text = "label11";
            // 
            // SrNo2
            // 
            this.SrNo2.AutoSize = true;
            this.SrNo2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrNo2.Location = new System.Drawing.Point(3, 30);
            this.SrNo2.Name = "SrNo2";
            this.SrNo2.Size = new System.Drawing.Size(17, 20);
            this.SrNo2.TabIndex = 8;
            this.SrNo2.Text = "2";
            // 
            // SrNo3
            // 
            this.SrNo3.AutoSize = true;
            this.SrNo3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrNo3.Location = new System.Drawing.Point(3, 60);
            this.SrNo3.Name = "SrNo3";
            this.SrNo3.Size = new System.Drawing.Size(17, 20);
            this.SrNo3.TabIndex = 9;
            this.SrNo3.Text = "3";
            // 
            // SrNo4
            // 
            this.SrNo4.AutoSize = true;
            this.SrNo4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrNo4.Location = new System.Drawing.Point(3, 90);
            this.SrNo4.Name = "SrNo4";
            this.SrNo4.Size = new System.Drawing.Size(17, 20);
            this.SrNo4.TabIndex = 10;
            this.SrNo4.Text = "4";
            // 
            // top5headName3
            // 
            this.top5headName3.AutoSize = true;
            this.top5headName3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headName3.Location = new System.Drawing.Point(39, 60);
            this.top5headName3.Name = "top5headName3";
            this.top5headName3.Size = new System.Drawing.Size(61, 20);
            this.top5headName3.TabIndex = 11;
            this.top5headName3.Text = "label15";
            // 
            // top5headName4
            // 
            this.top5headName4.AutoSize = true;
            this.top5headName4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headName4.Location = new System.Drawing.Point(39, 90);
            this.top5headName4.Name = "top5headName4";
            this.top5headName4.Size = new System.Drawing.Size(61, 20);
            this.top5headName4.TabIndex = 12;
            this.top5headName4.Text = "label16";
            // 
            // top5headAmount3
            // 
            this.top5headAmount3.AutoSize = true;
            this.top5headAmount3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headAmount3.Location = new System.Drawing.Point(203, 60);
            this.top5headAmount3.Name = "top5headAmount3";
            this.top5headAmount3.Size = new System.Drawing.Size(61, 20);
            this.top5headAmount3.TabIndex = 13;
            this.top5headAmount3.Text = "label17";
            // 
            // top5headAmount4
            // 
            this.top5headAmount4.AutoSize = true;
            this.top5headAmount4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headAmount4.Location = new System.Drawing.Point(203, 90);
            this.top5headAmount4.Name = "top5headAmount4";
            this.top5headAmount4.Size = new System.Drawing.Size(61, 20);
            this.top5headAmount4.TabIndex = 14;
            this.top5headAmount4.Text = "label18";
            // 
            // SrNo5
            // 
            this.SrNo5.AutoSize = true;
            this.SrNo5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrNo5.Location = new System.Drawing.Point(3, 120);
            this.SrNo5.Name = "SrNo5";
            this.SrNo5.Size = new System.Drawing.Size(19, 21);
            this.SrNo5.TabIndex = 15;
            this.SrNo5.Text = "5";
            // 
            // top5headName5
            // 
            this.top5headName5.AutoSize = true;
            this.top5headName5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headName5.Location = new System.Drawing.Point(39, 120);
            this.top5headName5.Name = "top5headName5";
            this.top5headName5.Size = new System.Drawing.Size(60, 21);
            this.top5headName5.TabIndex = 16;
            this.top5headName5.Text = "label5";
            // 
            // top5headAmount5
            // 
            this.top5headAmount5.AutoSize = true;
            this.top5headAmount5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top5headAmount5.Location = new System.Drawing.Point(203, 120);
            this.top5headAmount5.Name = "top5headAmount5";
            this.top5headAmount5.Size = new System.Drawing.Size(60, 21);
            this.top5headAmount5.TabIndex = 17;
            this.top5headAmount5.Text = "label6";
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(720, 550);
            this.Controls.Add(this.topheadsTable);
            this.Controls.Add(this.headspieChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastMonthExpenses);
            this.Controls.Add(this.lastMonth);
            this.Controls.Add(this.currentMonthExpenses);
            this.Controls.Add(this.currentMonth);
            this.Controls.Add(this.totalExpenses);
            this.Controls.Add(this.totalExpensesText);
            this.Controls.Add(this.projectOverview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            ((System.ComponentModel.ISupportInitialize)(this.headspieChart)).EndInit();
            this.topheadsTable.ResumeLayout(false);
            this.topheadsTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label projectOverview;
        private System.Windows.Forms.Label totalExpensesText;
        private System.Windows.Forms.Label totalExpenses;
        private System.Windows.Forms.Label currentMonthExpenses;
        private System.Windows.Forms.Label currentMonth;
        private System.Windows.Forms.Label lastMonthExpenses;
        private System.Windows.Forms.Label lastMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart headspieChart;
        private System.Windows.Forms.TableLayoutPanel topheadsTable;
        private System.Windows.Forms.Label SrNo1;
        private System.Windows.Forms.Label top5headName1;
        private System.Windows.Forms.Label top5headAmount1;
        private System.Windows.Forms.Label top5headAmount2;
        private System.Windows.Forms.Label top5headName2;
        private System.Windows.Forms.Label SrNo2;
        private System.Windows.Forms.Label SrNo3;
        private System.Windows.Forms.Label SrNo4;
        private System.Windows.Forms.Label top5headName3;
        private System.Windows.Forms.Label top5headName4;
        private System.Windows.Forms.Label top5headAmount3;
        private System.Windows.Forms.Label top5headAmount4;
        private System.Windows.Forms.Label SrNo5;
        private System.Windows.Forms.Label top5headName5;
        private System.Windows.Forms.Label top5headAmount5;
    }
}