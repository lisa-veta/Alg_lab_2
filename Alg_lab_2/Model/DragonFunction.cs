using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using static Alg_lab_2.Model.ImportData;

namespace Alg_lab_2.Model
{
    public class DragonFunction
    {
        public List<Line> Lines = new List<Line>(); 
        public void Invoke(int x1, int y1, int x2, int y2, int n)
        {
            int xn, yn;
            if (n > 0)
            {
                xn = (x1 + x2) / 2 + (y2 - y1) / 2;
                yn = (y1 + y2) / 2 - (x2 - x1) / 2;
                Invoke(x2, y2, xn, yn, n - 1);
                Invoke(x1, y1, xn, yn, n - 1);
            }
            if (n == 0)
            {
                AddLine(x1, y1, x2, y2);
            }
        }
        private void AddLine(int x1, int y1, int x2, int y2)
        {
            Line myline = new Line();
            myline.Stroke = ColorBrush;
            myline.X1 = x1;
            myline.Y1 = y1;
            myline.X2 = x2;
            myline.Y2 = y2;
            Lines.Add(myline);
        }
    }
}
