using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
namespace ExpenseManagmentSystem
{
    class ExpenseHeadManager
    {
        #region Singleton
        private static ExpenseHeadManager _instance = null;
        string dbName = AppSettings.GetSettings().headsDb;
        string table = "Heads";
        private ExpenseHeadManager()
        {

        }
        public static ExpenseHeadManager GetManager()
        {
            if (_instance == null)
            {
                _instance = new ExpenseHeadManager();
            }
            return _instance;
        }
        #endregion

        public List<ExpenseHead> GetHeads() 
        {
            List<ExpenseHead> heads = new List<ExpenseHead>();
            
            DataTable dataTable =  DBManager.GetManager().ReadData(dbName,table);
            foreach (DataRow row in dataTable.Rows) 
            {
                int Id = Convert.ToInt32(row["Id"]);
                string Name = Convert.ToString(row["Name"]);
                ExpenseHead expenseHead = new ExpenseHead()
                {
                    id = Id,
                    name = Name
                };
              //  MessageBox.Show($"{Id} : {Name}");
                heads.Add(expenseHead);
            }

            return heads;
        }

        public void DeleteExpenseHead(string headName) 
        {
            string where = $"Name = '{headName}'";
            DBManager.GetManager().DeleteData(dbName,table,where);
        }

        public void AddExpenseHead(string headName) 
        {
            
            string columns = "Name";
            string values = $"'{headName}'";
            DBManager.GetManager().InsertData(dbName, table, columns, values);
        }

        public void UpdateExpenseHead(string oldName,string NewName) 
        {
            int id = GetHeadId(oldName);
            string values = $"Name = '{NewName}'";
            string where = $"Id = '{id}'";

            DBManager.GetManager().UpdateData(dbName,table,values,where);
        }

        public int GetHeadId(string name)
        {
            int id = -1;
            foreach (var item in GetHeads())
            {
                if (item.name.Equals(name))
                {
                    id = item.id;
                    break;

                }
            }

            return id;
        }
    }
}
