using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ExpenseManagmentSystem
{
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
            LoadDataFromDB();
            HandleControlsResize();

            AppTheme.GetAppTheme().ApplyTheme(this);
        }

        private ScreenSizeHandler ScreenSizeHandler;
        public Size panelSize;
        private void HandleControlsResize()
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
            ScreenSizeHandler.AddControl(projectNameTextBox);
            ScreenSizeHandler.AddControl(projectPathTextBox);
            ScreenSizeHandler.AddControl(titleText);
            ScreenSizeHandler.AddControl(panel1);
            ScreenSizeHandler.AddControl(label2);
            ScreenSizeHandler.AddControl(label3);

            ScreenSizeHandler.AddControl(OpenProjectButton);
            ScreenSizeHandler.AddControl(createProjectButton);
            ScreenSizeHandler.AddControl(RenameButton);
            ScreenSizeHandler.AddControl(importButton);
            ScreenSizeHandler.AddControl(deleteButton);

            ScreenSizeHandler.AddControl(gridview, false);
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
            List<Project> projects = new List<Project>();
             projects = DataBaseManager.GetManager().GetProjects();
            //projects = ProjectManager.GetManager().GetProjects();
            gridview.DataSource = projects;
        }

        
        private void Add(object sender, EventArgs e)
        {
            //string fileSelected;
            //DialogueManager.GetManager().ShowSaveFileDialogue(out fileSelected);
            ShowSaveFileDialogue();
        }

        public void ShowSaveFileDialogue() 
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
                MessageBox.Show(projectPath);
                
                AddProjectInDB(projectName, projectPath);

            }
        }

        public void AddProjectInDB(string projectName,string projectPath) 
        {
            Project newProject = new Project() 
            {
             name = projectName,
             path = projectPath
            };

            //ProjectManager.GetManager().AddProject(newProject);
            DataBaseManager.GetManager().AddProject(newProject);
            LoadDataFromDB();
        }

        private void OpenProject(object sender, EventArgs e)
        {
            bool noProjectSelected = projectNameTextBox.Text.Equals(string.Empty) && projectPathTextBox.Text.Equals(string.Empty);
            if (noProjectSelected) 
            {
                MessageBox.Show("No Project Selected");
                return;
            }

            Project openProject = new Project()
            {
                name = projectNameTextBox.Text,
                path = projectPathTextBox.Text
            };

            DataBaseManager.GetManager().SetCurrentProject(openProject);
           // ProjectManager.GetManager().OpenProject(openProject);

            this.Close();
            Main.instance.SetProjectName();
            Main.instance.ShowDashBoard();
       
        }

        string filePath = string.Empty;
        private void CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int rowIndex = e.RowIndex;
                // 2nd Column -> project name
                projectNameTextBox.Text = gridview.Rows[rowIndex].Cells[0].Value.ToString();
                projectPathTextBox.Text = gridview.Rows[rowIndex].Cells[1].Value.ToString();

                Project project = new Project()
                {
                    name = projectNameTextBox.Text,
                    path = projectPathTextBox.Text
                };
                filePath = projectPathTextBox.Text.ToString();
                projectSelectedId = DataBaseManager.GetManager().GetProjectId(project);
            }
        }

        private void ImportProject(object sender, EventArgs e)
        {
            ImportFile();
        }

        private void ImportFile() 
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog.Filter = "Database Files (*.db)|*.db";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string importedDbName = openFileDialog.FileName;
                string folderPath = AppSettings.GetSettings().GetBackUpFolderPath();

                string BackupDbFileName = Path.GetFileName(importedDbName);

                string backupfilePath = Path.Combine(folderPath, BackupDbFileName);

                MessageBox.Show(BackupDbFileName);

                if (Directory.Exists(folderPath) == false) 
                {
                    Directory.CreateDirectory(folderPath);
                }
                bool fileExists = false;
                if (File.Exists(backupfilePath))
                {
                    // file with same name exist
                    BackupDbFileName = Path.GetFileNameWithoutExtension(importedDbName);
                    BackupDbFileName = String.Concat(BackupDbFileName,"_2.db");
                    backupfilePath = Path.Combine(folderPath, BackupDbFileName);
                    File.Copy(importedDbName, backupfilePath , true);
                    fileExists = true;
                }
                else 
                {
                    File.Copy(importedDbName, backupfilePath, true);
                }

                

                Project importedProject = new Project()
                {
                    name = Path.GetFileNameWithoutExtension(backupfilePath),
                    path = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(backupfilePath))
                };
            
               

                DataBaseManager.GetManager().AddProject(importedProject);
                LoadDataFromDB();
                
            }

        }

        private void RenameProject(object sender, EventArgs e)
        {

            RenameProject();
        }
        private int projectSelectedId = -1;
        private void RenameProject() 
        {
            Project RenamedProject = new Project()
            {
                name = projectNameTextBox.Text,
                path = projectPathTextBox.Text
            };
            
            RenamedProject.id = projectSelectedId;

            //rename file
            string newFileName = RenamedProject.path;
            
            DataBaseManager.GetManager().UpdateProject(RenamedProject);
            File.Move(filePath+".db", newFileName+".db");

            LoadDataFromDB();
        }


        private void DeleteProject(object sender, EventArgs e)
        {
            DeleteProject();    
        }

        private void DeleteProject() 
        {
            
            DialogResult result = MessageBox.Show(
                "Do you want to Delete Project File Permanently?", 
                "Confirmation",            
                MessageBoxButtons.YesNo,   
                MessageBoxIcon.Warning    
            );

            // Handle the user's response
            if (result == DialogResult.Yes)
            {

                Project project = new Project()
                {
                    name = projectNameTextBox.Text,
                    path = projectPathTextBox.Text
                };
                int _id = DataBaseManager.GetManager().GetProjectId(project);
                project.id = _id;

                File.Delete(project.path+".db");
                DataBaseManager.GetManager().DeleteProject(project);
                

                LoadDataFromDB();

            }
            else if (result == DialogResult.No)
            {
              
            }
        }

       
    }

}
