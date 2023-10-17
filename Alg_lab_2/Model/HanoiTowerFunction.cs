using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_lab_2.Model
{
    public class HanoiTowerFunction
    {
        public List<ItemHanoi> HanoiList = new List<ItemHanoi>();

        public void DoHanoiTower(int n, char A = 'A', char B= 'B', char C = 'C')
        {
            if (n == 1)
            {
                HanoiList.Add(new ItemHanoi(A - 65, C - 65));
            }
            else
            {
                DoHanoiTower(n - 1, A, C, B);
                HanoiList.Add(new ItemHanoi(A - 65, C - 65));
                DoHanoiTower(n - 1, B, A, C);
            }
        }
    }
}
