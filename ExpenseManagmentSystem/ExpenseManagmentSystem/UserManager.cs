using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ExpenseManagmentSystem
{
    class UserManager
    {

        #region Singleton
        private static UserManager _instance = null;
        string dbName = AppSettings.GetSettings().usersDb;
        string table = "Users";
        string tableSchema = @"(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Password TEXT NOT NULL
                ); ";
        private UserManager()
        {
            bool TABLE_DOES_NOT_EXIST = DBManager.GetManager().HasTable(dbName, table) == false;
            if (TABLE_DOES_NOT_EXIST) 
            {
                DBManager.GetManager().AddTable(dbName,table,tableSchema);
            }
        }
        public static UserManager GetManager()
        {
            if (_instance == null)
            {
                _instance = new UserManager();
            }
            return _instance;
        }
        #endregion

        public List<User> GetUsers() 
        {
            List<User> users = new List<User>();

            DataTable dataTable =  DBManager.GetManager().ReadData(dbName, table);

            foreach (DataRow row in dataTable.Rows) 
            {
                
                int Id = Convert.ToInt32(row["Id"]);
                string Name = Convert.ToString(row["Name"]);
                string Password = Convert.ToString(row["Password"]);
                
                User newUser = new User()
                {
                    id = Id,
                    name = Name,
                    password = Password
                };

                users.Add(newUser);
            }


            return users;
        }

        public void AddUser(User user)
        {

            string columns = "Name, Password";
            string values = $"'{user.name}', '{user.password}'";
            DBManager.GetManager().InsertData(dbName, table, columns, values);
        }

        public void DeleteUser(User user) 
        {
            string where = $"Name = '{user.name}'";
            DBManager.GetManager().DeleteData(dbName,table, where);
        }

        public void UpdateUser(User newData, User oldData) 
        {
            int id = GetUserId(oldData);

            string values = $"Name = '{newData.name}', Password = '{newData.password}'";
            string where = $"Id = '{id}'";
            DBManager.GetManager().UpdateData(dbName,table,values,where);
        }

        public int GetUserId(User user)
        {
            int id = -1;
            foreach (var item in DataBaseManager.GetManager().GetUsers())
            {
                if (user.name.Equals(item.name) && user.password.Equals(item.password))
                {
                    id = item.id;
                    break;
                }
            }

            return id;

        }

    }
}
