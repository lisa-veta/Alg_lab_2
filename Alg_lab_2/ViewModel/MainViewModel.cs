using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using Alg_lab_2.View;
using System.Drawing;
using Brushes = System.Windows.Media.Brushes;
using Image = System.Drawing.Image;
using Pen = System.Drawing.Pen;
using System.Windows.Media.Media3D;
using System.Threading;
using System.Windows.Interop;
using System.Windows.Shapes;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Documents;
using System.Data.SqlTypes;

namespace Alg_lab_2.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private static List<Bitmap> _bitmaps = new List<Bitmap>();
        public static Bitmap map;
        public static Graphics graphics;
        public static Pen pen;
        public static int depth = 5;

        //public MainViewModel()
        //{
        //    InitializeComponent();
        //    timer.Interval = 1000; 
        //    timer.Tick += new EventHandler(timer_Tick); 
        //    timer.Start();
        //}

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

        private Canvas _canv;
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
            //((MainWindow)System.Windows.Application.Current.MainWindow).Canv.Background = Brushes.LightSteelBlue;
            MainViewModel mm = new MainViewModel();
            //Kuku(mm);
            BB(500, 400);
            foreach (Line line in Lines)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Canv.Children.Add(line);
                Rewrite();
                //Thread.Sleep(100);
            }
            //for(int i = 0; i < Lines.Count; i++)
            //{
            //    ((MainWindow)System.Windows.Application.Current.MainWindow).Canv.Children.Clear();
            //    Thread.Sleep(10);
            //    int temp = i;
            //    while (temp >= 0)
            //    {
            //        ((MainWindow)System.Windows.Application.Current.MainWindow).Canv.Children.Add(Lines[i - temp]);
            //        temp--;
            //    }
            //}
        });

        public static void Rewrite()
        {

        }
        public static void Kuku(MainViewModel mainViewModel)
        {
            BB(500, 400);
            //List<Bitmap> bitmaps = new List<Bitmap>();
            //bitmaps = BIb(500, 400);
            int i = 0;
            //foreach (Bitmap bitmap in bitmaps)
            //{
            //    //mainviewmodel.img = bitmap as imagebrush;
            //    Image image = (Image)bitmap;
            //    //image.Save($"d:\\универ\\2 курс\\алгоритмы\\2 лаба\\папка\\test{i}.jpeg");
            //    var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
            //                                                                IntPtr.Zero,
            //                                                                Int32Rect.Empty,
            //                                                                BitmapSizeOptions.FromEmptyOptions());
            //    bitmap.Dispose();
            //    ImageBrush brush = new ImageBrush(bitmapSource);
            //    ((MainWindow)System.Windows.Application.Current.MainWindow).Imag = brush;
            //    Thread.Sleep(1000);
            //    i++;
            //}
            //Image image = (Image)bitmaps[bitmaps.Count - 1];
            //image.Save($"D:\\универ\\2 курс\\алгоритмы\\2 лаба\\папка\\Test.jpeg");
        }

        public static List<Bitmap> BIb(int width, int height)
        {
            //_bitmaps.Clear();
            //map = new Bitmap(width, height);
            //graphics = Graphics.FromImage(map);
            //pen = new Pen(System.Drawing.Color.White, 2);
            //graphics.Clear(System.Drawing.Color.Black);
            Dragon_func(width/2-100, height/2-100, width/2+130, height/2+180, 17);
            //_bitmaps.Add(map);
            return _bitmaps;
        }

        public static void BB(int width, int height)
        {
            Dragon_func(width / 2 - 100, height / 2 - 100, width / 2 + 130, height / 2 + 180, 10);
        }

        private static void Dragon_func(int x1, int y1, int x2, int y2, int n)
        {
            int xn, yn;
            if (n > 0)
            {
                xn = (x1 + x2) / 2 + (y2 - y1) / 2;
                yn = (y1 + y2) / 2 - (x2 - x1) / 2;
                Dragon_func(x2, y2, xn, yn, n - 1);
                Dragon_func(x1, y1, xn, yn, n - 1);
            }
            if (n == 0)
            {
                DrawLine(x1, y1, x2, y2);
                //graphics.DrawLine(pen, x1, y1, x2, y2);
                //RectangleF cloneRect = new RectangleF(0, 0, 500, 400);
                //System.Drawing.Imaging.PixelFormat format = map.PixelFormat;
                //_bitmaps.Add(map.Clone(cloneRect, format));
            }
        }

        //static Timer timer;
        //static int Timer = 0;
        //static void StartTimer()
        //{
        //    timer = new Timer(1000);
        //    timer.Elapsed += CheckTime;
        //    timer.AutoReset = true;
        //    timer.Enabled = true;
        //}

        //static void CheckTime(Object source, ElapsedEventArgs e)
        //{
        //    DrawLine(x1, y1, x2, y2);
        //    Timer++;
        //}
        public static void DrawLine(int x1, int y1, int x2, int y2)
        {
            Line myline = new Line();
            myline.Stroke = Brushes.Red;
            myline.X1 = x1;
            myline.Y1 = y1;
            myline.X2 = x2;
            myline.Y2 = y2;
            //((MainWindow)System.Windows.Application.Current.MainWindow).Canv.Children.Add(myline);
            //Thread.Sleep(1);
            Lines.Add(myline);
        }

        public ICommand EndWork => new DelegateCommand(param =>
        {
            TextBox textBox = new TextBox();
            textBox.Text = "ff";
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canv.Background = Brushes.White;
        });


        class Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        
    }
}
