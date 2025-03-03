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
    public partial class AddUser : Form
    {
        private ScreenSizeHandler ScreenSizeHandler;
        public Size panelSize;
        public AddUser()
        {
            InitializeComponent();
            LoadDataFromDB();

            HandleControlsResize();

            AppTheme.GetAppTheme().ApplyTheme(this);
        }

        private void HandleControlsResize()
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
            ScreenSizeHandler.AddControl(gridview, false);
            ScreenSizeHandler.AddControl(usernameTextBox);
            ScreenSizeHandler.AddControl(passwordTextBox);
            ScreenSizeHandler.AddControl(AddButton);
            ScreenSizeHandler.AddControl(Delete);
            ScreenSizeHandler.AddControl(label1);
            ScreenSizeHandler.AddControl(label2);

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
            List<User> users = new List<User>();
            users = DataBaseManager.GetManager().GetUsers();
            gridview.DataSource = users;
        }

        

        private void Delete_Click(object sender, EventArgs e)
        {

            DeleteUser();
        }

        public void DeleteUser() 
        {
            User user = new User
            {
                name = userNameSelected
            };

            DataBaseManager.GetManager().DeleteUser(user);
            LoadDataFromDB();
            ClearBoxes();
        }


        private void ClearBoxes() 
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private bool updating = false;
        private string userNameSelected;
        private string passwordSelected;
        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int rowIndex = e.RowIndex;
                // 2nd column -> user name Column
                usernameTextBox.Text = gridview.Rows[rowIndex].Cells[1].Value.ToString();
                passwordTextBox.Text = gridview.Rows[rowIndex].Cells[2].Value.ToString();
                userNameSelected = gridview.Rows[rowIndex].Cells[1].Value.ToString();
                passwordSelected = gridview.Rows[rowIndex].Cells[2].Value.ToString();
                updating = true;
            }
        }

        private void Save(object sender, EventArgs e)
        {
            if (updating)
            {
                UpdateUser();
                updating = false;
            }
            else 
            {
                Save();
            }
        }

        public void UpdateUser()
        {
            User oldUserData = new User()
            {
                name = userNameSelected,
                password = passwordSelected
                
            };

            int id = DataBaseManager.GetManager().GetUserId(oldUserData);

            User updatedUser = new User()
            {
                name = usernameTextBox.Text,
                password = passwordTextBox.Text,
                id = id
            };

            DataBaseManager.GetManager().UpdateUser(updatedUser);
            //UserManager.GetManager().UpdateUser(updatedUser,oldUserData);
            LoadDataFromDB();

        }

        private void Save() 
        {
            User newUser = new User() {
              name = usernameTextBox.Text,
              password = passwordTextBox.Text
            };
            DataBaseManager.GetManager().AddUser(newUser);
            LoadDataFromDB();

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
