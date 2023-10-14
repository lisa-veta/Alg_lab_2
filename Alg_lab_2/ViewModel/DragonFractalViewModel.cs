using Alg_lab_2.Model;
using Alg_lab_2.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using static Alg_lab_2.Model.CheckingErrors;
using static Alg_lab_2.Model.ImportData;

namespace Alg_lab_2.ViewModel
{
    public class DragonFractalViewModel : BaseViewModel
    {
        public int Width = 400;
        public int Height = 500;
        public DragonFractal WindowDF { get; set; }
        public int minValue = 1;

        private int _slider;
        public int Slider
        {
            get { return _slider; }
            set
            {
                _slider = value;
                OnPropertyChanged();
            }
        }

        private string _count;
        public string Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }
        private int CountInt;

        private Canvas _canv = new Canvas();
        public Canvas Canvas
        {
            get { return _canv; }
            set
            {
                _canv = value;
                OnPropertyChanged();
            }
        }

        public static List<Line> Lines = new List<Line>();
        public ICommand StartWork => new DelegateCommand(param =>
        {
            Canvas.Children.Clear();
            Lines.Clear();
            CountInt = CheckCombo(Count, MinValueForFractal, MaxValueForFractal);
            if (!isNotHasError) { Count = ""; return; };
            DragonFunction dragonFunction = new DragonFunction();
            dragonFunction.Invoke(Width / 2 - 100, Height / 2 - 100, Width / 2 + 130, Height / 2 + 180, CountInt);
            Lines = dragonFunction.Lines;
            DrawLines(Lines);
        });
        public ICommand DoForward => new DelegateCommand(param =>
        {
            Canvas.Children.Clear();
            Lines.Clear();
            CountInt += 1;
            Count = (CountInt).ToString();
            CountInt = CheckCombo(Count, MinValueForFractal, MaxValueForFractal);
            if (!isNotHasError) { Count = (--CountInt).ToString(); };
            DragonFunction dragonFunction = new DragonFunction();
            dragonFunction.Invoke(Width / 2 - 100, Height / 2 - 100, Width / 2 + 130, Height / 2 + 180, CountInt);
            Lines = dragonFunction.Lines;
            ShowPicture(Lines);
        });

        public ICommand DoBack => new DelegateCommand(param =>
        {
            Canvas.Children.Clear();
            Lines.Clear();
            CountInt -= 1;
            Count = (CountInt).ToString();
            CountInt = CheckCombo(Count, MinValueForFractal, MaxValueForFractal);
            if (!isNotHasError) { Count = (++CountInt).ToString(); };
            DragonFunction dragonFunction = new DragonFunction();
            dragonFunction.Invoke(Width / 2 - 100, Height / 2 - 100, Width / 2 + 130, Height / 2 + 180, CountInt);
            Lines = dragonFunction.Lines;
            ShowPicture(Lines);
        });

        public ICommand EndWork => new DelegateCommand(param =>
        {
            Lines.Clear();
            DragonFunction dragonFunction = new DragonFunction();
            dragonFunction.Invoke(Width / 2 - 100, Height / 2 - 100, Width / 2 + 130, Height / 2 + 180, CountInt);
            Lines = dragonFunction.Lines;
            ShowPicture(Lines);
        });

        public ICommand DoDelete => new DelegateCommand(param =>
        {
            Canvas.Children.Clear();
            Lines.Clear();
            ClearData();
        });
        

        public async void DrawLines(List<Line> lines)
        {
            for(int i = 0; i < lines.Count; i++)
            {
                Canvas.Children.Add(lines[i]);
                await Task.Delay(5);
                //Canvas canv = new Canvas();
                //for (int j = 0; j < Canvas.Children.Count; j++)
                //{
                //    Line myline = new Line();
                //    myline.Stroke = ColorBrush;
                //    myline.X1 = lines[j].X1;
                //    myline.Y1 = lines[j].Y1;
                //    myline.X2 = lines[j].X2;
                //    myline.Y2 = lines[j].Y2;
                //    canv.Children.Add(myline);
                //}
                //canvasList.Add(canv);
            }
        }
        public void ShowPicture(List<Line> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Canvas.Children.Add(lines[i]);
            }
        }

        private void ClearData()
        {
            Count = "";
        }

       
    }
}
