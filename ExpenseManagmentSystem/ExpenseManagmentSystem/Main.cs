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
    public partial class Main : Form
    {
        public static Main instance = null;
        private List<DashBoardButton> dashBoardButtons;
        public Button settingsButtonSelected;
        public Action<Size> PanelResized;

        ScreenSizeHandler ScreenSizeHandler;
        public Main()
        {
            if (instance == null) 
            {
                instance = this;
            }
   
            InitializeComponent();

            // open Project
            AppSettings.GetSettings().OpenDefaultProject();

            openProjectName.Text = $"{AppSettings.GetSettings().OpenProjectName}";

            ApplyTheme(dashBoardButton);

            // show dashboard screen
            ShowDashBoard();
            
            // set project Title
            ShowProjectTitle();

            // handle controle sizes like window maximize or minimize events
            HandleControlsResize();

            settingsButtonSelected = SettingsButton;
          
        }
        public void ApplyTheme(Button buttonSelected) 
        {
            AppTheme.GetAppTheme().ApplyTheme(this);

            // add side buttons in list<buttons>
            AddDashBoardButtons();
            ButtonSelected(buttonSelected);
        }
        
        public void AddDashBoardButtons() 
        {
            dashBoardButtons = new List<DashBoardButton>();
            AddDashButton(AddUserButton, false);
            AddDashButton(AdHeadsButton, false);
            AddDashButton(AddProjectButton, false);
            AddDashButton(CostReportButton, false);
            AddDashButton(LedgerButton, false);
            AddDashButton(AdExpenseButton, false);
            AddDashButton(dashBoardButton, false);
            AddDashButton(SettingsButton, false);
        }

        public void HandleControlsResize() 
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
            ScreenSizeHandler.AddControl(formspanel, false);
            ScreenSizeHandler.AddControl(panel2, false);
            ScreenSizeHandler.AddControl(AddUserButton);
            ScreenSizeHandler.AddControl(AdHeadsButton);
            ScreenSizeHandler.AddControl(AddProjectButton);
            ScreenSizeHandler.AddControl(CostReportButton);
            ScreenSizeHandler.AddControl(LedgerButton);
            ScreenSizeHandler.AddControl(AdExpenseButton);
            ScreenSizeHandler.AddControl(dashBoardButton);
            ScreenSizeHandler.AddControl(panel1, false);
            ScreenSizeHandler.AddControl(titleText);

            ScreenSizeHandler.AddControl(closeButton);
            ScreenSizeHandler.AddControl(minimizeButton);
            ScreenSizeHandler.AddControl(maxiMiseButton);
            ScreenSizeHandler.AddControl(SettingsButton);
        }
      

        public void ShowProjectTitle() 
        {
            string projectName = DataBaseManager.GetManager().GetOpenProject().name;
            //string projectName = ProjectManager.GetManager().GetCurrentlyOpenedProject().name;
            string title = "Expense Management App";
            titleText.Text = $"{title} - {projectName}" ;
        }

        public void ShowDashBoard() 
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.ResizeControls(formspanel.Size);
            ShowScreen(dashBoard,dashBoardButton);
        }

        public void AddDashButton(Button button, bool _selected) 
        {
            dashBoardButtons.Add(new DashBoardButton()
            {
                button = button,
                selected = _selected
            });
        }

        public void ButtonSelected(Button button) 
        {
            foreach (var item in dashBoardButtons) 
            {
                if (item.button.Equals(button))
                {
                    item.button.BackColor = AppTheme.GetAppTheme().colorTheme.darkColor;
                    item.button.ForeColor = AppTheme.GetAppTheme().colorTheme.lightColor;
                }
                else 
                {
                    item.button.BackColor = AppTheme.GetAppTheme().colorTheme.lightColor;
                    item.button.ForeColor = AppTheme.GetAppTheme().colorTheme.darkColor;
                }
            }
        }


        public void SetProjectName() 
        {
            AppSettings.GetSettings().OpenDefaultProject();
            openProjectName.Text = $"{AppSettings.GetSettings().OpenProjectName}";
        }
        

        private void ShowScreen(Form screen,Button buttonSelected)
        {
            ButtonSelected(buttonSelected);

            screen.TopLevel = false;
            screen.FormBorderStyle = FormBorderStyle.None;

            // Dock the form inside the panel to fill the entire panel area
            screen.Dock = DockStyle.Fill;

            // Clear any existing controls in the panel (if needed)
            formspanel.Controls.Clear();

            // Add the form to the panel
            formspanel.Controls.Add(screen);

            // Show the form within the panel
            screen.Show();

           
        }

        private void AddExpense(object sender, EventArgs e)
        {
            AddExpense addExpense = new AddExpense();
            addExpense.ResizeControls(formspanel.Size);
            ShowScreen(addExpense,AdExpenseButton);
        }

        private void AddHead(object sender, EventArgs e)
        {
            AddHead addHeads = new AddHead();
            ShowScreen(addHeads, AdHeadsButton) ;
            addHeads.ResizeControls(formspanel.Size);
        }

        private void AddUser(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            ShowScreen(addUser, AddUserButton);
            addUser.ResizeControls(formspanel.Size);
        }

        private void ShowLedgerReport(object sender, EventArgs e)
        {
            Ledger ledgerReport = new Ledger();
            ledgerReport.ResizeControls(formspanel.Size);
            ShowScreen(ledgerReport,LedgerButton);
        }

        private void ShowCostReport(object sender, EventArgs e)
        {
            CostReport costReport = new CostReport();
            costReport.ResizeControls(formspanel.Size);
            ShowScreen(costReport,CostReportButton);
        }

        private void AddProject(object sender, EventArgs e)
        {
            AddProject addProject =  new AddProject();
            addProject.ResizeControls(formspanel.Size);
            ShowScreen(addProject,AddProjectButton);
        }
        private void ShowDashBoard(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.ResizeControls(formspanel.Size);
            ShowScreen(dashBoard, dashBoardButton);
        }
        private void ShowSetting(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ResizeControls(formspanel.Size);
            ShowScreen(settings,SettingsButton);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Login._instance.Close();
        }


       

        public bool maxiMized = false;
        
        private void maximizeButton_Click(object sender, EventArgs e)
        {

            MaxiMizeWindow();
        }


        private void MaxiMizeWindow() 
        {
            maxiMized = !maxiMized;
            if (maxiMized)
            {
                
                this.WindowState = FormWindowState.Maximized;
                ScreenSizeHandler.ResizeControls(this.Size);
                PanelResized?.Invoke(formspanel.Size);
               
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                ScreenSizeHandler.ResizeControls(this.Size);
                PanelResized?.Invoke(formspanel.Size);
            }
        }
       


        private void MiniMizeForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


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

    }
}

public class DashBoardButton 
{
    public Button button;
    public bool selected = false;
}