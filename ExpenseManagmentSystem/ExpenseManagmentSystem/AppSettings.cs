using System.IO;
using System;
using System.Windows.Forms;
using ExpenseManagmentSystem;
using System.Drawing;
public class AppSettings 
{
    private static AppSettings _instance = null;
    public bool showDebugMessages = false;

    public User defaultUser;

    public string OpenProjectName;
    public string headsDb;
    public string usersDb;
    public string projectsDb;

    
    public static AppSettings GetSettings() 
    {
        if (_instance == null)
        {
            AppTheme.GetAppTheme().colorTheme = AppTheme.BlackWhite;
            _instance = new AppSettings();
        }
        return _instance;
    }
    private AppSettings() 
    {
        string backupfolder = GetBackUpFolderPath();
        backupfolder = Path.Combine(backupfolder, "shared");
        
        bool sharedFolderNotExist = !Directory.Exists(backupfolder);
        if (sharedFolderNotExist) 
        {
            Directory.CreateDirectory(backupfolder);
        }
        string DbName = "heads.db";
        headsDb = Path.Combine(backupfolder,DbName);
        usersDb = Path.Combine(backupfolder, "user.db");
        projectsDb = Path.Combine(backupfolder, "projects.db");

        defaultUser = new User()
        {
            name = "admin",
            password = "123"

        };

        
    }

    public string GetBackUpFolderPath() 
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktopFolderName = "Data Backup";

        string folderPath = Path.Combine(desktopPath, desktopFolderName);
        bool directoryNotExist = !Directory.Exists(folderPath);
        if (directoryNotExist) 
        {
            
            Directory.CreateDirectory(folderPath);
        }
        
        // hide folder
        File.SetAttributes(folderPath, FileAttributes.Hidden);
        return folderPath;
    }

    public void AddDefaultUser()
    {

        if (DataBaseManager.GetManager().GetUsers().Count == 0)
        {
            DataBaseManager.GetManager().AddUser(defaultUser);
        }

    }

    public void OpenDefaultProject()
    {
        Project openProject = DataBaseManager.GetManager().GetOpenProject();
        bool NoProjectFound = openProject == null;
        if (NoProjectFound)
        {
            MessageBox.Show("No Project Found: Create New Project");
            ShowCreateProjectDialogue();
        }
        bool projectFound = openProject != null;
        if (projectFound) 
        {
            //MessageBox.Show("Project Created But set in Db");
            DataBaseManager.GetManager().OpenProject(openProject);
            DataBaseManager.GetManager().SetCurrentProject(openProject);
        }

    }

    public void ShowCreateProjectDialogue()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Title = "Create Project : ";
        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        saveFileDialog.Filter = "Database Files (*.db)|*.db";
        saveFileDialog.FilterIndex = 1;
        DialogResult result = saveFileDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            string fileSelected = saveFileDialog.FileName;

            string projectName = Path.GetFileNameWithoutExtension(fileSelected);

            string folderPath = Path.GetDirectoryName(fileSelected);

            string projectPath = Path.Combine(folderPath, projectName);

            Project newProject = new Project();
            newProject.name = projectName;
            newProject.path = projectPath;

            DataBaseManager.GetManager().AddProject(newProject);
           
            DataBaseManager.GetManager().OpenProject(newProject);
            DataBaseManager.GetManager().SetCurrentProject(newProject);

        }
    }

}

