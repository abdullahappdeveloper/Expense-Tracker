using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ExpenseManagmentSystem
{
    class ProjectManager
    {

        #region Singleton
        private static ProjectManager _instance = null;
        string dbName = AppSettings.GetSettings().projectsDb;
        string table = "Projects";
        string currentProjectsTable = "CurrentProject";
        private ProjectManager() 
        {
        }
        public static ProjectManager GetManager() 
        {
            if (_instance == null) 
            {
                _instance = new ProjectManager();
            }
            return _instance;
        }
        #endregion

        public Project GetCurrentlyOpenedProject() 
        {
            Project currentProject = new Project();
            
            DataTable dataTable = DBManager.GetManager().ReadData(dbName,currentProjectsTable);
            
            foreach (DataRow dataRow in dataTable.Rows) 
            {
                string name = Convert.ToString(dataRow["Name"]);
                string path = Convert.ToString(dataRow["Path"]);
                currentProject.name = name;
                currentProject.path = path;
            }

            return currentProject;
        }
 
        public void OpenProject(Project openProject) 
        {
            openProject.id = 1;

            List<Project> openProjects = GetOpenProjects();
            bool NO_PROJECT_OPENED_YET = openProjects == null;

            if (NO_PROJECT_OPENED_YET)
            {
                InsertOpenProject(openProject);
            }
            else 
            {
                UpateOpenProject(openProject);
            }
        }

        private void InsertOpenProject(Project openProject) 
        {
            string columns = "Name, Path";
            string values = $"'{openProject.name}', '{openProject.path}'";

            DBManager.GetManager().InsertData(dbName, currentProjectsTable, columns, values);
        }

        private void UpateOpenProject(Project openProject)
        {
            int id = 1;

            string values = $"Name = '{openProject.name}', Path = '{openProject.path}'";

            string where = $"Id = '{id}'";
            
            DBManager.GetManager().UpdateData(dbName, currentProjectsTable, values, where);
        }

        public void RenameProject(Project newData,Project oldData) 
        {
            int id = GetProjectId(oldData);

            string values = $"Name = '{newData.name}', Path = '{newData.path}'";
            string where = $"Id = '{id}'";
            DBManager.GetManager().UpdateData(dbName,table,values,where);
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

        public void AddProject(Project newProject)
        {
            string columns = "Name, Path";
            string values = $"'{newProject.name}', '{newProject.path}'";

            DBManager.GetManager().InsertData(dbName,table,columns,values);
        }

        public void DeleteProject(Project project) 
        {
            int id = GetProjectId(project);
            string where = $"Id = '{id}'";
            DBManager.GetManager().DeleteData(dbName, table, where);
        }

        private List<Project> GetOpenProjects() 
        {
            List<Project> projects = new List<Project>();

            DataTable dataTable = DBManager.GetManager().ReadData(dbName, currentProjectsTable);

            foreach (DataRow row in dataTable.Rows)
            {

                int Id = Convert.ToInt32(row["Id"]);
                string Name = Convert.ToString(row["Name"]);
                string Path = Convert.ToString(row["Path"]);

                Project project = new Project()
                {
                    id = Id,
                    name = Name,
                    path = Path
                };

                projects.Add(project);
            }


            return projects;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();

            DataTable dataTable = DBManager.GetManager().ReadData(dbName, table);

            foreach (DataRow row in dataTable.Rows)
            {

                int Id = Convert.ToInt32(row["Id"]);
                string Name = Convert.ToString(row["Name"]);
                string Path = Convert.ToString(row["Path"]);

                Project project = new Project()
                {
                    id = Id,
                    name = Name,
                    path = Path
                };

                projects.Add(project);
            }


            return projects;
        }
    }
}
