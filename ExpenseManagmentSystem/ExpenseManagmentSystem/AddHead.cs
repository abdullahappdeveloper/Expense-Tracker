using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManagmentSystem
{
    public partial class AddHead : Form
    {

        private ScreenSizeHandler ScreenSizeHandler;
        public Size panelSize;
        public AddHead()
        {
            InitializeComponent();
            LoadDataFromDB();

            HandleControlsResize();

            AppTheme.GetAppTheme().ApplyTheme(this);
        }

        private void HandleControlsResize() 
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
            ScreenSizeHandler.AddControl(AddButton);
            ScreenSizeHandler.AddControl(Delete);
            ScreenSizeHandler.AddControl(headNameTextBox);
            ScreenSizeHandler.AddControl(gridView, false);
            ScreenSizeHandler.AddControl(label1);
            ScreenSizeHandler.AddControl(panel1, false);
            ScreenSizeHandler.AddControl(label3);

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
        

        private void LoadDataFromDB() 
        {
           List<ExpenseHead> heads = new List<ExpenseHead>();
           heads = DataBaseManager.GetManager().GetHeads();
             
           gridView.DataSource = heads;

           // ExpenseHeadManager.GetManager().GetHeads(); 
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DeleteHead();
        }

        private void DeleteHead() 
        {
              string selectedItem = headNameTextBox.Text.ToString();
             DataBaseManager.GetManager().DeleteExpenseHead(selectedItem);
           // ExpenseHeadManager.GetManager().DeleteExpenseHead(selectedItem);  
              LoadDataFromDB();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (updating)
            {
                UpdateHead();
                updating = false;
            }
            else 
            {
                Save();
            }
        }
        public void Save() 
        {
            string headName = headNameTextBox.Text;
            //ExpenseHeadManager.GetManager().AddExpenseHead(headName);
            DataBaseManager.GetManager().AddExpenseHead(headName);
            LoadDataFromDB();
        }

        private string headSelected = "";
        private bool updating = false;
        public void UpdateHead()
        {

            int id = DataBaseManager.GetManager().GetHeadId(headSelected);
            string newHeadName = headNameTextBox.Text;
            DataBaseManager.GetManager().UpdateExpenseHead(newHeadName, id);
           // ExpenseHeadManager.GetManager().UpdateExpenseHead(headSelected,newHeadName);
            LoadDataFromDB();

        }

        private void CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1) 
            {
                int rowIndex = e.RowIndex;
                // 2nd column -> head name Column
               headNameTextBox.Text =   gridView.Rows[rowIndex].Cells[1].Value.ToString();
               headSelected = gridView.Rows[rowIndex].Cells[1].Value.ToString();
               updating = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
