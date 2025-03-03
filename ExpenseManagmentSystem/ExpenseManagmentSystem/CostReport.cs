using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ExpenseManagmentSystem
{
    public partial class CostReport : Form
    {
        private ScreenSizeHandler ScreenSizeHandler;
        public Size panelSize;
        public CostReport()
        {
            InitializeComponent();
            LoadCostReport();

            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
          
            ScreenSizeHandler.AddControl(panel1, false);
            ScreenSizeHandler.AddControl(titleText);
            ScreenSizeHandler.AddControl(reportViewer,false);
            Main.instance.PanelResized += PanelResize;

            AppTheme.GetAppTheme().ApplyTheme(this);

        }

        private void PanelResize(Size panelSize)
        {
            ScreenSizeHandler.ResizeControls(panelSize);
        }

        public void ResizeControls(Size newformSize)
        {
            ScreenSizeHandler.ResizeControls(newformSize);
        }

        public void LoadCostReport() 
        {
            List<Expense> expenses = DataBaseManager.GetManager().GetExpenses();
            Project openProject = DataBaseManager.GetManager().GetOpenProject();
            foreach (var item in expenses)
            {
                item.Head = DataBaseManager.GetManager().GetHeadForId(item.HeadId);
            }


            List<ExpenseHead> expenseHeads = DataBaseManager.GetManager().GetHeads();
            // Add expense Heads
            List<Cost> costs = new List<Cost>();
            
            foreach (var item in expenseHeads) 
            {
                costs.Add(new Cost()
                {
                    HeadName = item.name,
                    Title = openProject.name
                }); 
            }


            foreach (var expenseItem in expenses) 
            {
                foreach (var costItem  in costs) 
                {
                    if (costItem.HeadName.Equals(expenseItem.Head)) 
                    {
                        costItem.Amount += expenseItem.Amount;
                    }
                }
             
            }



            ReportDataSource reportDataSource = new ReportDataSource("CostReport", costs);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.RefreshReport();
            
        }

        private void CostReport_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}

public class Cost 
{
 public string HeadName { get; set; }
 public int Amount { get; set; }
 public string Title { get; set; }
}
