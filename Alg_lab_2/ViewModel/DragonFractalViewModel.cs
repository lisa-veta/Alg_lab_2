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
        public int Width = 500;
        public int Height = 400;
        public DragonFractal WindowDF { get; set; }
        public int minValue = 1;
        private List<Canvas> canvasList = new List<Canvas>();

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

        private static ImageBrush _img;
        public ImageBrush Img
        {
            get { return _img; }
            set
            {
                _img = value;
                OnPropertyChanged();
            }
        }

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

        private Canvas _canvas = new Canvas();
        public Canvas CurrentCanvas
        {
            get { return _canvas; }
            set
            {
                _canvas = canvasList[Slider];
                OnPropertyChanged();
            }
        }



        public static List<Line> Lines = new List<Line>();
        public ICommand StartWork => new DelegateCommand(param =>
        {
            Canvas.Children.Clear();
            MakeSettings();
            if (!isNotHasError) return;
            DragonFunction dragonFunction = new DragonFunction();
            dragonFunction.Invoke(Width / 2 - 100, Height / 2 - 100, Width / 2 + 130, Height / 2 + 180, CountInt);
            DrawLines(dragonFunction.Lines);
        });

        private void MakeSettings()
        {
            CheckNotNull(Count);
            CheckInt(Count);
            if (!isNotHasError)
            {
                ClearData();
                return;
            }
            CountInt = int.Parse(Count);
            CheckInterval(CountInt, MaxValueForFractal, MinValueForFractal);
            if (!isNotHasError)
            {
                ClearData();
                return;
            }
        }

        public void DrawLines(List<Line> lines)
        {
            for(int i = 0; i < lines.Count; i++)
            {
                Canvas.Children.Add(lines[i]);
                Canvas canv = new Canvas();
                for(int j = 0; j < Canvas.Children.Count; j++)
                {
                    Line myline = new Line();
                    myline.Stroke = ColorBrush;
                    myline.X1 = lines[j].X1;
                    myline.Y1 = lines[j].Y1;
                    myline.X2 = lines[j].X2;
                    myline.Y2 = lines[j].Y2;
                    canv.Children.Add(myline);
                }
                canvasList.Add(canv);
            }
        }

        private void Menu_Click_SaveImage(Canvas canvas)
        {
            Microsoft.Win32.SaveFileDialog saveimg = new Microsoft.Win32.SaveFileDialog();
            //Canvas can = new Canvas();  // канвас уже есть
            saveimg.DefaultExt = ".PNG";
            saveimg.Filter = "Image (.PNG)|*.PNG";
            if (saveimg.ShowDialog() == true)
            {
                ToImageSource(canvas, saveimg.FileName);  //DragArena  - имя имеющегося канваса
            }
        }

        public static void ToImageSource(Canvas canvas, string filename)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
            canvas.Measure(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
            canvas.Arrange(new Rect(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight)));
            bmp.Render(canvas);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }

        private void ClearData()
        {
            Count = "";
        }

        public ICommand EndWork => new DelegateCommand(param =>
        {
            Canvas.Children.Clear();
            ClearData();
        });
    }
}
