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
        public ICommand StartWorkFractal => new DelegateCommand(param =>
        {
            DragonFractal dragonFractalWindow = new DragonFractal();
            DragonFractalViewModel dragonFractalViewModel = new DragonFractalViewModel();
            dragonFractalWindow.DataContext = dragonFractalViewModel;
            dragonFractalWindow.Show();
        });

        public ICommand StartWorkHanoi => new DelegateCommand(param =>
        {
            HanoiTowerWindow hanoiTowerWindow = new HanoiTowerWindow();
            HanoiTowerViewModel hanoiTowerViewModel = new HanoiTowerViewModel();
            hanoiTowerWindow.DataContext = hanoiTowerViewModel;
            hanoiTowerWindow.Show();
        });
    }
}
