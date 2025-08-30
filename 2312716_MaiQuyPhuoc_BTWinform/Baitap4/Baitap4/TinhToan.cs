using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap4
{
    internal class TinhToan
    {
        public static void ChaoHoi(ref string hoten, bool gioitinh,ref string chaoHoi)
        {
            
            if (gioitinh == true)
                chaoHoi = "Chào Ông " + hoten;
            else
                chaoHoi = "Chào Bà " + hoten;

         
        }

        public static int USCLN(ref int m, ref int n)
        {
            m = Math.Abs(m); //luôn là số dương
            n = Math.Abs(n); //luôn là số dương
            while (m != n)
            {
                if (m > n)
                    m = m - n;
                else
                    n = n - m;
            }
            return m;
        }
    }
}
