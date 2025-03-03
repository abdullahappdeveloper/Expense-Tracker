using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace ExpenseManagmentSystem
{
    public class ColorTheme 
    {
     public Color darkColor { get; set; }
     public Color lightColor { get; set; }
     public Color textColor { get; set; }

    }
    public class AppTheme
    {
        public static ColorTheme BlueViolet = new ColorTheme()
        {
            lightColor = Color.White,
            darkColor = Color.BlueViolet,
            textColor = Color.BlueViolet
        };
        public static ColorTheme DarkGrey = new ColorTheme()
        {
            lightColor = Color.White,
            darkColor = Color.Gray,
            textColor = Color.Black
        };

        public static ColorTheme Green = new ColorTheme()
        {
            lightColor = Color.White,
            darkColor = Color.ForestGreen,
            textColor = Color.Black
        };

        public static ColorTheme BlackWhite = new ColorTheme()
        {
            lightColor = Color.White,
            darkColor = Color.Black,
            textColor = Color.Black
        };

        #region Singleton
        private static AppTheme _instance =null;
        public static AppTheme GetAppTheme() 
        {
            if (_instance == null) 
            {
                _instance = new AppTheme();
            }
            return _instance;
        }
        
        private AppTheme() 
        {
        
        }
        #endregion

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                yield return control;

                // Recursively get controls from any container-type control
                if (control.HasChildren)
                {
                    foreach (Control child in GetAllControls(control))
                    {
                        yield return child;
                    }
                }
            }
        }

        public ColorTheme colorTheme { get; set; }
        
        public void ApplyTheme(Control form)
        {
           
            int count = GetAllControls(form).Count();
            form.BackColor = colorTheme.lightColor;
            //  MessageBox.Show($"{count}");

            foreach (Control control in GetAllControls(form)) 
            {

                if (control is  ReportViewer)
                {
                   // return;
                }
                if (control is Label) 
                {
                    control.BackColor = colorTheme.lightColor;
                    control.ForeColor = colorTheme.darkColor;
                }
                if (control is Button) 
                {
                    control.BackColor = colorTheme.darkColor;
                    control.ForeColor = colorTheme.lightColor;
                 
                }
                if (control is TextBox) 
                {
                    
                    control.BackColor = colorTheme.lightColor;
                    //control.ForeColor = colorTheme.darkColor;
                    control.ForeColor = colorTheme.textColor;
                }
                if (control is DataGridView gridView) 
                {
                    //gridView.ForeColor = colorTheme.darkColor;
                    gridView.ForeColor = colorTheme.textColor;
                    

                }
                if (control is Panel) 
                {
                    control.BackColor = colorTheme.lightColor;
                    control.ForeColor = colorTheme.darkColor;
                }
                if (control is ComboBox combobox) 
                {
                    combobox.ForeColor = colorTheme.textColor;
                    
                }
                if (control is DateTimePicker dateTimePicker) 
                {
                 
                }

            }
        
        }

        

    }
}
