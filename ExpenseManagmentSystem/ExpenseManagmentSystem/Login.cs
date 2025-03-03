using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace ExpenseManagmentSystem
{
    public partial class Login : Form
    {

        public static Login _instance = null;
        public Login()
        {
            InitializeComponent();
            _instance = this;
            if (Main.instance == null) 
            {
                Main.instance = new Main();
                Main.instance.FormClosed += FormClose;
            }
            AppSettings.GetSettings().AddDefaultUser();

            AppTheme.GetAppTheme().ApplyTheme(this);
        }
        

        private void FormClose(object sender, FormClosedEventArgs e) 
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LogInButton_Click(object sender, EventArgs e)
        {

            AuthenticateUser();
      
        }

        private void AuthenticateUser() 
        {
           
            List<User> adminUsers = new List<User>();
            adminUsers = DataBaseManager.GetManager().GetUsers();
            bool loginSuccess = false;
            foreach (var user in adminUsers) 
            {
                if (user.name.Equals(UserNameText.Text) && user.password.Equals(PasswordText.Text))
                {

                    loginSuccess = true;
                    break;
                }
                
            }

            if (loginSuccess)
            {
                ClearBoxes();
                Main.instance.Show();
                _instance.Hide();
            }
            else 
            {
                MessageBox.Show("Wrong User name or Password Try Again Later.");
            }
        }

        public void ClearBoxes()
        {
            UserNameText.Text = "";
            PasswordText.Text = "";
        }

       
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


# region drag Login Form
        Dragable dragable = new Dragable();
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            dragable.DragStarted(this.Location);
        }

        // Mouse Move Event
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            dragable.Draging(this);
        }

        // Mouse Up Event
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            dragable.DragEnded();
        }

#endregion

    }

}

