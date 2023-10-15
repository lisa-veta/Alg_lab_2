using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_lab_2.Model
{
    public class ItemHanoi
    {
        public int FromStick;
        public int ToStick;
        public ItemHanoi(int fromStick, int toStick)
        { 
            FromStick = fromStick;
            ToStick = toStick;    
        }
    }
}
