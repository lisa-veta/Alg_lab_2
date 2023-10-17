using Alg_lab_2.Model;
using Alg_lab_2.Properties;
using Alg_lab_2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static List<ItemHanoi> HanoiList = new List<ItemHanoi>();
        public ObservableCollection<string> Steps { get; set; } = new ObservableCollection<string>();

        private int CountOfRingsInt;

        private int _slider = 500;
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

        private bool _isEnable = false;
        public bool IsButtonEnable
        {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetSetting => new DelegateCommand(param =>
        {
            CountOfRingsInt = CheckCombo(CountOfRings, MinValueForHanoi, MaxValueForHanoi);
            if(!isNotHasError) { CountOfRings = ""; return; };
            FieldDefinition();
            IsButtonEnable = true;
        });

        private void FieldDefinition()
        {
            ClearCanvas();
            int RingWidth = FirstRingWidth;
            for (int i = 0; i < CountOfRingsInt; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Width = RingWidth;
                rect.Height = RingHeight;

                Canvas.SetBottom(rect, (Canvas0.Children.Count - 15) * RingHeight);
                Canvas.SetLeft(rect, 100 - RingWidth / 2);

                rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(RingColors[i]);
                rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom(RingColors[i]);
                rect.StrokeThickness = 1;
                rect.RadiusX = 10;
                rect.RadiusY = 10;

                Canvas0.Children.Add(rect);
                RingWidth -= RingWidthFall * 2;
            }
        }

        private void ClearCanvas()
        {
            Canvas0.Children.Clear();
            Canvas1.Children.Clear();
            Canvas2.Children.Clear();
        }

        public ICommand StartWork => new DelegateCommand(param => 
        {
            HanoiTowerFunction hanoiTowerFunction = new HanoiTowerFunction();
            HanoiList.Clear();
            CountOfRings = CountOfRingsInt.ToString(); ;
            hanoiTowerFunction.HanoiList.Clear();
            hanoiTowerFunction.DoHanoiTower(CountOfRingsInt);
            HanoiList = hanoiTowerFunction.HanoiList;
            MoveRings(hanoiTowerFunction.HanoiList);
        });

        public ICommand ResetWork => new DelegateCommand(param =>
        {
            HanoiList.Clear();
            FieldDefinition();
        });

        private async void MoveRings(List<ItemHanoi> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                IsButtonEnable = false;
                MoveRing(list[i].FromStick, list[i].ToStick);
                await Task.Delay(1100 - Slider);
                AddStepInWindow(i, list[i]);
            }
            IsButtonEnable = true;
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

        private void AddStepInWindow(int ind, ItemHanoi itemHanoi)
        {
            if (ind > 7)
            {
                Steps.RemoveAt(0);
                Steps.Add($"{ind + 1}: {itemHanoi.FromStick + 1} --> {itemHanoi.ToStick + 1}");
            }
            else 
            {
                Steps.Add($"{ind + 1}: {itemHanoi.FromStick + 1} --> {itemHanoi.ToStick + 1}");
            }
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
