using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Brushes = System.Windows.Media.Brushes;

namespace Alg_lab_2.Model
{
    public static class ImportData
    {
        public static int WidtH = 400;
        public static int HeighT = 500;
        public static int startWightOnePoint = WidtH / 2 - 20;
        public static int startHeightOnePoint = HeighT / 2 - 100;
        public static int startWightTwoPoint = WidtH / 2 + 210;
        public static int startHeightTwoPoint = HeighT / 2 + 180;
        public static readonly int MaxValueForFractal = 16;
        public static readonly int MinValueForFractal = 1;
        public static readonly SolidColorBrush ColorBrush = Brushes.Red;
        public static readonly int MaxValueForHanoi = 20;
        public static readonly int MinValueForHanoi = 1;
        public static readonly int FirstRingWidth = 210;
        public static readonly int RingHeight = 20;
        public static readonly int RingWidthFall = 5;
        public static readonly List<String> RingColors = new List<String> { "#FF3EFF", "#E93EFF", "#B94FFF", "#9955FF", "#7744FF", "#5555FF", "#5599FF", "#33CCFF", "#33FFFF", "#33FFDD", "#33FFAA", "#33FF33", "#99FF33", "#CCFF33", "#FFFF33", "#FFCC22", "#FFAA33", "#FF7744", "#FF5511", "#FF3333" };
    }
}
