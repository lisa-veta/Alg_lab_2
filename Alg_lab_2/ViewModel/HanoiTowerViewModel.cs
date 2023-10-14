using Alg_lab_2.Model;
using Alg_lab_2.Properties;
using Alg_lab_2.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static Alg_lab_2.Model.CheckingErrors;
using static Alg_lab_2.Model.ImportData;

namespace Alg_lab_2.ViewModel
{
    public class HanoiTowerViewModel : BaseViewModel
    {
        public HanoiTowerWindow WindowHT { get; set; }
        private int CountOfRingsInt;

        private string _count;
        public string CountOfRings
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        private Canvas _canv0 = new Canvas();
        public Canvas Canvas0
        {
            get { return _canv0; }
            set
            {
                _canv0 = value;
                OnPropertyChanged();
            }
        }

        private Canvas _canv1 = new Canvas();
        public Canvas Canvas1
        {
            get { return _canv1; }
            set
            {
                _canv1 = value;
                OnPropertyChanged();
            }
        }

        private Canvas _canv2 = new Canvas();
        public Canvas Canvas2
        {
            get { return _canv2; }
            set
            {
                _canv2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetSetting => new DelegateCommand(param =>
        {
            CountOfRingsInt = CheckCombo(CountOfRings, MinValueForHanoi, MaxValueForHanoi);
            if(!isNotHasError) { CountOfRings = ""; return; };
            FieldDefinition();
        });

        private void FieldDefinition()
        {
            Canvas0.Children.Clear();
            Canvas1.Children.Clear();
            Canvas2.Children.Clear();
            int RingWidth = FirstRingWidth;
            for (int i = 0; i < CountOfRingsInt; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Width = RingWidth;
                rect.Height = RingHeight;

                Canvas.SetBottom(rect, (Canvas0.Children.Count - 15) * RingHeight);//задаем положение по нижней границе каваса
                Canvas.SetLeft(rect, 100 - RingWidth / 2);//кольцо по центру

                rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(RingColors[i]);
                rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom(RingColors[i]);
                rect.StrokeThickness = 1;

                Canvas0.Children.Add(rect);
                RingWidth -= RingWidthFall * 2;
            }
        }

        public ICommand StartWork => new DelegateCommand(param => 
        {
            HanoiTowerFunction hanoiTowerFunction = new HanoiTowerFunction();
            hanoiTowerFunction.HanoiList.Clear();
            hanoiTowerFunction.DoHanoiTower(CountOfRingsInt);
            MoveRings(hanoiTowerFunction);
        });

        private async void MoveRings(HanoiTowerFunction hanoiTowerFunction)
        {
            foreach (ItemHanoi item in hanoiTowerFunction.HanoiList)
            {
                await Task.Delay(1000);
                MoveRing(item.FromStick, item.ToStick);
            }
        }

        private void MoveRing(int from, int to)
        {
            Canvas fromColumn = SetCanvas(from);
            Canvas toColumn = SetCanvas(to);

            if (fromColumn.Children.Count == 0)
            {
                return;
            }

            Rectangle rect = (Rectangle)fromColumn.Children[fromColumn.Children.Count - 1];
            fromColumn.Children.Remove(rect);
            Canvas.SetBottom(rect, (toColumn.Children.Count-15) * RingHeight);
            toColumn.Children.Add(rect);
        }

        private Canvas SetCanvas(int stick)
        {
            switch (stick)
            {
                case 0:
                    return Canvas0;
                case 1:
                    return Canvas1;
                case 2:
                    return Canvas2;
                default:
                    return null;
            }
        }

    }
}
