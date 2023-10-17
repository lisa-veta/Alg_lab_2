using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace Alg_lab_2.Model
{
    public static class ImportData
    {
        public static readonly int MaxValueForFractal = 16;
        public static readonly int MinValueForFractal = 1;
        public static readonly SolidColorBrush ColorBrush = Brushes.Red;
        public static readonly int MaxValueForHanoi = 20;
        public static readonly int MinValueForHanoi = 1;
        public static readonly int FirstRingWidth = 210;
        public static readonly int RingHeight = 20;
        public static readonly int RingWidthFall = 5;
        //public static readonly List<String> RingColors = new List<String> { "#FFD32F2F", "#FFC2185B", "#FF7B1FA2", "#FF512DA8", "#FF303F9F", "#FF1976D2", "#FF0288D1", "#FF0097A7", "#FF00796B", "#FF388E3C", "#FF689F38", "#FFFBC02D" };
        //public static readonly List<String> RingColors = new List<String> { "#FF77FF", "#D28EFF", "#9F88FF", "#99BBFF", "#77DDFF", "#66FFFF", "#BBFF66", "#DDFF77", "#FFDD55", "#FFDD66", "#FF8888", "#FF88C2" };
        public static readonly List<String> RingColors = new List<String> { "#FF3EFF", "#E93EFF", "#B94FFF", "#9955FF", "#7744FF", "#5555FF", "#5599FF", "#33CCFF", "#33FFFF", "#33FFDD", "#33FFAA", "#33FF33", "#99FF33", "#CCFF33", "#FFFF33", "#FFCC22", "#FFAA33", "#FF7744", "#FF5511", "#FF3333" };

    }
}
