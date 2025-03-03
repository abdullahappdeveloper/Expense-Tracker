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
    public partial class Settings : Form
    {
        const string Green = "Green";
        const string darkGray = "Dark Gray";
        const string blueViolet = "Blue Violet";
        const string blackandWhite = "Black & White";


        public Settings()
        {
            InitializeComponent();

            List<string> colors = new List<string>();
            colors.Add(blackandWhite);
            colors.Add(blueViolet);
            colors.Add(darkGray);
            colors.Add(Green);
            appThemeComboxBox.DataSource = colors;

            // handle controle sizes like window maximize or minimize events
            HandleControlsResize();
            
            AppTheme.GetAppTheme().ApplyTheme(this);

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
        public void HandleControlsResize()
        {
            ScreenSizeHandler = new ScreenSizeHandler(this.Size);
           
            ScreenSizeHandler.AddControl(panel1, false);
            ScreenSizeHandler.AddControl(appThemeComboxBox);
            ScreenSizeHandler.AddControl(appThemeLabel);
            ScreenSizeHandler.AddControl(titleText);
            Main.instance.PanelResized += PanelResize;

        }

            private void appThemeComboxBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = appThemeComboxBox.SelectedValue.ToString();
            switch (value) 
            {
                case blackandWhite:
                    AppTheme.GetAppTheme().colorTheme = AppTheme.BlackWhite;
                    
                    break;
                case blueViolet:
                    AppTheme.GetAppTheme().colorTheme = AppTheme.BlueViolet;
               
                    break;
                case darkGray:
                    AppTheme.GetAppTheme().colorTheme = AppTheme.DarkGrey;
                   
                    break;
                case Green:
                    AppTheme.GetAppTheme().colorTheme = AppTheme.Green;
                   
                    break;

            }


            AppTheme.GetAppTheme().ApplyTheme(this);

            Main.instance.ApplyTheme(Main.instance.settingsButtonSelected);
        }
    }
}
