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
using System.Linq;

namespace ExpenseManagmentSystem
{
    public partial class Ledger : Form
    {

        private ScreenSizeHandler ScreenSizeHandler;
        public Size panelSize;
        public Ledger()
        {
            InitializeComponent();

            LoadExpenseHeadsFromDB();

            SetDateFormate();

            HandleControlsResize();

            AppTheme.GetAppTheme().ApplyTheme(this);
        }

        private void SetDateFormate()
        {
            startDate.Format = DateTimePickerFormat.Custom;
            startDate.CustomFormat = "dd-MM-yyyy";
            endDate.Format = DateTimePickerFormat.Custom;
            endDate.CustomFormat = "dd-MM-yyyy";
        }

        private void HandleControlsResize()
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);

            ScreenSizeHandler.AddControl(panel1, false);
            ScreenSizeHandler.AddControl(titleText);
            ScreenSizeHandler.AddControl(reportViewer, false);
            ScreenSizeHandler.AddControl(startDate);
            ScreenSizeHandler.AddControl(endDate);
            ScreenSizeHandler.AddControl(label1);
            ScreenSizeHandler.AddControl(label2);
            ScreenSizeHandler.AddControl(label3);
            ScreenSizeHandler.AddControl(titleText);
            ScreenSizeHandler.AddControl(expenseHeadcomboBox, false);

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

        private void LoadExpenseHeadsFromDB()
        {
            List<ExpenseHead> expenseHeads = DataBaseManager.GetManager().GetHeads();
            List<string> headNames = new List<string>();
            foreach (var item in expenseHeads)
            {
                headNames.Add(item.name);
            }
            headNames.Add("All");
            expenseHeadcomboBox.DataSource = headNames;
        }

        private void Ledger_Load(object sender, EventArgs e)
        {
        }

        public void LoadLedgerReport() 
        {
            
            string selectedHeadName = expenseHeadcomboBox.SelectedValue.ToString();
            List<Expense> expenses = DataBaseManager.GetManager().GetExpenses();
            foreach (var item in expenses)
            {
                item.Head = DataBaseManager.GetManager().GetHeadForId(item.HeadId);
            }

           

            var filteredExpenses = expenses.Where(e =>
            {
                DateTime expenseDate = DateTime.Parse(e.Date); // Convert the string to DateTime
                return expenseDate >= startDate.Value.Date && expenseDate <= endDate.Value.Date && (e.Head.Equals(selectedHeadName) || (selectedHeadName.Equals("All")));
            }).ToList();

            foreach (var item in filteredExpenses)
            {
                DateTime date = Convert.ToDateTime(item.Date);
                string formattedDate = date.ToString("dd-MM-yy");
                item.Date = formattedDate;
            }

            var sortedExpenses = filteredExpenses.OrderBy(e => e.Date).ToArray();
           
           
          List<LedgerExpense> ledgerExpenses = sortedExpenses.Select((expense, index) => new LedgerExpense
            {
        SerialNumber = index + 1,
        Amount = expense.Amount,
        Date = expense.Date,
        Description = expense.Description,
        Vendor = expense.Vendor,
        Head = expense.Head,
        ReportTitle = expense.Head

            }).ToList();

            if (selectedHeadName.Equals("All"))
            {
                foreach (var item in ledgerExpenses) 
                {
                    string month = startDate.Value.ToString("MMMM yyy");
                    item.ReportTitle = $"Ledger Report ({month})";
                }
            }

            ReportDataSource reportDataSource = new ReportDataSource("LedgerDataSet", ledgerExpenses);

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.RefreshReport();
             //MessageBox.Show(expenseHeadcomboBox.SelectedValue.ToString());
        }

        private void PrintReport(object sender, EventArgs e)
        {
            LoadLedgerReport();
        }

    }
}

public class LedgerExpense: Expense 
{
    public int SerialNumber { get; set; }
    public string ReportTitle { get; set; }

}
