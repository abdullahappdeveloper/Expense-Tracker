using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ScreenSizeHandler
{
    private Size formSize;
    private List<Control> controls;
    private List<Rectangle> rectangles;
    private List<bool> hasFonts;
    private List<Font> fonts;
    public ScreenSizeHandler(Size screenSize) 
    {
        
        this.formSize = screenSize;
        controls = new List<Control>();
        rectangles = new List<Rectangle>();
        hasFonts = new List<bool>();
        fonts = new List<Font>();
    }

    public void AddControl(Control control) 
    {
        controls.Add(control);
        rectangles.Add(new Rectangle(control.Location, control.Size));
        hasFonts.Add(true);
        fonts.Add(control.Font);
        
    }
    public void AddControl(Control control,bool setFont) 
    {
        controls.Add(control);
        rectangles.Add(new Rectangle(control.Location, control.Size));
        hasFonts.Add(setFont);
        fonts.Add(control.Font);
    }
    

    public void ResizeControls(Size newformSize) 
    {
        foreach (var item in controls) 
        {
            int index = controls.IndexOf(item);
            bool hasFont = hasFonts[index];
            Resize(item,newformSize, rectangles[index], hasFont,index);
            
           
        }    
    }

    private void Resize(Control control, Size newformSize, Rectangle rectangle, bool hasFont,int index)
    {
        //control.Anchor = AnchorStyles.Right | AnchorStyles.Top |AnchorStyles.Bottom|AnchorStyles.Left;
        //return;
        float xRatio = (float)newformSize.Width / formSize.Width;
        float yRatio = (float)newformSize.Height / formSize.Height;
        

        int newX = (int)(rectangle.X * xRatio);
        int newY = (int)(rectangle.Y * yRatio);

        int newWidth = (int)(rectangle.Width * xRatio);
        int newHeight = (int)(rectangle.Height * yRatio);

        control.Location = new Point(newX, newY);
        control.Size = new Size(newWidth, newHeight);

        if (hasFont) 
        {
            float fontsize = fonts[index].Size * (xRatio/yRatio);
            control.Font = new Font(control.Font.FontFamily, fontsize,control.Font.Style);
        }
        //MessageBox.Show($"xratio : {xRatio} oldwidth : {rectangle.Width} newWidth : {newWidth} oldX : {rectangle.X} newX : {newX}");
    }

}
