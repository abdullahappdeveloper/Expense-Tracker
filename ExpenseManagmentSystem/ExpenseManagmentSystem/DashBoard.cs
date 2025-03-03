using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpenseManagmentSystem
{
    public partial class DashBoard : Form
    {

        public DashBoard()
        {
            InitializeComponent();


            // Get Head Total Amounts
            List<ExpenseHead> heads = DataBaseManager.GetManager().GetHeads();
            List<Expense> expenses = GetExpenses();

            List<Cost> headTotalAmounts = GetHeadTotalAmounts(heads, expenses);

            CreateTop5Heads(headTotalAmounts);

            int total = GetTotalExpense(headTotalAmounts);
            totalExpenses.Text = $"{total}";
            currentMonth.Text = DateTime.Now.ToString("MMMM yyyy");
            int thismonthtotal = GetTotalExpensesForMonth(DateTime.Now.Month, expenses);
            currentMonthExpenses.Text = $"{thismonthtotal}";

            lastMonth.Text = DateTime.Now.AddMonths(-1).ToString("MMMM yyyy");
            int lastmonthtotal = GetTotalExpensesForMonth(DateTime.Now.AddMonths(-1).Month, expenses);
            lastMonthExpenses.Text = $"{lastmonthtotal}";

            SetProjectOverviewText();

            CreatePieChart(headTotalAmounts);

            HandleControlsResize();

            AppTheme.GetAppTheme().ApplyTheme(this);
        }

        private void SetProjectOverviewText()
        {
            Project openProject = DataBaseManager.GetManager().GetOpenProject();
            if (openProject != null)
            {
                projectOverview.Text = $"{openProject.name} OverView :";
                Main.instance.ShowProjectTitle();
            }
        }

        private ScreenSizeHandler ScreenSizeHandler;
        public Size panelSize;
        private void HandleControlsResize()
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
            ScreenSizeHandler.AddControl(projectOverview);
            ScreenSizeHandler.AddControl(currentMonth);
            ScreenSizeHandler.AddControl(lastMonth);
            ScreenSizeHandler.AddControl(totalExpenses);
            ScreenSizeHandler.AddControl(totalExpensesText);
            ScreenSizeHandler.AddControl(currentMonthExpenses);
            ScreenSizeHandler.AddControl(lastMonthExpenses);
            ScreenSizeHandler.AddControl(label3);
            ScreenSizeHandler.AddControl(SrNo1);
            ScreenSizeHandler.AddControl(SrNo2);
            ScreenSizeHandler.AddControl(SrNo3);
            ScreenSizeHandler.AddControl(SrNo4);
            ScreenSizeHandler.AddControl(SrNo5);
            ScreenSizeHandler.AddControl(topheadsTable);
            ScreenSizeHandler.AddControl(top5headName1);
            ScreenSizeHandler.AddControl(top5headName2);
            ScreenSizeHandler.AddControl(top5headName3);
            ScreenSizeHandler.AddControl(top5headName4);
            ScreenSizeHandler.AddControl(top5headName5);
            ScreenSizeHandler.AddControl(top5headAmount1);
            ScreenSizeHandler.AddControl(top5headAmount2);
            ScreenSizeHandler.AddControl(top5headAmount3);
            ScreenSizeHandler.AddControl(top5headAmount4);
            ScreenSizeHandler.AddControl(top5headAmount5);
            ScreenSizeHandler.AddControl(headspieChart, false);

            Main.instance.PanelResized += PanelResize;
        }

        private void PanelResize(Size panelSize)
        {
            ScreenSizeHandler.ResizeControls(panelSize);
        }

        public void ResizeControls(Size newformSize)
        {
            ScreenSizeHandler.ResizeControls(newformSize);
        }

        private int GetTotalExpensesForMonth(int month,List<Expense> expenses) 
        {
           // MessageBox.Show($"month : {month}");
            int totalExpenses = 0;
            foreach (var item in expenses) 
            {
                DateTime date = Convert.ToDateTime(item.Date);
                if (date.Month.Equals(month)) 
                {
                    totalExpenses += item.Amount;
                }
            }

            return totalExpenses;
        }


        private int GetTotalExpense(List<Cost> headTotalAmounts)
        {
            int totalExpenses = 0;
            foreach (var head  in headTotalAmounts ) 
            {
                totalExpenses += head.Amount;
            }

            return totalExpenses;
        }

        private void CreateTop5Heads(List<Cost> headAmounts) 
        {

            var sortedHeads = headAmounts.OrderByDescending(headAmount => headAmount.Amount).ToList();
           
            
            int counter = 0;
            int TopRankings = 5;

            List<Cost> topHeads = new List<Cost>();
            foreach (var item in sortedHeads) 
            {
                topHeads.Add(item);
                counter++;
                if (counter >= TopRankings) break;
            }

            List<Rank> ranksTexts = new List<Rank>();
            AddRank(ranksTexts,top5headName1,top5headAmount1);
            AddRank(ranksTexts, top5headName2, top5headAmount2);
            AddRank(ranksTexts, top5headName3, top5headAmount3);
            AddRank(ranksTexts, top5headName4, top5headAmount4);
            AddRank(ranksTexts, top5headName5, top5headAmount5);


            for (int i = 0; i < topHeads.Count; i++) 
            {
                Rank rankText = ranksTexts[i];
                Cost rankData = topHeads[i];

                CreateRank(rankData, rankText);
            }

           
        }

        private void AddRank(List<Rank> ranksTexts, Label headName, Label headAmount) 
        {
            ranksTexts.Add(new Rank() 
            {
              name = headName,
              amount = headAmount
            });
        }

        private void CreateRank(Cost headRank,Rank rank) 
        {
            rank.name.Text = headRank.HeadName;
            rank.amount.Text = headRank.Amount.ToString();
        }


        private List<Cost> GetHeadTotalAmounts(List<ExpenseHead> heads, List<Expense> expenses) 
        {
            List<Cost> headAmounts = new List<Cost>();
            foreach (var item in heads)
            {
                headAmounts.Add(new Cost()
                {
                    HeadName = item.name,

                });
            }

            foreach (var expenseItem in expenses)
            {
                foreach (var costItem in headAmounts)
                {
                    if (costItem.HeadName.Equals(expenseItem.Head))
                    {
                        costItem.Amount += expenseItem.Amount;
                    }
                }
            }
            return headAmounts;
        }

        private List<Expense> GetExpenses() 
        {
            List<Expense> expenses = DataBaseManager.GetManager().GetExpenses();
            foreach (var item in expenses)
            {
                item.Head = DataBaseManager.GetManager().GetHeadForId(item.HeadId);
            }
            return expenses;
        }


        private void CreatePieChart(List<Cost> headAmounts)
        {
            var sortedHeads = headAmounts.OrderByDescending(cost => cost.Amount).ToList();
        
            headspieChart.Titles.Add("Heads Pie Chart");
            headspieChart.Series["headsOverview"].IsVisibleInLegend = false;

            int counter = 0;
            int TopRankings = 10;

            List<Cost> topHeads = new List<Cost>();
            foreach (var item in sortedHeads)
            {
                topHeads.Add(item);
                counter++;
                if (counter >= TopRankings) break;
            }

            foreach (var item in topHeads)
            {

                string headName = item.HeadName;
                int amount = item.Amount;
                headspieChart.Series["headsOverview"].Points.AddXY(headName, amount);
            }

            int leastAmount = 0;
            if (topHeads.Count > 3)
            {
                leastAmount = topHeads[3].Amount;
            }
           
            

            foreach (DataPoint point in headspieChart.Series["headsOverview"].Points)
            {
                int amount = Convert.ToInt32(point.YValues[0]);
                if (amount > leastAmount)
                {
                    point.Label = $"{point.AxisLabel}\n {point.YValues[0]}";
                }
                else
                {
                    point.Font = new Font("Arial", .000000001f);
                    point.Label = "";
                }

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}

public class Rank 
{
    public Label name;
    public Label amount;
}
