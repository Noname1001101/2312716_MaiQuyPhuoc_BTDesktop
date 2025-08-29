using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap2
{
    internal class TinhToan
    {
        public static void NoiChuoi(string ho, string ten,ref string s)
        {
            s = ho.Trim()+" "+ten.Trim();
        }

        public static long GiaiThua(int n)
        {
            
            if (n == 0)
            {
                return 1;
            }
            return n * GiaiThua(n - 1);

        }
    }
}
