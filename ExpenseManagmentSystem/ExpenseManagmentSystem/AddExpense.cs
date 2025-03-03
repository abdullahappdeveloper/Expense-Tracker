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
    public partial class AddExpense : Form
    {
        public AddExpense()
        {
            InitializeComponent();
            LoadDataFromDB();
            LoadExpenseHeadsFromDB();

            vendorNames = SugestionsManager.GetManager().GetVendorSuggestions();
            MakeTextBoxAutoComplete(VendorTextBox, vendorNames);

            descriptions = SugestionsManager.GetManager().GetDescriptionSuggestions();
            MakeTextBoxAutoComplete(descriptionTextBox, descriptions);

            HandleControlsResize();
            AppTheme.GetAppTheme().ApplyTheme(this);
        }

        private void HandleControlsResize()
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
            ScreenSizeHandler.AddControl(titleText);
            ScreenSizeHandler.AddControl(panel1);
            ScreenSizeHandler.AddControl(dateText);
            ScreenSizeHandler.AddControl(headText);
            ScreenSizeHandler.AddControl(descriptionText);
            ScreenSizeHandler.AddControl(vendorText);
            ScreenSizeHandler.AddControl(amountText);

            ScreenSizeHandler.AddControl(dateTimePicker);
            ScreenSizeHandler.AddControl(expenseHeadcomboBox);
            ScreenSizeHandler.AddControl(descriptionTextBox);
            ScreenSizeHandler.AddControl(VendorTextBox);
            ScreenSizeHandler.AddControl(amountTextBox);
            ScreenSizeHandler.AddControl(saveButton);
            ScreenSizeHandler.AddControl(DeleteButton);
            ScreenSizeHandler.AddControl(clearButton);
            ScreenSizeHandler.AddControl(gridview, false);

            Main.instance.PanelResized += PanelResize;
        }

        private ScreenSizeHandler ScreenSizeHandler;
        public Size panelSize;

        private void PanelResize(Size panelSize)
        {
            ScreenSizeHandler.ResizeControls(panelSize);
        }

        public void ResizeControls(Size newformSize)
        {
            ScreenSizeHandler.ResizeControls(newformSize);
        }



        public void MakeTextBoxAutoComplete(TextBox textBox,List<string> suggestions) 
        {
            textBox.AutoCompleteMode = AutoCompleteMode.Append;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(suggestions.ToArray());
            textBox.AutoCompleteCustomSource = collection;
        }

        public void LoadDataFromDB() 
        {
            List<Expense> expenses = new List<Expense>();

            expenses = DataBaseManager.GetManager().GetExpenses();
            foreach(var item in expenses)
            {
                item.Head = DataBaseManager.GetManager().GetHeadForId(item.HeadId);
            }
            expenses.Reverse();
            gridview.DataSource = expenses;
        }

        private void LoadExpenseHeadsFromDB() 
        {
           List<ExpenseHead> expenseHeads = DataBaseManager.GetManager().GetHeads();
           List<string> headNames = new List<string>();
            foreach (var item in expenseHeads) 
            {
                headNames.Add(item.name);
            }
           expenseHeadcomboBox.DataSource = headNames; 
        }

        private void Clear(object sender, EventArgs e)
        {
            updating = false;
            ClearBoxes();
        }

        public void SaveExpense() 
        {
            string date = dateTimePicker.Value.ToShortDateString();
            string headName = expenseHeadcomboBox.SelectedValue.ToString();
            int headID = DataBaseManager.GetManager().GetHeadId(headName);
            int amount = Convert.ToInt32(amountTextBox.Text);
            string description = descriptionTextBox.Text;
            string vendor = VendorTextBox.Text;
            Expense newExpense = new Expense()
            {
                Date = date,
                Description = description,
                Vendor = vendor,
                Amount = amount,
                HeadId = headID
            };

            //MessageBox.Show(headID.ToString());
            DataBaseManager.GetManager().AddExpense(newExpense);
            LoadDataFromDB();
            
        }

        public void UpdateExpense() 
        {

            string date = dateTimePicker.Value.ToShortDateString();
            string headName = expenseHeadcomboBox.SelectedValue.ToString();
            int headID = DataBaseManager.GetManager().GetHeadId(headName);
            int amount = Convert.ToInt32(amountTextBox.Text);
            string description = descriptionTextBox.Text;
            string vendor = VendorTextBox.Text;
            Expense newExpense = new Expense()
            {
                Date = date,
                Description = description,
                Vendor = vendor,
                Amount = amount,
                HeadId = headID
            };
            newExpense.id = SelectedExpenseID;

            DataBaseManager.GetManager().UpdateExpense(newExpense);
            LoadDataFromDB();

        }


        public void ClearBoxes() 
        {
            amountTextBox.Text = "";
            descriptionTextBox.Text = "";
            VendorTextBox.Text = "";
            dateTimePicker.Value = DateTime.Now;
            expenseHeadcomboBox.SelectedIndex = -1;
            
        }

        private void Save(object sender, EventArgs e)
        {
            if (descriptionTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Plz Enter Description!");
                return;
            }
            if (VendorTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Plz Enter Vendor!");
                return;
            }
            if (amountTextBox.Text.Equals(string.Empty)) 
            {
                MessageBox.Show("Plz Enter Amount!");
                return;
            }


            if (updating) 
            {
                UpdateExpense();
                updating = false;
            }
            else 
            {
                SaveExpense();
            }
            
        }

        private bool updating = false;
        private int SelectedExpenseID = -1;
        
        private void CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int rowIndex = e.RowIndex;
                dateTimePicker.Value = Convert.ToDateTime(gridview.Rows[rowIndex].Cells[1].Value.ToString());
                string headName = gridview.Rows[rowIndex].Cells[2].Value.ToString();
                expenseHeadcomboBox.SelectedIndex = expenseHeadcomboBox.FindString(headName);

                descriptionTextBox.Text = gridview.Rows[rowIndex].Cells[3].Value.ToString();
                VendorTextBox.Text = gridview.Rows[rowIndex].Cells[4].Value.ToString();
                amountTextBox.Text = gridview.Rows[rowIndex].Cells[5].Value.ToString();
                updating = true;

                GetExpenseID();
            }
        }

        public void GetExpenseID() 
        {
            string date = dateTimePicker.Value.ToShortDateString();
            string headName = expenseHeadcomboBox.SelectedValue.ToString();
            int headID = DataBaseManager.GetManager().GetHeadId(headName);
            int amount = Convert.ToInt32(amountTextBox.Text);
            string description = descriptionTextBox.Text;
            string vendor = VendorTextBox.Text;
            Expense newExpense = new Expense()
            {
                Date = date,
                Description = description,
                Vendor = vendor,
                Amount = amount,
                HeadId = headID
            };

            SelectedExpenseID = GetIDForExpense(newExpense);
        }

        private void Delete(object sender, EventArgs e)
        {
            DeleteExpense();
        }
        public void DeleteExpense() 
        {
            string date = dateTimePicker.Value.ToShortDateString();
            
            Expense newExpense = new Expense() {
                Date = date,
                id = SelectedExpenseID
            };
            
            DataBaseManager.GetManager().DeleteExpense(newExpense);
            LoadDataFromDB();
            ClearBoxes();
        }

        public int GetIDForExpense(Expense newExpense) 
        {
            int id = -1;
            List<Expense> expenses = new List<Expense>();

            expenses = DataBaseManager.GetManager().GetExpenses();
            foreach (var item in expenses)
            {
                if (item.Amount.Equals(newExpense.Amount)) 
                {
                    if (item.Date.Equals(newExpense.Date)) 
                    {
                        if (item.Description.Equals(newExpense.Description))
                        {

                            if (item.Vendor.Equals(newExpense.Vendor)) 
                            {

                                if (item.HeadId.Equals(newExpense.HeadId))
                                {
                                    id = item.id;
                                    break;

                                }
                            }
                        
                        }
                    }
                }
            }

            return id;

        }


        #region Vendor Suggestions
        private List<string> vendorNames = new List<string>();
        private void OnVendorEntered(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string vendorName = VendorTextBox.Text;
                AddSuggestion(vendorName,VendorTextBox,vendorNames);
                
            }
        }
        private void AddSuggestion(string name,TextBox textBox,List<string> suggestions) 
        {
            int MIN_ALPHABETS_COUNT = 4;

            if (name.Length >= MIN_ALPHABETS_COUNT && suggestions.Contains(name) == false) 
            {
                suggestions.Add(name);
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(suggestions.ToArray());
                textBox.AutoCompleteCustomSource = collection;
            }
        }
        #endregion

        #region Description Suggestions
        private List<string> descriptions = new List<string>();
        private void OnDescriptionEntered(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string description = descriptionTextBox.Text;
                AddSuggestion(description, descriptionTextBox, descriptions);

            }
        }
        #endregion

    }
}
