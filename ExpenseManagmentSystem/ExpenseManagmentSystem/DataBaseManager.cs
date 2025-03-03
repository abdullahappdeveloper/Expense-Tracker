using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

public class DataBaseManager 
{
    #region Singleton
    private static DataBaseManager _instance = null;
    private static bool showDebugMessage = false;
    private static string headsDb;
    private static string projectsDb;
    public static DataBaseManager GetManager() 
    {
        if (_instance == null) 
        {
            showDebugMessage = AppSettings.GetSettings().showDebugMessages;
            _instance = new DataBaseManager();

            headsDb = AppSettings.GetSettings().headsDb;
            projectsDb = AppSettings.GetSettings().projectsDb;
        }
        return _instance;
    }
    #endregion

    public SQLiteConnection GetConnection(string dbName)
    {
        string databasePath = "Data Source=" + dbName + ";Version=3;";

        SQLiteConnection connection = new SQLiteConnection(databasePath);
        
        return connection;
        
       
    }
    public string expensesDB;

    public List<User> GetUsers() 
    {
        List<User> adminUsers = new List<User>();

        using (SQLiteConnection connection = GetConnection(AppSettings.GetSettings().usersDb))
        {
            connection.Open();

            if ( HasTable("Users", connection) == false) 
            {
                CreateUsersTable(connection);
                
            }

            string selectQuery = "SELECT * FROM Users;";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {

                // Execute the command and get a reader to read the data
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Check if there are any rows returned
                    if (reader.HasRows)
                    {
                        // Read each row
                        while (reader.Read())
                        {
                            // Access columns by name or index
                         
                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            string password = reader.GetString(reader.GetOrdinal("Password"));

                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            User user = new User();
                            user.name = name;
                            user.password = password;
                            user.id = id; 
                            adminUsers.Add(user);
                           

            
                        }
                    }
                    else
                    {
                        if(showDebugMessage)
                        Console.WriteLine("No data found.");
                    }
                }
           


        }

            connection.Close();

        }

        return adminUsers;
    }
    public bool HasTable(string tableName, SQLiteConnection connection) 
    {
        bool hasTable =false ;
        // Query to check if the table exists
        string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";

        // Create a command object
        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            // Execute the command and read the result
            object result = command.ExecuteScalar();

            // Check if the table exists
            if (result != null)
            {
                hasTable = true;
                
            }
            else
            {
                
            }
        }

        return hasTable;
    }


    public List<ExpenseHead> GetHeads() 
    {

        List<ExpenseHead> headNames = new List<ExpenseHead>();

        using (SQLiteConnection connection = GetConnection(headsDb))
        {
            connection.Open();
            if ( HasTable("Heads", connection) == false) 
            {
                CreateHeadsTable(connection);
            }

            string selectQuery = "SELECT * FROM Heads;";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {

                // Execute the command and get a reader to read the data
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Check if there are any rows returned
                    if (reader.HasRows)
                    {
                        // Read each row
                        while (reader.Read())
                        {
                            // Access columns by name or index

                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            var head = new ExpenseHead();
                            head.name = name;
                            head.id = id;
                            headNames.Add(head);
                          
                           
                        }
                    }
                    else
                    {
                        if(showDebugMessage) Console.WriteLine("No data found.");
                    }
                }


            }

            connection.Close();

        }


        return headNames;
    }

    private void CreateHeadsTable(SQLiteConnection connection) 
    {
        string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Heads (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );
            ";
        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
        {
            // Execute the query to create the table
            command.ExecuteNonQuery();
            if(showDebugMessage) MessageBox.Show("Db and Table created Successfully");

        }
      
    }

    public void DeleteExpenseHead(string headName) 
    {
        using (SQLiteConnection connection = GetConnection(headsDb))
        {
            connection.Open();

            string deleteQuery = "DELETE FROM Heads WHERE Name = @Name";
            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", headName);


                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                   if(showDebugMessage)  MessageBox.Show("Head Deleted Successfully");
                }
                else
                {
                   if(showDebugMessage)  MessageBox.Show("Head Delete Failed");
                }


            }

            connection.Close();
        }

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

    public void DeleteUser(User user)
    {
        using (SQLiteConnection connection = GetConnection(AppSettings.GetSettings().usersDb))
        {
            connection.Open();


            string deleteQuery = "DELETE FROM Users WHERE Name = @Name";
            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", user.name);


                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if (showDebugMessage)
                        MessageBox .Show("User Deleted Successfully");
                }
                else
                {
                    if(showDebugMessage)
                    MessageBox.Show("User Delete Failed");
                }

            }

            connection.Close();
        }

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


    public string GetHeadForId(int id)
    {
        string headName = "";
        foreach (var item in GetHeads())
        {
            if (item.id.Equals(id))
            {
                headName = item.name;
                break;

            }
        }

        return headName;
    }

    private void CreateUsersTable(SQLiteConnection connection) 
    {
        string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Password TEXT NOT NULL
                );
            ";
        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
        {
            // Execute the query to create the table
            command.ExecuteNonQuery();

        }
    }

    public void UpdateUser(User user) 
    {
        using (SQLiteConnection connection = GetConnection(AppSettings.GetSettings().usersDb))
        {
            connection.Open();

            string updateQuery = "UPDATE Users SET Name = @Name, Password = @Password WHERE Id = @Id";
            using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", user.name);
                command.Parameters.AddWithValue("@Password", user.password);
                command.Parameters.AddWithValue("@Id", user.id);


                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage)
                    MessageBox.Show("User Updated Successfully");
                }
                else
                {
                    if(showDebugMessage)
                    MessageBox.Show("User update Failed");
                }


            }

            connection.Close();
        }
    }

    public void UpdateExpenseHead(string headName, int _id)
    {
        using (SQLiteConnection connection = GetConnection(headsDb))
        {
            connection.Open();


            string updateQuery = "UPDATE Heads SET Name = @Name WHERE Id = @Id";
            using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", headName);
                command.Parameters.AddWithValue("@Id", _id);


                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                   if(showDebugMessage) MessageBox.Show("Head Updated Successfully");
                }
                else
                {
                    if(showDebugMessage) MessageBox.Show("Head update Failed");
                }


            }

            connection.Close();
        }

    }


    public void AddExpenseHead(string headName)
    {


        using (SQLiteConnection connection = GetConnection(headsDb))
        {
            connection.Open();

            string insertQuery = @"
                INSERT INTO Heads (Name) 
                VALUES (@Name);
            ";
            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", headName);
            
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage) MessageBox.Show("Data Inserted Successfully");
                }
                else
                {
                    if(showDebugMessage) MessageBox.Show("Data Insert Failed");
                }


            }

            connection.Close();

        }
    }


    public void AddUser(User newUser)
    {
        

        using (SQLiteConnection connection = GetConnection(AppSettings.GetSettings().usersDb))
        {
            connection.Open();

            string insertQuery = @"
                INSERT INTO Users (Name, Password) 
                VALUES (@Name, @Password);
            ";

            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", newUser.name);
                command.Parameters.AddWithValue("@Password", newUser.password);

                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage)
                    MessageBox.Show("Data Inserted Successfully");
                }
                else
                {
                    if (showDebugMessage)
                        MessageBox.Show("Data Insert Failed");
                }


            }

            connection.Close();

        }
    }

    private void CreateExpensesTable(SQLiteConnection connection) 
    {
        string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Expenses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT NOT NULL, HeadID INTEGER NOT NULL, Description TEXT NOT NULL,Vendor TEXT NOT NULL, Amount INTEGER NOT NULL

                );
            ";
        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
        {
            // Execute the query to create the table
            command.ExecuteNonQuery();
            if (showDebugMessage)
                MessageBox.Show("Expense Table created Successfully");

        }
   
    }


    public void OpenProject(Project openProject) 
    {
        
        expensesDB = $"{openProject.path}.db";

        FileInfo fileinfo = new FileInfo(expensesDB);
        if(showDebugMessage)
        MessageBox.Show($"{fileinfo.FullName}");
    }

    public List<Expense> GetExpenses()
    {

        List<Expense> expenses = new List<Expense>();

        using (SQLiteConnection connection = GetConnection(expensesDB))
        {
            connection.Open();

            if (HasTable("Expenses", connection) == false)
            {
                CreateExpensesTable(connection);
            }
           

            string selectQuery = "SELECT * FROM Expenses;";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {

                // Execute the command and get a reader to read the data
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Check if there are any rows returned
                    if (reader.HasRows)
                    {
                        // Read each row
                        while (reader.Read())
                        {
                            // Access columns by name or index

                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string date = reader.GetString(reader.GetOrdinal("Date"));
                            int headID = reader.GetInt32(reader.GetOrdinal("HeadID"));
                            string description = reader.GetString(reader.GetOrdinal("Description"));
                            string vendor = reader.GetString(reader.GetOrdinal("Vendor"));
                            int amount = reader.GetInt32(reader.GetOrdinal("Amount"));

                            expenses.Add(new Expense()
                            {
                                id = id,
                                Date = date,
                                HeadId = headID,
                                Description = description,
                                Vendor = vendor,
                                Amount = amount
                                
                            }); 


                        }
                    }
                    else
                    {
                        if(showDebugMessage)
                        Console.WriteLine("No data found.");
                    }
                }



            }

            connection.Close();

        }


        return expenses;
    }


    public void AddExpense(Expense newExpense)
    {

        using (SQLiteConnection connection = GetConnection(expensesDB))
        {
            connection.Open();

            string insertQuery = @"
                INSERT INTO Expenses (Date, HeadID, Description, Vendor, Amount) 
                VALUES (@Date, @HeadID, @Description, @Vendor, @Amount);
            ";

            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
            {

                command.Parameters.AddWithValue("@Date", newExpense.Date);
                command.Parameters.AddWithValue("@HeadID", newExpense.HeadId);
                command.Parameters.AddWithValue("@Description", newExpense.Description);
                command.Parameters.AddWithValue("@Vendor", newExpense.Vendor);
                command.Parameters.AddWithValue("@Amount", newExpense.Amount);

                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage)
                    MessageBox.Show("Expense Inserted Successfully");
                }
                else
                {
                    if(showDebugMessage)
                    MessageBox.Show("Expense Insert Failed");
                }


            }

            connection.Close();

        }
    }

    public void UpdateExpense(Expense newExpense)
    {
        
        using (SQLiteConnection connection = GetConnection(expensesDB))
        {
            connection.Open();

            string updateQuery = "UPDATE Expenses SET Date = @Date, HeadID = @HeadID, Description = @Description, Vendor = @Vendor, Amount = @Amount WHERE Id = @Id";

            using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
            {

                command.Parameters.AddWithValue("@Date", newExpense.Date);
                command.Parameters.AddWithValue("@HeadID", newExpense.HeadId);
                command.Parameters.AddWithValue("@Description", newExpense.Description);
                command.Parameters.AddWithValue("@Vendor", newExpense.Vendor);
                command.Parameters.AddWithValue("@Amount", newExpense.Amount);
                command.Parameters.AddWithValue("@Id", newExpense.id);

                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage)
                    MessageBox.Show("Expense Updated Successfully");
                }
                else
                {
                    if(showDebugMessage)
                    MessageBox.Show("Expense Update Failed");
                }


            }

            connection.Close();

        }
    }


    public void DeleteExpense(Expense newExpense)
    {
        using (SQLiteConnection connection = GetConnection(expensesDB))
        {
            connection.Open();


            string deleteQuery = "DELETE FROM Expenses WHERE Id = @Id";
            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", newExpense.id);

                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage)
                    MessageBox.Show("Expense Deleted Successfully");
                }
                else
                {
                    if(showDebugMessage)
                    MessageBox.Show("Expense Delete Failed");
                }

            }

            connection.Close();
        }

    }



    public List<Project> GetProjects()
    {
        List<Project> projects = new List<Project>();

        using (SQLiteConnection connection = GetConnection(projectsDb))
        {
            connection.Open();

            if (HasTable("Projects", connection) == false)
            {
                CreateProjectsTable(connection);
            }
            if (HasTable("CurrentProject", connection) == false)
            {
                CreateCurrentProjectTable(connection);
            }

            string selectQuery = "SELECT * FROM Projects;";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {

                // Execute the command and get a reader to read the data
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Check if there are any rows returned
                    if (reader.HasRows)
                    {
                        // Read each row
                        while (reader.Read())
                        {
                            // Access columns by name or index

                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            string path = reader.GetString(reader.GetOrdinal("Path"));

                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            

                            projects.Add(new Project() 
                            {
                              id = id,
                              name = name, 
                              path = path 
                            });


                        }
                    }
                    else
                    {
                        if(showDebugMessage)
                        Console.WriteLine("No data found.");
                    }
                }



            }

            connection.Close();

        }

        return projects;
    }

    public void SetCurrentProject(Project openProject) 
    {
        openProject.id = 1;
        using (SQLiteConnection connection = GetConnection(projectsDb))
        {
            connection.Open();

            if (GetOpenProject() == null) 
            {
                InsertProject( connection,openProject);
            }


            string updateQuery = "UPDATE CurrentProject SET Name = @Name, Path = @Path WHERE Id = @Id";

            using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
            {

                command.Parameters.AddWithValue("@Name", openProject.name);
                command.Parameters.AddWithValue("@Path", openProject.path);
                command.Parameters.AddWithValue("@Id", openProject.id);

                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage) MessageBox.Show("Project Set Successfully");
                }
                else
                {
                    if(showDebugMessage) MessageBox.Show("Project Set Failed");
                }


            }

            connection.Close();

        }
    }

    public Project GetOpenProject() 
    {
        List<Project> OpenProjects = new List<Project>();

        using (SQLiteConnection connection = GetConnection(projectsDb))
        {
            connection.Open();

            if (HasTable("CurrentProject", connection) == false)
            {
                CreateCurrentProjectTable(connection);
            }

            string selectQuery = "SELECT * FROM CurrentProject;";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {

                // Execute the command and get a reader to read the data
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Check if there are any rows returned
                    if (reader.HasRows)
                    {
                        // Read each row
                        while (reader.Read())
                        {
                            // Access columns by name or index

                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            string path = reader.GetString(reader.GetOrdinal("Path"));

                            int id = reader.GetInt32(reader.GetOrdinal("Id"));


                            OpenProjects.Add(new Project()
                            {
                                id = id,
                                name = name,
                                path = path
                            });


                        }
                    }
                    else
                    {
                        if(showDebugMessage)
                        Console.WriteLine("No data found.");
                    }
                }



            }

            connection.Close();

        }
        bool projectFound = OpenProjects.Count > 0;
        Project projectOpen = null;
        if (projectFound) 
        {
            projectOpen = OpenProjects[0];
        }
        return projectOpen;
    }


    private void InsertProject(SQLiteConnection connection,Project openProject) 
    {
        string insertQuery = @"
                INSERT INTO CurrentProject (Name, Path) 
                VALUES (@Name, @Path);
            ";

        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
        {

            command.Parameters.AddWithValue("@Name", openProject.name);
            command.Parameters.AddWithValue("@Path", openProject.path);


            // Execute the query to create the table
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                if(showDebugMessage)
                 MessageBox.Show("Project Inserted Successfully");
            }
            else
            {
                if(showDebugMessage)
                MessageBox.Show("Project Insert Failed");
            }


        }

    }


    private void CreateProjectsTable(SQLiteConnection connection) 
    {
        string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Projects (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL, Path TEXT NOT NULL

                );
            ";
        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
        {
            // Execute the query to create the table
            command.ExecuteNonQuery();

        }
    }

    private void CreateCurrentProjectTable(SQLiteConnection connection)
    {
        string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS CurrentProject (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL, Path TEXT NOT NULL

                );
            ";
        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
        {
            // Execute the query to create the table
            command.ExecuteNonQuery();

        }
    }


    public void AddProject(Project newProject)
    {

        using (SQLiteConnection connection = GetConnection(projectsDb))
        {
            connection.Open();
            if (HasTable("Projects", connection) == false)
            {
                CreateProjectsTable(connection);
            }

            string insertQuery = @"
                INSERT INTO Projects (Name, Path) 
                VALUES (@Name, @Path);
            ";

            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
            {

                command.Parameters.AddWithValue("@Name", newProject.name);
                command.Parameters.AddWithValue("@Path", newProject.path);
                

                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if(showDebugMessage)
                    MessageBox.Show("Project Inserted Successfully");
                }
                else
                {
                    if(showDebugMessage)
                    MessageBox.Show("Project Insert Failed");
                }


            }

            connection.Close();

        }
    }

    public void DeleteProject(Project project) 
    {
        using (SQLiteConnection connection = GetConnection(projectsDb))
        {
            connection.Open();


            string deleteQuery = "DELETE FROM Projects WHERE Id = @Id";
            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", project.id);

                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if (showDebugMessage)
                        MessageBox.Show("Project Deleted Successfully");
                }
                else
                {
                    if (showDebugMessage)
                        MessageBox.Show("Project Delete Failed");
                }

            }

            connection.Close();
        }
    }

    public int GetProjectId(Project project)
    {
        int id = -1;
        foreach (var item in GetProjects())
        {
            if (item.name.Equals(project.name) && item.path.Equals(project.path))
            {
                id = item.id;
                break;

            }
        }

        return id;
    }

    public void UpdateProject(Project project) 
    {
        using (SQLiteConnection connection = GetConnection(projectsDb))
        {
            connection.Open();


            string updateQuery = "UPDATE Projects SET Name = @Name, Path = @Path WHERE Id = @Id";
            using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", project.name);
                command.Parameters.AddWithValue("@Path", project.path);

                command.Parameters.AddWithValue("@Id", project.id);


                // Execute the query to create the table
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    if (showDebugMessage) MessageBox.Show("Project Updated Successfully");
                }
                else
                {
                    if (showDebugMessage) MessageBox.Show("Project update Failed");
                }


            }

            connection.Close();
        }
    }
}


public class DBManager
{
    private static DBManager _instance = null;
    private DBManager() 
    {
    
    }
    public static DBManager GetManager() 
    {
        if (_instance == null)
        {
            _instance = new DBManager();
        }
        return _instance;
    }

    private SQLiteConnection GetConnection(string dbName) 
    {
        string databasePath = "Data Source=" + dbName + ";Version=3;";

        SQLiteConnection connection = new SQLiteConnection(databasePath);

        return connection;
    }

    public void AddTable(string table, string db, string tableSchema) 
    {
        using (SQLiteConnection connection = GetConnection(db)) 
        {

            connection.Open();

            string query = $"CREATE TABLE IF NOT EXISTS {table} {tableSchema};";
            using (SQLiteCommand command = new SQLiteCommand(query,connection))
            {
                command.ExecuteNonQuery();
                MessageBox.Show($"{table} added in {db} with schema {tableSchema}");
            }


           connection.Close();
        }

    }

    public void InsertData(string dbName,string tableName, string columns, string values)
    {
        using (var connection = GetConnection(dbName))
        {
            connection.Open();
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Data inserted successfully.");
    }

    // Read data from a table
    public System.Data.DataTable ReadData(string dbName,string tableName)
    {
        using (var connection = GetConnection(dbName))
        {
            connection.Open();
            string selectQuery = $"SELECT * FROM {tableName}";

            using (var command = new SQLiteCommand(selectQuery, connection))
            {
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    connection.Close();
                    return dt;
                }
            }

            connection.Close();
        }
    }

    // Update data in a table
    public void UpdateData(string dbName, string tableName, string setValues, string whereClause)
    {
        using (var connection = GetConnection(dbName))
        {
            connection.Open();
            string query = $"UPDATE {tableName} SET {setValues} WHERE {whereClause}";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        
    }

    // Delete data from a table
    public void DeleteData(string dbName,string tableName, string whereClause)
    {
        using (var connection = GetConnection(dbName))
        {
            connection.Open();

            string query = $"DELETE FROM {tableName} WHERE {whereClause}";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        
    }

    public bool HasTable(string dbName, string tableName)
    {
        bool hasTable = false;
        // Query to check if the table exists
        string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";

        using (var connection = GetConnection(dbName))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                // Execute the command and read the result
                object result = command.ExecuteScalar();

                // Check if the table exists
                if (result != null)
                {
                    hasTable = true;

                }

            }
            connection.Close();
        }
        return hasTable;
    }
}

