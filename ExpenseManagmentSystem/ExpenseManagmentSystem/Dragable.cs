using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManagmentSystem
{
    class Dragable
    {
        
        private bool dragging = false;
        private Point startMousePostion;
        private Point startPoint;
        public void DragStarted(Point _startPoint) 
        {
            dragging = true;
            startMousePostion = Cursor.Position;
            startPoint = _startPoint;
            
        }
        
        public void Draging(Control control) 
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(startMousePostion));
                Point newPosition = Point.Add(startPoint, new Size(diff));
                control.Location = newPosition;
            }
          
        }
        public void DragEnded() 
        {
            dragging = false;
        }

       
       

    }
}
